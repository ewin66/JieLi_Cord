///*************************************************************************/
///*
///* 文件名    ：IBridge_ItemClass.cs                                      
///* 程序说明  : 基础资料类型接口
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

namespace SG.Interfaces.Database
{
    /// <summary>
    /// 基础资料类型接口
    /// </summary>
    public interface IBridge_ItemClass
    {
        /// <summary>
        /// 获取ItemClass
        /// </summary>
        /// <param name="FNumber"></param>
        /// <returns></returns>
        DataTable GetItemClass(string FNumber);

        bool DeleteItemClass(string FNumber);

        bool IsExistsItemClass(string FNumber);
    }
}
