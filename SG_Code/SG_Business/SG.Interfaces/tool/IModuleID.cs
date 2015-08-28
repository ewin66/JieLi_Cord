///*************************************************************************/
///*
///* 文件名    ：ModuleID.cs                                
///* 程序说明  : 模块编号和名称定义
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
    /// 模块编号.
    /// </summary>
    public enum ModuleID
    {
        None = 0,
        DataBase = 1,
        PurchaseModule = 2,
        SalesModule = 3,
        InventoryModule = 4,
        ProductionModule = 5,
        AccountModule = 6,
        SystemManage = 7,
        ProductionManage = 8, //用于排序
        SetModule = 9 //表格设置
    }

    /// <summary>
    /// 模块名称.
    /// </summary>
    public class ModuleNames
    {
        public const string DataBase = "基础数据";//
        public const string PurchaseModule = "采购模块";
        public const string SalesModule = "销售模块";
        public const string InventoryModule = "库存模块";
        public const string ProductionModule = "生产管理";
        public const string AccountModule = "财务管理";
        public const string SystemManage = "系统管理";
        public const string ProductionManage = "生产管理";
        public const string SetModule = "表格设置";
    }
}
