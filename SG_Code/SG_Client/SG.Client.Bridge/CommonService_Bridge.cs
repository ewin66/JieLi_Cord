using SG.Client.WCFHost;
using SG.Client.WCFHost.Base_CommonService_H;
using SG.Client.WCFIISHost;
using SG.Client.WCFIISHost.Base_CommonService_W;
using SG.Common;
using SG.Interfaces;
using SG.Interfaces.Base;
using SG.Server.DataAccess;
using SG.Server.DataAccess.Base;
///*************************************************************************/
///*
///* 文件名    ：CommonService_Bridge.cs                                      
///* 程序说明  : 公共客户端桥接类
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
    public class ADODirect_CommonService
    {
         private IBridge_CommonService _DAL_Instance = null;//数据层实例

         public ADODirect_CommonService()
        {
            _DAL_Instance = new dalCommon(Loginer.CurrentUser);
        }

         public IBridge_CommonService GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WCFHost_CommonService : IBridge_CommonService
    {
        public WCFHost_CommonService()
        {

        }

        public System.Data.DataTable GetSystemOrganization()
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.GetSystemOrganization(validationTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetSystemDataSet()
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.GetSystemDataSet(validationTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetSystemDataSetByOrg(string sOrgID)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.GetSystemDataSetByOrg(validationTicket, sOrgID);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable SearchLog(string sFilter)
        {       

            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.SearchLog(loginTicket, sFilter);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool TestConnection()
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.TestConnection(validationTicket);
                
            }
        }
        public bool TestConnection(string dbType, string Server, string database, string user, string password)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.TestConnectionD(validationTicket,dbType, Server, database, user, password);

            }
        }
        public void WriteLogOP(string sFunID, string sFSubunID, string sFdesc, string sSql)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                client.WriteLogOP(loginTicket, sFunID, sFSubunID, sFdesc, sSql);
                
            }
        }




        public System.Data.DataTable GetModules()
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetModules(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }


        public string GetTableID(string sTableName, string sFieldID)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.C_GetTableID(loginTicket, sTableName, sFieldID);
            }
        }


        public string GetTableFieldValue(string sTableName, string sField, string SCon)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.C_GetTableFieldValue(loginTicket, sTableName, sField,SCon);
            }
        }


        public string GetSQLServerDbListString(string sServerName, string sUser, string sPwd)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.GetSQLServerDbListString(validationTicket, sServerName, sUser, sPwd);

            }
        }




        public System.Data.DataTable getTable(string sTable)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.getTable(loginTicket,sTable);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable getField(string sTableName)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.getField(loginTicket, sTableName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable getDataTableSQL(string sql)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.getDataTableSQL(loginTicket, sql);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }
    }

    public class WCFIISHost_CommonService : IBridge_CommonService
    {
        public WCFIISHost_CommonService()
        {

        }
        public System.Data.DataTable GetSystemOrganization()
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.GetSystemOrganization(validationTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetSystemDataSet()
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.GetSystemDataSet(validationTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetSystemDataSetByOrg(string sOrgID)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.GetSystemDataSetByOrg(validationTicket, sOrgID);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable SearchLog(string sFilter)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.SearchLog(loginTicket, sFilter);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool TestConnection()
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.TestConnection(validationTicket);

            }
        }
        public bool TestConnection(string dbType, string Server, string database, string user, string password)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.TestConnectionD(validationTicket, dbType, Server, database, user, password);
            }
        }
        public void WriteLogOP(string sFunID, string sFSubunID, string sFdesc, string sSql)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                client.WriteLogOP(loginTicket, sFunID, sFSubunID, sFdesc, sSql);

            }
        }


        public System.Data.DataTable GetModules()
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetModules(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }


        public string GetTableID(string sTableName, string sFieldID)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.C_GetTableID(loginTicket, sTableName,sFieldID);
            }
        }


        public string GetTableFieldValue(string sTableName, string sField, string SCon)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.C_GetTableFieldValue(loginTicket, sTableName, sField,SCon);
            }
        }


        public string GetSQLServerDbListString(string sServerName, string sUser, string sPwd)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.GetSQLServerDbListString(validationTicket,sServerName,sUser,sPwd);
                
            }
        }

        public System.Data.DataTable getTable(string sTable)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.getTable(loginTicket, sTable);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable getField(string sTableName)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.getField(loginTicket, sTableName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }


        public System.Data.DataTable getDataTableSQL(string sql)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.getDataTableSQL(loginTicket, sql);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }
    }

}
