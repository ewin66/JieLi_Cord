///*************************************************************************/
///*
///* 文件名    ：IBridge_UserGroup.cs                                      
///* 程序说明  : 用户权限的接口类
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

namespace SG.Interfaces.Base
{
    public interface IBridge_UserGroup
    {
        /// <summary>
        /// 获取不重复的工具栏（所有）
        /// </summary>
        /// <returns></returns>
        DataTable GetAuthorityItem();
        /// <summary>
        /// 获取一个功能的菜单和工具栏
        /// </summary>
        /// <param name="sFunID"></param>
        /// <returns></returns>
        DataTable GetAuthorityItem(string sFunID);
        /// <summary>
        /// 获取用户组
        /// </summary>
        /// <returns></returns>
        DataTable GetUserGroup();
        DataSet GetUserGroup(string groupCode);
        /// <summary>
        /// 获取所有的菜单和工具栏按钮
        /// </summary>
        /// <returns></returns>
        DataTable GetFormTagCustomName();
        /// <summary>
        /// 检查用户组是否存在
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        bool CheckNoExists(string groupCode);
        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="groupCode"></param>
        /// <returns></returns>
        bool DeleteGroupByKey(string groupCode);
        /// <summary>
        /// 获取窗体是否有权限
        /// </summary>
        /// <param name="account"></param>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        int GetFormAuthority(string account, int moduleID);
        /// <summary>
        /// 获取窗体是否显示
        /// </summary>
        /// <param name="account"></param>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        int GetFormShow(string account, int moduleID);
        /// <summary>
        /// 获取菜单是否有权限
        /// </summary>
        /// <param name="account"></param>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        int GetMenuAuthority(string account, int moduleID);
        /// <summary>
        /// 获取菜单是否显示
        /// </summary>
        /// <param name="account"></param>
        /// <param name="moduleID"></param>
        /// <returns></returns>
        int GetMenuShow(string account, int moduleID);
    }
}
