///*************************************************************************/
///*
///* 文件名    ：frmMenuAuth.cs                   
///* 程序说明  : 系统菜单管理窗体,定义菜单的权限
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
using System.Collections;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;
using SG.Client.Library;
using SG.Common;
using SG.Interfaces;
using SG.Client.SystemModule.Properties;
using SG.Client.Library.UserControls;
using SG.Business;
using SG.Models.Base;


namespace SG.Client.SystemModule
{
    /// <summary>
    /// 系统菜单管理窗体,定义菜单的权限
    /// </summary>
    public partial class frmMenuAuth : frmBaseDataForm
    {
        private bllMenuMgr _BLL = null;//业务逻辑

        public frmMenuAuth()
        {
            InitializeComponent();
            gvMenus.CustomDrawRowIndicator += gvMenus_CustomDrawRowIndicator;
            gvMenus.IndicatorWidth = 40; 
        }

        void gvMenus_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void frmMenuAuth_Load(object sender, EventArgs e)
        {
            this.InitializeForm();//自定义初始化操作
            this.ButtonStateChanged(UpdateType.None);
            //this.InitActionPanel();

            gvMenus_FocusedRowChanged(gvMenus, new FocusedRowChangedEventArgs(0, gvMenus.FocusedRowHandle));

            this.BindingSummaryNavigator(controlNavigatorSummary, gcMenus);
            if (_FormMenuName != string.Empty)
                this._FunctionID = bllComDataBaseTool.GetFunctionID(this._FormMenuName);
            this.Tag = this._FunctionID;
        }

        //初始化窗体
        protected override void InitializeForm()
        {
            _DetailGroupControl = pnlDetail;
            _SummaryView = new DevGridView(gvMenus);

            _BLL = new bllMenuMgr();
            _BLL.GetSummaryData(true);
            gcMenus.DataSource = _BLL.SummaryTable;

            tpSummary.PageVisible = true;
            tpDetail.PageVisible = false;
            tcBusiness.ShowTabHeader = DefaultBoolean.False;
            tcBusiness.SelectedTabPage = tpSummary;
           
            base.InitializeForm();
        }

        public override bool ButtonAuthorized(int authorityValue)
        {
            //禁用一些按钮
            if (authorityValue == ButtonAuthority.ADD) return false;
            if (authorityValue == ButtonAuthority.PRINT) return false;
            if (authorityValue == ButtonAuthority.PREVIEW) return false;

            //处理特殊权限
            if (authorityValue == ButtonAuthority.EX_01)
                return this.HasPurview(authorityValue); //检查单个权限

            return base.ButtonAuthorized(authorityValue);
        }

        protected override void ButtonStateChanged(UpdateType currentState)
        {
            base.ButtonStateChanged(currentState);
            _buttons.GetButtonByName("btnView").Enable = false;
            pcActions.Enabled = this.IsAddOrEditMode;
        }

        /// <summary>
        /// 删除功能控制面板
        /// </summary>
        private void DelActionPanel()
        {
            pcActions.BeginInit();        
            pcActions.Controls.Clear();
            pcActions.EndInit();
        }


        /// <summary>
        /// 初始化功能权限控制面板
        /// </summary>
        private void InitActionPanel(string sfunid)
        {
            int ROW = 11;
            int rowTop = 3;
            int colLeft = 2;
            int count = 0;
            
            
            string filter = string.Format(tb_sys_Fun_MenuBar.FFunctionID + "={0}", sfunid);
            DataRow[] rs = _BLL.AuthorityItem.Select(filter);
            foreach (DataRow actionRow in rs)
            {
                int value = ConvertEx.ToInt(actionRow[tb_sys_Fun_MenuBar.FAuthority]);
                if (value == 0) continue;

                ucCheckEdit checkEdit = new ucCheckEdit();
                checkEdit.Name = "ucCheckEdit_" + value.ToString();
                checkEdit.IsChecked = false;
                checkEdit.Location = new System.Drawing.Point(colLeft, rowTop);
                checkEdit.MaximumSize = new System.Drawing.Size(2333, 21);
                checkEdit.MinimumSize = new System.Drawing.Size(29, 21);
                checkEdit.Size = new System.Drawing.Size(88, 21);
                checkEdit.TabIndex = 0;
                checkEdit.CheckText = ConvertEx.ToString(actionRow[tb_sys_Fun_MenuBar.FName]); //显示预设的名称
                checkEdit.Tag = actionRow; //标记
                pcActions.Controls.Add(checkEdit);

                rowTop += 21 + 2;
                count++;
                if (count > ROW)
                {
                    colLeft += checkEdit.Width - 8;
                    rowTop = 3;
                    count = 0;
                }
            }
            pcActions.EndInit();
        }

        /// <summary>
        /// 初始化功能权限控制面板
        /// </summary>
        private void InitActionPanel()
        {
            int ROW = 11;
            int rowTop = 3;
            int colLeft = 2;
            int count = 0;

            pcActions.BeginInit();
            foreach (DataRow actionRow in _BLL.AuthorityItem.Rows)
            {
                int value = ConvertEx.ToInt(actionRow[tb_sys_Fun_MenuBar.FAuthority]);
                if (value == 0) continue;

                ucCheckEdit checkEdit = new ucCheckEdit();
                checkEdit.Name = "ucCheckEdit_" + value.ToString();
                checkEdit.IsChecked = false;
                checkEdit.Location = new System.Drawing.Point(colLeft, rowTop);
                checkEdit.MaximumSize = new System.Drawing.Size(2333, 21);
                checkEdit.MinimumSize = new System.Drawing.Size(29, 21);
                checkEdit.Size = new System.Drawing.Size(88, 21);
                checkEdit.TabIndex = 0;
                checkEdit.CheckText = ConvertEx.ToString(actionRow[tb_sys_Fun_MenuBar.FName]); //显示预设的名称
                checkEdit.Tag = actionRow; //标记
                pcActions.Controls.Add(checkEdit);

                rowTop += 21 + 2;
                count++;
                if (count > ROW)
                {
                    colLeft += checkEdit.Width - 8;
                    rowTop = 3;
                    count = 0;
                }
            }
            pcActions.EndInit();
        }

        protected override void SetEditMode()
        {
            base.SetEditMode();
            _buttons.GetButtonByName("btnImport").Enable = false;
        }

        protected override void SetViewMode()
        {
            base.SetViewMode();
            _buttons.GetButtonByName("btnImport").Enable = true;
        }

        /// <summary>
        /// 初始化按钮
        /// </summary>
        public override void InitButtons()
        {
            base.InitButtons();

            ArrayList list = new ArrayList();
            list.Add(this.ToolbarRegister.CreateButton("btnImport", "导入菜单", Resources._24_Clone.ToBitmap(), new Size(57, 28), this.DoImportMenu, "btnImport"));
            this.Buttons.AddRange(list);
        }

        public override void DoDelete(IButtonInfo sender)
        {
            AssertFocusedRow();//检查是否选择一条记录
            if (!Msg.AskQuestion("真的要删除?")) return;

            //调用业务逻辑类删除记录
            DataRow summary = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
            string sFdes = "删除菜单" + summary[tb_sys_Function.FName] + "(" + summary[tb_sys_Function.FNumber] + ")";
            bool b = _BLL.Delete(summary[_BLL.KeyFieldName].ToString());
            AssertEqual(b, true, "删除记录时发生错误!");
            
            bllComDataBaseTool.WriteLogOp(_FunctionID, "0", sFdes);
            base.DoDelete(sender);
            this.DeleteSummaryRow(_SummaryView.FocusedRowHandle);//删除Summary资料行
            if (_SummaryView.FocusedRowHandle < 0) //删除了最後一条记录. 显示Summary页面.
                ShowSummaryPage(true);
            else
            {
                _BLL.CreateDataBinder(_SummaryView.GetDataRow(_SummaryView.FocusedRowHandle));
                this.DoViewContent(sender);
                base.DoDelete(sender);
            }
        }

        public override void DoCancel(IButtonInfo sender)
        {
            base.DoCancel(sender);
        }

        public override void DoEdit(IButtonInfo sender)
        {
            base.DoEdit(sender);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        public override void DoSave(IButtonInfo sender)
        {
            if (!gvMenus.IsValidRowHandle(gvMenus.FocusedRowHandle)) return;
            DataTable summary = gcMenus.DataSource as DataTable;

            DataRow currentRow = gvMenus.GetDataRow(gvMenus.FocusedRowHandle);
            int temp = ConvertEx.ToInt(currentRow[tb_sys_Function.FAuths]); //取当前菜单的权限
            string menuName = ConvertEx.ToString(currentRow[tb_sys_Function.FNumber]);//当前菜单名
            string MenuId = ConvertEx.ToString(currentRow[tb_sys_Function.FID]);//当前菜单ID
            //取窗体的权限
            int auths = 0; int val = 0;
            ucCheckEdit ce;
            DataRow row;
            //string filter;

            foreach (Control ctr in pcActions.Controls)
            {
                if (!(ctr is ucCheckEdit)) continue;

                ce = ctr as ucCheckEdit;
                row = ce.Tag as DataRow; //功能点的数据行
                val = ConvertEx.ToInt(row[tb_sys_Fun_MenuBar.FAuthority]);
                if (ce.IsChecked) auths += val; //累加权限数值

                //filter = "FNumber='" + menuName + "' and FAuthority=" + val.ToString();
                //DataRow[] rows = _BLL.FormTagCustomName.Select(filter);
                //if (rows.Length > 0) //有自定义功能点名称
                //{
                //    string tagName = ConvertEx.ToString(rows[0][tb_sys_Fun_MenuBar.FName]);
                //    if (ce.IsChecked && (tagName.ToUpper() != ce.CheckText.ToUpper()))
                //        rows[0][tb_sys_Fun_MenuBar.FName] = ce.CheckText;//修改新功能点名称

                //    if (ce.IsChecked == false) //删除了功能名称
                //        rows[0].Delete();
                //}
                //else
                //{
                    //string authName = ConvertEx.ToString(row[tb_sys_Fun_MenuBar.FAuthority]);
                    //if (authName.ToUpper() != ce.CheckText.ToUpper())
                    //{
                    //    DataRow newrow = _BLL.FormTagCustomName.NewRow();
                    //    newrow[tb_sys_Fun_MenuBar.FMenuID] = MenuId;
                    //    newrow[tb_sys_Fun_MenuBar.FAuthority] = val;
                    //    newrow[tb_sys_Fun_MenuBar.FName] = ce.CheckText; //新的名称
                    //    _BLL.FormTagCustomName.Rows.Add(newrow);
                    //}
                //}
            }

            if (auths != temp)
            {
                currentRow[tb_sys_Function.FAuths] = auths;//修改新权限
            }

            //保存两种数据: 1.菜单  2.各窗体的功能点名称            
            if (_BLL.Update(_UpdateType))
            {
                string sFdes = (_UpdateType == UpdateType.Add ? "新增" : "修改") + "功能" + menuName + "的权限";
                bllComDataBaseTool.WriteLogOp(_FunctionID, "0", sFdes);
                base.DoSave(sender);
                Msg.ShowInformation("保存成功!");
            }
        }

        public void DoImportMenu(IButtonInfo sender)
        {
            //导入菜单数据
            bool success = _BLL.ImportMenu((this.MdiParent as IMdiForm).MainMenu, false);
            if (success)
            {
                string msg = string.Format("导入菜单数据成功！共更新{0}个，导入新菜单{1}个！",
                    _BLL.LastUpdated, _BLL.LastInserted);

                bllComDataBaseTool.WriteLogOp(_FunctionID, "0", msg);
                Msg.ShowInformation(msg);
            }
        }

        private void gvMenus_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (gvMenus.IsValidRowHandle(e.FocusedRowHandle))
                this.ShowCurrentRowActions(e.FocusedRowHandle);// 显示菜单的功能
        }

        /// <summary>
        /// 显示菜单的功能
        /// </summary>
        /// <param name="rowHandle"></param>
        private void ShowCurrentRowActions(int rowHandle)
        {
            DataRow row; int value;
            int Auths = ConvertEx.ToInt(gvMenus.GetDataRow(rowHandle)[tb_sys_Function.FAuths]);
            string menu = ConvertEx.ToString(gvMenus.GetDataRow(rowHandle)[tb_sys_Function.FID]);
            
            DelActionPanel();
          
            InitActionPanel(menu);
            foreach (Control c in pcActions.Controls)
            {
                if (c is ucCheckEdit)
                {
                    row = c.Tag as DataRow;
                    value = ConvertEx.ToInt(row[tb_sys_Fun_MenuBar.FAuthority]);

                    (c as ucCheckEdit).IsChecked = (value & Auths) == value;

                    //显示自定义的功能点名称
                    //string filter = "FID='" + menu + "' and FAuths=" + value.ToString();
                    //DataRow[] rows = _BLL.FormTagCustomName.Select(filter);
                    //if (rows.Length > 0)
                    //    (c as ucCheckEdit).CheckText = ConvertEx.ToString(rows[0][tb_sys_Fun_MenuBar.FName]);
                    //else
                    (c as ucCheckEdit).CheckText = ConvertEx.ToString(row[tb_sys_Fun_MenuBar.FName]);
                }
            }
        }
    }
}
