///*************************************************************************/
///*
///* 文件名    ：IWriteSQLConfigValue.cs                                      
///* 程序说明  : 用于扩展Tag标记的自定义对象
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Tools.DataOperate.SQLConfig
{
    /// <summary>
    /// 存储SQL连接配置的接口
    /// </summary>
    public interface IWriteSQLConfigValue
    {
        /// <summary>
        /// 写入SQL的连接配置信息
        /// </summary>
        void Write();

        /// <summary>
        /// 读取SQL的连接配置信息
        /// </summary>
        void Read();

        /// <summary>
        /// SQL Server Name/IP
        /// </summary>
        string ServerName { get; set; }

        /// <summary>
        /// 连接的数据库
        /// </summary>
        string InitialCatalog { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        string DbType { get; set; }

        /// <summary>
        /// 生成连接字符串
        /// </summary>
        /// <returns></returns>
        string BuildConnectionString();
    }

}


