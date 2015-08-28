///*************************************************************************/
///*
///* 文件名    ：CommonDataDict_Bridge.cs    
///*
///* 程序说明  : 公共数据字典桥接
///*               用于管理只有Code,Name的字典数据，以Type分开。
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Client.WCFHost;
using SG.Client.WCFHost.Base_CommonService_H;
using SG.Client.WCFHost.Database_ISGDatabase_H;
using SG.Client.WCFIISHost;
using SG.Client.WCFIISHost.Database_SGDatabase_W;
using SG.Common;
using SG.Interfaces.Database;
using SG.Server.DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Client.Bridge.Database
{
    /// <summary>
    /// 配置数据连接桥接
    /// </summary>
    public class ADODirect_CommonDataDict
    {
        private IBridge_CommonDataDict _DAL_Instance = null;//数据层实例

        public ADODirect_CommonDataDict()
        {
            _DAL_Instance = new dalCommonDataDict(Loginer.CurrentUser);
        }

        public IBridge_CommonDataDict GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WcfHost_CommonDataDict : IBridge_CommonDataDict
    {
        public WcfHost_CommonDataDict()
        {

        }

       
        public System.Data.DataTable SearchBy(string dataType)
        {
            using(SGDatabase_HClient client=WcfClientFactory.CreateSGDatabase_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.SearchCommonType(validationTicket, dataType);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool AddCommonType(string fid, string code, string name)
        {
            using (SGDatabase_HClient client = WcfClientFactory.CreateSGDatabase_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.AddCommonType(validationTicket, fid,code,name);
                
            }
        }

        public bool DeleteCommonType(string code)
        {
            using (SGDatabase_HClient client = WcfClientFactory.CreateSGDatabase_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.DeleteCommonType(validationTicket,  code);

            }
        }

        public bool IsExistsCommonType(string code)
        {
            using (SGDatabase_HClient client = WcfClientFactory.CreateSGDatabase_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.IsExistsCommonType(validationTicket, code);

            }
        }
    }

    public class WcfIISHost_CommonDataDict : IBridge_CommonDataDict
    {
        public WcfIISHost_CommonDataDict()
        {

        }
        
        public System.Data.DataTable SearchBy(string dataType)
        {
            using (SGDatabase_WClient client = SoapClientFactory.CreateSGDatabase_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.SearchCommonType(validationTicket, dataType);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool AddCommonType(string fid, string code, string name)
        {
            using (SGDatabase_WClient client = SoapClientFactory.CreateSGDatabase_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.AddCommonType(validationTicket, fid, code, name);

            }
        }

        public bool DeleteCommonType(string code)
        {
            using (SGDatabase_WClient client = SoapClientFactory.CreateSGDatabase_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.DeleteCommonType(validationTicket, code);

            }
        }

        public bool IsExistsCommonType(string code)
        {
            using (SGDatabase_WClient client = SoapClientFactory.CreateSGDatabase_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.IsExistsCommonType(validationTicket, code);

            }
        }
    }
}