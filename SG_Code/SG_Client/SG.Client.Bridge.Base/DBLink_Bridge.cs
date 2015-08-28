///*************************************************************************/
///*
///* 文件名    ：DBLink_Bridge.cs                                      
///* 程序说明  : 配置数据连接桥接
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Client.WCFHost;
using SG.Client.WCFHost.Base_CommonService_H;
using SG.Client.WCFIISHost;
using SG.Client.WCFIISHost.Base_CommonService_W;
using SG.Common;
using SG.Interfaces.Base;
using SG.Server.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Client.Bridge.Base
{
  
    /// <summary>
    /// 配置数据连接桥接
    /// </summary>
    public class ADODirect_DBLink
    {
        private IBridge_DbLink _DAL_Instance = null;//数据层实例

        public ADODirect_DBLink()
        {
            _DAL_Instance = new dalDbLink(Loginer.CurrentUser);
        }

        public IBridge_DbLink GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WcfHost_DBLink : IBridge_DbLink
    {
        public WcfHost_DBLink()
        {

        }

        public System.Data.DataTable GetDBLink()
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                //byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDBLink(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetDBLinkByID(string key)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                //byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDBLinkByID(loginTicket, key);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }
    }

    public class WcfIISHost_DBLink : IBridge_DbLink
    {
        public WcfIISHost_DBLink()
        {

        }

        public System.Data.DataTable GetDBLink()
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                //byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDBLink(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetDBLinkByID(string key)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                //byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDBLinkByID(loginTicket, key);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }
    }
}
