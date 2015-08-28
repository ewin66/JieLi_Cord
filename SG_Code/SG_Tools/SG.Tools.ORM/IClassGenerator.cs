
///*************************************************************************/
///*
///* 文件名    ：IClassGenerator.cs    
///*
///* 程序说明  :  生成对象关系模型(ORM)
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///*************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SG.Tools.ORM
{
    /// <summary>
    ///生成对象关系模型(ORM)
    /// </summary>
    public interface IClassGenerator
    {

        /// <summary>
        /// 生成对象关系模型(ORM)
        /// </summary>
        /// <param name="spaceName">命名空间</param>
        /// <param name="className">类名</param>
        /// <param name="comment">类注释</param>
        /// <param name="tableName">对应的数据表名</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="isSummaryTable">是否主表</param>
        /// <param name="metal">表结构元数据</param>
        /// <returns>返回ORM源码</returns>
        string Generate(string spaceName, string className, string comment, string tableName,
           string primaryKey, bool isSummaryTable, DataTable metal);

    }
}
