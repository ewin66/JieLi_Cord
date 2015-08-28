///*************************************************************************/
///*
///* 文件名    ：IMsg.cs                                
///* 程序说明  : 消息显示接口
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces
{
    /// <summary>
    /// 消息显示接口
    /// </summary>
    public interface IMsg
    {
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="msg"></param>
        void UpdateMessage(string msg);
    }
}