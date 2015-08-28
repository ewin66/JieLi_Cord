///*************************************************************************/
///*
///* 文件名    ：IBridge_User.cs                                      
///* 程序说明  : 用户数据字典的接口类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using SG.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces.Base
{
    public interface IBridge_User
    {
        DataTable Getb_sys_Users();
        DataTable Getb_sys_User(string account);
        DataTable Getb_sys_UserByNovellID(string novellAccount);
        DataTable Getb_sys_UserDirect(string account, string DBName);
        DataTable Getb_sys_UserAuthorities(Loginer user);
        DataTable Getb_sys_UserGroups(string account);

        bool Update(DataSet ds);
        bool DeleteUser(string account);
        bool ExistsUser(string account);
        bool ModifyPassword(string account, string pwd);
        bool ModifyPwdDirect(string account, string pwd, string DBName);

        void Logout(string account);
        DataTable Login(LoginUser loginUser, char LoginUserType);
        DataTable LoginByCard(LoginUser loginUser, char LoginUserType);

        DataSet Getb_sys_UserReportData(DateTime createDateFrom, DateTime createDateTo);

    }
}
