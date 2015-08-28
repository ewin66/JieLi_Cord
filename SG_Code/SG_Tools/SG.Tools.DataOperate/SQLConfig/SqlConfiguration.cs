///*************************************************************************/
///*
///* 文件名    ：SqlConfiguration.cs                                      
///* 程序说明  : SQL的连接参数配置类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using SG.Common;
using System.Windows.Forms;
//using SG.Interfaces.Interfaces_System;

namespace SG.Tools.DataOperate.SQLConfig
{
    /// <summary>
    /// SQL的连接参数配置类
    /// </summary>
    public class SqlConfiguration 
    {
        /// <summary>
        /// SQL连接字符串格式
        /// </summary>
        private const string DEF_SQL_CONNECTION = @"Data Source={0};Initial Catalog={1};User ID={2};Password ={3};Persist Security Info=True;";
        /// <summary>
        /// SQLExpress服务器名
        /// </summary>
        public const string DEF_SQL_SERVER = @".";

        /// <summary>
        /// 用于测试连接的数据库
        /// </summary>
        public const string DEF_SQL_TEST_DB = "master";

        /// <summary>
        ///  SQL的连接参数配置注册表路径
        /// </summary>
        public const string REG_SQL_CFG = @"SOFTWARE\SG_Soft\V2.01\DB";

       

        /// <summary>
        /// 建立连接的数据名
        /// </summary>
        private string _InitialCatalog = string.Empty;

        public SqlConfiguration() { }
        public SqlConfiguration(string InitialCatalog) { _InitialCatalog = InitialCatalog; }

        /// <summary>
        ///预设连接数据库
        /// </summary>
        public string InitialCatalog
        {
            get
            {
                if (_InitialCatalog == string.Empty)
                    return DEF_SQL_TEST_DB;
                else
                    return _InitialCatalog;
            }
            set { _InitialCatalog = value; }
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        public SqlConnection TestConnection(string server, string database, string user, string password, ref string errMsg)
        {
            try
            {
                string connstr = string.Format(DEF_SQL_CONNECTION, server, database, user, password);
                SqlConnection conn = new SqlConnection(connstr);

                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
                return null;
            }
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        public  bool TestConnection(string server, string database, string user, string password)
        {
            const string DEF_SQL_CONNECTION = @"Data Source={0};Initial Catalog={1};User ID={2};Password ={3};Persist Security Info=True;";

            try
            {
                string connstr = string.Format(DEF_SQL_CONNECTION, server, database, user, password);
                SqlConnection conn = new SqlConnection(connstr);

                conn.Open();
                //Msg.ShowInformation("测试成功！");
                return true;
            }
            catch (Exception ex)
            {

                Msg.ShowInformation(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        public  bool TestConnection()
        {
            try
            {
                SqlConfiguration cfg = new SqlConfiguration();
                SqlConnection conn = cfg.CreateConnection();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
                return false;
            }
        }

        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <param name="sServerName"></param>
        /// <param name="sUser"></param>
        /// <param name="sPwd"></param>
        /// <returns></returns>
        public string GetDbList(string sServerName, string sUser, string sPwd)
        {
            try
            {
                string sDbList = "";
                string connstr = string.Format(DEF_SQL_CONNECTION, sServerName, "master", sUser, sPwd);
                SqlConnection conn = new SqlConnection(connstr);

                conn.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter("SELECT name FROM sysdatabases WHERE (dbid > 4) ORDER BY name", conn);
                da.Fill(ds);
                foreach (DataRow myRow in ds.Tables[0].Rows)
                {
                    if (sDbList == "")
                        sDbList = myRow["name"].ToString();
                    else
                        sDbList =sDbList + "," + myRow["name"].ToString();
                }
                return sDbList;
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
                return null;
            }
        }

        private  IWriteSQLConfigValue _sqlConfig = null;

        /// <summary>
        /// 设置SQL配置策略
        /// </summary>
        /// <param name="config"></param>
        public  void SetSQLConfig(IWriteSQLConfigValue config)
        {
            _sqlConfig = config;
        }

        /// <summary>
        /// 创建SQL连接对象
        /// </summary>
        /// <returns></returns>
        public SqlConnection CreateConnection()
        {
            if (_sqlConfig == null)
                _sqlConfig = new IniFileWriter(Application.StartupPath + DbConfiguration_Factory.INI_CFG_PATH);
           
            return CreateConnection(_sqlConfig);
        }

        /// <summary>
        /// 当前指定IWriteSQLConfigValue的连接字符串
        /// </summary>
        public  string CurrentConnectionString
        {
            get
            {
                return _sqlConfig.BuildConnectionString();
            }
        }

        /// <summary>
        /// 建立连接
        /// </summary>
        public SqlConnection CreateConnection(IWriteSQLConfigValue config)
        {
            if (config == null) throw new Exception("Program cann't run without a SQL configuration.You should config the SQL connection by running CSFramework.Tools.SqlConnector.exe!");

            string connstr = string.Format(DEF_SQL_CONNECTION, config.ServerName, config.InitialCatalog, config.UserName, config.Password);
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 生成连接字符串
        /// </summary>
        /// <param name="config">SQL配置策略</param>
        /// <returns></returns>
        public string GetConnectionString(IWriteSQLConfigValue config)
        {
            string connstr = string.Format(DEF_SQL_CONNECTION, config.ServerName, config.InitialCatalog, config.UserName, config.Password);
            return connstr;
        }


    }
}
