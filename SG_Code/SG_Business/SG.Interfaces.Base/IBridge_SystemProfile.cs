///*************************************************************************/
///*
///* 文件名    ：IBridge_SystemProfile.cs                                
///* 程序说明  : 系统参数接口
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

namespace SG.Interfaces.Base
{
    public interface IBridge_SystemProfile
    {
        /// <summary>
        /// 获取所有参数
        /// </summary>
        /// <returns></returns>
        DataSet GetSystemProfile();

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetSystemProfileVal(string key);
    }
}
