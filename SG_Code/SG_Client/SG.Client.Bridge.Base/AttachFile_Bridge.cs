///*************************************************************************/
///*
///* 文件名    ：AttachFile_Bridge.cs                                      
///* 程序说明  : 附件桥接
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Client.WCFHost;
using SG.Client.WCFHost.Base_CommonService_H;
using SG.Client.WCFIISHost;
using SG.Client.WCFIISHost.Base_CommonService_W;
using SG.Common;
using SG.Interfaces.Base;
using SG.Server.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Client.Bridge.Base
{
    public class ADODirect_AttachFile
    {
        private IBridge_AttachFile _DAL_Instance = null;//数据层实例

        public ADODirect_AttachFile()
        {
            _DAL_Instance = new dalAttachFile(Loginer.CurrentUser);
        }

        public IBridge_AttachFile GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WcfIISHost_AttachFile : IBridge_AttachFile
    {
        public WcfIISHost_AttachFile()
        {
        }

        #region IBridge_AttachFile Members

        public System.Data.DataTable GetAttachFileData(string docID)
        {
            using (CommonService_WClient client = SoapClientFactory.CreateCommonService_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetAttachedFiles(loginTicket, docID);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        #endregion

      
    }

    public class WcfHost_AttachFile : IBridge_AttachFile
    {
        public WcfHost_AttachFile()
        {
        }

        #region IBridge_AttachFile Members

        public System.Data.DataTable GetAttachFileData(string docID)
        {
            using (CommonService_HClient client = WcfClientFactory.CreateCommonService_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetAttachedFiles(loginTicket, docID);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        #endregion
    }
}
