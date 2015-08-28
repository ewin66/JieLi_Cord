using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using SG.Business;
using SG.Business.Base;
using SG.Client.Library;
using SG.Common;
using SG.Interfaces;
using SG.Models.Base;
///*************************************************************************/
///*
///* 文件名    ：frmSystemProfile.cs                   
///* 程序说明  : 系统参数设置
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG.Client.SystemModule
{
    public partial class frmSystemProfile : frmBaseDataForm
    {
        private bllSystemProfile _BLL = null;//业务逻辑

        ISummaryView _ClassView;
        public frmSystemProfile()
        {
            InitializeComponent();
            this.Load += frmSystemProfile_Load;
            
            gvprofile.CustomRowCellEditForEditing += gvprofile_CustomRowCellEditForEditing;
            gvprofile.CellValueChanged += gvprofile_CellValueChanged;
            
        }

       
        /// <summary>
        /// 单元格编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gvprofile_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.ColumnHandle != 10) return;
            DataRow dr = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
            if (dr[tb_sys_SystemProfile.FType].ToString() == "2")
            {
               
                RepositoryItemComboBox cbx = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                cbx.Items.Clear();
                cbx.Items.Add("是");
                cbx.Items.Add("否");
                cbx.SelectedIndexChanged += cbx_SelectedIndexChanged;
                e.RepositoryItem = cbx;
            }
            if (dr[tb_sys_SystemProfile.FType].ToString() == "3")
            {
                RepositoryItemDateEdit dat = new RepositoryItemDateEdit();
                dat.Mask.EditMask="yyyy-MM-dd";
                //dat.Click += dat_Click;
                e.RepositoryItem = dat;
                e.RepositoryItem.DisplayFormat.FormatString = "yyyy-MM-dd";
                e.RepositoryItem.EditFormat.FormatString = "yyyy-MM-dd";
            }
        }

        //void dat_Click(object sender, EventArgs e)
        //{

        //    BaseEdit edit = gvprofile.ActiveEditor;
        //    edit.EditValue = Convert.ToDateTime(edit.EditValue).ToString("yyyy-MM-dd");
        //    DataRow dr = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
        //    dr["ISUP"] = "1";
        //    _BLL.UpdateByRow(dr);
        //    gvprofile.CloseEditor();
        //    gvprofile.UpdateCurrentRow();
        //    gvprofile.RefreshData();
        //}



        void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseEdit edit = gvprofile.ActiveEditor;
            DataRow dr= _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
            if (edit.EditValue.ToString() == "是")
            {
                dr[tb_sys_SystemProfile.FValue] = "1";
                //gvprofile.SetFocusedRowCellValue(gvprofile.Columns[tb_sys_SystemProfile.FValue], "1");
            }
            else
            {
                dr[tb_sys_SystemProfile.FValue] = "1";
            }
            //gvprofile.SetFocusedRowCellValue(gvprofile.Columns[tb_sys_SystemProfile.FValue], "0");
            //gvprofile.SetFocusedRowCellValue(gvprofile.Columns["ISUP"], "1");
            dr["ISUP"] = "1";
            _BLL.UpdateByRow(dr);
            gvprofile.CloseEditor();
            gvprofile.UpdateCurrentRow();
            gvprofile.RefreshData();
        }

        void gvprofile_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            BaseEdit edit = gvprofile.ActiveEditor;
            DataRow dr = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
            if (edit.EditValue.ToString() == "是")
            {
                dr[tb_sys_SystemProfile.FValue] = "1";
                //gvprofile.SetFocusedRowCellValue(gvprofile.Columns[tb_sys_SystemProfile.FValue], "1");
            }
            else if (edit.EditValue.ToString() == "否")
            {
                dr[tb_sys_SystemProfile.FValue] = "0";
                //gvprofile.SetFocusedRowCellValue(gvprofile.Columns[tb_sys_SystemProfile.FValue], "0");
            }
            else
            {
                if (dr[tb_sys_SystemProfile.FType].ToString() == "3")
                {
                                        
                }
                dr[tb_sys_SystemProfile.FValue] = edit.EditValue;
             //   gvprofile.SetFocusedRowCellValue(gvprofile.Columns[tb_sys_SystemProfile.FValue], edit.EditValue);
            }
           // gvprofile.SetFocusedRowCellValue(gvprofile.Columns["ISUP"], "1");
            dr["ISUP"] = "1";
            _BLL.UpdateByRow(dr);
            gvprofile.CloseEditor();
            gvprofile.UpdateCurrentRow();
            gvprofile.RefreshData();

        }

        public override void DoSave(IButtonInfo sender)
        {
            try
            {
                _BLL.SummaryTable.AcceptChanges();
                DataTable Savedt = _BLL.SummaryTable.Copy();
                string sDesc = "修改参数";
                for (int i = 0; i < Savedt.Rows.Count; i++)
                {
                    if (Savedt.Rows[i]["ISUP"].ToString() == "0")
                        Savedt.Rows[i].Delete();
                    else
                        sDesc += Savedt.Rows[i][tb_sys_SystemProfile.FDescription].ToString() + "——" + Savedt.Rows[i][tb_sys_SystemProfile.FValue].ToString();
                }
                bool ret = _BLL.Update(Savedt, _UpdateType);
                if (ret)
                {
                    base.DoSave(sender);
                    bllComDataBaseTool.WriteLogOp(_FunctionID, "0", sDesc); //日志
                    Msg.ShowInformation("保存成功!");
                }
                else
                    Msg.Warning("保存失败!");
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }
        }

        public override void DoCancel(IButtonInfo sender)
        {
            if (Msg.AskQuestion("要取消修改吗?"))
            {
                gvprofile.Columns[2].OptionsColumn.AllowEdit = false;
                base.DoCancel(sender);
            }

           
        }
           

        public override void DoEdit(IButtonInfo sender)
        {
            try
            {
                gvprofile.Columns[2].OptionsColumn.AllowEdit = true;
                
                base.DoEdit(sender);
            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        void frmSystemProfile_Load(object sender, EventArgs e)
        {
            this.InitializeForm();//自定义初始化操作
            this.gvprofile.CustomDrawRowIndicator += gvprofile_CustomDrawRowIndicator;
            gridProfileClass.CustomDrawRowIndicator += gridProfileClass_CustomDrawRowIndicator;
            gvprofile.IndicatorWidth = 40;
            gridProfileClass.IndicatorWidth = 40;
            gridProfileClass.RowClick += gridProfileClass_RowClick;
            if (_FormMenuName != string.Empty)
                this._FunctionID = bllComDataBaseTool.GetFunctionID(this._FormMenuName);
            this.Tag = this._FunctionID;
        }

        void gridProfileClass_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = _ClassView.GetDataRow(_ClassView.FocusedRowHandle);
            BindGvprofile(dr[tb_sys_SystemProfile.FCategory].ToString());
        }

        void gridProfileClass_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        void gvprofile_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }



        //初始化窗体
        protected override void InitializeForm()
        {
            _DetailGroupControl = pnlDetail;
            _SummaryView = new DevGridView(gvprofile);

            _BLL = new bllSystemProfile();
            _BLL.GetSystemProfile();
            gcProfileClass.DataSource = _BLL._SysClass;
            gcprofile.DataSource = _BLL.SummaryTable;
            _ClassView = new DevGridView(gridProfileClass);
            //绑定从表
            DataRow dr = _ClassView.GetDataRow(_ClassView.FocusedRowHandle);
            BindGvprofile(dr[tb_sys_SystemProfile.FCategory].ToString());
            gvprofile.Columns[2].OptionsColumn.AllowEdit = false; 
            
            tpSummary.PageVisible = true;
            tpDetail.PageVisible = false;
            tcBusiness.ShowTabHeader = DefaultBoolean.False;
            tcBusiness.SelectedTabPage = tpSummary;
           
            base.InitializeForm();
        }

        /// <summary>
        /// 绑定分类参数
        /// </summary>
        /// <param name="sfilter"></param>
        private void BindGvprofile(string sfilter)
        {
            string strF = tb_sys_SystemProfile.FCategory + "='" + sfilter + "'";
            gvprofile.ActiveFilterString = strF;
            //gcprofile.DataSource = _BLL.SummaryTable.Select(strF);
        }

        public override bool ButtonAuthorized(int authorityValue)
        {
            //禁用一些按钮
            if (authorityValue == ButtonAuthority.ADD) return false;
            if (authorityValue == ButtonAuthority.DELETE) return false;
            if (authorityValue == ButtonAuthority.PRINT) return false;
            if (authorityValue == ButtonAuthority.PREVIEW) return false;

            //处理特殊权限
            if (authorityValue == ButtonAuthority.EX_01)
                return this.HasPurview(authorityValue); //检查单个权限

            return base.ButtonAuthorized(authorityValue);
        }
    }
}
