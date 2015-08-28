///*************************************************************************/
///*
///* 文件名    ：IFuzzySearchSupportable.cs                                
///* 程序说明  : 支持模糊查询的接口,用于frmFuzzySearch窗体
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///*************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces
{
    /// <summary>
    /// 支持模糊查询的接口,用于frmFuzzySearch窗体
    /// </summary>
    public interface IFuzzySearchSupportable
    {
        string FuzzySearchName { get; }
        DataTable FuzzySearch(string content);
    }
}