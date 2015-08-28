
///*************************************************************************/
///*
///* 文件名    ：frmCommonDataDict.cs    
///*
///* 程序说明  : 公共数据字典窗体
///*               用于管理只有Code,Name的字典数据，以Type分开。
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using SG.Client.Library;
using SG.Business.Database;
using SG.Business;
using SG.Common;
using SG.Models.Database;
using SG.Interfaces;


namespace SG.Client.Database
{
    /// <summary>
    /// 公共数据字典窗体
    /// </summary>
    public partial class frmCommonDataDict : frmBaseDataForm
    {
        bllCommonDataDict _BLL;
        ISummaryView _ClassView;
        public frmCommonDataDict()
        {
            InitializeComponent();
            gridProfileClass.CustomDrawRowIndicator += gridProfileClass_CustomDrawRowIndicator;
            gvSummary.CustomDrawRowIndicator += gvSummary_CustomDrawRowIndicator;
            gvSummary.IndicatorWidth = 40;
            gridProfileClass.IndicatorWidth = 40;
            gridProfileClass.RowClick += gridProfileClass_RowClick;
        }

        void gridProfileClass_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = _ClassView.GetDataRow(_ClassView.FocusedRowHandle);            
            txtDataType.EditValue = dr[tb_t_CommDataDictType.__KeyName];
            BindGvprofile(dr[tb_t_CommDataDictType.__KeyName].ToString());
        }

        /// <summary>
        /// 绑定分类参数
        /// </summary>
        /// <param name="sfilter"></param>
        private void BindGvprofile(string sfilter)
        {
            string strF = tb_t_CommonDataDict.FDataTypeID + "='" + sfilter + "'";
            gvSummary.ActiveFilterString = strF;
            //gcprofile.DataSource = _BLL.SummaryTable.Select(strF);
        }
        void gvSummary_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        void gridProfileClass_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void frmCommonDataDict_Load(object sender, EventArgs e)
        {
            this.InitializeForm();//自定义初始化操作            
        }


        public override void DoAdd(IButtonInfo sender)
        {
            try
            {
                _BLL.CreateDataBinder(null);
                DoBindingSummaryEditor(_BLL.DataBinder); //绑定数据输入控件
                base.DoAdd(sender);
                ShowDetailPage(true);               
            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        public string GetFunctionID()
        {
            return this._FunctionID;
        }

        protected override void InitializeForm()
        {
            _SummaryView = new DevGridView(gvSummary);//每个业务窗体必需给这个变量赋值.
            _ClassView = new DevGridView(gridProfileClass);
            _ActiveEditor = txtNativeName;
            //_KeyEditor = txtDataCode;
            _DetailGroupControl = gcDetailEditor;
            _BLL = new bllCommonDataDict(); //业务逻辑实例
            gvSummary.DoubleClick += new EventHandler(OnGridViewDoubleClick); //主表DoubleClict
            //绑定相关缓存数据
            //DataBinder.BindingLookupEditDataSource(txt_CommonType, DataDictCache.Cache.CommonDataDictType, "TypeName", "DataType");
            DataBinder.BindingLookupEditDataSource(txtDataType, DataDictCache.Cache.CommonDataDictType, "FTYPENAME", "FID");

            //DataBinder.BindingLookupEditDataSource(colDataType.ColumnEdit as RepositoryItemLookUpEdit,
            //    DataDictCache.Cache.CommonDataDictType, "FTYPENAME", "FID");
           
            gcSummary.DataSource = DataDictCache.Cache.CommonDataDict;
            gcProfileClass.DataSource = DataDictCache.Cache.CommonDataDictType;
            if (_FormMenuName != string.Empty)
                this._FunctionID = bllComDataBaseTool.GetFunctionID(this._FormMenuName);
            this.Tag = this._FunctionID;
            base.InitializeForm();
        }

        

        private void btnQuery_Click(object sender, EventArgs e)
        {//搜索数据                        
            ((bllCommonDataDict)_BLL).SearchBy(txt_CommonType.EditValue.ToString(), true);
            this.DoBindingSummaryGrid(_BLL.SummaryTable); //绑定主表的Grid
            this.ShowSummaryPage(true); //显示Summary页面. 
        }
        /// <summary>
        /// 用户在Summary页选择一条记录. 显示当前记录的详细资料
        /// </summary>
        /// <param name="sender"></param>
        public override void DoViewContent(IButtonInfo sender)
        {
            AssertFocusedRow(); //检查有无记录.                
            _BLL.CreateDataBinder(_SummaryView.GetDataRow(_SummaryView.FocusedRowHandle));
            base.DoViewContent(sender);
            DoBindingSummaryEditor(_BLL.DataBinder); //绑定数据输入控件
            ShowDetailPage(false); //用户点击ViewContent按钮可以显示Summary页                
        }

        public override void DoEdit(IButtonInfo sender)
        {
            AssertFocusedRow();
            base.DoEdit(sender);
            DoViewContent(sender);
            ShowDetailPage(true);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="sender"></param>
        public override void DoDelete(IButtonInfo sender)
        {
            AssertFocusedRow();//检查是否选择一条记录
            if (!Msg.AskQuestion("真的要删除?")) return;

            //调用业务逻辑类删除记录
            DataRow summary = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
            bool b = _BLL.Delete(summary[_BLL.KeyFieldName].ToString());
            AssertEqual(b, true, "删除记录时发生错误!");
            if(b)
            {
                bllComDataBaseTool.WriteLogOp(_FunctionID, "0", "删除数据字典" + summary[tb_t_CommonDataDict.FNativeName].ToString() + "(" + summary[tb_t_CommonDataDict.FDataCode].ToString() + ")");
            }
            base.DoDelete(sender);
            this.DeleteSummaryRow(_SummaryView.FocusedRowHandle);//删除Summary资料行
            if (_SummaryView.FocusedRowHandle < 0) //删除了最後一条记录. 显示Summary页面.
                ShowSummaryPage(true);
            else
            {
                _BLL.CreateDataBinder(_SummaryView.GetDataRow(_SummaryView.FocusedRowHandle));
                DoBindingSummaryEditor(_BLL.DataBinder); //显示主表记录详细资料                                                                            
                base.DoDelete(sender);
            }
        }

        protected override void ButtonStateChanged(UpdateType currentState)
        {
            base.ButtonStateChanged(currentState);
            this.SetDetailEditorsAccessable(_DetailGroupControl, this.DataChanged);

            //仅新增状态可修改主键输入框
            if (_KeyEditor != null) _KeyEditor.Enabled = UpdateType.Add == currentState;

            //当按钮状态改变时设置Add,Del按钮是否可用
            btnAddCommonType.Enabled = this.IsAddOrEditMode;
            btnDelCommonType.Enabled = this.IsAddOrEditMode;

            //this.SetEditorEnable(txtDataCode, false, true);
        }
        public override void DoCancel(IButtonInfo sender)
        {
            if (Msg.AskQuestion("要取消修改吗?"))
                base.DoCancel(sender);
        }

        // 检查主表数据是否完整或合法 override
        protected  bool ValidatingData()
        {
            if (txtDataType.Text == string.Empty)
            {
                Msg.Warning("类型不能為空!");
                txtDataType.Focus();
                return false;
            }

            if (txtNativeName.Text.Trim() == string.Empty)
            {
                Msg.Warning("名称不能為空!");
                txtNativeName.Focus();
                return false;
            }
            
            if (_UpdateType == UpdateType.Add)
            {
                if (bllComDataBaseTool.GetTableFieldValue(tb_t_CommonDataDict.__TableName, tb_t_CommonDataDict.__KeyName, tb_t_CommonDataDict.FDataCode + "='" + txtDataCode.Text + "'") != string.Empty)
                {
                    Msg.Warning("编号已存在!");
                    txtDataCode.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 绑定输入框
        /// </summary>
        protected  void DoBindingSummaryEditor(DataTable summary) //override
        {
            try
            {
                if (summary == null) return;
                DataBinder.BindingTextEdit(txtDataCode, summary, tb_t_CommonDataDict.FDataCode);
                //if (summary.Rows[0][tb_t_CommonDataDict.FDataTypeID].ToString() != string.Empty)
                //    summary.Rows[0][tb_t_CommonDataDict.FDataTypeID] = txtDataType.EditValue;
                DataBinder.BindingTextEdit(txtDataType, summary, tb_t_CommonDataDict.FDataTypeID);
                DataBinder.BindingTextEdit(txtEnglishName, summary, tb_t_CommonDataDict.FEnglishName);
                DataBinder.BindingTextEdit(txtNativeName, summary, tb_t_CommonDataDict.FNativeName);
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        //重写保存功能
        public override void DoSave(IButtonInfo sender)
        {
            UpdateLastControl(); //更新最后一个输入控件的数据
            string sDesc="";
            if (!ValidatingData()) return; //检查输入完整性

            //调用UpdateEx扩展方法提交数据，由后台生成主键并返回到客户端。
            SaveResultEx ret = _BLL.UpdateEx(_UpdateType);//调用业务逻辑层的Update方法提交数据
            if(_UpdateType==UpdateType.Add)
                sDesc="新增数据字典";
            else
                sDesc="修改数据字典";

            if (ret.Success)
            {
                _BLL.DataBinder.Rows[0][tb_t_CommonDataDict.FDataCode] = ret.PrimaryKey;//生成的主键

                this.UpdateSummaryRow(_BLL.DataBinder.Rows[0]); //刷新表格内的数据.                                    
                this._UpdateType = UpdateType.None;
                this.SetViewMode();
                this.ShowDetailPage(false);
                this.ButtonStateChanged(_UpdateType);
                bllComDataBaseTool.WriteLogOp(_FunctionID, "0", sDesc + _BLL.DataBinder.Rows[0][tb_t_CommonDataDict.FNativeName].ToString() + "(" + _BLL.DataBinder.Rows[0][tb_t_CommonDataDict.FDataCode].ToString() + ")");
                DataDictCache.RefreshCache();
                gcSummary.DataSource = DataDictCache.Cache.CommonDataDict;
                Msg.ShowInformation("保存成功!");
            }
            else
                Msg.Warning("保存失败!");
        }


        /// <summary>
        /// 检查公共数据字典的类型
        /// </summary>
        /// <returns></returns>
        private bool ValidateCommonType()
        {
            int id = 0;

            Int32.TryParse(txtCommonTypeId.Text, out id);
            if (id == 0)
            {
                Msg.Warning("编号必须大于0!");
                txtCommonTypeId.Focus();
                return false;
            }

            bool exists = ((bllCommonDataDict)_BLL).IsExistsCommonType(id.ToString());
            if (exists)
            {
                Msg.Warning("编号已存在!");
                txtCommonTypeId.Focus();
                return false;
            }

            if (txtCommonTypeName.Text.Trim() == string.Empty)
            {
                Msg.Warning("名称不能為空!");
                txtCommonTypeName.Focus();
                return false;
            }

            return true;
        }

        private void btnAddCommonType_Click(object sender, EventArgs e)
        {
            if (false == ValidateCommonType()) return;
            string sfid = bllComDataBaseTool.GetTableID(tb_t_CommDataDictType.__TableName, tb_t_CommDataDictType.__KeyName);
            //增加一个字典类型
            bool success = (_BLL as bllCommonDataDict).AddCommonType(sfid,txtCommonTypeId.Text, txtCommonTypeName.Text);
            if (success)
            {
                DataDictCache.RefreshCache(tb_t_CommDataDictType.__TableName);
                bllComDataBaseTool.WriteLogOp(_FunctionID, "0", "新增公共字典类型:" + txtCommonTypeName.Text + "(" + txtCommonTypeId.Text + ")");
                DataDictCache.RefreshCache();
                gcProfileClass.DataSource = DataDictCache.Cache.CommonDataDictType;
                DataBinder.BindingLookupEditDataSource(txtDataType, DataDictCache.Cache.CommonDataDictType, "FTYPENAME", "FID");
                Msg.ShowInformation("新增成功！");
            }
        }

        private void btnDelCommonType_Click(object sender, EventArgs e)
        {
            int id = 0;

            Int32.TryParse(txtCommonTypeId.Text, out id);
            if (id == 0)
            {
                Msg.Warning("编号必须大于0!");
                txtCommonTypeId.Focus();
                return;
            }

            if (false == Msg.AskQuestion("确认要删除 '" + txtCommonTypeId.Text + "' 的记录!")) return;

            //删除字典类型
            bool success = (_BLL as bllCommonDataDict).DeleteCommonType(txtCommonTypeId.Text);
            if (success)
            {
                DataDictCache.Cache.DeleteCacheRow(tb_t_CommDataDictType.__TableName, tb_t_CommDataDictType.__KeyName, txtCommonTypeId.Text);
                bllComDataBaseTool.WriteLogOp(_FunctionID, "0", "删除公共字典类型:" + txtCommonTypeName.Text + "(" + txtCommonTypeId.Text + ")");
                DataDictCache.RefreshCache();
                gcProfileClass.DataSource = DataDictCache.Cache.CommonDataDictType;
                DataBinder.BindingLookupEditDataSource(txtDataType, DataDictCache.Cache.CommonDataDictType, "FTYPENAME", "FID");
                Msg.ShowInformation("删除成功！");
            }
        }

      
        private void btnEmpty_Click(object sender, EventArgs e)
        {
            base.ClearContainerEditorText(btnEmpty.Parent);
        }
    }
}
