using SG.Client.WCFHost;
using SG.Client.WCFHost.Database_ISGDatabase_H;
using SG.Client.WCFIISHost;
using SG.Client.WCFIISHost.Database_SGDatabase_W;
using SG.Common;
using SG.Interfaces.Database;
using SG.Server.DataAccess.Database;
///*************************************************************************/
///*
///* 文件名    ：ItemClass_Bridge.cs    
///*
///* 程序说明  : 基础资料名称桥接。
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
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
    public class ADODirect_ItemClass
    {
        private IBridge_ItemClass _DAL_Instance = null;//数据层实例

        public ADODirect_ItemClass()
        {
            _DAL_Instance = new dalItemClass(Loginer.CurrentUser);
        }

        public IBridge_ItemClass GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WcfHost_ItemClass : IBridge_ItemClass
    {
        public WcfHost_ItemClass()
        {

        }

             

        public System.Data.DataTable GetItemClass(string FNumber)
        {
            using (SGDatabase_HClient client = WcfClientFactory.CreateSGDatabase_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.GetItemClass(validationTicket, FNumber);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool DeleteItemClass(string FNumber)
        {
            using (SGDatabase_HClient client = WcfClientFactory.CreateSGDatabase_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.DeleteItemClass(validationTicket, FNumber);

            }
        }

        public bool IsExistsItemClass(string FNumber)
        {
            using (SGDatabase_HClient client = WcfClientFactory.CreateSGDatabase_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.IsExistsItemClass(validationTicket, FNumber);

            }
        }
    }

    public class WcfIISHost_ItemClass : IBridge_ItemClass
    {
        public WcfIISHost_ItemClass()
        {

        }

 
        public System.Data.DataTable GetItemClass(string FNumber)
        {
            using (SGDatabase_WClient client = SoapClientFactory.CreateSGDatabase_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.GetItemClass(validationTicket, FNumber);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        public bool DeleteItemClass(string FNumber)
        {
            using (SGDatabase_WClient client = SoapClientFactory.CreateSGDatabase_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.DeleteItemClass(validationTicket, FNumber);

            }
        }

        public bool IsExistsItemClass(string FNumber)
        {
            using (SGDatabase_WClient client = SoapClientFactory.CreateSGDatabase_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.IsExistsItemClass(validationTicket, FNumber);

            }
        }
    }
}