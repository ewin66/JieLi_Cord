using SG.Client.Bridge;
using SG.Client.Bridge.Base;
using SG.Common;
using SG.Interfaces.Base;
using SG.Models.Base;
///*************************************************************************/
///*
///* 文件名    ：bllSystemProfile.cs        
///
///* 程序说明  : 系统参数业务逻辑层
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

namespace SG.Business.Base
{
    /// <summary>
    /// 系统参数业务层
    /// </summary>
    public class bllSystemProfile : bllBaseDataDict
    {
        private IBridge_SystemProfile _MyBridge;
        private bool _IsAdd = false;
        public DataTable _SysClass;
        public bllSystemProfile()
        {
            _KeyFieldName = tb_sys_SystemProfile.__KeyName; //主键字段
            _SummaryTableName = tb_sys_SystemProfile.__TableName;//表名
            _WriteDataLog = false;//是否保存日志                    
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_sys_SystemProfile));
            _MyBridge = this.CreateBridge();
        }

        /// <summary>
        /// 创建实现了桥接接口的通信通道
        /// </summary>
        /// <returns></returns>
        private IBridge_SystemProfile CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_SystemProfile().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WcfIISHost_SystemProfile();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WcfHost_SystemProfile();

            return null;
        }

        /// <summary>
        /// 获取所有参数
        /// </summary>
        /// <returns></returns>
        public DataTable GetSystemProfile()
        {
            DataSet ds = _MyBridge.GetSystemProfile();
            _SummaryTable = ds.Tables[1];
            _SysClass = ds.Tables[0];
            
            return _SummaryTable;
        }

        /// <summary>
        /// 通过行更新datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dr"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public void UpdateByRow(DataRow dr)
        {
            _SummaryTable=DataConverter.UpdateTableRowByRow(_SummaryTable, dr, tb_sys_SystemProfile.__KeyName);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="updateType">操作类型</param>
        /// <returns></returns>
        public bool Update(DataTable sSavatb, UpdateType updateType)
        {
            sSavatb.AcceptChanges();
            for (int i = 0; i < sSavatb.Rows.Count; i++)
                if (updateType == UpdateType.Modify)
                    sSavatb.Rows[i].SetModified();

            DataSet ds = new DataSet();
            ds.Tables.Add(sSavatb.Copy());
            bool ret = _DataDictBridge.Update(ds); //调用DAL层更新数据
            //bool ret = base.Update(updateType);
            if (ret)
            {
                //_SummaryTable.AcceptChanges();
                _IsAdd = false;
            }

            return ret;
        }
    }
}
