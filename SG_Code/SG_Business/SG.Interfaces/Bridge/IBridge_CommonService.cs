///*************************************************************************/
///*
///* 文件名    ：IBridge_DataDict.cs                                      
///* 程序说明  : 桥接。
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

namespace SG.Interfaces
{
   public interface IBridge_CommonService
    {
        DataTable GetSystemOrganization();

        DataTable GetSystemDataSet();

        DataTable GetSystemDataSetByOrg(string sOrgID);

        DataTable SearchLog(string sFilter);

        bool TestConnection();

        bool TestConnection(string dbType,string Server, string database, string user, string password);

        void WriteLogOP(string sFunID, string sFSubunID, string sFdesc, string sSql);

        DataTable GetModules();

        string GetTableID(string sTableName, string sFieldID);

        string GetTableFieldValue(string sTableName, string sField, string SCon);
       /// <summary>
       /// 获取SQLServer服务器的数据库列表，用“，”分开
       /// </summary>
       /// <returns></returns>
        string GetSQLServerDbListString(string sServerName, string sUser, string sPwd);

       /// <summary>
       /// 获取数据库表（为空则为全部，模糊查找）
       /// </summary>
       /// <param name="sTable"></param>
       /// <returns></returns>
        DataTable getTable(string sTable);
       /// <summary>
       /// 获取数据表字段
       /// </summary>
       /// <param name="sTableName"></param>
       /// <returns></returns>
        DataTable getField(string sTableName);
       /// <summary>
       /// 通过SQL语句获取DataTable
       /// </summary>
       /// <param name="sql"></param>
       /// <returns></returns>
        DataTable getDataTableSQL(string sql);
    }
}
