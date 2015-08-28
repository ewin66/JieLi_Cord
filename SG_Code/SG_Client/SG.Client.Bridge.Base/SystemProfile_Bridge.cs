using SG.Client.WCFHost;
using SG.Client.WCFHost.Base_CommonService_H;
using SG.Client.WCFIISHost;
using SG.Client.WCFIISHost.Base_CommonService_W;
using SG.Common;
using SG.Interfaces.Base;
using SG.Server.DataAccess.Base;
///*************************************************************************/
///*
///* 文件名    ：SystemProfile_Bridge.cs                                      
///* 程序说明  : 系统参数桥接
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
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
    public class ADODirect_SystemProfile
    {
        private IBridge_SystemProfile _DAL_Instance = null;//数据层实例

        public ADODirect_SystemProfile()
        {
            _DAL_Instance = new dalSystemProfile(Loginer.CurrentUser);
        }

        public IBridge_SystemProfile GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WcfHost_SystemProfile : IBridge_SystemProfile
    {
        public WcfHost_SystemProfile()
        {

        }

        public System.Data.DataSet GetSystemProfile()
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                //byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetSystemProfile(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

      

        public string GetSystemProfileVal(string key)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                //byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.G_GetSystemProfileVal(loginTicket, key);
              
            }
        }
    }

    public class WcfIISHost_SystemProfile : IBridge_SystemProfile
    {
        public WcfIISHost_SystemProfile()
        {

        }

        public System.Data.DataSet GetSystemProfile()
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                //byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetSystemProfile(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }


        public string GetSystemProfileVal(string key)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                //byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.G_GetSystemProfileVal(loginTicket, key);

            }
        }
    }
}
