using SG.Client.Bridge;
using SG.Common;
using SG.Models.Database;
///*************************************************************************/
///*
///* 文件名    ：bllDataBase.cs                                     
///* 程序说明  : 基础资料逻辑层基类，继承bllBaseDataDict，增加了基础资料分类录入
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

namespace SG.Business
{
    public class bllDataBase:bllBaseDataDict
    {
        /// <summary>
        /// 分类字段名
        /// </summary>
        protected string _ClassKeyFieldName = string.Empty;
        /// <summary>
        /// 分类表名
        /// </summary>
        protected string _ClassSummaryTableName = string.Empty;
        /// <summary>
        /// 基础数据分类(在分类表格内显示)
        /// </summary>
        protected DataTable _ClassSummaryTable = null;
        /// <summary>
        /// 本次操作的数据(仅一条记录)，当前绑定输入框的数据
        /// </summary>
        public DataTable _ClassDataBinder = null;

        /// <summary>
        /// 主键字段名
        /// </summary>
        public string ClassKeyFieldName { get { return _ClassKeyFieldName; } }

        /// <summary>
        /// 主表名称
        /// </summary>
        public string ClassSummaryTableName { get { return _ClassSummaryTableName; } }

        /// <summary>
        /// 字典数据表
        /// </summary>
        public DataTable ClassSummaryTable { get { return _ClassSummaryTable; } }

        /// <summary>
        /// 当前数据绑定对象(DataTable)
        /// 该表只有一条记录，用于数据修改页面的数据绑定。
        /// </summary>
        public DataTable ClassDataBinder { get { return _ClassDataBinder; } }

        /// <summary>
        /// 因绑定基础数据分类输入控件的数据源为DataTable,所以提供SourceRow创建一个DataTable
        /// </summary>       
        /// <param name="sourceRow"></param>
        public void CreateDataBinderClass(DataRow sourceRow)
        {
            if (sourceRow == null)
            {
                _ClassDataBinder = _ClassSummaryTable.Clone();
                _ClassDataBinder.Rows.Add(_ClassDataBinder.NewRow());//插入一条空记录
            }
            else
            {
                _ClassDataBinder = sourceRow.Table.Clone();
                _ClassDataBinder.Rows.Add(sourceRow.ItemArray);
            }
        }

        /// <summary>
        /// 保存数据字典分类
        /// </summary>
        /// <param name="updateType">本次操作状态(新增/修改)</param>
        /// <returns></returns>
        public virtual bool UpdateClass(UpdateType updateType)
        {
            DataTable original = null;

            //提交缓存数据，确保输入框的数据已提交到绑定的数据源，将记录状态改变Unchanged.
            _ClassDataBinder.AcceptChanges();

            //再还原记录的状态
            if (updateType == UpdateType.Modify) _ClassDataBinder.Rows[0].SetModified();
            if (updateType == UpdateType.Add)
            {
                _ClassDataBinder.Rows[0].SetAdded();
                _ClassDataBinder.Rows[0][_ClassKeyFieldName] = bllComDataBaseTool.GetTableID(_ClassSummaryTableName, _ClassKeyFieldName);
            }

            //创建一个副本用于保存
            DataSet data = new DataSet();
            data.Tables.Add(_ClassDataBinder.Copy());
           
            //取当前记录的主键值
            string key = ConvertEx.ToString(_ClassDataBinder.Rows[0][_ClassKeyFieldName]);

            //如启用日志功能记录本次修改
            if (_WriteDataLog)
            {
                original = _DataDictBridge.GetDataByKey(key); //保存前的原始数据
                this.WriteLog(original, _ClassDataBinder);//保存修改日志
            }

            
            //调用数据层的方法提交数据
            return _DataDictBridge.Update(data);
        }

        /// <summary>
        /// 保存数据字典，返回由后台自动生成的主键。
        /// </summary>
        /// <param name="updateType">本次操作状态(新增/修改)</param>
        /// <returns>返回结果</returns>
        public virtual SaveResultEx UpdateClassEx(UpdateType updateType)
        {
            DataTable original = null;

            //提交缓存数据，确保输入框的数据已提交到绑定的数据源，将记录状态改变Unchanged.
            _ClassDataBinder.AcceptChanges();

            //再还原记录的状态
            if (updateType == UpdateType.Modify) _ClassDataBinder.Rows[0].SetModified();
            if (updateType == UpdateType.Add)
            {
                _ClassDataBinder.Rows[0].SetAdded();
                _ClassDataBinder.Rows[0][_ClassKeyFieldName] = bllComDataBaseTool.GetTableID(_ClassSummaryTableName, _ClassKeyFieldName);
            }

            //创建一个副本用于保存
            DataSet data = new DataSet();
            data.Tables.Add(_ClassDataBinder.Copy());

            //取当前记录的主键值
            string key = ConvertEx.ToString(_ClassDataBinder.Rows[0][_ClassKeyFieldName]);

            //如启用日志功能记录本次修改
            if (_WriteDataLog && updateType == UpdateType.Modify)
            {
                original = _DataDictBridge.GetDataByKey(key); //保存前的原始数据
                this.WriteLog(original, _ClassDataBinder);//保存修改日志
            }

            //调用数据层的方法提交数据
            return _DataDictBridge.UpdateEx(data);
        }
    }
}
