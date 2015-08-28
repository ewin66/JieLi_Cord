using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Client.WCFHost;
using SG.Client.WCFHost.ExtControl_ExtGridControl_H;
using SG.Client.WCFIISHost;
using SG.Client.WCFIISHost.ExtControl_ExtGridControl_W;
using SG.Common;
using SG.Interfaces.ExtControl;
using SG.Server.DataAccess.ExtControl;

namespace SG.Client.Bridge.ExtControl
{
    /// <summary>
    /// 数据显示控件桥接
    /// </summary>
    public class ADODirect_ExtGridControl
    {
        private IBridge_ExtGridControl _DAL_Instance = null;//数据层实例

        public ADODirect_ExtGridControl()
        {
            _DAL_Instance = new dalExtGridControl(Loginer.CurrentUser);
        }

        public IBridge_ExtGridControl GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WcfHost_ExtGridControl : IBridge_ExtGridControl
    {
        public WcfHost_ExtGridControl()
        {

        }

        public DataTable GetReportFiled(string sReportName)
        {
            using (ExtGridControl_HClient client = WcfClientFactory.CreateExtGridControl_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetReportFiled(loginTicket, sReportName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }
        public DataTable GetRportData(string sReportName, string sFilter, bool bIsGetCount, int nPageIndex)
        {
            using (ExtGridControl_HClient client = WcfClientFactory.CreateExtGridControl_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetRportData(loginTicket, sReportName, sFilter, bIsGetCount, nPageIndex);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }
        public DataTable GetDataTableBySQL(string sql)
        {
            using (ExtGridControl_HClient client = WcfClientFactory.CreateExtGridControl_HClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDataTableBySQL(loginTicket, sql);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }
    }

    public class WcfIISHost_ExtGridControl : IBridge_ExtGridControl
    {
        public WcfIISHost_ExtGridControl()
        {

        }

        public System.Data.DataTable GetReportFiled(string sReportName)
        {
            using (ExtGridControl_WClient client = SoapClientFactory.CreateExtGridControl_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetReportFiled(loginTicket, sReportName);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }
        public DataTable GetRportData(string sReportName, string sFilter, bool bIsGetCount, int nPageIndex)
        {
            using (ExtGridControl_WClient client = SoapClientFactory.CreateExtGridControl_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetRportData(loginTicket, sReportName, sFilter, bIsGetCount, nPageIndex);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }
        public DataTable GetDataTableBySQL(string sql)
        {
            using (ExtGridControl_WClient client = SoapClientFactory.CreateExtGridControl_WClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetDataTableBySQL(loginTicket, sql);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }
    }
}
