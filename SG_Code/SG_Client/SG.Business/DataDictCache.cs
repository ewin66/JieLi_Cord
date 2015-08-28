using SG.Client.Bridge;
using SG.Interfaces;
using SG.Interfaces.Base;
using SG.Models;
using SG.Models.Base;
using SG.Models.Database;
using SG.Models.Set;
///*************************************************************************/
///*
///* 文件名    ：DataDictCache.cs      
///
///* 程序说明  : 数据字典缓存数据
///               
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
    /*
     数据字典缓存数据
     */
    public class DataDictCache
    {

        private DataDictCache() { } /*私有构造器,不允许外部创建实例*/

        #region 缓存数据唯一实例

        private static DataDictCache _Cache = null;

        /// <summary>
        /// 缓存数据唯一实例
        /// </summary>
        public static DataDictCache Cache
        {
            get
            {
                if (_Cache == null)
                {
                    _Cache = new DataDictCache();
                    _Cache.DownloadBaseCacheData();//下载基本数据                    
                }
                return _Cache;
            }
        }
        #endregion

        #region 外部使用的静态方法

        /// <summary>
        /// 刷新缓存数据
        /// </summary>
        public static void RefreshCache()
        {
            DataDictCache.Cache.DownloadBaseCacheData();
        }

        /// <summary>
        /// 刷新单个数据字典
        /// </summary>
        /// <param name="tableName">字典表名</param>
        public static void RefreshCache(string tableName)
        {
            DataTable cache = DataDictCache.Cache.GetCacheTableData(tableName);

            if (cache != null) //有客户窗体引用缓存数据时才更新
            {
                IBridge_DataDict bridge = BridgeFactory.CreateDataDictBridge(tableName, "");
                DataTable data = bridge.GetDataDictByTableName(tableName);
                cache.Rows.Clear();
                foreach (DataRow row in data.Rows) cache.ImportRow(row);
                cache.AcceptChanges();
            }
        }

        #endregion

        #region 2.数据表缓存数据. 局域变易及属性定义

        private DataSet _AllDataDicts = null;

        private DataTable _BusinessTables = null;
        public DataTable BusinessTables { get { return _BusinessTables; } }

        private DataTable _StockType = null;
        public DataTable StockType { get { return _StockType; } }

        private DataTable _Currency = null;
        public DataTable Currency { get { return _Currency; } }

        private DataTable _PayType = null;
        public DataTable PayType { get { return _PayType; } }

        private DataTable _User = null; //用户表
        public DataTable User { get { return _User; } }

        private DataTable _Person = null; //营销员
        public DataTable Person { get { return _Person; } }

        private DataTable _Storage = null; //仓库
        public DataTable Storage { get { return _Storage; } }

        private DataTable _Unit = null;
        public DataTable Unit { get { return _Unit; } }

        private DataTable _DepartmentData = null;
        public DataTable DepartmentData { get { return _DepartmentData; } }

        private DataTable _CustomerAttributes = null;
        public DataTable CustomerAttributes { get { return _CustomerAttributes; } }

        private DataTable _Bank = null;
        public DataTable Bank { get { return _Bank; } }

        private DataTable _CommonDataDictType = null;
        public DataTable CommonDataDictType { get { return _CommonDataDictType; } }

        private DataTable _CommonDataDict = null;
        public DataTable CommonDataDict { get { return _CommonDataDict; } }

        private DataTable _Location = null;
        public DataTable Location { get { return _Location; } }

        private DataTable _DbLink = null;
        /// <summary>
        /// 数据库连接数据字典
        /// </summary>
        public DataTable DbLink { get { return _DbLink; } }

        private DataTable _ItemClass = null;
        /// <summary>
        /// 基础资料类型
        /// </summary>
        public DataTable ItemClass { get { return _ItemClass; } }

        private DataTable _ItemPropDesc = null;
        /// <summary>
        /// 基础资料描述
        /// </summary>
        public DataTable ItemPropDesc { get { return _ItemPropDesc; } }
        /// <summary>
        /// 功能表
        /// </summary>
        private DataTable _Function = null;
        /// <summary>
        /// 功能
        /// </summary>
        public DataTable Function { get { return _Function; } }
        /// <summary>
        /// 按钮表
        /// </summary>
        private DataTable _FunBar=null;
        /// <summary>
        /// 按钮
        /// </summary>
        public DataTable FunBar { get { return _FunBar; } }

        #endregion


        public void DownloadBaseCacheData()
        {
            IBridge_DataDict bridge = BridgeFactory.CreateDataDictBridge("");

            //下载小字典表数据
            _AllDataDicts = bridge.DownloadDicts();

            if (_AllDataDicts == null) return;
            //调用数据表名
            _AllDataDicts.Tables[0].TableName = tb_sys_User.__TableName;
            _AllDataDicts.Tables[1].TableName = tb_sys_Department.__TableName;
            _AllDataDicts.Tables[2].TableName = tb_sys_DbLink.__TableName;
            _AllDataDicts.Tables[3].TableName = tb_t_CommDataDictType.__TableName;
            _AllDataDicts.Tables[4].TableName = tb_t_CommonDataDict.__TableName;
            _AllDataDicts.Tables[5].TableName = tb_t_ItemClass.__TableName;
            _AllDataDicts.Tables[6].TableName = tb_t_ItemPropDesc.__TableName;
            _AllDataDicts.Tables[7].TableName = tb_sys_Function.__TableName; ;
            _AllDataDicts.Tables[8].TableName = tb_sys_Fun_MenuBar.__TableName;
            //_AllDataDicts.Tables[9].TableName = tb_Location.__TableName;
            //_AllDataDicts.Tables[10].TableName = "#Dept"; //tb_CommDataDictType表的部门类别的记录

            //跟据存储过程返回数据表的顺序取
            _User = _AllDataDicts.Tables[0];
            _DepartmentData = _AllDataDicts.Tables[1];
            _DbLink = _AllDataDicts.Tables[2];
            _CommonDataDictType = _AllDataDicts.Tables[3];
            _CommonDataDict = _AllDataDicts.Tables[4];
            _CommonDataDict.TableName = tb_t_CommonDataDict.__TableName;
            _ItemClass = _AllDataDicts.Tables[5];
            _ItemPropDesc = _AllDataDicts.Tables[6];
            _Function = _AllDataDicts.Tables[7];
            _FunBar = _AllDataDicts.Tables[8];
            //_CustomerAttributes = _AllDataDicts.Tables[4];
            //_Bank = _AllDataDicts.Tables[5];
            //_CommonDataDictType = _AllDataDicts.Tables[6];
            //_PayType = _AllDataDicts.Tables[7];
            //_Currency = _AllDataDicts.Tables[8];
            //_Location = _AllDataDicts.Tables[9];
            //_DepartmentData = _AllDataDicts.Tables[10];

           

        }

        /// <summary>
        /// 跟据表名取数据表实例
        /// </summary>
        /// <param name="tableName">字典表名</param>
        /// <returns></returns>
        private DataTable GetCacheTableData(string tableName)
        {
            foreach (DataTable dt in _AllDataDicts.Tables)
            {
                if (dt.TableName.ToUpper() == tableName.ToUpper()) return dt;
            }

            DataTable cache = null;
            //if (tableName == tb_CommDataDictType.__TableName) cache = _CommonDataDictType;            
            return cache;
        }

        /// <summary>
        ///删除字典数据某一行数据
        /// </summary>
        /// <param name="tableName">字典表名</param>
        /// <param name="keyField">主键</param>
        /// <param name="key">主键值</param>
        public void DeleteCacheRow(string tableName, string keyField, string key)
        {
            DataTable cach = this.GetCacheTableData(tableName);
            if (cach != null)
            {
                DataRow[] rows = cach.Select(keyField + "='" + key + "'");
                if (rows.Length > 0)
                    cach.Rows.Remove(rows[0]);
                cach.AcceptChanges();
            }
        }
    }
}
