using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SG.Server.IISHost.ExtControl
{
    /// <summary>
    /// 数据显示控件WCF接口
    /// </summary>
    [ServiceContract(Name = "ExtGridControl_W",
           Namespace = "SG.Server.Host.ExtControl")]
    public interface IExtGridControl_W
    {
        /// <summary>
        /// 获取报表列信息
        /// </summary>
        /// <param name="loginTicket"></param>
        /// <param name="sReportName">报表名称</param>
        /// <returns></returns>
        [OperationContract]
        byte[] GetReportFiled(byte[] loginTicket, string sReportName);
        /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <param name="loginTicket"></param>
        /// <param name="sReportName">报表名称</param>
        /// <param name="sFilter">过滤条件</param>
        /// <param name="bIsGetCount">是否获取记录总数</param>
        /// <param name="nPageIndex">当前页数</param>
        /// <returns></returns>
        [OperationContract]
        byte[] GetRportData(byte[] loginTicket, string sReportName, string sFilter, bool bIsGetCount, int nPageIndex);
        /// <summary>
        /// 通过SQL获取DataTable
        /// </summary>
        /// <param name="loginTicket"></param>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        [OperationContract]
        byte[] GetDataTableBySQL(byte[] loginTicket, string sql);
    }
}
