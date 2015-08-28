///*************************************************************************/
///*
///* 文件名    ：CustomException.cs                                      
///* 程序说明  : 用户自定义异常
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
    /// 用户自定义异常
    /// </summary>
    public class CustomException : Exception
    {
        public CustomException(string message)
            : base(message)
        { }
    }
}
