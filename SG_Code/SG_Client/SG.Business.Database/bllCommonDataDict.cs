///*************************************************************************/
///*
///* 文件名    ：bllCommonDataDict.cs    
///*
///* 程序说明  : 公共数据字典业务层
///*               用于管理只有Code,Name的字典数据，以Type分开。
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Client.Bridge;
using SG.Interfaces.Database;
using SG.Models.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Business.Database
{
    /// <summary>
    /// 公共字典数据业务逻辑层
    /// </summary>
    public class bllCommonDataDict : bllBaseDataDict
    {
        private IBridge_CommonDataDict _SelfBridge;
        public bllCommonDataDict()
        {

            _KeyFieldName = tb_t_CommonDataDict.__KeyName; //主键字段
            _SummaryTableName = tb_t_CommonDataDict.__TableName;//表名
            _WriteDataLog = false;//是否保存日志            
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_t_CommonDataDict));
            _SelfBridge = BridgeFactory.CreateCommonDataDictBridge();
            _SummaryTable = DataDictCache.Cache.CommonDataDict;
        }

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="dataType">字典类型</param>
        /// <param name="resetCurrent">重置当前处理的数据</param>
        /// <returns></returns>
        public DataTable SearchBy(string dataType, bool resetCurrent)
        {
            DataTable data = _SelfBridge.SearchBy(dataType);
            if (resetCurrent) _SummaryTable = data;
            this.SetDefault(_SummaryTable);
            return data;
        }

        /// <summary>
        /// 增加一个字典类型
        /// </summary>
        /// <param name="code">编号</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public bool AddCommonType(string sfid,string code, string name)
        {
            return _SelfBridge.AddCommonType(sfid,code, name);
        }

        /// <summary>
        /// 删除字典类型
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns></returns>
        public bool DeleteCommonType(string code)
        {
            return _SelfBridge.DeleteCommonType(code);
        }

        /// <summary>
        /// 检查字典类型是否存在
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public bool IsExistsCommonType(string id)
        {
            return _SelfBridge.IsExistsCommonType(id);
        }
    }
}
