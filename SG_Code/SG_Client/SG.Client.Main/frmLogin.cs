
///*************************************************************************/
///*
///* 文件名    ：frmLogin.cs                                      
///* 程序说明  : 登录窗体
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
using System.Threading;
using System.Windows.Forms;
using System.IO;
using SG.Client.Library;
using SG.Client.Core;
using SG.Client.Bridge;
using SG.Common;
using SG.Interfaces.Base;
using SG.Interfaces;
using SG.Business;
using SG.Business.Base;


namespace SG.Client.Main
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class frmLogin : frmBase
    {
        private ILoginAuthorization _CurrentAuthorization = null;//当前授权模式

        /// <summary>
        /// 私有构造器
        /// </summary>
        private frmLogin()
        {
            InitializeComponent();
            rdCard.Click += new EventHandler(rdCard_Click);
            rdUser.Click += new EventHandler(rdUser_Click);
            cmbOrg.EditValueChanged += cmbOrg_EditValueChanged;
            timer1.Tick += timer1_Tick;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            InitLoginWindow(); //初始化登陆窗体
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            VerifyUserByCard();
        }

        private void VerifyUserByCard()
        {
            try
            {
                timer1.Stop();
                if (string.IsNullOrEmpty(txtCardNo.Text))
                {
                    txtCardNo.Text = "";
                    txtCardNo.Focus();
                    lblInfo.Text = "请刷卡。。。";
                    timer1.Start();
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                this.SetButtonEnable(false);
                this.Update();//必须
                this.ShowLoginInfo("正在验证卡号");

                string cardNo = CEncoder.Encode(txtCardNo.Text);/*常规加密*/
                string dataSetID = cmbDataset.EditValue.ToString();//帐套编号
                string dataSetDB = GetDataSetDBName();
                string DbType = GetDataDbType();
                string dbName = GetDBName();
                LoginUser loginUser = new LoginUser(cardNo, dataSetID, dataSetDB);
                loginUser.DbType = DbType;
                loginUser.DBName = dbName;

                Loginer.CurrentUser.DbType = DbType;
                Loginer.CurrentUser.DBName = dbName;

                if (_CurrentAuthorization.LoginByCard(loginUser)) //调用登录策略
                {
                    //if (chkSaveLoginInfo.Checked) 
                    this.SaveLoginInfo();//跟据选项保存登录信息                    
                    SystemAuthentication.Current = _CurrentAuthorization; //授权成功, 保存当前授权模式
                    Program.MainForm = new frmMain();//登录成功创建主窗体                    
                    Program.MainForm.InitUserInterface(new LoadStatus(lblLoadingInfo));

                    this.DialogResult = DialogResult.OK; //成功
                    this.Close(); //关闭登陆窗体
                }
                else
                {
                    txtCardNo.Text = "";
                    txtCardNo.Focus();
                    lblInfo.Text = "登录失败，请检查卡号！";
                    timer1.Start();
                    this.ShowLoginInfo("登录失败，请检查卡号!");
                    //Msg.Warning("登录失败，请检查卡号!");
                }
            }
            catch (CustomException ex)
            {
                this.SetButtonEnable(true);
                this.ShowLoginInfo(ex.Message);
                Msg.Warning(ex.Message);

                txtCardNo.Text = "";
                txtCardNo.Focus();
                lblInfo.Text = "登录失败，请检查卡号！";
                timer1.Start();
            }
            catch (Exception ex)
            {
                this.SetButtonEnable(true);
                this.ShowLoginInfo("登录失败，请检查卡号!" + ex.Message);
                Msg.Warning("登录失败，请检查卡号!" + ex.Message);

                txtCardNo.Text = "";
                txtCardNo.Focus();
                lblInfo.Text = "登录失败，请检查卡号！";
                timer1.Start();
            }

            this.Cursor = Cursors.Default;
        }

        void cmbOrg_EditValueChanged(object sender, EventArgs e)
        {
            DataRowView dv = cmbOrg.GetSelectedDataRow() as DataRowView;
            string sOrgID = dv["FID"].ToString();
            BindingDataSet(sOrgID);
        }

        void rdUser_Click(object sender, EventArgs e)
        {
            setLogin(false);
        }

        void rdCard_Click(object sender, EventArgs e)
        {
            setLogin(true);
        }

        private void setLogin(Boolean isCard)
        {
            if (isCard)
            {
                rdCard.Checked = true;
                rdUser.Checked = false;

                btnLogin.Visible = false;
                lblInfo.Visible = true;
                label1.Visible = false;
                label2.Visible = false;
                txtPwd.Visible = false;
                txtUser.Visible = false;
                //chkSaveLoginInfo.Visible = false;
                btnModifyPwd.Visible = false;
                txtCardNo.Visible = true;
                txtCardNo.Focus();
                timer1.Start();
            }
            else
            {
                rdCard.Checked = false;
                rdUser.Checked = true;

                btnLogin.Visible = true;
                lblInfo.Visible = false;
                label1.Visible = true;
                label2.Visible = true;
                txtPwd.Visible = true;
                txtUser.Visible = true;
                //chkSaveLoginInfo.Visible = true;
                btnModifyPwd.Visible = true;
                txtCardNo.Visible = false;
                txtPwd.Focus();
                timer1.Stop();
            }
        }

        /// <summary>
        /// 显示登陆窗体.(公共静态方法)
        /// </summary>        
        public static bool Login()
        {
            frmLogin form = new frmLogin();
            DialogResult result = form.ShowDialog();
            bool ret = (result == DialogResult.OK) && (SystemAuthentication.Current != null);
            return ret;
        }

        /// <summary>
        /// 初始化登陆窗体, 创建登录策略
        /// </summary>
        private void InitLoginWindow()
        {
            rdUser.Checked = true;
            timer1.Interval = 2000;

            this.BindingOrganization(); //绑定组织机构
            //this.BindingDataSet();//绑定帐套数据源
            this.ReadLoginInfo(); //读取保存的登录信息
            this.Text += " (后台连接:" + BridgeFactory.BridgeType.ToString() + ")";

            SystemAuthentication.Current = null;

            LoginAuthType authType = (LoginAuthType)SystemConfig.CurrentConfig.LoginAuthType; //系统设置
            if (authType == LoginAuthType.LocalSystemAuth)
            {
                _CurrentAuthorization = new LoginSystemAuth();
                btnLogin.Text = "登录 (&L)";
                this.Update();//自动显示窗体
            }
            else if (authType == LoginAuthType.NovellUserAuth)
            {
                _CurrentAuthorization = new LoginNovellAuth(txtUser, lblLoadingInfo);
                btnLogin.Text = "Novell自动登录";

                this.txtPwd.Enabled = false;
                this.txtUser.Enabled = false;
                this.Visible = true;
                this.Update();//自动显示窗体

                btnLogin.PerformClick();//直接登录系统
            }
            else if (authType == LoginAuthType.WindowsDomainAuth)
            {
                _CurrentAuthorization = new LoginWindowsDomainAuth(txtUser, lblLoadingInfo);
                btnLogin.Text = "域用户自动登录";

                this.txtPwd.Enabled = false;
                this.txtUser.Enabled = false;
                this.Visible = true;
                this.Update();//自动显示窗体 

                btnLogin.PerformClick();//直接登录系统
            }
            else //不明类型,禁止登录
            {
                pcInputArea.Enabled = false;
                btnLogin.Enabled = false;
            }

        }

        private void ReadLoginInfo()
        {
            //存在用户配置文件，自动加载登录信息
            string cfgINI = Application.StartupPath + BridgeFactory.INI_CFG;
            if (File.Exists(cfgINI))
            {
                IniFile ini = new IniFile(cfgINI);
                chkSaveLoginInfo.Checked = ini.IniReadValue("LoginWindow", "SaveLogin") == "Y";
                if (chkSaveLoginInfo.Checked)
                {
                    cmbOrg.EditValue = ini.IniReadValue("LoginWindow", "OrganizationID");

                    BindingDataSet((cmbOrg.GetSelectedDataRow() as DataRowView)["FID"].ToString());
                    cmbDataset.EditValue = ini.IniReadValue("LoginWindow", "DataSetID");
                }

                if (ini.IniReadValue("LoginWindow", "LoginMode") == "0") //用户名登录
                {
                    setLogin(false);
                    txtUser.Text = ini.IniReadValue("LoginWindow", "User");
                    txtPwd.Text = CEncoder.Decode(ini.IniReadValue("LoginWindow", "Password"));
                    
                }
                else //刷卡登录
                {
                    setLogin(true);
                }
            }
        }

        private void SaveLoginInfo()
        {
            //存在用户配置文件，自动加载登录信息
            string cfgINI = Application.StartupPath + BridgeFactory.INI_CFG;

            IniFile ini = new IniFile(cfgINI);
            ini.IniWriteValue("LoginWindow", "SaveLogin", chkSaveLoginInfo.Checked ? "Y" : "N");
            if (chkSaveLoginInfo.Checked)
            {
                ini.IniWriteValue("LoginWindow", "OrganizationID", cmbOrg.EditValue.ToString());
                ini.IniWriteValue("LoginWindow", "DataSetID", cmbDataset.EditValue.ToString());

                if (rdUser.Checked) //用户名登录
                {
                    ini.IniWriteValue("LoginWindow", "User", txtUser.Text);
                    ini.IniWriteValue("LoginWindow", "Password", CEncoder.Encode(txtPwd.Text));
                    ini.IniWriteValue("LoginWindow", "LoginMode", "0");
                }
                else //刷卡登录
                {
                    ini.IniWriteValue("LoginWindow", "User", "");
                    ini.IniWriteValue("LoginWindow", "Password", "");
                    ini.IniWriteValue("LoginWindow", "LoginMode", "1");
                }
            }
            else
            {
                ini.IniWriteValue("LoginWindow", "OrganizationID", "-1");
                ini.IniWriteValue("LoginWindow", "DataSetID", "-1");
                ini.IniWriteValue("LoginWindow", "User", "");
                ini.IniWriteValue("LoginWindow", "Password", "");
                if (rdUser.Checked) //用户名登录
                {
                    ini.IniWriteValue("LoginWindow", "LoginMode", "0");
                }
                else //刷卡登录
                {
                    ini.IniWriteValue("LoginWindow", "LoginMode", "1");
                }
            }
        }

        private void BindingOrganization()
        {
            IBridge_CommonService bridge = BridgeFactory.CreateCommonServiceBridge();
            DataTable data = bridge.GetSystemOrganization();
            DataBinder.BindingLookupEditDataSource(cmbOrg, data, "FNAME", "FNUMBER");
        }

        private void BindingDataSet(string sOrgID)
        {
            IBridge_CommonService bridge = BridgeFactory.CreateCommonServiceBridge();
            DataTable data = bridge.GetSystemDataSetByOrg(sOrgID);
            DataBinder.BindingLookupEditDataSource(cmbDataset, data, "FNAME", "FNUMBER");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.SetButtonEnable(false);
                this.Update();//必须
                this.ShowLoginInfo("正在验证用户名及密码");

                bllUser.ValidateLogin(txtUser.Text, txtPwd.Text);//检查登录信息

                string userID = txtUser.Text;
                string password = CEncoder.Encode(txtPwd.Text);/*常规加密*/
                string dataSetID = cmbDataset.EditValue.ToString();//帐套编号
                string dataSetDB = GetDataSetDBName();
                string DbType = GetDataDbType();
                string dbName = GetDBName();
                LoginUser loginUser = new LoginUser(userID, password, dataSetID, dataSetDB);
                loginUser.DbType = DbType;
                loginUser.DBName = dbName;

                Loginer.CurrentUser.DbType = DbType;
                Loginer.CurrentUser.DBName = dbName;

                if (_CurrentAuthorization.Login(loginUser)) //调用登录策略
                {
                    //if (chkSaveLoginInfo.Checked) 
                    this.SaveLoginInfo();//跟据选项保存登录信息                    
                    SystemAuthentication.Current = _CurrentAuthorization; //授权成功, 保存当前授权模式
                    Program.MainForm = new frmMain();//登录成功创建主窗体                    
                    Program.MainForm.InitUserInterface(new LoadStatus(lblLoadingInfo));

                    this.DialogResult = DialogResult.OK; //成功
                    this.Close(); //关闭登陆窗体
                }
                else
                {
                    this.ShowLoginInfo("登录失败，请检查用户名和密码!");
                    Msg.Warning("登录失败，请检查用户名和密码!");
                }
            }
            catch (CustomException ex)
            {
                this.SetButtonEnable(true);
                this.ShowLoginInfo(ex.Message);
                Msg.Warning(ex.Message);
            }
            catch (Exception ex)
            {
                this.SetButtonEnable(true);
                this.ShowLoginInfo("登录失败，请检查用户名和密码!" + ex.Message);
                Msg.Warning("登录失败，请检查用户名和密码!" + ex.Message);
            }

            this.Cursor = Cursors.Default;
        }

        private string GetDataSetDBName()
        {
            DataRowView view = (DataRowView)cmbDataset.Properties.GetDataSourceRowByKeyValue(cmbDataset.EditValue);
            return ConvertEx.ToString(view.Row["FDatabase"]);
        }
        /// <summary>
        /// 选择的帐套编号
        /// </summary>
        /// <returns></returns>
        private string GetDBName()
        {
            DataRowView view = (DataRowView)cmbDataset.Properties.GetDataSourceRowByKeyValue(cmbDataset.EditValue);
            return ConvertEx.ToString(view.Row["FNumber"]);
        }
        private string GetDataDbType()
        {
            DataRowView view = (DataRowView)cmbDataset.Properties.GetDataSourceRowByKeyValue(cmbDataset.EditValue);
            return ConvertEx.ToString(view.Row["FSign"]);
        }
        private void ShowLoginInfo(string info)
        {
            lblLoadingInfo.Text = info;
            lblLoadingInfo.Update();
        }

        private void SetButtonEnable(bool value)
        {
            btnLogin.Enabled = value;
            btnCancel.Enabled = value;
            btnLogin.Update();
            btnCancel.Update();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Msg.AskQuestion("确定要退出系统吗？")) Application.Exit();
        }

        private void btnModifyPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginUser user = new LoginUser();
            user.Account = txtUser.Text;
            user.DataSetID = cmbDataset.EditValue.ToString();
            user.DataSetDBName = GetDBName();
            frmModifyPwd.Execute(user, ModifyPwdType.LoginWindowDirect);
        }
    }
}