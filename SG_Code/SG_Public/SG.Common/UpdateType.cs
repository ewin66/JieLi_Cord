///*************************************************************************/
///*
///* 文件名    ：UpdateType.cs                                      
///* 程序说明  : 数据窗体的操作类型
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
    /// 数据窗体的操作类型
    /// </summary>
    public enum UpdateType
    {
        None,

        /// <summary>
        /// 新增状态
        /// </summary>
        Add,

        /// <summary>
        /// 修改状态
        /// </summary>
        Modify
    }
}
