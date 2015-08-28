///*************************************************************************/
///*
///* 文件名    ：SGParameter.cs                                      
///* 程序说明  : 全局参数，用于减少读取中间层，对数据库的访问
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Parameters
{
    /// <summary>
    /// 全局参数，用于减少读取中间层，对数据库的访问
    /// </summary>
    public class SGParameter
    {
        /// <summary>
        /// 帐套管理中的帐套表
        /// </summary>
        public static Hashtable hAccountConn = new Hashtable();

        public static string sAppPath = "";
       
        /// <summary>
        /// 帐套连接结构
        /// </summary>
        public struct sAccountConn
        {

            /// <summary>
            /// 服务器IP
            /// </summary>
            public string sServer;
            /// <summary>
            /// 数据库
            /// </summary>
            public string sDatabase;
            /// <summary>
            /// 用户名
            /// </summary>
            public string sUser;
            /// <summary>
            /// 密码
            /// </summary>
            public string sPwd;
            /// <summary>
            /// 
            /// </summary>
            public string sDbType;
        }
    }
}
