///*************************************************************************/
///*
///* 文件名    ：bllNullObjectDataDict.cs    
///*
///* 程序说明  : 数据字典的空业务逻辑类．仅用于初始化实例．
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

namespace SG.Business
{
    /// <summary>
    /// 数据字典的空业务逻辑类．仅用于初始化实例．
    /// </summary>
    public class bllNullObjectDataDict : bllBaseDataDict
    {
        public override bool CheckNoExists(string keyValue)
        {
            return false;
        }

        public override void CreateDataBinder(System.Data.DataRow sourceRow)
        {
            //
        }

        public override bool Delete(string keyValue)
        {
            return true;
        }

        public override System.Data.DataTable GetDataByKey(string keyValue)
        {
            return new DataTable();
        }

        public override DataTable GetSummaryData(bool resetCurrent)
        {
            return new DataTable();
        }

        public override bool Update(SG.Common.UpdateType updateType)
        {
            return true;
        }
    }
}
