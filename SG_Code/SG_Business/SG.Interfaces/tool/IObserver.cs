///*************************************************************************/
///*
///* 文件名    ：IObserver.cs                                
///* 程序说明  : 观察者接口
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
    /// 观察者接口
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// 发送通知
        /// </summary>
        void Notify();
    }

}
