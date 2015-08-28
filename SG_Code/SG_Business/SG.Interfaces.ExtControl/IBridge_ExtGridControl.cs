///*************************************************************************/
///*
///* 文件名    ：IExtGridControl.cs                                
///* 程序说明  : 数据显示控件
///* 原创作者  ：东莞思谷 XiaoHe Yan
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces.ExtControl
{
    /// <summary>
    /// 数据显示控件
    /// </summary>
    public interface IBridge_ExtGridControl
    {
        /// <summary>
        /// 获取报表列信息
        /// </summary>
        /// <param name="sReportName">报表名称</param>
        /// <returns></returns>
        DataTable GetReportFiled(string sReportName);
        /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <param name="sReportName">报表名称</param>
        /// <param name="sFilter">过滤条件</param>
        /// <param name="bIsGetCount">是否获取记录总数</param>
        /// <param name="nPageIndex">当前页数</param>
        /// <returns></returns>
        DataTable GetRportData(string sReportName, string sFilter, bool bIsGetCount, int nPageIndex);
        /// <summary>
        /// 通过SQL获取DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        DataTable GetDataTableBySQL(string sql);
    }
}
