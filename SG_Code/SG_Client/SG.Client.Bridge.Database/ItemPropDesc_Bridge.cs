using SG.Client.WCFHost;
using SG.Client.WCFHost.Database_ISGDatabase_H;
using SG.Client.WCFIISHost;
using SG.Client.WCFIISHost.Database_SGDatabase_W;
using SG.Common;
using SG.Interfaces.Database;
using SG.Server.DataAccess.Database;
///*************************************************************************/
///*
///* 文件名    ：ItemPropDesc_Bridge.cs    
///*
///* 程序说明  : 基础资料描述桥接。
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
    public class ADODirect_ItemPropDesc
    {
        private IBridge_ItemPropDesc _DAL_Instance = null;//数据层实例

        public ADODirect_ItemPropDesc()
        {
            _DAL_Instance = new dalItemPropDesc(Loginer.CurrentUser);
        }

        public IBridge_ItemPropDesc GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WcfHost_ItemPropDesc : IBridge_ItemPropDesc
    {
        public WcfHost_ItemPropDesc()
        {

        }

        
        public System.Data.DataSet GetItemDesc(string FNumber)
        {
            using (SGDatabase_HClient client = WcfClientFactory.CreateSGDatabase_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.GetItemDesc(validationTicket, FNumber);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public bool DeleteItemDesc(string fid)
        {
            using (SGDatabase_HClient client = WcfClientFactory.CreateSGDatabase_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.DeleteItemDesc(validationTicket, fid);

            }
        }

        public bool SetOrder(string Upfid, string Downfid)
        {
            using (SGDatabase_HClient client = WcfClientFactory.CreateSGDatabase_HClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.SetOrder(validationTicket,Upfid,Downfid);

            }
        }
    }

    public class WcfIISHost_ItemPropDesc : IBridge_ItemPropDesc
    {
        public WcfIISHost_ItemPropDesc()
        {

        }


        public System.Data.DataSet GetItemDesc(string FNumber)
        {
            using (SGDatabase_WClient client = SoapClientFactory.CreateSGDatabase_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                byte[] receivedData = client.GetItemDesc(validationTicket, FNumber);
                return ZipTools.DecompressionDataSet(receivedData);
            }
        }

        public bool DeleteItemDesc(string fid)
        {
            using (SGDatabase_WClient client = SoapClientFactory.CreateSGDatabase_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.DeleteItemDesc(validationTicket, fid);

            }
        }

        public bool SetOrder(string Upfid, string Downfid)
        {
            using (SGDatabase_WClient client = SoapClientFactory.CreateSGDatabase_WClient())
            {
                byte[] validationTicket = WebServiceSecurity.GetLoginTicket();
                return client.SetOrder(validationTicket, Upfid,Downfid);

            }
        }
    }
}