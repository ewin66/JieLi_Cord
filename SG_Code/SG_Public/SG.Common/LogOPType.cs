///*************************************************************************/
///*
///* 文件名    ：LogOPType.cs                                
///* 程序说明  : 系统日志功能跟踪的操作数据类型
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Common
{
    /// <summary>
    /// 系统日志功能跟踪的操作数据类型
    /// </summary>
    public enum LogOPType
    {
        None = 0,

        /// <summary>
        /// 跟踪修改的记录
        /// </summary>
        LogEdit = 1,

        /// <summary>
        /// 跟踪删除的记录
        /// </summary>
        LogDelete = 2,

        /// <summary>
        /// 跟踪新增的记录
        /// </summary>
        LogAppend = 3
    }

}
