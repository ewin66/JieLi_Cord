using System;
///*************************************************************************/
///*
///* 文件名    ：IBridge_DbLink.cs                                      
///* 程序说明  : 多数据库连接的接口类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces.Base
{
    /// <summary>
    /// 多数据库连接的接口类
    /// </summary>
    public interface IBridge_DbLink
    {
        /// <summary>
        /// 获取数据连接列表
        /// </summary>
        /// <returns></returns>
        DataTable GetDBLink();
        /// <summary>
        /// 获取数据连接列表
        /// </summary>
        /// <returns></returns>
        DataTable GetDBLinkByID(string key);
    }
}
