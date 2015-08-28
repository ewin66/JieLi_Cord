///*************************************************************************/
///*
///* 文件名    ：ILogSupportable.cs   
///
///* 程序说明  : 支持写入日志的接口
///* 
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces
{
    /// <summary>
    /// 支持写入日志的接口
    /// </summary>
    public interface ILogSupportable
    {
        /// <summary>
        /// 写入单表日志
        /// </summary>        
        void WriteLog(DataTable original, DataTable changes);

        /// <summary>
        /// 写入多个表的日志,TableIndex=0:主表,1..n为明细表
        /// </summary>
        /// <param name="changes"></param>
        void WriteLog(DataSet original, DataSet changes);
    }
}
