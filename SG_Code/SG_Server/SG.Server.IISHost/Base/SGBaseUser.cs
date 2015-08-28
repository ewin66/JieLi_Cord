
///*************************************************************************/
///*
///* 文件名    ：SGBaseUser.cs                                      
///* 程序说明  : 用户WCF实现类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Common;
using System.Data;
using SG.Server.DataAccess.Base;
using SG.Server.IISHost.Base;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace SG.Server.IISHost.Base
{
    /// <summary>
    /// 用户WCF实现类
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
     public class SGBaseUser:ISGBaseUser_W
    {
        #region 用户管理(dalUser)的方法


        public byte[] U_GetUsers(byte[] loginTicket)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalUser(loginer).Getb_sys_Users();
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
           
        }


        public byte[] U_GetUserReportData(byte[] loginTicket, DateTime createDateFrom, DateTime createDateTo)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = new dalUser(loginer).Getb_sys_UserReportData(createDateFrom, createDateTo);
            return ZipTools.CompressionObject(data);
        }


        public byte[] U_GetUser(byte[] loginTicket, string account)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalUser(loginer).Getb_sys_User(account);
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }


        public byte[] U_GetUserGroups(byte[] loginTicket, string account)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalUser(loginer).Getb_sys_UserGroups (account);
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }


        public byte[] U_GetUserByNovellID(byte[] loginTicket, string novellAccount)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalUser(loginer).Getb_sys_UserByNovellID(novellAccount);
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }


        public bool U_UpdateUser(byte[] loginTicket, byte[] userData)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

                DataSet data = ZipTools.DecompressionDataSet(userData);
                return new dalUser(loginer).Update(data);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        public bool U_DeleteUser(byte[] loginTicket, string account)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
                return new dalUser(loginer).DeleteUser(account);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        public bool U_ExistsUser(byte[] loginTicket, string account)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            return new dalUser(loginer).ExistsUser(account);
        }


        public bool U_ModifyPassword(byte[] loginTicket, string account, string pwd)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

                return new dalUser(loginer).ModifyPassword(account, pwd);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        public byte[] U_GetUserAuthorities(byte[] loginTicket)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalUser(loginer).Getb_sys_UserAuthorities(loginer);
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
        }


        public void U_Logout(byte[] loginTicket)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
                new dalUser(loginer).Logout(loginer.Account);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        public byte[] U_Login(byte[] validationTicket, byte[] loginUser, char LoginUserType)
        {
            bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

            //检查校验码成功,有效的登录请求.
            if (pass)
            {
                LoginUser userInfo = ZipTools.DecompressionObject(loginUser) as LoginUser;
                Loginer lg = new Loginer();
                lg.DbType = userInfo.DbType;
                lg.DBName = userInfo.DBName;
                DataTable dt = new dalUser(lg).Login(userInfo, LoginUserType);
                return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(dt));                
            }
            else
                return null;
        }

        public byte[] U_LoginByCard(byte[] validationTicket, byte[] loginUser, char LoginUserType)
        {
            bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

            //检查校验码成功,有效的登录请求.
            if (pass)
            {
                LoginUser userInfo = ZipTools.DecompressionObject(loginUser) as LoginUser;
                Loginer lg = new Loginer();
                lg.DbType = userInfo.DbType;
                lg.DBName = userInfo.DBName;
                DataTable dt = new dalUser(lg).LoginByCard(userInfo, LoginUserType);
                return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(dt));
            }
            else
                return null;
        }


        public bool U_ModifyPwdDirect(byte[] validationTicket, string account, string pwd, string DBName)
        {
            try
            {
                bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

                //检查校验码成功,有效的登录请求.
                if (pass)
                    return new dalUser(null).ModifyPwdDirect(account, pwd, DBName);
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }


        public byte[] U_GetUserDirect(byte[] validationTicket, string account, string DBName)
        {
            bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

            //检查校验码成功,有效的登录请求.
            if (pass)
            {
                DataTable dt = new dalUser(null).Getb_sys_UserDirect(account, DBName);
                return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(dt));
            }
            else
                return null;
        }

        #endregion

        #region 用户组管理(dalUserGroup)的方法



        public byte[] G_GetAuthorityItems(byte[] loginTicket)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            DataTable data = new dalUserGroup(loginer).GetAuthorityItem();
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }

        public byte[] G_GetAuthorityItem(byte[] loginTicket, string sFunID)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            DataTable data = new dalUserGroup(loginer).GetAuthorityItem(sFunID);
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));

        }

        public byte[] G_GetUserGroup(byte[] loginTicket)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            DataTable data = new dalUserGroup(loginer).GetUserGroup();
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }

        public byte[] G_GetUserGroupByCode(byte[] loginTicket, string groupCode)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            DataSet data = new dalUserGroup(loginer).GetUserGroup(groupCode);
            return ZipTools.CompressionObject(data);
        }

        public byte[] G_GetFormTagCustomName(byte[] loginTicket)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            DataTable data = new dalUserGroup(loginer).GetFormTagCustomName();
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }

        public bool G_CheckNoExists(byte[] loginTicket, string groupCode)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalUserGroup(loginer).CheckNoExists(groupCode);

        }

        public bool G_DeleteGroupByKey(byte[] loginTicket, string groupCode)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalUserGroup(loginer).DeleteGroupByKey(groupCode);
        }

        public int G_GetFormAuthority(byte[] loginTicket, string account, int moduleID)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            object o = new dalUserGroup(loginer).GetFormAuthority(account, moduleID);
            return Convert.ToInt32(o);
        }

        public int GetFormShow(byte[] loginTicket, string account, int moduleID)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            object o = new dalUserGroup(loginer).GetFormShow(account, moduleID);
            return Convert.ToInt32(o);
        }

        public int GetMenuAuthority(byte[] loginTicket, string account, int moduleID)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            object o = new dalUserGroup(loginer).GetMenuAuthority(account, moduleID);
            return Convert.ToInt32(o);
        }

        public int GetMenuShow(byte[] loginTicket, string account, int moduleID)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            object o = new dalUserGroup(loginer).GetMenuShow(account, moduleID);
            return Convert.ToInt32(o);
        }

        #endregion


    }
}