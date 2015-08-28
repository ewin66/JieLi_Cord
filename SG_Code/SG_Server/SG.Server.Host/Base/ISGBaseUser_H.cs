///*************************************************************************/
///*
///* 文件名    ：ISGBaseUser_H.cs                                      
///* 程序说明  : 用户WCF接口
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.Host.Base
{
   /// <summary>
    /// 用户WCF接口
   /// </summary>

    [ServiceContract(Name = "SGBaseUser_H",
            Namespace = "SG.Server.Host.Base")]
    public interface ISGBaseUser_H

    {

        #region 用户管理(dalUser)的方法

        [OperationContract]
        byte[] U_GetUsers(byte[] loginTicket);

        [OperationContract]
        byte[] U_GetUserReportData(byte[] loginTicket, DateTime createDateFrom, DateTime createDateTo);

        [OperationContract]
        byte[] U_GetUser(byte[] loginTicket, string account);

        [OperationContract]
        byte[] U_GetUserGroups(byte[] loginTicket, string account);

        [OperationContract]
        byte[] U_GetUserByNovellID(byte[] loginTicket, string novellAccount);

        [OperationContract]
        bool U_UpdateUser(byte[] loginTicket, byte[] userData);

        [OperationContract]
        bool U_DeleteUser(byte[] loginTicket, string account);

        [OperationContract]
        bool U_ExistsUser(byte[] loginTicket, string account);

        [OperationContract]
        bool U_ModifyPassword(byte[] loginTicket, string account, string pwd);

        [OperationContract]
        byte[] U_GetUserAuthorities(byte[] loginTicket);

        [OperationContract]
        void U_Logout(byte[] loginTicket);

        [OperationContract]
        byte[] U_Login(byte[] validationTicket, byte[] loginUser, char LoginUserType);

        [OperationContract]
        byte[] U_LoginByCard(byte[] validationTicket, byte[] loginUser, char LoginUserType);

        [OperationContract]
        bool U_ModifyPwdDirect(byte[] validationTicket, string account, string pwd, string DBName);

        [OperationContract]
        byte[] U_GetUserDirect(byte[] validationTicket, string account, string DBName);


        #endregion

        #region 用户组管理(dalUserGroup)的方法

        [OperationContract]
        byte[] G_GetAuthorityItems(byte[] loginTicket);
        [OperationContract]
        byte[] G_GetAuthorityItem(byte[] loginTicket,string sFunID);
        [OperationContract]
        byte[] G_GetUserGroup(byte[] loginTicket);

        [OperationContract]
        byte[] G_GetUserGroupByCode(byte[] loginTicket, string groupCode);

        [OperationContract]
        byte[] G_GetFormTagCustomName(byte[] loginTicket);

        [OperationContract]
        bool G_CheckNoExists(byte[] loginTicket, string groupCode);

        [OperationContract]
        bool G_DeleteGroupByKey(byte[] loginTicket, string groupCode);

        [OperationContract]
        int G_GetFormAuthority(byte[] loginTicket, string account, int moduleID);
        [OperationContract]
        int GetFormShow(byte[] loginTicket, string account, int moduleID);
        [OperationContract]
        int GetMenuAuthority(byte[] loginTicket, string account, int moduleID);
        [OperationContract]
        int GetMenuShow(byte[] loginTicket, string account, int moduleID);

        #endregion
       
       

    }
}