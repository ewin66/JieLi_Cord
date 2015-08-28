using SG.Business;
using SG.Business.Database;
using SG.Client.Database.Properties;
using SG.Client.Library;
using SG.Common;
using SG.Interfaces;
using SG.Models.Database;
///*************************************************************************/
///*
///* 文件名    ：frmDatabaseSet.cs    
///*
///* 程序说明  : 基础资料配置。
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SG.Client.Database
{
    public partial class frmDatabaseSet : SG.Client.Library.frmBaseDataForm
    {
        bllDatabaseSet _BLL;
        ISummaryView _ClassView;
        /// <summary>
        /// 保存分类
        /// </summary>
        bool IsSaveClass = true;
        Control _ClassDetial;
        Control _AttDetial;
        public frmDatabaseSet()
        {
            InitializeComponent();
            gridProfileClass.CustomDrawRowIndicator += gridProfileClass_CustomDrawRowIndicator;
            gvSummary.CustomDrawRowIndicator += gvSummary_CustomDrawRowIndicator;
            gvSummary.IndicatorWidth = 40;
            gridProfileClass.IndicatorWidth = 40;
            this.Load += frmDatabaseSet_Load;
        }

        void frmDatabaseSet_Load(object sender, EventArgs e)
        {
            this.InitializeForm();//自定义初始化操作 
        }

        protected override void InitializeForm()
        {
            _SummaryView = new DevGridView(gvSummary);//每个业务窗体必需给这个变量赋值.
            _ClassView = new DevGridView(gridProfileClass);
            _ActiveEditor = ucClassFNumber;
            //_KeyEditor = txtDataCode;
            _DetailGroupControl = gcDetailEditor;
            _ClassDetial = gcItemClassEditor;
            _ActiveEditor = gcAttributeEditor;
            _BLL = new bllDatabaseSet();
            //_BLL = new bllCommonDataDict(); //业务逻辑实例
            gvSummary.DoubleClick += new EventHandler(OnGridViewDoubleClick); //主表DoubleClict
            gcProfileClass.DoubleClick += gcProfileClass_DoubleClick;
            //绑定相关缓存数据
            ucClassCTable.lookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TBNAME", (int)(ucClassCTable.Width-ucClassCTable.LabelWidth), "数据库"));
            ucClassTable.lookUpEdit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TBNAME", (int)(ucClassTable.Width - ucClassTable.LabelWidth), "数据库"));
            DataBinder.BindingLookupEditDataSource(ucClassCTable.lookUpEdit, bllComDataBaseTool.getTable("t_%"), "TBNAME", "TBNAME");
            DataBinder.BindingLookupEditDataSource(ucClassTable.lookUpEdit, bllComDataBaseTool.getTable("t_%"), "TBNAME", "TBNAME");

            ShowSummary();

            if (_FormMenuName != string.Empty)
                this._FunctionID = bllComDataBaseTool.GetFunctionID(this._FormMenuName);
            this.Tag = this._FunctionID;
            base.InitializeForm();
        }

      
        void gcProfileClass_DoubleClick(object sender, EventArgs e)
        {
            //DoViewContentClass(sender);
        }
        private void ShowSummary()
        {
            try
            {
                _BLL.GetItemPropDesc();
                _BLL.GetItemClass();
                gcProfileClass.DataSource = _BLL.ClassSummaryTable;                
                DoBindingSummaryGrid(_BLL.SummaryTable); //绑定主表的Grid
                

                ShowSummaryPage(true); //显示Summary页面. 
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }
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

        public override void InitButtons()
        {
            base.InitButtons();
            ArrayList list = new ArrayList();
            if (ButtonIsShow("btnSaveClass"))
                list.Add(this.ToolbarRegister.CreateButton("btnSaveClass", "保存类型", SG.Client.Resources.Properties.Resources._24_Save.ToBitmap(), new Size(57, 28), this.DoSaveClass, "btnSaveClass"));
            if (ButtonIsShow("btnDelClass")) 
                list.Add(this.ToolbarRegister.CreateButton("btnDelClass", "删除类型", SG.Client.Resources.Properties.Resources._24_Delete.ToBitmap(), new Size(57, 28), this.DoDelClass, "btnDelClass"));
            if (ButtonIsShow("btnEditClass")) 
                list.Add(this.ToolbarRegister.CreateButton("btnEditClass", "编辑类型", SG.Client.Resources.Properties.Resources._24_Edit.ToBitmap(), new Size(57, 28), this.DoEditClass, "btnEditClass"));
            if (ButtonIsShow("btnAddClass")) 
                list.Add(this.ToolbarRegister.CreateButton("btnAddClass", "新增类型", SG.Client.Resources.Properties.Resources._24_Add.ToBitmap(), new Size(57, 28), this.DoAddClass, "btnAddClass"));
            this.Buttons.AddRange(list, "btnClose");
        }
        public override void DoCancel(IButtonInfo sender)
        {
            if (Msg.AskQuestion("要取消修改吗?"))
            {
                tpSummary.PageEnabled = true;
                base.DoCancel(sender);
            }
        }
        /// <summary>
        /// 保存基础资料名称
        /// </summary>
        private void DoViewContentClass(IButtonInfo sender)
        {
            AssertFocusedRowClass(); //检查有无记录.                
            _BLL.CreateDataBinderClass(_ClassView.GetDataRow(_ClassView.FocusedRowHandle));
            base.DoViewContent(sender);
            DoBindingSummaryClassEditor(_BLL.ClassDataBinder); //绑定数据输入控件
            ShowDetailPage(false); //用户点击ViewContent按钮可以显示Summary页    
        }

        /// <summary>
        /// 检查有无记录
        /// </summary>
        protected void AssertFocusedRowClass()
        {
            bool ret = (_ClassView == null) || (_ClassView.IsValidRowHandle(_ClassView.FocusedRowHandle) == false);
            if (ret) throw new Exception("您没有选择记录，操作取消!");
        }

        // 检查基础资料分类数据是否完整或合法 override
        protected bool ValidatingDataClass()
        {
            if (ucClassFNumber.txtTextEdit.Text == string.Empty)
            {
                Msg.Warning("编号不能為空!");
                ucClassFNumber.txtTextEdit.Focus();
                return false;
            }

            if (ucClassFName.txtTextEdit.Text.Trim() == string.Empty)
            {
                Msg.Warning("名称不能為空!");
                ucClassFName.txtTextEdit.Focus();
                return false;
            }

            if (_UpdateType == UpdateType.Add)
            {
                if (bllComDataBaseTool.GetTableFieldValue(tb_t_ItemClass.__TableName, tb_t_ItemClass.__KeyName, tb_t_ItemClass.FNumber + "='" + ucClassFNumber.txtTextEdit.Text + "'") != string.Empty)
                {
                    Msg.Warning("编号已存在!");
                    ucClassFNumber.txtTextEdit.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 保存基础资料名称
        /// </summary>
        private void DoSaveClass(IButtonInfo sender)
        {
            UpdateLastControl(); //更新最后一个输入控件的数据
            string sDesc = "";
            if (!ValidatingDataClass()) return; //检查输入完整性

            //调用UpdateEx扩展方法提交数据，由后台生成主键并返回到客户端。
            SaveResultEx ret = _BLL.UpdateClassEx(_UpdateType);//调用业务逻辑层的Update方法提交数据
            if (_UpdateType == UpdateType.Add)
                sDesc = "新增基础数据";
            else
                sDesc = "修改基础数据";

            if (ret.Success)
            {

                this.UpdateClassSummaryRow(_BLL._ClassDataBinder.Rows[0]); //刷新表格内的数据.                                    
                this._UpdateType = UpdateType.None;
                this.SetViewMode();
                this.ShowDetailPageClass(false);
                this.ButtonStateChanged(_UpdateType);
                bllComDataBaseTool.WriteLogOp(_FunctionID, "0", sDesc + _BLL._ClassDataBinder.Rows[0][tb_t_ItemClass.FName].ToString() + "(" + _BLL._ClassDataBinder.Rows[0][tb_t_ItemClass.FNumber].ToString() + ")");
                DataDictCache.RefreshCache();
                gcProfileClass.DataSource = DataDictCache.Cache.ItemClass;
                //_BLL.ClassSummaryTable = DataDictCache.Cache.ItemClass;
                
                Msg.ShowInformation("保存成功!");
            }
            else
                Msg.Warning("保存失败!");
        }

        /// <summary>
        /// 更新当前操作的缓存记录
        /// 保存数据后更新Summary当前记录.
        /// 如果是修改后保存,将最新数据替换当前记录的数据.
        /// 如果是新增后保存,在表格内插入一条记录.
        /// </summary>
        protected virtual void UpdateClassSummaryRow(DataRow summary)
        {
            if (_ClassView.DataSource == null) return;
            if (summary == null) return;
            try
            {
                DataTable dt = (DataTable)_ClassView.DataSource;

                //如果是新增后保存,在表格内插入一条记录.
                if (_UpdateType == UpdateType.Add)
                {
                    DataRow newrow = dt.NewRow();//表格的数据源增加一条记录

                    this.ReplaceDataRowChanges(summary, newrow);//替换数据

                    dt.Rows.Add(newrow);
                    _ClassView.RefreshDataSource();
                    _ClassView.FocusedRowHandle = dt.Rows.Count - 1;
                    dt.AcceptChanges();
                }

                //如果是修改后保存,将最新数据替换当前记录的数据.
                if (_UpdateType == UpdateType.Modify || _UpdateType == UpdateType.None)
                {
                    int focusedRowHandle = _ClassView.FocusedRowHandle;

                    DataRow dr = _ClassView.GetDataRow(focusedRowHandle);

                    this.ReplaceDataRowChanges(summary, dr);//替换数据

                    dr.Table.AcceptChanges();
                    _ClassView.RefreshRow(focusedRowHandle);//修改或新增要刷新Grid数据          
                }
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }


        /// <summary>
        /// 增加基础资料名称
        /// </summary>
        private void DoAddClass(IButtonInfo sender)
        {
            try
            {
                IsSaveClass = true;
                _BLL.CreateDataBinderClass(null);
                DoBindingSummaryClassEditor(_BLL._ClassDataBinder); //绑定数据输入控件
                base.DoAdd(sender);
                ShowDetailPageClass(true);
            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        protected override void ButtonStateChanged(UpdateType currentState)
        {
            base.ButtonStateChanged(currentState);
            
            this.SetDetailEditorsAccessable(_DetailGroupControl, this.DataChanged);
            if (IsSaveClass)
                this.SetDetailEditorsAccessable(_ClassDetial, this.DataChanged);
            else
                this.SetDetailEditorsAccessable(_ActiveEditor, this.DataChanged);

            //仅新增状态可修改主键输入框
            if (_KeyEditor != null) _KeyEditor.Enabled = UpdateType.Add == currentState;
                     

        }


        protected override void SetViewMode()
        {
            base.SetViewMode();

            _buttons.GetButtonByName("btnView").Enable = _AllowDataOperate;
            _buttons.GetButtonByName("btnAdd").Enable = _AllowDataOperate && ButtonAuthorized(ButtonAuths("btnAdd"));
            _buttons.GetButtonByName("btnDelete").Enable = _AllowDataOperate && ButtonAuthorized(ButtonAuths("btnDelete"));
            _buttons.GetButtonByName("btnEdit").Enable = _AllowDataOperate && ButtonAuthorized(ButtonAuths("btnEdit"));
            _buttons.GetButtonByName("btnAddClass").Enable = _AllowDataOperate && ButtonAuthorized(ButtonAuths("btnAddClass"));
            _buttons.GetButtonByName("btnDeleteClass").Enable = _AllowDataOperate && ButtonAuthorized(ButtonAuths("btnDeleteClass"));
            _buttons.GetButtonByName("btnEditClass").Enable = _AllowDataOperate && ButtonAuthorized(ButtonAuths("btnEditClass"));
            _buttons.GetButtonByName("btnPrint").Enable = ButtonAuthorized(ButtonAuths("btnPrint"));
            _buttons.GetButtonByName("btnPreview").Enable = ButtonAuthorized(ButtonAuths("btnPreview"));
            _buttons.GetButtonByName("btnSave").Enable = false;
            _buttons.GetButtonByName("btnSaveClass").Enable = false;
            _buttons.GetButtonByName("btnCancel").Enable = false;
        }

        /// <summary>
        /// 设置编制模式
        /// </summary>
        protected override void SetEditMode()
        {
            base.SetEditMode();

            _buttons.GetButtonByName("btnView").Enable = false;
            _buttons.GetButtonByName("btnAdd").Enable = false;
            _buttons.GetButtonByName("btnAddClass").Enable = false;
            _buttons.GetButtonByName("btnDelete").Enable = false;
            _buttons.GetButtonByName("btnDeleteClass").Enable = false;
            _buttons.GetButtonByName("btnEdit").Enable = false;
            _buttons.GetButtonByName("btnEditClass").Enable = false;
            _buttons.GetButtonByName("btnPrint").Enable = false;
            _buttons.GetButtonByName("btnPreview").Enable = false;
            if (IsSaveClass)
            {
                _buttons.GetButtonByName("btnSave").Enable = false;
                _buttons.GetButtonByName("btnSaveClass").Enable = _AllowDataOperate && ButtonAuthorized(ButtonAuths("btnSaveClass")); ;
            }
            else
            {
                _buttons.GetButtonByName("btnSave").Enable = _AllowDataOperate && ButtonAuthorized(ButtonAuths("btnSave")); ; ;
                _buttons.GetButtonByName("btnSaveClass").Enable = false;
            }
            _buttons.GetButtonByName("btnCancel").Enable = true;
        }
        /// <summary>
        /// 显示分类明细页
        /// </summary>
        protected void ShowDetailPageClass(bool disableSummaryPage)
        {
            try
            {
                this.SuspendLayout();
                this.tpDetail.PageEnabled = true;
                tcClass.PageEnabled = true;
                tcAttribute.PageEnabled = false;
                tcBusiness.SelectedTabPage = this.tpDetail;
                tpSummary.PageEnabled = !disableSummaryPage;
                FocusEditor(); //第一个编辑框获得焦点.
                this.ResumeLayout();
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        /// <summary>
        /// 显示明细页
        /// </summary>
        protected void ShowDetailPage(bool disableSummaryPage)
        {
            try
            {
                this.SuspendLayout();
                this.tpDetail.PageEnabled = true;
                tcClass.PageEnabled = false;
                tcAttribute.PageEnabled = true;
                tcBusiness.SelectedTabPage = this.tpDetail;
                tpSummary.PageEnabled = !disableSummaryPage;
                FocusEditor(); //第一个编辑框获得焦点.
                this.ResumeLayout();
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        /// <summary>
        /// 修改基础资料名称
        /// </summary>
        private void DoEditClass(IButtonInfo sender)
        {
            
            base.DoEdit(sender);
            DoViewContentClass(sender);
            ShowDetailPage(true);
        }

       

        /// <summary>
        /// 删除基础资料名称
        /// </summary>
        private void DoDelClass(IButtonInfo sender)
        {

        }


        /// <summary>
        /// 绑定输入框
        /// </summary>
        protected void DoBindingSummaryClassEditor(DataTable summary) //override
        {
            try
            {
                if (summary == null) return;
                DataBinder.BindingTextEdit(ucClassFNumber.txtTextEdit, summary, tb_t_ItemClass.FNumber);              
                DataBinder.BindingTextEdit(ucClassFName.txtTextEdit, summary,tb_t_ItemClass.FName);
                DataBinder.BindingTextEdit(ucClassCTable.lookUpEdit, summary, tb_t_ItemClass.FSQLClassTableName);
                DataBinder.BindingTextEdit(ucClassTable.lookUpEdit, summary, tb_t_ItemClass.FSQLTableName);
                DataBinder.BindingTextEdit(ucClassNote.memoEdit, summary, tb_t_ItemClass.FNote);
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }
    }
}
