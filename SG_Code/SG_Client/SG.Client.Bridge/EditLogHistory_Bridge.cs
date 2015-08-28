
///*************************************************************************/
///*
///* 文件名    ：EditLogHistory_Bridge.cs
///*
///* 程序说明  : 修改历史记录数据层桥接单元
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ServiceModel;
using SG.Server.DataAccess;
using SG.Common;
using SG.Interfaces;
using SG.Client.WCFHost;
using SG.Client.WCFIISHost.Base_CommonService_W;
using SG.Client.WCFHost.Base_CommonService_H;
using SG.Client.WCFIISHost;


namespace SG.Bridge
{
    public class ADODirect_Log
    {
        private IBridge_EditLogHistory _DAL_Instance = null;//数据层实例

        public ADODirect_Log()
        {
            _DAL_Instance = new dalEditLogHistory(Loginer.CurrentUser);
        }

        public IBridge_EditLogHistory GetInstance()
        {
            return _DAL_Instance;
        }
    }


    public class WCFIISHost_Log : IBridge_EditLogHistory
    {
        public WCFIISHost_Log()
        {
        }

        #region IBridge_SystemLog Members

        public void WriteLog(string logID, DataTable originalData, DataTable changes, string tableName, string keyFieldName, bool isMaster)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bsOriginal = ZipTools.CompressionDataSet(dalBase.TableToDataSet(originalData));
                byte[] bsChanges = ZipTools.CompressionDataSet(dalBase.TableToDataSet(changes));

                client.WriteLog(loginTicket, logID, bsOriginal, bsChanges, tableName, keyFieldName, isMaster);
            }
        }

        public DataSet SearchLog(string logUser, string tableName, DateTime dateFrom, DateTime dateTo)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.SearchLogData(loginTicket, logUser, tableName, dateFrom, dateTo);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public DataTable GetLogFieldDef(string tableName)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetLogFieldDef(loginTicket, tableName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public string[] GetTracedFields(string tableName)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                string[] arr = client.GetTracedFields(loginTicket, tableName);
                return arr;
            }
        }

        public bool SaveFieldDef(DataTable data)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bsData = ZipTools.CompressionDataSet(dalBase.TableToDataSet(data));
                return client.SaveFieldDef(loginTicket, bsData);
            }
        }

        #endregion
    }

    public class WcfHost_Log : IBridge_EditLogHistory
    {
        public WcfHost_Log()
        {
        }

        #region IBridge_SystemLog Members

        public void WriteLog(string logID, DataTable originalData, DataTable changes, string tableName, string keyFieldName, bool isMaster)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bsOriginal = ZipTools.CompressionDataSet(dalBase.TableToDataSet(originalData));
                byte[] bsChanges = ZipTools.CompressionDataSet(dalBase.TableToDataSet(changes));

                client.WriteLog(loginTicket, logID, bsOriginal, bsChanges, tableName, keyFieldName, isMaster);
            }
        }

        public DataSet SearchLog(string logUser, string tableName, DateTime dateFrom, DateTime dateTo)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.SearchLogData(loginTicket, logUser, tableName, dateFrom, dateTo);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public DataTable GetLogFieldDef(string tableName)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetLogFieldDef(loginTicket, tableName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public string[] GetTracedFields(string tableName)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                string[] arr = client.GetTracedFields(loginTicket, tableName);
                return arr;
            }
        }

        public bool SaveFieldDef(DataTable data)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bsData = ZipTools.CompressionDataSet(dalBase.TableToDataSet(data));
                return client.SaveFieldDef(loginTicket, bsData);
            }
        }

        #endregion
    }
}
