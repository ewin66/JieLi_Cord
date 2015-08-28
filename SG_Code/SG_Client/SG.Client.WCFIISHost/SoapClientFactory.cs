///*************************************************************************/
///*
///* 文件名    ：WcfClientFactory.cs                                      
///* 程序说明  : WCF服务客户端实例工厂
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Client.WCFIISHost.Base_SGBaseUser_W;
using System.ServiceModel;
using SG.Client.WCFIISHost.Base_CommonService_W;
using SG.Client.WCFIISHost.Base_SGBaseDict_W;
using SG.Client.WCFIISHost.Set_SGSetFunSQL_W;
using SG.Client.WCFIISHost.Database_SGDatabase_W;
using SG.Client.WCFIISHost.ExtControl_ExtGridControl_W;

namespace SG.Client.WCFIISHost
{
    /// <summary>
    /// WCF服务客户端实例工厂
    /// </summary>
    public  class SoapClientFactory
    {
        /// <summary>
        /// 创建用户服务的SOAP Client对象
        /// </summary>
        /// <returns></returns>
        public static SGBaseUser_WClient CreateSGBaseUser_WClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "http_ISGBaseUser_W");//从配置文件(app.config)读取配置。            
            string endpoint = SoapClientConfig.GetSoapRemoteAddress("http_ISGBaseUser_W");
            return new SGBaseUser_WClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例
           
        }

        /// <summary>
        /// 公共函数Client对象
        /// </summary>
        /// <returns></returns>
        public static CommonService_WClient CreateCommonService_WClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "http_ICommonService_W");//从配置文件(app.config)读取配置。            
            string endpoint = SoapClientConfig.GetSoapRemoteAddress("http_ICommonService_W");
            return new CommonService_WClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例
           
        }

        /// <summary>
        /// 数据字典Client对象
        /// </summary>
        /// <returns></returns>
        public static SGBaseDict_WClient CreateSGBaseDict_WClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "http_ISGBaseDict_W");//从配置文件(app.config)读取配置。            
            string endpoint = SoapClientConfig.GetSoapRemoteAddress("http_ISGBaseDict_W");
            return new SGBaseDict_WClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例

        }

        public static SGSetFunSQL_WClient CreateSGSetFunSQL_WClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "http_ISGSetFunSQL_W");//从配置文件(app.config)读取配置。            
            string endpoint = SoapClientConfig.GetSoapRemoteAddress("http_ISGSetFunSQL_W");
            return new SGSetFunSQL_WClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例

        }

        public static SGDatabase_WClient CreateSGDatabase_WClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "http_ISGDatabase_W");//从配置文件(app.config)读取配置。            
            string endpoint = SoapClientConfig.GetSoapRemoteAddress("http_ISGDatabase_W");
            return new SGDatabase_WClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例

        }

        public static ExtGridControl_WClient CreateExtGridControl_WClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            SoapClientConfig.ReadBindingConfig(BINDING, "http_IExtGridControl_W");//从配置文件(app.config)读取配置。            
            string endpoint = SoapClientConfig.GetSoapRemoteAddress("http_IExtGridControl_W");
            return new ExtGridControl_WClient(BINDING, new EndpointAddress(endpoint));//构建WCF客户端实例
        }
    }
}
