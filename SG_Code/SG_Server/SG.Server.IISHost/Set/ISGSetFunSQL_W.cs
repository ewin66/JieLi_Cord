///*************************************************************************/
///*
///* 文件名    ：ISGSetFunSQL_W.cs                                      
///* 程序说明  : Grid设置WCF接口
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

namespace SG.Server.IISHost.Set
{
    [ServiceContract(Name = "SGSetFunSQL_W",
                Namespace = "SG.Server.IISHost.Set")]
    public interface ISGSetFunSQL_W
    {
        #region Grid配置信息
        [OperationContract]
        /// <summary>
        /// 删除一条列信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool F_DeleteFunSQL(byte[] loginTicket, string key);
        [OperationContract]
        /// <summary>
        /// 获取列信息列表
        /// </summary>
        /// <returns></returns>
        byte[] F_GetFunSQL(byte[] loginTicket);
        [OperationContract]
        /// <summary>
        /// 获取一条列信息，即一个Grid的信息，包括SQL信息，列信息，行颜色
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] F_GetFunSQLByID(byte[] loginTicket, string key);
        [OperationContract]
        /// <summary>
        /// 获取一条列信息，即一个Grid的信息，包括SQL信息，列信息，行颜色(多一个用户设置ColInfo)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] F_GetFunSQLByUser(byte[] loginTicket, string key);
        [OperationContract]
        /// <summary>
        /// 通过列信息的SQL返回通过SQL语句查询到数据,sKey为Sys_Fun_SQL的FNumber，所以FNumber设定则不能修改
        /// </summary>
        /// <param name="sCon"></param>
        /// <returns></returns>
        byte[] F_GetFunSQLData(byte[] loginTicket, string sCon, string sKey);
        [OperationContract]
        /// <summary>
        /// 检查是否存在Grid配置信息
        /// </summary>
        /// <param name="FunNum"></param>
        /// <returns></returns>
        bool F_CheckFunNoExists(byte[] loginTicket, string FunNum);

        /// <summary>
        /// 获取报表配置主信息
        /// </summary>
        /// <param name="loginTicket"></param>
        /// <returns></returns>
        [OperationContract]
        byte[] F_GetSysFun(byte[] loginTicket);
        /// <summary>
        /// 获取所有功能模块
        /// </summary>
        /// <param name="loginTicket"></param>
        /// <returns></returns>
        [OperationContract]
        byte[] F_GetAllFunModel(byte[] loginTicket);
        #endregion

        #region 查询方案
        [OperationContract]
        /// <summary>
        /// 删除一个方案  
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool S_DeleteRPTColInfoScheme(byte[] loginTicket, string key);
        [OperationContract]
        /// <summary>
        /// 获取一个Grid方案，当前用户的方案
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        byte[] S_GetRPTScheme(byte[] loginTicket, string key);
        [OperationContract]
        /// <summary>
        /// 获取一个Grid的方案，key——方案主表的FID
        /// </summary>
        /// <returns></returns>
        byte[] S_GetRPTColInfoScheme(byte[] loginTicket, string key);
        [OperationContract]
        /// <summary>
        /// 获取一个Grid的方案，key——Grid配置ID
        /// </summary>
        /// <returns></returns>
        byte[] S_GetRPTColInfoSchemetmp(byte[] loginTicket, string key);
        [OperationContract]
        /// <summary>
        /// 检查是否存在方案
        /// </summary>
        /// <param name="FunNum"></param>
        /// <returns></returns>
        bool S_CheckRPTNoExists(byte[] loginTicket, string FName);

        #endregion
    }
}
