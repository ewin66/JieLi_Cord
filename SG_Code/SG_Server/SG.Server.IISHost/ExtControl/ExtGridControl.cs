using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using SG.Common;
using SG.Server.DataAccess.ExtControl;

namespace SG.Server.IISHost.ExtControl
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ExtGridControl : IExtGridControl_W
    {
        public byte[] GetReportFiled(byte[] loginTicket, string sReportName)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

                DataTable data = new dalExtGridControl(loginer).GetReportFiled(sReportName);
                return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        public byte[] GetRportData(byte[] loginTicket, string sReportName, string sFilter, bool bIsGetCount, int nPageIndex)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

                DataTable data = new dalExtGridControl(loginer).GetRportData(sReportName, sFilter, bIsGetCount, nPageIndex);
                return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        public byte[] GetDataTableBySQL(byte[] loginTicket, string sql)
        {
            try
            {
                Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

                DataTable data = new dalExtGridControl(loginer).GetDataTableBySQL(sql);
                return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}