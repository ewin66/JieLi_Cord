using SG.Client.WCFHost;
using SG.Client.WCFHost.Base_SGBaseUser_H;
using SG.Client.WCFIISHost;
using SG.Client.WCFIISHost.Base_SGBaseUser_W;
///*************************************************************************/
///*
///* 文件名    ：UserGroup_Bridge.cs                                      
///* 程序说明  : 用户组数据层桥接功能
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
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
    /// 用户组数据层桥接功能
    /// </summary>
    public class ADODirect_UserGroup
    {
        private IBridge_UserGroup _DAL_Instance = null;//数据层实例

        public ADODirect_UserGroup()
        {
            _DAL_Instance = new dalUserGroup(Loginer.CurrentUser);
        }

        public IBridge_UserGroup GetInstance()
        {
            return _DAL_Instance;
        }
    }

     /// <summary>
    /// 用户组WCF中间层桥接功能
    /// </summary>
    public class WcfHost_UserGroup : IBridge_UserGroup
    {
        public WcfHost_UserGroup()
        {

        }

        public System.Data.DataTable GetAuthorityItem()
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetAuthorityItems(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetAuthorityItem(string sFunID)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetAuthorityItem(loginTicket,sFunID);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetUserGroup()
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetUserGroup(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataSet GetUserGroup(string groupCode)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetUserGroupByCode(loginTicket,groupCode);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public System.Data.DataTable GetFormTagCustomName()
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetFormTagCustomName(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool CheckNoExists(string groupCode)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.G_CheckNoExists(loginTicket,groupCode);
                
            }
        }

        public bool DeleteGroupByKey(string groupCode)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.G_DeleteGroupByKey(loginTicket, groupCode);

            }
        }

        public int GetFormAuthority(string account, int moduleID)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.G_GetFormAuthority(loginTicket, account,moduleID);

            }
        }

        public int GetFormShow(string account, int moduleID)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.GetFormShow(loginTicket, account, moduleID);

            }
        }

        public int GetMenuAuthority(string account, int moduleID)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.GetMenuAuthority(loginTicket, account, moduleID);

            }
        }

        public int GetMenuShow(string account, int moduleID)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.GetMenuShow(loginTicket, account, moduleID);

            }
        }
    }

      /// <summary>
    /// 用户组WCF中间层桥接功能
    /// </summary>
    public class WcfIISHost_UserGroup : IBridge_UserGroup
    {
        public WcfIISHost_UserGroup()
        {

        }

        public System.Data.DataTable GetAuthorityItem()
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetAuthorityItems(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetAuthorityItem(string sFunID)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetAuthorityItem(loginTicket,sFunID);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataTable GetUserGroup()
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetUserGroup(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public System.Data.DataSet GetUserGroup(string groupCode)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetUserGroupByCode(loginTicket,groupCode);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public System.Data.DataTable GetFormTagCustomName()
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.G_GetFormTagCustomName(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool CheckNoExists(string groupCode)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.G_CheckNoExists(loginTicket,groupCode);
                
            }
        }

        public bool DeleteGroupByKey(string groupCode)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.G_DeleteGroupByKey(loginTicket, groupCode);

            }
        }

        public int GetFormAuthority(string account, int moduleID)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.G_GetFormAuthority(loginTicket, account,moduleID);

            }
        }

        public int GetFormShow(string account, int moduleID)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.GetFormShow(loginTicket, account, moduleID);

            }
        }

        public int GetMenuAuthority(string account, int moduleID)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.GetMenuAuthority(loginTicket, account, moduleID);

            }
        }

        public int GetMenuShow(string account, int moduleID)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                return client.GetMenuShow(loginTicket, account, moduleID);

            }
        }
    }
}
