﻿using SG.Client.Bridge;
using SG.Common;
using SG.Models;
using SG.Models.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Business.Base
{
    /// <summary>
    /// 公司资料管理业务逻辑层
    /// </summary>
    public class bllCompanyInfo : bllBaseDataDict
    {
        public bllCompanyInfo()
        {
            _KeyFieldName = tb_sys_CompanyInfo.FCompanyCode;
            _SummaryTableName = tb_sys_CompanyInfo.__TableName;
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_sys_CompanyInfo));
        }

        private bool _IsAdd = false;

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="updateType">操作类型</param>
        /// <returns></returns>
        public override bool Update(UpdateType updateType)
        {
            _SummaryTable.Rows[0][tb_sys_CompanyInfo.FCreationDate] = DateTime.Now;
            _SummaryTable.Rows[0][tb_sys_CompanyInfo.FLastUpdatedBy] = Loginer.CurrentUser.Account;

            _SummaryTable.AcceptChanges();

            if (_IsAdd)
                _SummaryTable.Rows[0].SetAdded();
            else
                _SummaryTable.Rows[0].SetModified();

            DataSet ds = new DataSet();
            ds.Tables.Add(_SummaryTable.Copy());
            bool ret = _DataDictBridge.Update(ds); //调用DAL层更新数据
            //bool ret = base.Update(updateType);
            if (ret)
            {              
                _SummaryTable.AcceptChanges();
                _IsAdd = false;
            }

            return ret;
        }

        /// <summary>
        /// 获取公司资料
        /// </summary>
        public override DataTable GetSummaryData(bool resetCurrent)
        {
            _DataDictBridge.TableName = _SummaryTableName;
            _SummaryTable = _DataDictBridge.GetSummaryData();

            if (_SummaryTable.Rows.Count == 0)
            {
                DataRow row = _SummaryTable.NewRow();
                row[tb_sys_CompanyInfo.FID] = "1";
                row[tb_sys_CompanyInfo.FCreatedBy] = Loginer.CurrentUser.Account;
                row[tb_sys_CompanyInfo.FCreationDate] = DateTime.Now;
                _SummaryTable.Rows.Add(row);
                _IsAdd = true;
            }
            else _IsAdd = false;

            return _SummaryTable;
        }
    }
}