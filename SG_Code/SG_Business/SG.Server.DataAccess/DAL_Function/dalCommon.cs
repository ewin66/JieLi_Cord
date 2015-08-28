using SG.Common;
using SG.Interfaces;
///*************************************************************************/
///*
///* 文件名    ：dalCommon.cs                                      
///* 程序说明  : 公共功能的DAL层
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Interfaces.Base;
using SG.Server.DataAccess;
using SG.Tools.DataOperate;
using SG.Tools.DataOperate.SQLConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.DataAccess
{
    public class dalCommon : dalBase, IBridge_CommonService
    {
        public dalCommon(Loginer user)
            : base(user)
        {

        }

        public DataTable GetSystemOrganization()
        {
            string dbType = DbConfiguration_Factory.DbType;
            string sConn = DbConfiguration_Factory.GetAccountConnString();
            string sSQL = "select FID,FNumber,FName from T_Organization";
            return new DataBaseLayer(sConn, dbType).ExecuteQueryDataTable(sSQL.ToUpper());
        }

        public System.Data.DataTable GetSystemDataSet()
        {
            string dbType = DbConfiguration_Factory.DbType;
            string sConn = DbConfiguration_Factory.GetAccountConnString();
            string sSQL = string.Format(@"SELECT    T_Account.FID, T_Account.FNumber, T_Account.FName, T_Account.FDatabase, T_Account.FServerName, T_Account.FUser, T_Account.FPwd, T_Account.FDataType, T_Account.FOrgID, T_Account.FCreateDate, T_Account.FBackUpDate, T_Account.FVer, T_Account.FProductName, T_Account.FOnlineCount,   T_Account.FServerIP,T_DbType.FSign " +
                              " FROM         T_Account inner join T_DbType ON T_Account.FID = T_DbType.FID  where T_Account.FIsUse=1");
            return new DataBaseLayer(sConn, dbType).ExecuteQueryDataTable(sSQL.ToUpper());
        }

        public System.Data.DataTable GetSystemDataSetByOrg(string sOrgID)
        {
            string dbType = DbConfiguration_Factory.DbType;
            string sConn = DbConfiguration_Factory.GetAccountConnString();
            string sSQL = string.Format(@"SELECT    T_Account.FID, T_Account.FNumber, T_Account.FName, T_Account.FDatabase, T_Account.FServerName, T_Account.FUser, T_Account.FPwd, T_Account.FDataType, T_Account.FOrgID, T_Account.FCreateDate, T_Account.FBackUpDate, T_Account.FVer, T_Account.FProductName, T_Account.FOnlineCount,   T_Account.FServerIP,T_DbType.FSign " +
                              " FROM         T_Account inner join T_DbType ON T_Account.FID = T_DbType.FID  where T_Account.FIsUse=1 and T_Account.FOrgID='{0}'", sOrgID);
            return new DataBaseLayer(sConn, dbType).ExecuteQueryDataTable(sSQL.ToUpper());
        }

        public System.Data.DataTable SearchLog(string sFilter)
        {
            DataSet ds;
            string sql = "SELECT     l.FID, l.FDate, u.FAccount, u.FUserName, f.FNumber AS FunNum, f.FName AS FunName, fs.FNumber AS FsubNum, fs.FName AS FsubName, l.FDescription, " +
                     " l.FMachineName, l.FIPAddress, l.FSQL " +
                     " FROM         sys_log AS l INNER JOIN " +
                     " sys_User AS u ON l.FUserID = u.FID LEFT OUTER JOIN " +
                     " sys_Function AS f ON l.FFunctionID = f.FID LEFT OUTER JOIN " +
                     " sys_Fun_MenuBar AS fs ON l.FSubFunctionID = fs.FID where 1=1 " + sFilter;
            ds = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataSet(sql);
            return ds.Tables[0];
        }

        public bool TestConnection()
        {
            try
            {
                string dbType = DbConfiguration_Factory.DbType;
                string sConn = DbConfiguration_Factory.GetAccountConnString();
                string sSQL = "SELECT    T_Account.FID, T_Account.FNumber, T_Account.FName, T_Account.FDatabase, T_Account.FServerName, T_Account.FUser, T_Account.FPwd, T_Account.FDataType, T_Account.FOrgID, T_Account.FCreateDate, T_Account.FBackUpDate, T_Account.FVer, T_Account.FProductName, T_Account.FOnlineCount,   T_Account.FServerIP,T_DbType.FSign " +
                              " FROM         T_Account inner join T_DbType ON T_Account.FID = T_DbType.FID  ";
                DataTable dt = new DataBaseLayer(sConn, dbType).ExecuteQueryDataTable(sSQL);
                if (dt == null)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public void WriteLogOP(string sFunID, string sFSubunID, string sFdesc, string sSql)
        {
            string sql = "insert into sys_log( FID, FDate, FUserID, FFunctionID, FSubFunctionID, FDescription, FMachineName, FIPAddress, FSQL) ";
            sql += " values(" + DocNoTool.GetTableID(_Loginer.DBName, "sys_log", "FID",_Loginer) + ",";
            if (_Loginer.DbType == DbAcessTyp.Oracle)
                sql += "sysdate,";
            else
                sql += "getdate(),";
            sql += _Loginer.Fid + "," + sFunID + "," + sFSubunID + ",'" + sFdesc + "','" + _Loginer.MachineName + "','" + _Loginer.IPAddress + "','" + sSql + "')";

            new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);
        }

        /// <summary>
        /// 获取模块名称定义
        /// </summary>
        /// <returns></returns>
        public DataTable GetModules()
        {
            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable("SELECT * FROM  sys_Models");
        }

        /// <summary>
        /// 返回表的FID最大值，用于保存数据时获取Key的最大值
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="sFieldID"></param>
        /// <returns></returns>
        public string GetTableID(string sTableName, string sFieldID)
        {
            return DocNoTool.GetTableID(_Loginer.DBName, sTableName, sFieldID, _Loginer);
        }

        /// <summary>
        /// 返回表字段的值，根据条件SCon返回sTableName的字段sFieldID的值
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="sFieldID"></param>
        /// <returns></returns>
        public string GetTableFieldValue(string sTableName, string sField,string SCon)
        {

            string sql="";
            if (_Loginer.DbType == DbAcessTyp.SQLServer)
                sql = string.Format("SELECT isnull({0},'') FROM {1} where 1=1 " + SCon, sField, sTableName);
            else
                sql = string.Format("SELECT nvl({0},'') FROM {1} where 1=1 " + SCon, sField, sTableName);
            object o=new DataBaseLayer(_Loginer.DBName).GetSingle(sql);
            return o==null?"":o.ToString();
        }

        /// <summary>
        /// 获取SQLServer服务器的数据库列表，用“，”分开
        /// </summary>
        /// <param name="sServerName"></param>
        /// <param name="sUser"></param>
        /// <param name="sPwd"></param>
        /// <returns></returns>
        public string GetSQLServerDbListString(string sServerName, string sUser, string sPwd)
        {
           return new SqlConfiguration().GetDbList(sServerName, sUser, sPwd);
        }


        public bool TestConnection(string dbType, string Server, string database, string user, string password)
        {
            bool Successed = false;
            if (dbType == "Oracle")
            {
                //Oracle
                //OraConfiguration orcf = new OraConfiguration();
                //string RefMsg = "";
                Successed = new OraConfiguration().TestConnection(Server, database, user, password);
            }
            else
            {
                //SQLServer
                //SqlConfiguration sqlcf = new SqlConfiguration();
                Successed = new SqlConfiguration().TestConnection(Server, database, user, password);
            }

            return Successed;

        }


        public DataTable getTable(string sTable)
        {
            string sql = "";
            if(_Loginer.DbType==DbAcessTyp.Oracle)
            {
                sql = "select table_name tbName,tablespace_name,temporary from user_tables  where 1=1 ";
                if (sTable != string.Empty)
                    sql += " and TABLE_NAME like '" + sTable.ToUpper() + "'";
            }
            else
            {
                sql = "select name tbName from sysobjects where xtype='u' ";
                if (sTable != string.Empty)
                    sql += "  and name like '" + sTable + "'";
            }

            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
        }

        public DataTable getField(string sTableName)
        {
            string sql = "";
            if (_Loginer.DbType == DbAcessTyp.Oracle)
            {
                sql = "select column_name,data_type from user_tab_columns where table_name='" + sTableName + "'";
               
            }
            else
            {
                sql = "SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.columns WHERE TABLE_NAME='" + sTableName + "'";

            }

            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
        }


        public DataTable getDataTableSQL(string sql)
        {
            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
        }
    }
}
