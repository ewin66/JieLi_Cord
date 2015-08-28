///*************************************************************************/
///*
///* 文件名    ：frmCompanyInfo.cs    
///*
///* 程序说明  : 公司资料设置
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///*************************************************************************/

using SG.Business;
using SG.Business.Base;
using SG.Client.Library;
using SG.Common;
using SG.Interfaces;
using SG.Models;
using SG.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SG.Client.SystemModule
{
    /// <summary>
    /// 公司资料设置
    /// </summary>
    public partial class frmCompanyInfo : frmBaseDataDictionary
    {
        public frmCompanyInfo()
        {
            InitializeComponent();
        }

        private void frmCompanyInfo_Load(object sender, EventArgs e)
        {
            _BLL = new bllCompanyInfo(); //业务逻辑层
            _BLL.GetSummaryData(true);//获取数据
            _DetailGroupControl = gcDetailEditor;

            this.InitializeForm();
            if (_FormMenuName != string.Empty)
                this._FunctionID = bllComDataBaseTool.GetFunctionID(this._FormMenuName);
            this.Tag = this._FunctionID;
            BindingSummaryEditor(_BLL.SummaryTable); //绑定输入控件
            ButtonStateChanged(UpdateType.None);
            this.ShowDetailPage(true);
            tpSummary.Hide();
        }

        public override void DoCancel(IButtonInfo sender)
        {
            if (!Msg.AskQuestion("要取消修改吗?")) return;

            _BLL.GetSummaryData(true);//获取数据
            BindingSummaryEditor(_BLL.SummaryTable); //绑定输入控件

            this._UpdateType = UpdateType.None;
            this.SetViewMode();
            this.ButtonStateChanged(_UpdateType);
        }

        public override void DoEdit(IButtonInfo sender)
        {
            this._UpdateType = UpdateType.Modify;
            this.SetEditMode();
            this.ButtonStateChanged(_UpdateType);
        }

        public override void DoSave(IButtonInfo sender)
        {
            this.UpdateLastControl();

            if (txtCompanyCode.Text == "")
            {
                Msg.Warning("公司编号不能为空！");
                txtCompanyCode.Focus();
                return;
            }

            if (txtNativeName.Text == "")
            {
                Msg.Warning("公司中文名称不能为空！");
                txtNativeName.Focus();
                return;
            }

            if (_BLL.Update(_UpdateType))
            {
                this._UpdateType = UpdateType.None;
                this.SetViewMode();
                this.ButtonStateChanged(_UpdateType);
                string sFdes = _UpdateType == UpdateType.Add ? "新增" : "修改" + "公司信息";
                bllComDataBaseTool.WriteLogOp(_FunctionID, "0", sFdes);
                Msg.ShowInformation("保存成功！");
            }
            else
                Msg.ShowInformation("保存失败！");
        }

        protected override void ButtonStateChanged(UpdateType currentState)
        {
            bool accessable = currentState == UpdateType.Add || currentState == UpdateType.Modify;
            base.SetDetailEditorsAccessable(gcDetailEditor, accessable);
            base.ButtonStateChanged(currentState);

            //禁用数据操作按钮
            _buttons.GetButtonByName("btnView").Enable = false;
            _buttons.GetButtonByName("btnAdd").Enable = false;
            _buttons.GetButtonByName("btnDelete").Enable = false;
            _buttons.GetButtonByName("btnPrint").Enable = false;
            _buttons.GetButtonByName("btnPreview").Enable = false;
        }

        private void BindingSummaryEditor(object summary)
        {
            try
            {
                if (summary == null) return;
                DataBinder.BindingTextEdit(txtCompanyCode, summary, tb_sys_CompanyInfo.FCompanyCode);
                DataBinder.BindingTextEdit(txtEnglishName, summary, tb_sys_CompanyInfo.FEnglishName);
                DataBinder.BindingTextEdit(txtNativeName, summary, tb_sys_CompanyInfo.FNativeName);
                DataBinder.BindingTextEdit(txtProgramName, summary, tb_sys_CompanyInfo.FProgramName);

                DataBinder.BindingTextEdit(txtAddress, summary, tb_sys_CompanyInfo.FAddress);
                DataBinder.BindingTextEdit(txtFax, summary, tb_sys_CompanyInfo.FFax);
                DataBinder.BindingTextEdit(txtReportHead, summary, tb_sys_CompanyInfo.FReportHead);
                DataBinder.BindingTextEdit(txtTel, summary, tb_sys_CompanyInfo.FTel);
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }
    }
}
