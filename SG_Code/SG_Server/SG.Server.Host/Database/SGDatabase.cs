///*************************************************************************/
///*
///* 文件名    ：SGDatabase.cs                                      
///* 程序说明  : 基础数据WCF类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Common;
using SG.Server.DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.Host.Database
{
    public class SGDatabase : ISGDatabase_H
    {
        #region 公共数据字典
        public byte[] SearchCommonType(byte[] loginTicket, string dataType)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalCommonDataDict(loginer).SearchBy(dataType);
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
            
        }


        public bool AddCommonType(byte[] loginTicket,string sfid, string code, string name)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
                return new dalCommonDataDict(loginer).AddCommonType(sfid,code, name);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        public bool DeleteCommonType(byte[] loginTicket, string code)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
                return new dalCommonDataDict(loginer).DeleteCommonType(code);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        public bool IsExistsCommonType(byte[] loginTicket, string code)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalCommonDataDict(loginer).IsExistsCommonType(code);
        }
        #endregion

        #region 基础资料名称
        public byte[] GetItemClass(byte[] loginTicket, string FNumber)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalItemClass(loginer).GetItemClass(FNumber);
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
        }

        public bool DeleteItemClass(byte[] loginTicket, string FNumber)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
                return new dalItemClass(loginer).DeleteItemClass(FNumber);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool IsExistsItemClass(byte[] loginTicket, string FNumber)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalItemClass(loginer).IsExistsItemClass(FNumber); ;
        }
        #endregion

        #region 基础资料描述
        public byte[] GetItemDesc(byte[] loginTicket, string FNumber)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = new dalItemPropDesc(loginer).GetItemDesc(FNumber);
            return ZipTools.CompressionDataSet(data);
        }

        public bool DeleteItemDesc(byte[] loginTicket, string fid)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
                return new dalItemPropDesc(loginer).DeleteItemDesc(fid);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool SetOrder(byte[] loginTicket, string Upfid, string Downfid)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalItemPropDesc(loginer).SetOrder(Upfid, Downfid);

        }
        #endregion
    }
}
