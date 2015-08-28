///*************************************************************************/
///*
///* 文件名    ：ILoginAuthorization.cs                                      
///* 程序说明  : 系统登录策略
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces
{
    /// <summary>
    /// 系统登录策略
    /// </summary>
    public interface ILoginAuthorization
    {
        /// <summary>
        /// 登录,验证用户．
        /// </summary>
        /// <param name="loginUser">登录用户信息</param>
        /// <returns></returns>
        bool Login(LoginUser loginUser);

        /// <summary>
        /// 刷卡登录,验证用户．
        /// </summary>
        /// <param name="loginUser">登录用户信息</param>
        /// <returns></returns>
        bool LoginByCard(LoginUser loginUser);

        /// <summary>
        /// 当前登录策略是否支持登出模式
        /// </summary>
        bool SupportLogout { get; }

        /// <summary>
        /// 登出
        /// </summary>
        void Logout();
    }

    /// <summary>
    /// 系统登录用户类型
    /// </summary>
    public enum LoginUserType
    {
        S, //System Account
        W, //Windows Domain Account
        N  //Novell Account
    }

}
