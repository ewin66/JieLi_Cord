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
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SG.Client.WCFHost.Base_SGBaseUser_H;
using SG.Client.WCFHost.Base_CommonService_H;
using SG.Client.WCFHost.Base_SGBaseDict_H;
using SG.Client.WCFHost.Set_SGSetFunSQL_H;
using SG.Client.WCFHost.Database_ISGDatabase_H;
using SG.Client.WCFHost.ExtControl_ExtGridControl_H;

namespace SG.Client.WCFHost
{
    /// <summary>
    /// WCF服务客户端实例工厂
    /// </summary>
    public class WcfClientFactory
    {
        
        /// <summary>
        /// 创建公共服务的SOAP Client对象
        /// </summary>
        /// <returns></returns>
        public static SGBaseUser_HClient CreateSGBaseUser_HClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            WcfClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_SGBaseUser_H");//从配置文件(app.config)读取配置。            
            string endpoint = WcfClientConfig.GetWcfRemoteAddress("WSHttpBinding_SGBaseUser_H");
            return new SGBaseUser_HClient(BINDING, new EndpointAddress(endpoint)); 
            
        }

        public static CommonService_HClient CreateCommonService_HClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            WcfClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_CommonService_H");//从配置文件(app.config)读取配置。            
            string endpoint = WcfClientConfig.GetWcfRemoteAddress("WSHttpBinding_CommonService_H");
            return new CommonService_HClient(BINDING, new EndpointAddress(endpoint)); 
            
        }

        public static SGBaseDict_HClient CreateBaseDict_HClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            WcfClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_SGBaseDict_H");//从配置文件(app.config)读取配置。            
            string endpoint = WcfClientConfig.GetWcfRemoteAddress("WSHttpBinding_SGBaseDict_H");
            return new SGBaseDict_HClient(BINDING, new EndpointAddress(endpoint));

        }

        public static SGSetFunSQL_HClient CreateFunSQL_HClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            WcfClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_SGSetFunSQL_H");//从配置文件(app.config)读取配置。            
            string endpoint = WcfClientConfig.GetWcfRemoteAddress("WSHttpBinding_SGSetFunSQL_H");
            return new SGSetFunSQL_HClient(BINDING, new EndpointAddress(endpoint));

        }

        public static SGDatabase_HClient CreateSGDatabase_HClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            WcfClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_SGDatabase_H");//从配置文件(app.config)读取配置。            
            string endpoint = WcfClientConfig.GetWcfRemoteAddress("WSHttpBinding_SGDatabase_H");
            return new SGDatabase_HClient(BINDING, new EndpointAddress(endpoint));

        }

        public static ExtGridControl_HClient CreateExtGridControl_HClient()
        {
            WSHttpBinding BINDING = new WSHttpBinding();
            WcfClientConfig.ReadBindingConfig(BINDING, "WSHttpBinding_ExtGridControl_H");//从配置文件(app.config)读取配置。            
            string endpoint = WcfClientConfig.GetWcfRemoteAddress("WSHttpBinding_ExtGridControl_H");
            return new ExtGridControl_HClient(BINDING, new EndpointAddress(endpoint));
        }
    }
}
