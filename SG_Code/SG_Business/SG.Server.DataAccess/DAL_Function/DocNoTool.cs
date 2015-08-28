///*************************************************************************/
///*
///* 文件名    ：DocNoTool.cs                              
///* 程序说明  : 单据号码管理工具
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///*************************************************************************/

using SG.Common;
using SG.Tools.DataOperate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.DataAccess
{
    /// <summary>
    /// 单据号码管理工具
    /// </summary>
    public class DocNoTool
    {
        /// <summary>
        /// 获取表的最大ID
        /// </summary>
        /// <param name="sTableName"></param>
        /// <returns></returns>
        public static string GetTableID(string sDBName, string sTableName,string sFieldID)
        {
            string sql = string.Format("SELECT isnull(max({0})+1,1) FROM {1} ", sFieldID, sTableName);

            return new DataBaseLayer(sDBName).GetSingle(sql).ToString();
        }

        /// <summary>
        /// 获取表的最大ID
        /// </summary>
        /// <param name="sTableName"></param>
        /// <returns></returns>
        public static string GetTableID(string sDBName, string sTableName, string sFieldID,Loginer cUer)
        {
            string sql = "";
            if (cUer.DbType == DbAcessTyp.SQLServer)
                sql = string.Format("SELECT isnull(max({0})+1,1) FROM {1} ", sFieldID, sTableName);
            else
                sql = string.Format("SELECT nvl(max({0})+1,1) FROM {1} ", sFieldID, sTableName);

            return new DataBaseLayer(sDBName).GetSingle(sql).ToString();
        }

         //<summary>
         //在同一事务内生成单号
         //</summary>
         //<param name="tran">当前事务</param>
         //<param name="DocNoName">单据名称</param>
         //<returns></returns>
        public static string GetNumber(string sDBName, string Tablename,bool IsUp)
        {
            string strNo = "";
            string strNy = DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM");
            string sHead = "";
            string sfid="";
            string sql = "select * from sys_FBillSN where FTableName ='" + Tablename + "' and FYYMM='" + strNy + "'";
            DataTable dt = new DataBaseLayer(sDBName).ExecuteQueryDataTable(sql);
            if (dt.Rows.Count == 0)
            {
                sql = "select FHeader from sys_FBillSN where fid in (select max(fid) from sys_FBillSN where FTableName ='" + Tablename + "')";
                sHead = new DataBaseLayer(sDBName).GetSingle(sql).ToString();
                strNo = sHead + strNy + "1";
                sfid=GetTableID(sDBName,"sys_FBillSN","FID");
                sql = "inert into sys_FBillSN(Fid, FTableName, FHeader, FYYMM, FMaxID, FIsLock) values(" + sfid + ",'" + Tablename + "','" + sHead + "','" + strNy + "',2,0)";
                if (IsUp)
                    new DataBaseLayer(sDBName).ExecuteSql(sql);
            }
            if (dt.Rows.Count == 1)
            {
                sHead = dt.Rows[0]["FHeader"].ToString();
                strNo = sHead + strNy + dt.Rows[0]["FMaxID"].ToString();
                sql = "update sys_FBillSN set FMaxID=FMaxID+1 where  FTableName ='" + Tablename + "' and FYYMM='" + strNy + "'";
                if(IsUp)
                    new DataBaseLayer(sDBName).ExecuteSql(sql);
            }
            
            return strNo;
        }
        /// <summary>
        /// 获取编号
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="dataCode"></param>
        /// <param name="asHeader"></param>
        /// <returns></returns>
        public static string GetDataSN(string sDBName,string Tablename, bool asHeader, bool IsUp)
        {
            string strNo = "";           
            string sHead = "";
           
            string sql = "select * from sys_DataSN where FTableName ='" + Tablename + "'";
            DataTable dt = new DataBaseLayer(sDBName).ExecuteQueryDataTable(sql);            
            if (dt.Rows.Count == 1)
            {
                sHead = dt.Rows[0]["FHeader"].ToString();
                
                strNo = sHead +Convert.ToInt32(dt.Rows[0]["FMaxID"]).ToString("d" + dt.Rows[0]["FLength"].ToString());
                sql = "update sys_DataSN set FMaxID=FMaxID+1 where  FTableName ='" + Tablename + "'";
                if (IsUp)
                    new DataBaseLayer(sDBName).ExecuteSql(sql);
            }

            return strNo;
        }

        //public static string GetDataSN(SqlConnection conn, string dataCode, bool asHeader)
        //{
        //    string SQL = "sp_GetDataSN '" + dataCode + "','" + (asHeader ? "Y" : "N") + "'";
        //    SqlCommand cmd = new SqlCommand(SQL, conn);
        //    object no = cmd.ExecuteScalar();
        //    return ConvertEx.ToString(no);
        //}

    }
}
