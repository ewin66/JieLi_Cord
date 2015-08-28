using SG.Client.WCFHost;
using SG.Client.WCFHost.Base_SGBaseDict_H;
using SG.Client.WCFIISHost;
using SG.Client.WCFIISHost.Base_SGBaseDict_W;
using SG.Common;
using SG.Interfaces;
using SG.Interfaces.Base;
using SG.Server.DataAccess;
///*************************************************************************/
///*
///* 文件名    ：SGBaseDict_Bridge.cs                                      
///* 程序说明  : 数据字典客户端桥接类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Client.Bridge
{
   

   public class ADODirect_SGBaseDict
   {
      

         //数据层实例
        private IBridge_DataDict _DAL_Instance = null;

        public ADODirect_SGBaseDict(Type ORM)
        {
            //创建数据层的实例
            _DAL_Instance = dalBaseDataDict.CreateDalByORM(Loginer.CurrentUser, ORM.FullName);
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="derivedClassName">派生类的类名.如xxx.xx.x.dalProduct.(未指定类名则创建基类实例)</param>
        public ADODirect_SGBaseDict(string derivedClassName)
        {
            //创建数据层的实例
            if (String.IsNullOrEmpty(derivedClassName))
            {
                _DAL_Instance = new dalBaseDataDict(Loginer.CurrentUser);
            }
            else
            {
                _DAL_Instance = dalBaseDataDict.CreateDalByClassName(Loginer.CurrentUser, derivedClassName);
            }
        }

        ///// <summary>
        ///// 构造器
        ///// </summary>
        ///// <param name="ORM">ORM类</param>
        ///// <param name="derivedClassName">派生类的类名,如xxx.xx.x.dalProduct,xxx.xx.x.dalPerson</param>
        //public ADODirect_DataDict(Type ORM, string derivedClassName)
        //    : this(derivedClassName)
        //{
        //    _DAL_Instance.ORM = ORM;
        //}

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="derivedClassName">派生类的类名,如xxx.xx.x.dalProduct,xxx.xx.x.dalPerson</param>
        public ADODirect_SGBaseDict(string tableName, string derivedClassName)
            : this(derivedClassName)
        {
            _DAL_Instance.TableName = tableName;
        }

        public IBridge_DataDict GetInstance()
        {
            return _DAL_Instance;
        }
   }

    public class WCFHost_SGBaseDict:IBridge_DataDict
    {
        private Type _ORM;
        private string _TableName;

        public WCFHost_SGBaseDict()
        {

        }
        
        public WCFHost_SGBaseDict(Type ORM)
            : this()
        {
            _ORM = ORM;

        }


        public WCFHost_SGBaseDict(string tableName)
            : this()
        {
            _TableName = tableName;
        }

        public Type ORM { get { return _ORM; } set { _ORM = value; } }
        public string TableName { get { return _TableName; } set { _TableName = value; } }
        public System.Data.DataTable GetDataByKey(string key)
        {
            using(SGBaseDict_HClient client=WcfClientFactory.CreateBaseDict_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDataByKey(loginTicket, _ORM.FullName, key);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetSummaryData()
        {
            using (SGBaseDict_HClient client = WcfClientFactory.CreateBaseDict_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetSummaryData(loginTicket, _ORM.FullName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetDataDictByTableName(string tableName)
        {
            using (SGBaseDict_HClient client = WcfClientFactory.CreateBaseDict_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDataDictByTableName(loginTicket, tableName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool Update(System.Data.DataSet data)
        {
            using (SGBaseDict_HClient client = WcfClientFactory.CreateBaseDict_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = ZipTools.CompressionDataSet(data);
                return client.Update(loginTicket, bs, _ORM.FullName);
            }
        }

        public SaveResultEx UpdateEx(System.Data.DataSet data)
        {
            using (SGBaseDict_HClient client = WcfClientFactory.CreateBaseDict_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = ZipTools.CompressionDataSet(data);
                byte[] rt = client.UpdateEx(loginTicket, bs, _ORM.FullName);
                return (SaveResultEx)ZipTools.DecompressionObject(rt);
            }
        }

        public bool Delete(string keyValue)
        {
            using (SGBaseDict_HClient client = WcfClientFactory.CreateBaseDict_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.Delete(loginTicket, keyValue, _ORM.FullName);
            }
        }

        public bool CheckNoExists(string keyValue)
        {
            using (SGBaseDict_HClient client = WcfClientFactory.CreateBaseDict_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.CheckNoExists(loginTicket, keyValue, _ORM.FullName);
            }
        }

        
        public System.Data.DataSet DownloadDicts()
        {
            using (SGBaseDict_HClient client = WcfClientFactory.CreateBaseDict_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.DownloadDicts(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }
    }

    public class WCFIISHost_SGBaseDict:IBridge_DataDict
    {
       private Type _ORM;
        private string _TableName;

        public WCFIISHost_SGBaseDict()
        {

        }
        
        public WCFIISHost_SGBaseDict(Type ORM)
            : this()
        {
            _ORM = ORM;

        }


        public WCFIISHost_SGBaseDict(string tableName)
            : this()
        {
            _TableName = tableName;
        }

        public Type ORM { get { return _ORM; } set { _ORM = value; } }
        public string TableName { get { return _TableName; } set { _TableName = value; } }
        public System.Data.DataTable GetDataByKey(string key)
        {
            using (SGBaseDict_WClient client = SoapClientFactory.CreateSGBaseDict_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDataByKey(loginTicket, _ORM.FullName, key);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetSummaryData()
        {
            using (SGBaseDict_WClient client = SoapClientFactory.CreateSGBaseDict_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetSummaryData(loginTicket, _ORM.FullName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetDataDictByTableName(string tableName)
        {
            using (SGBaseDict_WClient client = SoapClientFactory.CreateSGBaseDict_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDataDictByTableName(loginTicket, tableName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool Update(System.Data.DataSet data)
        {
            using (SGBaseDict_WClient client = SoapClientFactory.CreateSGBaseDict_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = ZipTools.CompressionDataSet(data);
                return client.Update(loginTicket, bs, _ORM.FullName);
            }
        }

        public SaveResultEx UpdateEx(System.Data.DataSet data)
        {
            using (SGBaseDict_WClient client = SoapClientFactory.CreateSGBaseDict_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bs = ZipTools.CompressionDataSet(data);
                byte[] rt = client.UpdateEx(loginTicket, bs, _ORM.FullName);
                return (SaveResultEx)ZipTools.DecompressionObject(rt);
            }
        }

        public bool Delete(string keyValue)
        {
            using (SGBaseDict_WClient client = SoapClientFactory.CreateSGBaseDict_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.Delete(loginTicket, keyValue, _ORM.FullName);
            }
        }

        public bool CheckNoExists(string keyValue)
        {
            using (SGBaseDict_WClient client = SoapClientFactory.CreateSGBaseDict_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.CheckNoExists(loginTicket, keyValue, _ORM.FullName);
            }
        }


        public System.Data.DataSet DownloadDicts()
        {
            using (SGBaseDict_WClient client = SoapClientFactory.CreateSGBaseDict_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.DownloadDicts(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }
    }
}
