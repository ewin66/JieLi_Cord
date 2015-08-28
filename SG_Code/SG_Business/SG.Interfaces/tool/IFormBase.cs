///*************************************************************************/
///*
///* 文件名    ：IFormBase.cs                                      
///* 程序说明  : 基类窗体接口
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
    /// 基类窗体接口
    /// </summary>
    public interface IFormBase
    {
        /// <summary>
        /// 设置窗体皮肤
        /// </summary>
        void LoadSkin();

        /// <summary>
        /// 设置窗体皮肤
        /// </summary>
        /// <param name="skinName">名称</param>
        void SetSkin(string skinName);
    }
}
