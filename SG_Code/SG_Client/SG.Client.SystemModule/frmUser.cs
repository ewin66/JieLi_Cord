///*************************************************************************/
///*
///* 文件名    ：frmUser.cs                   
///* 程序说明  : 用户管理窗体
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///*************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SG.Business.Base;
using SG.Client.Library;
using SG.Common;
using SG.Interfaces;
using SG.Models.Base;
using SG.Models;
using SG.Client.Bridge;
using SG.Business;


namespace SG.Client.SystemModule
{
    public partial class frmUser : frmBaseDataForm
    {
        private bllUser _DataProxy = new bllUser();//用户业务类

        public frmUser()
        {
            InitializeComponent();
            InitializeForm();
            gvSummary.CustomDrawRowIndicator += gvSummary_CustomDrawRowIndicator;
            gvSummary.IndicatorWidth = 40; 
            
        }

        void gvSummary_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            this.InitButtons();
            this.SetViewMode();
            this.SetButtonAuthority();
            if (_FormMenuName != string.Empty)
                this._FunctionID = bllComDataBaseTool.GetFunctionID(this._FormMenuName);
            this.Tag = this._FunctionID;
        }

        protected override void InitializeForm()
        {
            try
            {
                _SummaryView = new DevGridView(gvSummary);
                _ActiveEditor = txtAccount;
                _DetailGroupControl = gcDetailEditor;
                gvSummary.DoubleClick += new EventHandler(OnGridViewDoubleClick); //主表DoubleClict

                frmGridCustomize.RegisterGrid(gvSummary);
                frmGridCustomize.AddMenuItem(gvSummary, "修改密码", null, OnChangePwdClick, true);

                DevStyle.SetGridControlLayout(gcSummary, false);//表格设置   
                DevStyle.SetSummaryGridViewLayout(gvSummary);

                DataTable data = CommonData.GetSystemDataSet();
                ucDataSets.BindingDataSource(data, tb_T_Account.FNumber, tb_T_Account.FName);
                
                ShowSummary(); //下载显示数据.
                BindingSummaryNavigator(controlNavigatorSummary, gcSummary); //Summary导航条.
                ShowSummaryPage(true); //一切初始化完毕後显示SummaryPage        
            }
            catch (Exception ex) { Msg.ShowException(ex); }
        }

        public void OnChangePwdClick(object sender, EventArgs e)
        {
            DataRow user = gvSummary.GetDataRow(gvSummary.FocusedRowHandle);
            LoginUser data = new LoginUser();
            data.Account = user[tb_sys_User.FAccount].ToString();
            data.Password = user[tb_sys_User.FPassword].ToString();
            data.DataSetDBName = Loginer.CurrentUser.DBName;
            data.DataSetID = Loginer.CurrentUser.DataSetID;
            frmModifyPwd.Execute(data, ModifyPwdType.UserManage);
        }

        private void ShowSummary()
        {
            try
            {
                _DataProxy.GetUsers();
                DoBindingSummaryGrid(_DataProxy.SummaryTable); //绑定主表的Grid
                ShowSummaryPage(true); //显示Summary页面. 
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }
        }

        public override void DoAdd(IButtonInfo sender)
        {
            try
            {
                _DataProxy.CreateDataBinder(null);
                DoBindingSummaryEditor(_DataProxy.DataBinder); //显示主表记录详细资料                            
                base.DoAdd(sender);
                txtPassword1.Text = "123456"; //default password
                txtPassword2.Text = "123456";
                ShowDetailPage(true);
            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        public override void DoDelete(IButtonInfo sender)
        {
            try
            {
                if (!Msg.AskQuestion("真的要删除?")) return;

                AssertFocusedRow();

                DataRow summary = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
                bool b = _DataProxy.Delete(summary[tb_sys_User.FAccount].ToString());
                AssertEqual(b, true, "删除记录时发生错误!");
                bllComDataBaseTool.WriteLogOp(_FunctionID, "0", "删除用户：" + summary[tb_sys_User.FAccount].ToString());
                base.DoDelete(sender);
                this.DeleteSummaryRow(_SummaryView.FocusedRowHandle);//删除Summary资料行
                if (_SummaryView.FocusedRowHandle < 0) //删除了最後一条记录. 显示Summary页面.
                    ShowSummaryPage(true);
                else
                {
                    _DataProxy.CreateDataBinder(_SummaryView.GetDataRow(_SummaryView.FocusedRowHandle));
                    DoBindingSummaryEditor(_DataProxy.DataBinder); //显示主表记录详细资料                                                                            
                    base.DoDelete(sender);
                }
            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        public override void DoEdit(IButtonInfo sender)
        {
            try
            {
                AssertFocusedRow();
                base.DoEdit(sender);
                DoViewContent(sender);
                ShowDetailPage(true);
            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        //当用户在Summary页选择一条记录. 显示当前记录的详细资料及明细表资料.
        public override void DoViewContent(IButtonInfo sender)
        {
            try
            {
                AssertFocusedRow(); //检查有无记录.                                
                _DataProxy.CreateDataBinder(_SummaryView.GetDataRow(_SummaryView.FocusedRowHandle));
                Exception.Equals(_DataProxy.DataBinder, null);
                base.DoViewContent(sender);
                DoBindingSummaryEditor(_DataProxy.DataBinder); //显示主表记录详细资料       
                string account = ConvertEx.ToString(_DataProxy.DataBinder.Rows[0][tb_sys_User.FAccount]);
                DataBinder.BindingListBoxLookupData(this.lbMyGroups, _DataProxy.GetUserGroups(account), tb_sys_UserGroup.FName);
                ShowDetailPage(false); //用户点击ViewContent按钮可以显示Summary页                
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }


        public override void DoCancel(IButtonInfo sender)
        {
            if (Msg.AskQuestion("要取消修改吗?"))
                base.DoCancel(sender);
        }

        /// <summary>
        /// 改变按钮状态
        /// </summary>
        /// <param name="currentState"></param>
        protected override void ButtonStateChanged(UpdateType currentState)
        {
            this.SetDetailEditorsAccessable(gcDetailEditor, this.DataChanged);

            //新增状态下显示密码输入框
            gcPassword.Visible = UpdateType.Add == currentState;

            //管理员能锁定用户
            chkIsLocked.Enabled = Loginer.CurrentUser.IsAdmin();

            txtLoginCounter.Properties.ReadOnly = true;
            txtLastLogoutTime.Properties.ReadOnly = true;

            //仅管理员可以给用户分配帐套
            ucDataSets.Enabled = this.IsAddOrEditMode && Loginer.CurrentUser.IsAdmin();
        }

        protected override void SetDetailEditorsAccessable(Control panel, bool value)
        {
            base.SetDetailEditorsAccessable(gcDetailEditor, value);
            txtAccount.Enabled = (_UpdateType != UpdateType.Modify && value);//号码不充许修改.

            gcPassword.Visible = _UpdateType == UpdateType.Add; //只能新增用戶時輸入密碼
        }

        public override void DoSave(IButtonInfo sender)
        {
            try
            {
                UpdateLastControl();

                //保存數據前如修改了原始數據，必需復製數據用于保存．
                _DataProxy.DataBinder.AcceptChanges();
                DataTable forSave = _DataProxy.DataBinder.Copy();
                if (!ValidatingData(forSave.Rows[0])) return;

                //新增用户时可设置密码，修改状态不支持改密码。
                if (UpdateType.Add == _UpdateType)
                {
                    forSave.Rows[0][tb_sys_User.FPassword] = CEncoder.Encode(txtPassword2.Text); //可以选择MD5加密

                    forSave.Rows[0][tb_sys_User.FID] = BridgeFactory.CreateCommonServiceBridge().GetTableID(tb_sys_User.__TableName,tb_sys_User.__KeyName);
                }

                bool ret = _DataProxy.Update(forSave, _UpdateType);
                if (ret)
                {
                    UpdateSummaryRow(forSave.Rows[0]); //刷新表格内的数据.                    
                    _DataProxy.SummaryTable.AcceptChanges();
                    string sFdes = (_UpdateType == UpdateType.Add ? "新增" : "修改") + "用户" + forSave.Rows[0][tb_sys_User.FUserName] + "(" + forSave.Rows[0][tb_sys_User.FAccount] + ")";
                    bllComDataBaseTool.WriteLogOp(_FunctionID, "0", sFdes);
                    base.DoSave(sender);
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

        // 检查主表数据是否完整或合法
        private bool ValidatingData(DataRow summary)
        {
            if (txtAccount.Text == string.Empty)
            {
                Msg.Warning("请输入用户编号!");
                txtAccount.Focus();
                return false;
            }

            if (txtUserName.Text == string.Empty)
            {
                Msg.Warning("请输入用户名!");
                txtUserName.Focus();
                return false;
            }

            if (_UpdateType == UpdateType.Add)
            {

                //新增状态输入密码, 如果密码不匹配, 提示信息
                if (txtPassword1.Text.Trim() == "" || txtPassword2.Text.Trim() == ""
                     || (txtPassword1.Text.Trim() != txtPassword2.Text.Trim()))
                {
                    Msg.Warning("两次输入密码不正确!");
                    txtPassword1.Focus();
                    return false;
                }
            }

            if (_UpdateType == UpdateType.Add)
            {
                if (_DataProxy.CheckNoExists(txtAccount.Text))
                {
                    Msg.Warning("用户名已存在!");
                    txtAccount.Focus();
                    return false;
                }
            }

            return true;
        }

        protected void DoBindingSummaryEditor(object summary)
        {
            try
            {
                if (summary == null) return;

                DataBinder.BindingTextEdit(txtAccount, summary, tb_sys_User.FAccount);
                DataBinder.BindingTextEdit(txtNovellAccount, summary, tb_sys_User.FNovellAccount);
                DataBinder.BindingTextEdit(txtDomainName, summary, tb_sys_User.FDomainName);
                DataBinder.BindingTextEdit(txtUserName, summary, tb_sys_User.FUserName);
                DataBinder.BindingTextEdit(txtTel, summary, tb_sys_User.FTel);
                DataBinder.BindingTextEdit(txtEmail, summary, tb_sys_User.FMail);
                DataBinder.BindingCheckEdit(chkIsLocked, summary, tb_sys_User.FIsLocked);
                DataBinder.BindingTextEdit(txtLastLogoutTime, summary, tb_sys_User.FLastLogoutTime);
                DataBinder.BindingTextEdit(txtLoginCounter, summary, tb_sys_User.FLoginCounter);
                DataBinder.BindingControl(ucDataSets, summary, tb_sys_User.FDataSets, "EditValue");
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        public override void DoPrint(IButtonInfo button)
        {
            //DevExpress Report DEMO
            //new frmRpTUserList().ShowDialog();

            //FastReport DEMO
            //new frmReporTUser().ShowDialog();
        }

    }
}

