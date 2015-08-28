///*************************************************************************/
///*
///* 文件名    ：IBridge_CommonDataDict.cs                                      
///* 程序说明  : 数据字典的接口
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
    /// 共同数据字典表的数据层桥接接口
    /// </summary>
    public interface IBridge_CommonDataDict
    {
        DataTable SearchBy(string dataType);
        bool AddCommonType(string fid, string code, string name);
        bool DeleteCommonType(string code);
        bool IsExistsCommonType(string code);
    }
}
