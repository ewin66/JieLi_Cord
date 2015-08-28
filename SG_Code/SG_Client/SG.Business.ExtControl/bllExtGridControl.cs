using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Client.Bridge;
using SG.Interfaces.ExtControl;

namespace SG.Business.ExtControl
{
    public class bllExtGridControl
    {
        private IBridge_ExtGridControl _ExtGridControlBridge;

        public bllExtGridControl()
        {
            _ExtGridControlBridge = BridgeFactory.CreateExtGridControlBridge();
        }

        public DataTable GetReportFiled(string sReportName)
        {
            return _ExtGridControlBridge.GetReportFiled(sReportName);
        }

        public DataTable GetRportData(string sReportName, string sFilter, bool bIsGetCount = false, int nPageIndex = 1)
        {
            return _ExtGridControlBridge.GetRportData(sReportName, sFilter, bIsGetCount, nPageIndex);
        }
        public DataTable GetDataTableBySQL(string sql)
        {
            return _ExtGridControlBridge.GetDataTableBySQL(sql);
        }
    }
}
