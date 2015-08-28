using SG.Client.Bridge;
using SG.Common;
using SG.Interfaces.Database;
using SG.Models.Database;
///*************************************************************************/
///*
///* 文件名    ：bllDatabaseSet.cs    
///*
///* 程序说明  : 基础数据设置。
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

namespace SG.Business.Database
{
    public class bllDatabaseSet : bllDataBase
    {
        private IBridge_ItemClass _ItemClassBridge;
        private IBridge_ItemPropDesc _ItemPropDescBridge;

        public bllDatabaseSet()
        {
            _KeyFieldName = tb_t_ItemPropDesc.__KeyName; //主键字段
            _SummaryTableName = tb_t_ItemPropDesc.__TableName;//表名
            _ClassKeyFieldName = tb_t_ItemClass.__KeyName;//分类字段主键
            _ClassSummaryTableName = tb_t_ItemClass.__TableName;//表名
            _WriteDataLog = true;//是否保存日志            
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_t_ItemClass));
            _ItemClassBridge = BridgeFactory.CreateItemClassBridge();
            _ItemPropDescBridge = BridgeFactory.CreateItemPropDescBridge();
            
            
        }

        public DataTable GetItemClass()
        {
            DataDictCache.RefreshCache();
            _ClassSummaryTable = DataDictCache.Cache.ItemClass;

            SetDefault(_ClassSummaryTable);
            return _ClassSummaryTable;
        }

        public DataTable GetItemPropDesc()
        {
            _SummaryTable = DataDictCache.Cache.ItemPropDesc;
            return _SummaryTable;
        }

        protected override void SetDefault(DataTable data)
        {
            if(data.TableName==tb_t_ItemClass.__TableName)
            {
                data.Columns[tb_t_ItemClass.FUserID].DefaultValue = Loginer.CurrentUser.Fid;
                data.Columns[tb_t_ItemClass.FCreateDate].DefaultValue = DateTime.Now;
            }
        }
       
    }
}
