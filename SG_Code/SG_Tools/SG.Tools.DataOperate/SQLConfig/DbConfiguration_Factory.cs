///*************************************************************************/
///*
///* 文件名    ：DbConfiguration_Factory.cs                              
///* 程序说明  : 数据库连接配置Factory。
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///*************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Common;
using System.Windows.Forms;
using System.Data;

namespace SG.Tools.DataOperate.SQLConfig
{
    /// <summary>
    /// 数据库连接配置Factory。
    /// </summary>
    public class DbConfiguration_Factory
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        private string _dbType=DbAcessTyp.SQLServer;
        /// <summary>
        /// INI配置文件
        /// </summary>
        public const string INI_CFG_PATH = @"\Config\AccountDB.ini";

        /// <summary>
        /// 代码生成类INI配置文件
        /// </summary>
        public const string INI_CFG_CLASS_PATH = @"\Config\CLASSDB.ini";
        /// <summary>
        /// 获取数据类型
        /// </summary>
        public static string DbType
        {
            get
            {
                IWriteSQLConfigValue _write = new IniFileWriter(SG.Parameters.SGParameter.sAppPath + INI_CFG_PATH);
                return _write.DbType;
            }
        }
        public DbConfiguration_Factory()
        {
            //获取配置文件

            IWriteSQLConfigValue _write = new IniFileWriter(SG.Parameters.SGParameter.sAppPath + INI_CFG_PATH);
            _dbType= _write.DbType;
        }
        /// <summary>
        /// 获取帐套管理数据库连接串
        /// </summary>
        /// <returns></returns>
        public static string GetAccountConnString()
        {
            string sConn = "";
            IWriteSQLConfigValue cfg = new IniFileWriter(SG.Parameters.SGParameter.sAppPath + INI_CFG_PATH);
            if(cfg.DbType==DbAcessTyp.SQLServer)
            {
                sConn = new SqlConfiguration().GetConnectionString(cfg);
            }
            else if(cfg.DbType==DbAcessTyp.Oracle)
            {
                sConn = new OraConfiguration().GetConnectionString(cfg);
            }

            return sConn;
        }

        public static string GetConnString(IWriteSQLConfigValue cfg)
        {
            string sConn = "";
            
            if (cfg.DbType == DbAcessTyp.SQLServer)
            {
                sConn = new SqlConfiguration().GetConnectionString(cfg);
            }
            else if (cfg.DbType == DbAcessTyp.Oracle)
            {
                sConn = new OraConfiguration().GetConnectionString(cfg);
            }

            return sConn;
        }

       
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        public static bool TestConnection()
        {
            bool sRet = false;
            if(DbType==DbAcessTyp.SQLServer) //SQL
            {
                sRet = new SqlConfiguration().TestConnection();
            }
            else if (DbType == DbAcessTyp.Oracle)
            {
                sRet = new OraConfiguration().TestConnection();
            }
            return sRet;
        }

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IDbConnection CreateConnection(IWriteSQLConfigValue config)
        {
            if (DbType == DbAcessTyp.SQLServer) //SQL
            {
                return  new SqlConfiguration().CreateConnection(config);
            }
            else if (DbType == DbAcessTyp.Oracle)
            {
               return new OraConfiguration().CreateConnection(config);
            }
            return null;
        }

        /// <summary>
        /// 设置连接
        /// </summary>
        /// <param name="config"></param>
        public static void SetSQLConfig(IWriteSQLConfigValue config)
        {
            if (DbType == DbAcessTyp.SQLServer) //SQL
            {
                new SqlConfiguration().SetSQLConfig(config);
            }
            else if (DbType == DbAcessTyp.Oracle)
            {
                new OraConfiguration().SetSQLConfig(config);
            }
        }
    }
}
