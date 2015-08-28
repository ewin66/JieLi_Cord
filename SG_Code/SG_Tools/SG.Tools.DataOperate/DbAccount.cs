///*************************************************************************/
///*
///* 文件名    ：DbAccount.cs                                      
///* 程序说明  : 获取帐套库的所有的数据库，生成HasTable
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using SG.Tools.DataOperate.SQLConfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Tools.DataOperate
{
    /// <summary>
    /// 获取帐套库的所有的数据库，生成HasTable
    /// </summary>
    public  class DbAccount
    {
        /// <summary>
        /// 获取帐套库的数据库写入HasTable
        /// </summary>
        public static void GetDbAccount()
        {
            if (SG.Parameters.SGParameter.hAccountConn != null)
                SG.Parameters.SGParameter.hAccountConn.Clear();
            else
                SG.Parameters.SGParameter.hAccountConn = new System.Collections.Hashtable();
            string dbType = DbConfiguration_Factory.DbType;
            string sConn = DbConfiguration_Factory.GetAccountConnString();
            string sSQL = "SELECT     T_Account.FID, T_Account.FNumber, T_Account.FName, T_Account.FDatabase, T_Account.FServerName, T_Account.FUser, T_Account.FPwd, T_Account.FDataType, " +
                                    " T_Account.FOrgID, T_Account.FCreateDate, T_Account.FBackUpDate, T_Account.FVer, T_Account.FProductName, T_Account.FOnlineCount, T_Account.FServerIP, T_DbType.FSign " +
                          " FROM         T_Account INNER JOIN T_DbType ON T_Account.FID = T_DbType.FID  ";
            DataTable sAccount = new DataBaseLayer(sConn, dbType).ExecuteQueryDataTable(sSQL);
            foreach(DataRow myRow in sAccount.Rows)
            {
                SG.Parameters.SGParameter.sAccountConn sAC = new Parameters.SGParameter.sAccountConn();
                sAC.sServer = myRow["FServerName"].ToString();
                sAC.sDatabase = myRow["FDatabase"].ToString();
                sAC.sUser = myRow["FUser"].ToString();
                sAC.sPwd = myRow["FPwd"].ToString();
                sAC.sDbType = myRow["FSign"].ToString();
                SG.Parameters.SGParameter.hAccountConn.Add(myRow["FNumber"].ToString(), sAC);
            }            
        }
               
    }
}
