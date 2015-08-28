using SG.Client.WCFHost;
using SG.Client.WCFHost.Base_SGBaseUser_H;
using SG.Client.WCFIISHost;
using SG.Client.WCFIISHost.Base_SGBaseUser_W;
using SG.Common;
using SG.Interfaces;
using SG.Interfaces.Base;
using SG.Server.DataAccess.Base;
///*************************************************************************/
///*
///* 文件名    ：SGBaseUser_Bridge.cs                                      
///* 程序说明  : 用户客户端桥接类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Client.Bridge.Base
{
    /// <summary>
    /// 直接访问类
    /// </summary>
    public class ADODirect_SGBaseUser
    {
        private IBridge_User _DAL_Instance = null;//数据层实例

        public ADODirect_SGBaseUser()
        {
            _DAL_Instance = new dalUser(Loginer.CurrentUser);
        }

        public IBridge_User GetInstance()
        {
            return _DAL_Instance;
        }
    }

    /// <summary>
    /// WCFHost访问类
    /// </summary>
    public class WCFHost_SGBaseUser : IBridge_User
    {
        public WCFHost_SGBaseUser()
        {

        }



        public DataTable Getb_sys_Users()
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUsers(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable Getb_sys_User(string account)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUser(loginTicket, account);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable Getb_sys_UserByNovellID(string novellAccount)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUserByNovellID(loginTicket, novellAccount);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable Getb_sys_UserDirect(string account, string DBName)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                byte[] receivedData = client.U_GetUserDirect(loginTicket, account, DBName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable Getb_sys_UserAuthorities(Loginer user)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                byte[] receivedData = client.U_GetUserAuthorities(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable Getb_sys_UserGroups(string account)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUserGroups(loginTicket, account);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool Update(DataSet ds)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bDs = ZipTools.CompressionDataSet(ds);
                return client.U_UpdateUser(loginTicket, bDs);

            }
        }

        public bool DeleteUser(string account)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.U_DeleteUser(loginTicket, account);

            }
        }

        public bool ExistsUser(string account)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.U_ExistsUser(loginTicket, account);

            }
        }

        public bool ModifyPassword(string account, string pwd)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.U_ModifyPassword(loginTicket, account, pwd);

            }
        }

        public bool ModifyPwdDirect(string account, string pwd, string DBName)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.U_ModifyPwdDirect(loginTicket, account, pwd, DBName);

            }
        }

        public void Logout(string account)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                client.U_Logout(loginTicket);

            }
        }

        public DataTable Login(LoginUser loginUser, char LoginUserType)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.GetLoginTicket();
                byte[] login = ZipTools.CompressionObject(loginUser);

                byte[] receivedData = client.U_Login(loginTicket, login, LoginUserType);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable LoginByCard(LoginUser loginUser, char LoginUserType)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.GetLoginTicket();
                byte[] login = ZipTools.CompressionObject(loginUser);

                byte[] receivedData = client.U_LoginByCard(loginTicket, login, LoginUserType);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataSet Getb_sys_UserReportData(DateTime createDateFrom, DateTime createDateTo)
        {
            using (SGBaseUser_HClient client = WcfClientFactory.CreateSGBaseUser_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUserReportData(loginTicket, createDateFrom, createDateTo);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }
    }

    /// <summary>
    /// WCFIISHost访问类
    /// </summary>
    public class WCFIISHost_SGBaseUser : IBridge_User
    {
        public WCFIISHost_SGBaseUser()
        {

        }

        public DataTable Getb_sys_Users()
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUsers(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable Getb_sys_User(string account)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUser(loginTicket, account);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable Getb_sys_UserByNovellID(string novellAccount)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUserByNovellID(loginTicket, novellAccount);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable Getb_sys_UserDirect(string account, string DBName)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                byte[] receivedData = client.U_GetUserDirect(loginTicket, account, DBName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable Getb_sys_UserAuthorities(Loginer user)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                byte[] receivedData = client.U_GetUserAuthorities(loginTicket);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable Getb_sys_UserGroups(string account)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUserGroups(loginTicket, account);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool Update(DataSet ds)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] bDs = ZipTools.CompressionDataSet(ds);
                return client.U_UpdateUser(loginTicket, bDs);

            }
        }

        public bool DeleteUser(string account)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.U_DeleteUser(loginTicket, account);

            }
        }

        public bool ExistsUser(string account)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.U_ExistsUser(loginTicket, account);

            }
        }

        public bool ModifyPassword(string account, string pwd)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.U_ModifyPassword(loginTicket, account, pwd);

            }
        }

        public bool ModifyPwdDirect(string account, string pwd, string DBName)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                return client.U_ModifyPwdDirect(loginTicket, account, pwd, DBName);

            }
        }

        public void Logout(string account)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);

                client.U_Logout(loginTicket);

            }
        }

        public DataTable Login(LoginUser loginUser, char LoginUserType)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.GetLoginTicket();
                byte[] login = ZipTools.CompressionObject(loginUser);


                byte[] receivedData = client.U_Login(loginTicket, login, LoginUserType);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataTable LoginByCard(LoginUser loginUser, char LoginUserType)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.GetLoginTicket();
                byte[] login = ZipTools.CompressionObject(loginUser);


                byte[] receivedData = client.U_LoginByCard(loginTicket, login, LoginUserType);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public DataSet Getb_sys_UserReportData(DateTime createDateFrom, DateTime createDateTo)
        {
            using (SGBaseUser_WClient client = SoapClientFactory.CreateSGBaseUser_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.U_GetUserReportData(loginTicket, createDateFrom, createDateTo);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

    }


}
