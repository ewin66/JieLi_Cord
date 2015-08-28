///*************************************************************************/
///*
///* 文件名    ：SqlConfiguration.cs                                      
///* 程序说明  : 将连接配置保存在INI文件
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
//using SG.Interfaces.Interfaces_System;
using System.IO;
using SG.Common;
using System.Configuration;

namespace SG.Tools.DataOperate.SQLConfig
{
    /// <summary>
    /// 通过参数获取字符串
    /// </summary>
    public class IniGetParamter:IWriteSQLConfigValue
    {
        private string _iniFile;
        private string _ServerName;
        private string _Password;
        private string _UserName;
        private string _InitialCatalog;
        private string _DbType;

        /// <summary>
        /// 参数初始化字符串
        /// </summary>
        /// <param name="sServerName">服务器</param>
        /// <param name="sInitialCatalog">数据库</param>
        /// <param name="sUserName">用户名</param>
        /// <param name="sPassword">密码(已加密)</param>
        /// <param name="sDbType">数据类型</param>
        public IniGetParamter(string sServerName, string sInitialCatalog, string sUserName, string sPassword, string sDbType)
        {
            _ServerName = sServerName;
            _InitialCatalog = sInitialCatalog;
            _UserName = sUserName;
            _Password = CEncoder.Decode(sPassword);
            _DbType = sDbType;
        }

        public void Write()
        {
            //
        }

        public void Read()
        {
           
        }

        public string BuildConnectionString()
        {
            return "";
        }

        public string InitialCatalog { get { return _InitialCatalog; } set { _InitialCatalog = value; } }
        public string ServerName { get { return _ServerName; } set { _ServerName = value; } }
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public string DbType { get { return _DbType; } set { _DbType = value; } }


    }

    /// <summary>
    /// 将连接配置保存在INI文件
    /// </summary>
    public class IniFileWriter : IWriteSQLConfigValue
    {
        #region IWriteConfigValue Members

        private string _iniFile;
        private string _ServerName;
        private string _Password;
        private string _UserName;
        private string _InitialCatalog;
        private string _DbType;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="iniFile">INI文件</param>
        public IniFileWriter(string iniFile)
        {
            _iniFile = iniFile;
            if (!File.Exists(iniFile))
                Write();

            Read();
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        public void Read()
        {
            IniFile cfg = new IniFile(_iniFile);
            if (cfg != null)
            {
                _ServerName = cfg.IniReadValue("BdConfiguration", "SQLServer");
                _InitialCatalog = cfg.IniReadValue("BdConfiguration", "database");
                _UserName = cfg.IniReadValue("BdConfiguration", "SqlUser");
                _Password = CEncoder.Decode(cfg.IniReadValue("BdConfiguration", "SqlPwd")); //解密
                _DbType = cfg.IniReadValue("BdConfiguration", "DbType");
            }
        }

        /// <summary>
        /// 将配置写入INI文件
        /// </summary>
        public void Write()
        {
            IniFile cfg = new IniFile(_iniFile);
            if (cfg != null)
            {
                cfg.IniWriteValue("BdConfiguration", "SQLServer", _ServerName);
                cfg.IniWriteValue("BdConfiguration", "Database", _InitialCatalog);
                cfg.IniWriteValue("BdConfiguration", "SqlUser", _UserName);
                cfg.IniWriteValue("BdConfiguration", "SqlPwd", CEncoder.Encode(_Password)); //加密
                cfg.IniWriteValue("BdConfiguration", "DbType",_DbType);
            }
        }

        /// <summary>
        /// 生成连接字符串
        /// </summary>
        /// <returns></returns>
        public string BuildConnectionString()
        {
            if (_DbType == DbAcessTyp.SQLServer)
                return new SqlConfiguration().GetConnectionString(this);
            else
                return new OraConfiguration().GetConnectionString(this);
        }

        /// <summary>
        /// 加载连接配置
        /// </summary>
        /// <param name="ConfigFile">配置文件</param>
        public static void LoadConfiguration(string ConfigFile)
        {
            if (File.Exists(ConfigFile))
            {
                IWriteSQLConfigValue cfg = new IniFileWriter(ConfigFile);
                new SqlConfiguration().SetSQLConfig(cfg);
            }
            else
                throw new Exception("Program cann't run without a BdConfiguration.You should config the SQL connection by running CSFramework.Tools.SqlConnector.exe!");
        }

        public string InitialCatalog { get { return _InitialCatalog; } set { _InitialCatalog = value; } }
        public string ServerName { get { return _ServerName; } set { _ServerName = value; } }
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public string DbType { get { return _DbType; } set { _DbType = value; } }
        #endregion
    }

    /// <summary>
    /// 将连接配置保存在INI文件(开发环境使用)
    /// </summary>
    public class SQLExpressCfg : IWriteSQLConfigValue
    {
        private string _ConnectionString;
        private string _iniFile;

        public SQLExpressCfg(string iniFile)
        {
            _iniFile = iniFile;
            this.Read();
        }
        #region IWriteSQLConfigValue Members

        public void Write()
        {
            //
        }

        public void Read()
        {
            _ConnectionString = File.ReadAllText(_iniFile, Encoding.UTF8);
        }

        public string BuildConnectionString()
        {
            return _ConnectionString;
        }

        public string ServerName { get { return ""; } set { } }
        public string InitialCatalog { get { return ""; } set { } }
        public string UserName { get { return ""; } set { } }
        public string Password { get { return ""; } set { } }
        public string DbType { get { return ""; } set { } }
        #endregion
    }

    /// <summary>
    /// 连接参数保存在系统注册表
    /// </summary>
    public class RegisterWriter : IWriteSQLConfigValue
    {
        #region IWriteConfigValue Members

        private string _keyPath;
        private string _ServerName;
        private string _Password;
        private string _UserName;
        private string _InitialCatalog;
        private string _DbType;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="keyPath">注册表位置</param>
        public RegisterWriter(string keyPath)
        {
            _keyPath = keyPath;
            Read();
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        public void Read()
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey(_keyPath);
            if (key != null)
            {
                _ServerName = ConvertEx.ToString(key.GetValue("SQLServer", "."));
                _InitialCatalog = ConvertEx.ToString(key.GetValue("SqlDatabase", ""));
                _UserName = ConvertEx.ToString(key.GetValue("SqlUser", "sa"));
                _Password = ConvertEx.ToString(key.GetValue("SqlPwd", ""));
                _DbType = ConvertEx.ToString(key.GetValue("DbType", ""));
                if (_Password != string.Empty) _Password = CEncoder.Decode(_Password);
                key.Close();
            }
        }

        /// <summary>
        /// 写入配置
        /// </summary>
        public void Write()
        {
            RegistryKey key = Registry.LocalMachine.CreateSubKey(_keyPath);
            if (key != null)
            {
                key.SetValue("SQLServer", _ServerName);
                key.SetValue("SqlDatabase", _InitialCatalog);
                key.SetValue("SqlUser", _UserName);
                key.SetValue("SqlPwd", CEncoder.Encode(_Password));
                key.SetValue("DbType",_DbType);
                key.Close();
            }
        }

        /// <summary>
        /// 生成连接字符串
        /// </summary>
        /// <returns></returns>
        public string BuildConnectionString()
        {
            return new SqlConfiguration().GetConnectionString(this);
        }

        public string InitialCatalog { get { return _InitialCatalog; } set { _InitialCatalog = value; } }
        public string ServerName { get { return _ServerName; } set { _ServerName = value; } }
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }

        public string DbType { get { return _DbType; } set { _DbType = value; } }
        #endregion
    }

    /// <summary>
    /// 将连接配置保存在INI文件(开发环境使用)
    /// </summary>
    public class WebConfigCfg : IWriteSQLConfigValue
    {
        private string _ConnectionString;

        public WebConfigCfg()
        {
            this.Read();
        }

        #region IWriteSQLConfigValue Members

        public void Write()
        {
            //
        }

        public void Read()
        {
            _ConnectionString = ConfigurationSettings.AppSettings["SystemConnectionString"];
        }

        public string BuildConnectionString()
        {
            return _ConnectionString;
        }

        public string ServerName { get { return ""; } set { } }
        public string InitialCatalog { get { return ""; } set { } }
        public string UserName { get { return ""; } set { } }
        public string Password { get { return ""; } set { } }
        public string DbType { get { return ""; } set { } }
        #endregion
    }


}
