///*************************************************************************/
///*
///* 文件名    ：dalLog.cs                              
///* 程序说明  : 日志处理
///* 原创作者  ：武汉金泰迪 XW Peng 
///* 
///* Copyright 2014-2015 武汉金泰迪信息技术有限公司
///*************************************************************************/

using JTD.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTD.Tools.DataOperate;
using System.Data;

namespace JTD.Server.DataAccess.DAL_Function
{
    public class dalLog
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logUser"></param>
        public static void InsertLog(Loginer logUser,string sFunID,string sFSubunID,string sFdesc,string sSql)
        {
            string sql = "insert into sys_log( FID, FDate, FUserID, FFunctionID, FSubFunctionID, FDescription, FMachineName, FIPAddress, FSQL) ";
            sql += " values(" + DocNoTool.GetTableID(logUser.DBName, "sys_log", "FID") + ",";
            if (logUser.DbType == DbAcessTyp.Oracle)
                sql += "sysdate,";
            else
                sql += "getdate(),";
            sql += logUser.Fid + "," + sFunID + "," + sFSubunID + ",'" + sFdesc + "','" + logUser.MachineName + "','" + logUser.IPAddress + "','" + sSql + "')";

            new DataBaseLayer(logUser.DBName).ExecuteSql(sql);
        }
        /// <summary>
        /// 查询日志数据 第二个参数为查询条件
        /// </summary>
        /// <param name="logUser"></param>
        /// <param name="sFilter"></param>
        /// <returns></returns>
        public static DataSet GetLog(Loginer logUser,string sFilter)
        {
            DataSet ds;
            string sql = "SELECT     l.FID, l.FDate, u.FAccount, u.FUserName, f.FNumber AS FunNum, f.FName AS FunName, fs.FNumber AS FsubNum, fs.FName AS FsubName, l.FDescription, " +
                     " l.FMachineName, l.FIPAddress, l.FSQL " +
                     " FROM         sys_log AS l INNER JOIN " +
                     " sys_User AS u ON l.FUserID = u.FID LEFT OUTER JOIN " +
                     " sys_Function AS f ON l.FFunctionID = f.FID LEFT OUTER JOIN " +
                     " sys_Fun_MenuBar AS fs ON l.FSubFunctionID = fs.FID where 1=1 " + sFilter;
            ds = new DataBaseLayer(logUser.DBName).Query(sql);
            return ds;

        }
    }
}
