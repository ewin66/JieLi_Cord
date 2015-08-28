using SG.Client.Bridge;
using SG.Interfaces;
using SG.Models.Base;
///*************************************************************************/
///*
///* 文件名    ：bllComDataBaseTool.cs                                
///* 程序说明  : 基础数据操作工具
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SG.Business
{
    /// <summary>
    /// 基础数据操作类
    /// </summary>
    public class bllComDataBaseTool
    {
        /// <summary>
        /// 获取表FID最大值，sTable——表名；sField——字段名
        /// </summary>
        /// <param name="sTable"></param>
        /// <param name="sFiled"></param>
        /// <returns></returns>
        public static string GetTableID(string sTable,string sFiled)
        {
            return BridgeFactory.CreateCommonServiceBridge().GetTableID(sTable, sFiled);
        }

        /// <summary>
        /// 写入操作日志,sFunID——功能ID，SubID——子功能ID，sFdesc——描述
        /// </summary>
        public static void WriteLogOp(string sFunID,string sSubID,string sFdesc)
        {
            IBridge_CommonService comBridge = BridgeFactory.CreateCommonServiceBridge();
            comBridge.WriteLogOP(sFunID, sSubID, sFdesc,"");
        }

        /// <summary>
        /// 返回表字段的值，根据条件SCon返回sTableName的字段sFieldID的值
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="sFieldID"></param>
        /// <returns></returns>
        public static  string GetTableFieldValue(string sTableName, string sField,string SCon)
        {
            return BridgeFactory.CreateCommonServiceBridge().GetTableFieldValue(sTableName,sField," and " + SCon);
        }

        /// <summary>
        /// 获取窗体的功能ID
        /// </summary>
        /// <param name="sMenu"></param>
        /// <returns></returns>
        public static string GetFunctionID(string sMenu)
        {
            string sRet = BridgeFactory.CreateCommonServiceBridge().GetTableFieldValue(tb_sys_Function.__TableName, tb_sys_Function.__KeyName, " And " + tb_sys_Function.FNumber + "='" + sMenu + "'");
            if (sRet == string.Empty)
                sRet = "0";
            return sRet;
        }
        /// <summary>
        /// 获取SQLServer服务器的数据库列表，用“，”分开
        /// </summary>
        public static string GetSQLServerDbListString(string sServerName, string sUser, string sPwd)
        {
            return BridgeFactory.CreateCommonServiceBridge().GetSQLServerDbListString(sServerName, sUser, sPwd);
        }

        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="Server"></param>
        /// <param name="database"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool TestConnection(string dbType, string Server, string database, string user, string password)
        {
            return BridgeFactory.CreateCommonServiceBridge().TestConnection(dbType, Server, database, user, password);            
        }

        /// <summary>
        /// 获取系统参数的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSystemProfileVal(string key)
        {
            return BridgeFactory.CreateSystemProfileBridge().GetSystemProfileVal(key);
        }

        /// <summary>
        /// 获取数据库的表名 stb为过滤字段，支持%%模糊采选
        /// </summary>
        /// <param name="stb"></param>
        /// <returns></returns>
        public static DataTable getTable(string stb)
        {
            return BridgeFactory.CreateCommonServiceBridge().getTable(stb);
        }

        /// <summary>
        /// 获取表的字段
        /// </summary>
        /// <param name="stable"></param>
        /// <returns></returns>
        public static DataTable getField(string stable)
        {
            return BridgeFactory.CreateCommonServiceBridge().getField(stable);
        }

        /// <summary>
        /// 通过SQL语句查询Datatable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTableSql(string sql)
        {
            return BridgeFactory.CreateCommonServiceBridge().getDataTableSQL(sql);
        }
    }
}
