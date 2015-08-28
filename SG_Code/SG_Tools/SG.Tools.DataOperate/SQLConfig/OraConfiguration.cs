///*************************************************************************/
///*
///* 文件名    ：oraConfiguration.cs                                      
///* 程序说明  : Oracle的连接参数配置类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using SG.Common;
using Microsoft.Win32;
using System.IO;
using System.Data;
using System.Reflection;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SG.Tools.DataOperate.SQLConfig
{
    /// <summary>
    /// Oracle的连接参数配置类
    /// </summary>
    public class OraConfiguration 
    {
         /// <summary>
        /// Oracle连接字符串格式
        /// </summary>
        //private const string DEF_SQL_CONNECTION = @"Data Source={0};Initial Catalog={1};User ID={2};Password ={3};Persist Security Info=True;";
        //private const string DEF_SQL_CONNECTION = @"Data Source={0};Password={1};User ID={2}";
        private const string DEF_SQL_CONNECTION = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP) (HOST={0}) (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME= {1})));Password={2};User Id={3}";

        /// <summary>
        /// SQLExpress服务器名
        /// </summary>
        public const string DEF_SQL_SERVER = @"127.0.0.1";

        /// <summary>
        /// 用于测试连接的数据库
        /// </summary>
        public const string DEF_SQL_TEST_DB = "orcl";

        /// <summary>
        ///  SQL的连接参数配置注册表路径
        /// </summary>
        public const string REG_SQL_CFG = @"SOFTWARE\SG_Soft\V2.01\DB";

    
        private  IWriteSQLConfigValue _sqlConfig = null;
        /// <summary>
        /// 建立连接的数据名
        /// </summary>
        private string _InitialCatalog = string.Empty;



        public OraConfiguration() { }

        public OraConfiguration(string InitialCatalog) { _InitialCatalog = InitialCatalog; }
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
        public OracleConnection TestConnection(string server, string database, string user, string password, ref string errMsg)
        {
            try
            {
                string connstr = string.Format(DEF_SQL_CONNECTION, server, database, password, user);
                OracleConnection conn = new OracleConnection(connstr);

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
        /// <returns></returns>
        public  bool TestConnection(string server, string database, string user, string password)
        {
            try
            {
                string connstr = string.Format(DEF_SQL_CONNECTION, server, database, password, user);
                OracleConnection conn = new OracleConnection(connstr);
                conn.Open();
                //Msg.ShowInformation("测试成功！");
                return true;
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
                return false;
            }
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        //public bool TestConnection(string database, string user, string password)
        //{
        //    try
        //    {
        //        string connstr = string.Format(DEF_SQL_CONNECTION, database, password, user);
        //        OracleConnection conn = new OracleConnection(connstr);
        //        conn.Open();
        //        //Msg.ShowInformation("测试成功！");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Msg.ShowException(ex);
        //        return false;
        //    }
        //}
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        public  bool TestConnection()
        {
            try
            {
                OraConfiguration cfg = new OraConfiguration();
                OracleConnection conn = cfg.CreateConnection();
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
        public OracleConnection CreateConnection()
        {
            if(_sqlConfig==null)
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
        public OracleConnection CreateConnection(IWriteSQLConfigValue config)
        {
            if (config == null) throw new Exception("Program cann't run without a SQL configuration.You should config the SQL connection by running CSFramework.Tools.SqlConnector.exe!");

            string connstr = string.Format(DEF_SQL_CONNECTION,config.ServerName, config.InitialCatalog, config.Password, config.UserName);
            OracleConnection conn = new OracleConnection(connstr);
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
            string connstr = string.Format(DEF_SQL_CONNECTION, config.ServerName, config.InitialCatalog, config.Password, config.UserName);
            return connstr;
        }

        #region Oracle TNS 处理
        /// <summary>
        /// 本机是否安装Oracle
        /// </summary>
        /// <returns></returns>
        public bool IsInstallOracle()
        {
            bool IsInstall = false;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ORACLE");
            if (key == null)
                key = GetValueWithRegView(RegistryHive.LocalMachine, @"SOFTWARE\ORACLE", RegistryView.Registry64); //UtilityReg64.OpenSubKey(Registry.LocalMachine.OpenSubKey("SOFTWARE"), "ORACLE", false, UtilityReg64.eRegWow64Options.KEY_WOW64_64KEY);
            if ( key != null)
            {
                IsInstall = true;
            }
            return IsInstall;
        }
        /// <summary>
        /// 获取本机配置的OracleTNS的名称和服务器列表，返回二维数组，不同时实例用“，”隔开
        /// </summary>
        /// <returns></returns>
        public string[] iniOracleTNS()
        {
            //string strOraHome = "";
            //strOraHome = UtilityReg.Get64BitRegistryKey("HKEY_LOCAL_MACHINE", @"SOFTWARE\ORACLE\KEY_OraClient11g_home1", "Oracle_Home");

            //Oracle加载实例名
            string[] sRet = new string[3];
            string[] values = null;
            string oracleHome = "";
            string oracleName = "";
            string oracleHost = "";
            string oraclePort = "";
            string DbListValue = "";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ORACLE");
            if (key == null)
                key = GetValueWithRegView(RegistryHive.LocalMachine, @"SOFTWARE\ORACLE", RegistryView.Registry64); //UtilityReg64.OpenSubKey(Registry.LocalMachine.OpenSubKey("SOFTWARE"), "ORACLE", false, UtilityReg64.eRegWow64Options.KEY_WOW64_64KEY);
            if (key != null)           
            {
                //如果该机安装了Oracle则继续,否则提示本机未安装Oracle
                values = key.GetValueNames();
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i].Equals("ORACLE_HOME"))
                    {
                        oracleHome =key.GetValue("ORACLE_HOME").ToString();
                    }
                }
                if (oracleHome.Equals(""))
                {
                    oracleHome = FindOracleHome("SOFTWARE\\ORACLE");
                }
                //ArrayList arr = new ArrayList();
                string path = oracleHome + @"\network\admin\tnsnames.ora";
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        String line;
                        string separator = "=";
                        string oldOrac = "";
                        string[] hp = new string[2];
                        while ((line = sr.ReadLine()) != null)
                        {
                            line = line.Trim();
                            if (line != "")
                            {
                                char c = line[0];
                                if (c >= 'A' && c <= 'z')
                                {
                                    DbListValue = line.Substring(0, line.IndexOf(separator)).Trim();
                                    //arr.Add(DbListValue);
                                    //cmbDatabase.Items.Add(DbListValue);
                                    if (oracleName == "")
                                    {
                                        oracleName = DbListValue;
                                    }
                                    else
                                    {
                                        oldOrac = oracleName;
                                        oracleName = oracleName + "," + DbListValue;
                                    }
                                }
                                else
                                {
                                    if (line.Contains("IPC)"))
                                    {
                                        oracleName = oldOrac;
                                    }
                                    else
                                    {
                                        if (line.Contains("HOST"))
                                        {
                                            string host = getStringValue(line, "HOST", ")");
                                            string[] vHost = host.Split(separator.ToCharArray());
                                            //tableHost.Add(DbListValue, vHost[1]);
                                            if (oracleHost == "")
                                                oracleHost = vHost[1].Trim();
                                            else
                                                oracleHost = oracleHost + "," + vHost[1].Trim();
                                        }
                                        if (line.Contains("PORT"))
                                        {
                                            string port = getStringValue(line, "PORT", ")");
                                            string[] vPort = port.Split(separator.ToCharArray());
                                            //tablePort.Add(DbListValue, vPort[1]);
                                            if (oraclePort == "")
                                                oraclePort = vPort[1];
                                            else
                                                oraclePort = oraclePort + "," + vPort[1];
                                        }
                                    }
                                }
                            }
                        }
                    }
                    sRet[0] = oracleName;
                    sRet[1] = oracleHost;
                    sRet[2] = oraclePort;
                }
                catch (Exception ex)
                {
                    Msg.ShowInformation("无法打开tnsnames.ora文件\n" + ex.Message);
                    sRet = null;
                    //MessageBox.Show("无法打开tnsnames.ora文件\n" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                Msg.ShowInformation("本机未安装Oracle数据库,请安装后在配置!");
                sRet = null;
                //MessageBox.Show("本机未安装Oracle数据库,请安装后在配置!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            return sRet;
        }

        /// <summary>
        /// 用于32位程序访问64位注册表
        /// </summary>
        /// <param name="hive">根级别的名称</param>
        /// <param name="keyName">不包括根级别的名称</param>
        /// <param name="valueName">项名称</param>
        /// <param name="view">注册表视图</param>
        /// <returns>值</returns>
        private RegistryKey GetValueWithRegView(RegistryHive hive, string keyName,  RegistryView view)
        {

            SafeRegistryHandle handle = new SafeRegistryHandle(GetHiveHandle(hive), true);//获得根节点的安全句柄

            RegistryKey subkey = RegistryKey.FromHandle(handle, view).OpenSubKey(keyName);//获得要访问的键

            RegistryKey key = RegistryKey.FromHandle(subkey.Handle, view);//根据键的句柄和视图获得要访问的键

            return key;
            //return key.GetValue(valueName);//获得键下指定项的值
        }

        private  IntPtr GetHiveHandle(RegistryHive hive)
        {
            IntPtr preexistingHandle = IntPtr.Zero;

            IntPtr HKEY_CLASSES_ROOT = new IntPtr(-2147483648);
            IntPtr HKEY_CURRENT_USER = new IntPtr(-2147483647);
            IntPtr HKEY_LOCAL_MACHINE = new IntPtr(-2147483646);
            IntPtr HKEY_USERS = new IntPtr(-2147483645);
            IntPtr HKEY_PERFORMANCE_DATA = new IntPtr(-2147483644);
            IntPtr HKEY_CURRENT_CONFIG = new IntPtr(-2147483643);
            IntPtr HKEY_DYN_DATA = new IntPtr(-2147483642);
            switch (hive)
            {
                case RegistryHive.ClassesRoot: preexistingHandle = HKEY_CLASSES_ROOT; break;
                case RegistryHive.CurrentUser: preexistingHandle = HKEY_CURRENT_USER; break;
                case RegistryHive.LocalMachine: preexistingHandle = HKEY_LOCAL_MACHINE; break;
                case RegistryHive.Users: preexistingHandle = HKEY_USERS; break;
                case RegistryHive.PerformanceData: preexistingHandle = HKEY_PERFORMANCE_DATA; break;
                case RegistryHive.CurrentConfig: preexistingHandle = HKEY_CURRENT_CONFIG; break;
                case RegistryHive.DynData: preexistingHandle = HKEY_DYN_DATA; break;
            }
            return preexistingHandle;
        }

        /// <summary>
        /// 返回寻找的字符串
        /// 用来解析tnsnames.ora文件获取主机和端口
        /// </summary>
        /// <param name="line"></param>
        /// <param name="Key"></param>
        /// <param name="split"></param>
        /// <returns></returns>
        private string getStringValue(string line, string Key, string split)
        {
            string value = "";
            value = line.Substring(line.IndexOf(Key), (line.Length - line.IndexOf(Key)));
            string temp = "";
            string vt = "";
            for (int i = 0; i < value.Length; i++)
            {
                temp = value.Substring(i, 1);
                if (temp.Equals(split))
                {
                    return vt;
                }
                else
                {
                    vt = vt + temp;
                }
            }
            return vt;
        }
        /// <summary>
        /// 根据注册表项寻找oracle安装路径，加载服务名
        /// edit by clarkleo 2009-12-28
        /// </summary>
        /// <returns></returns>
        private string FindOracleHome(string skPath)
        {
            string oracleHome = "";
            string subKeyPath = skPath;
            string split = "\\";
            string[] SubKey = null;
            string[] values = null;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(skPath);
            if (key == null)
                key = GetValueWithRegView(RegistryHive.LocalMachine, skPath, RegistryView.Registry64); //UtilityReg64.OpenSubKey(Registry.LocalMachine.OpenSubKey("SOFTWARE"), "ORACLE", false, UtilityReg64.eRegWow64Options.KEY_WOW64_64KEY);

            SubKey = key.GetSubKeyNames();
            for (int i = 0; i < SubKey.Length; i++)
            {
                subKeyPath = skPath + split + SubKey[i];
                key = Registry.LocalMachine.OpenSubKey(subKeyPath);
                if (key == null)
                    key = GetValueWithRegView(RegistryHive.LocalMachine, subKeyPath, RegistryView.Registry64);
                values = key.GetValueNames();
                for (int j = 0; j < values.Length; j++)
                {
                    if (values[j].Equals("ORACLE_HOME"))
                    {
                        oracleHome =key.GetValue("ORACLE_HOME").ToString();
                        if (File.Exists(oracleHome + @"\network\admin\tnsnames.ora"))
                            return oracleHome;
                    }
                }
            }
            if (oracleHome.Equals(""))
            {
                for (int i = 0; i < SubKey.Length; i++)
                {
                    oracleHome = FindOracleHome(SubKey[i]);
                    if (!oracleHome.Equals(""))
                    {
                        return oracleHome;
                    }
                }

            }
            return oracleHome;
        }

        #endregion
       
    }
   
}
