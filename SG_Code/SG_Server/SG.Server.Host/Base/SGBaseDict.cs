///*************************************************************************/
///*
///* 文件名    ：SGBaseDict.cs                                      
///* 程序说明  : 数据字典数据层WCF实现类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using SG.Common;
using SG.Server.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.Host.Base
{
   public  class SGBaseDict:ISGBaseDict_H
    {

       public byte[] GetDataByKey(byte[] loginTicket, string ORM_TypeName, string key)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);
            DataTable data = dict.GetDataByKey(key);
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }

       public byte[] GetSummaryData(byte[] loginTicket, string ORM_TypeName)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);
            DataTable data = dict.GetSummaryData();
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }

        public byte[] GetDataDictByTableName(byte[] loginTicket, string tableName)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            dalBaseDataDict dict = new dalBaseDataDict(loginer, tableName);
            DataTable data = dict.GetSummaryData();
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }

        public bool Update(byte[] loginTicket, byte[] bs, string ORM_TypeName)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = ZipTools.DecompressionDataSet(bs);
            dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);
            return dict.Update(data);
        }

        public byte[] UpdateEx(byte[] loginTicket, byte[] bs, string ORM_TypeName)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

                DataSet data = ZipTools.DecompressionDataSet(bs);
                dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);
                SaveResultEx result = dict.UpdateEx(data);//保存数据
                return ZipTools.CompressionObject(result);//序列化返回对象
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool Delete(byte[] loginTicket, string keyValue, string ORM_TypeName)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
                dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);//创建DAL层实例
                return dict.Delete(keyValue);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);//转换为客户端可截取的异常类型(FaultException)信息。
                //throw new FaultException("删除记录发生错误！");//或者提示更具体的异常信息，屏蔽WCF系统内部消息。
            }
        }

        public bool CheckNoExists(byte[] loginTicket, string keyValue, string ORM_TypeName)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            dalBaseDataDict dict = dalBaseDataDict.CreateDalByORM(loginer, ORM_TypeName);
            return dict.CheckNoExists(keyValue);
        }


        public byte[] DownloadDicts(byte[] loginTicket)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

                DataSet data = new dalBaseDataDict(loginer).DownloadDicts();
                
                return ZipTools.CompressionObject(data);//序列化返回对象
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}
