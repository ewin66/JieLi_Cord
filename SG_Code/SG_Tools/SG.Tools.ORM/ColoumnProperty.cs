
///*************************************************************************/
///*
///* 文件名    ：ColoumnProperty.cs                              
///* 程序说明  : 字段属性，一个简单的实体类。
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///*************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace SG.Tools.ORM
{
    /// <summary>
    /// 字段属性
    /// </summary>
    public class ColoumnProperty
    {
        private string _columnName;
        private bool _isPrimaryKey;

        /// <summary>
        /// 字段名
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }

        public ColoumnProperty(string columnName, bool isPrimaryKey)
        {
            _columnName = columnName;
            _isPrimaryKey = isPrimaryKey;
        }
    }

}
