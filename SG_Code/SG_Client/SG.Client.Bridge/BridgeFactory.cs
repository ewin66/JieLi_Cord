
///*************************************************************************/
///*
///* 文件名    ：BridgeFactory.cs                                      
///* 程序说明  : 服务端桥接类型, 高级版支持ADO Direct与WebService层互换。
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using SG.Common;
using SG.Tools.DataOperate.SQLConfig;
using SG.Client.WCFHost;
using SG.Client.WCFIISHost;
using SG.Client.WCFHost.Base_CommonService_H;
using SG.Client.WCFHost.Base_SGBaseUser_H;
using SG.Client.WCFIISHost.Base_CommonService_W;
using SG.Client.WCFIISHost.Base_SGBaseUser_W;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SG.Interfaces.Base;
using SG.Client.Bridge.Base;
using SG.Interfaces;
using SG.Interfaces.Set;
using SG.Client.Bridge.Set;
using SG.Interfaces.Database;
using SG.Client.Bridge.Database;
using SG.Interfaces.ExtControl;
using SG.Client.Bridge.ExtControl;

namespace SG.Client.Bridge
{
    /// <summary>
    /// 服务端桥接类型, 高级版支持ADO Direct与WebService层互换。
    /// </summary>
    public enum BridgeType
    {
        /// <summary>
        /// 未知桥接类型,用于初始化
        /// </summary>
        Unknow,

        /// <summary>        
        /// BLL层通过桥接方式调用数据层的接口
        /// BLL层直接调用数据层存取数据(ADO Direct)
        /// </summary>
        ADODirect,

        /// <summary>
        /// BLL层通过桥接方式调用WebService层的接口
        /// </summary>
        WebService,

        /// <summary>
        /// BLL层通过桥接方式调用WcfHost层的接口
        /// </summary>
        WcfHost
    }

    /// <summary>
    /// 数据层的桥接工厂
    /// </summary>
    public class BridgeFactory
    {
        public const string UNKNOW_BRIDGE_TYPE = "没有指定桥接类型(Bridge Type)，创建数据层桥接实例失败！";
        public const string TEST_BRIDGE_FAILED = "测试桥接功能失败，无法建立与后台数据层的连接！";
        public const string LOST_DAL_FILE = "数据访问层模块文件丢失！";

        /// <summary>
        /// 数据访问层模块文件名
        /// </summary>
        public const string DLL_FILE_NAME = "SG.Server.DataAccess.Base.dll";

        /// <summary>
        /// 配置文件
        /// </summary>
        public const string INI_CFG = @"\config\user.ini";

        /// <summary>
        /// 动态配置桥接类型
        /// </summary>
        private static BridgeType _BridgeType = BridgeType.Unknow;

        /// <summary>
        /// 预设桥接类型
        /// </summary>
        private static BridgeType _DefaultBridgeType = BridgeType.WebService;

        /// <summary>
        /// 从配置文件获取桥接方式
        /// </summary>
        public static BridgeType BridgeType
        {
            get
            {
                if (_BridgeType == BridgeType.Unknow)
                {
                    string iniFile = Application.StartupPath + BridgeFactory.INI_CFG;

                    //有配置文件
                    if (File.Exists(iniFile))
                    {
                        IniFile ini = new IniFile(iniFile);
                        string bridgeType = ini.IniReadValue("BridgeType", "BridgeType");

                        if (Enum.IsDefined(typeof(BridgeType), bridgeType))
                            _BridgeType = (BridgeType)Enum.Parse(typeof(BridgeType), bridgeType);
                        else
                            return _DefaultBridgeType;//返回预设连接类型
                    }
                    else
                    {
                        _BridgeType = _DefaultBridgeType;//返回预设连接类型
                    }
                }

                return _BridgeType;
            }
        }

        /// <summary>
        /// 跟据ORM创建桥接功能
        /// </summary>
        /// <param name="ORM">ORM类</param>
        /// <returns></returns>
        public static IBridge_DataDict CreateDataDictBridge(Type ORM)
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_SGBaseDict(ORM).GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WCFIISHost_SGBaseDict(ORM);

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WCFHost_SGBaseDict(ORM);

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 创建用户组的数据层桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_UserGroup CreateUserGroupBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_UserGroup().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WcfIISHost_UserGroup();


            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WcfHost_UserGroup();

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }     

        /// <summary>
        /// 创建公共功能数据层的桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_CommonService CreateCommonServiceBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_CommonService().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WCFIISHost_CommonService();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WCFHost_CommonService();

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 创建数据字典的数据层桥接实例
        /// </summary>        
        /// <returns></returns>
        public static IBridge_DataDict CreateDataDictBridge(string derivedClassName)
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_SGBaseDict(derivedClassName).GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WCFIISHost_SGBaseDict();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WCFHost_SGBaseDict();

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 创建数据字典的数据层桥接实例
        /// </summary>
        /// <param name="tableName">数据字典表名</param>
        /// <returns></returns>
        public static IBridge_DataDict CreateDataDictBridge(string tableName, string derivedClassName)
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_SGBaseDict(tableName, derivedClassName).GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WCFIISHost_SGBaseDict(tableName);

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WCFHost_SGBaseDict(tableName);

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 创建用户管理的数据层桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_User CreateUserBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_SGBaseUser().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WCFIISHost_SGBaseUser();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WCFHost_SGBaseUser();

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 创建Grid配置的数据层桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_FunSQL CreateFunSQLBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_SGSetFunSQL().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WCFIISHost_SGSetFunSQL();
                

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WCFHost_SGSetFunSQL();

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 创建查询方案的数据层桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_RPTColInfoScheme CreateRPTColInfoSchemeBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_RPTColInfoScheme().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WCFIISHost_RPTColInfoScheme();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WCFHost_RPTColInfoScheme();

            throw new CustomException(UNKNOW_BRIDGE_TYPE);
        }

        /// <summary>
        /// 获取系统参数桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_SystemProfile CreateSystemProfileBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_SystemProfile().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WcfIISHost_SystemProfile();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WcfHost_SystemProfile();

            return null;
        }

        /// <summary>
        /// 获取公共数据字典桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_CommonDataDict CreateCommonDataDictBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_CommonDataDict().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WcfIISHost_CommonDataDict();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WcfHost_CommonDataDict();

            return null;
        }

        /// <summary>
        /// 获取基础资料名称桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_ItemClass CreateItemClassBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_ItemClass().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WcfIISHost_ItemClass();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WcfHost_ItemClass();

            return null;
        }

        /// <summary>
        /// 获取基础资料属性桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_ItemPropDesc CreateItemPropDescBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_ItemPropDesc().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WcfIISHost_ItemPropDesc();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WcfHost_ItemPropDesc();

            return null;
        }

        /// <summary>
        /// 获取数据显示控件桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_ExtGridControl CreateExtGridControlBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_ExtGridControl().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WcfIISHost_ExtGridControl();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WcfHost_ExtGridControl();

            return null;
        }

        /// <summary>
        /// 测试WebService连接
        /// </summary>
        /// <returns></returns>
        private static bool TestWebServiceConnection()
        {
            try
            {
                CommonService_WClient commonService = SoapClientFactory.CreateCommonService_WClient();
                
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return commonService.TestConnection(validationTicket);
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
                return false;
            }
        }

        /// <summary>
        /// 测试WebService连接
        /// </summary>
        /// <returns></returns>
        private static bool TestWcfHostConnection()
        {
            try
            {
                CommonService_HClient commonService = WcfClientFactory.CreateCommonService_HClient();
                
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return commonService.TestConnection(validationTicket);
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
                return false;
            }
        }

        /// <summary>
        /// 测试AdoDirect连接         
        /// </summary>
        /// <returns></returns>
        private static bool TestADOConnection()
        {
            // 数据访问层的模块文件
            string DalFile = Application.StartupPath + @"\" + DLL_FILE_NAME;

            bool exists = File.Exists(DalFile);
            if (false == exists)
                throw new CustomException(LOST_DAL_FILE + "\r\n\r\nFile:" + DalFile);
            return exists && DbConfiguration_Factory.TestConnection();  //SqlConfiguration().TestConnection();
        }

        /// <summary>
        /// 初始化桥接功能
        /// </summary>
        public static bool InitializeBridge()
        {
            bool connected = false;

            try
            {
                //ADODirect方式，从INI文件读配置信息
                if (BridgeType.ADODirect == BridgeType)
                {
                    //获取连接配置.支持4种连接配置:1.INI, 2.注册表 3.SQLExpress INI 4.Web.Config
                    //IWriteSQLConfigValue cfgRegistry = new RegisterWriter(SqlConfiguration.REG_SQL_CFG);

                    //开发环境，直接从INI文件读取SQL连接配置
                    //IWriteSQLConfigValue cfgSQLExpress = new SQLExpressCfg(Application.StartupPath + @"\CSFramework.ini");
                    
                    //生产环境连接配置
                    IWriteSQLConfigValue cfgNormal = new IniFileWriter(Application.StartupPath + DbConfiguration_Factory.INI_CFG_PATH);

                    //设置配置信息
                    //SqlConfiguration.SetSQLConfig(cfgNormal);
                    DbConfiguration_Factory.SetSQLConfig(cfgNormal);
                    connected = TestADOConnection();//测试AdoDirect连接                
                }

                if (BridgeType.WebService == BridgeType)
                {
                    //初始化服务端的SQL连接
                    connected = TestWebServiceConnection();//测试WebService连接
                }

                if (BridgeType.WcfHost == BridgeType)
                {
                    //初始化服务端SQL连接
                    connected = TestWcfHostConnection();//测试WebService连接
                }
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }

            //测试桥接是否成功
            if (false == connected)
            {
                Msg.Warning(TEST_BRIDGE_FAILED + "\r\n\r\nBridgeType:" + BridgeFactory.BridgeType.ToString());
            }

            return connected;
        }



    }
}
