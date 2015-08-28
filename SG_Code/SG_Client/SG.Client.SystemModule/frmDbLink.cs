///*************************************************************************/
///*
///* 文件名    ：frmDbLink.cs        
///
///* 程序说明  : 数据库连接管理的界面层
///               
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using DevExpress.XtraEditors.Repository;
using SG.Business;
using SG.Business.Base;
using SG.Client.Library;
using SG.Common;
using SG.Interfaces;
using SG.Models.Base;
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
    public partial class frmDbLink : frmBaseDataForm
    {
        private bllDbLink _DataProxy = new bllDbLink();
        DataTable tblDataType = new DataTable("DbType");
        bool IsTestOK = false;
        /// <summary>
        /// 数据库连接字头，放置帐套中的数据库连接与帐套管理的数据连接重码
        /// </summary>
        private string sHead = "DbLink-";
        public frmDbLink()
        {
            InitializeComponent();
            SetDbTypeLookUpEdit();
            InitializeForm();
            this.Load += frmDbLink_Load;
            //lookUpDataBase.Click += lookUpDataBase_Click;
            txtDbType.EditValueChanged += txtDbType_EditValueChanged;
            txtServer.LostFocus += txtServer_LostFocus;
            txtUserName.LostFocus += txtUserName_LostFocus;
            txtPwd.LostFocus += txtPwd_LostFocus;
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

        void txtPwd_LostFocus(object sender, EventArgs e)
        {
            SetDataBase();
        }

        void txtUserName_LostFocus(object sender, EventArgs e)
        {
            SetDataBase();
        }

        void txtServer_LostFocus(object sender, EventArgs e)
        {
            SetDataBase();
        }

        void txtDbType_EditValueChanged(object sender, EventArgs e)
        {
            if(txtDbType.Text.ToUpper().Contains("ORACLE"))
            {
                SetDataBase();
            }
        }


        void frmDbLink_Load(object sender, EventArgs e)
        {
            this.InitButtons();
            this.SetViewMode();
            this.SetButtonAuthority();
            //if (_FormMenuName != string.Empty)
            //    this._FunctionID = bllComDataBaseTool.GetFunctionID(this._FormMenuName);
            this.Tag = this._FunctionID;
        }

        /// <summary>
        /// 扩展窗体的按钮，新增工资按钮。
        /// </summary>
        public override void InitButtons()
        {
            base.InitButtons();
            //bool salaryRight = (ButtonAuthority.EX_01 & this.FormAuthorities) == ButtonAuthority.EX_01;
            //if (salaryRight)
            //{
                //创建“查看工资”按钮
            if (ButtonIsShow("btnTest"))
            {
                IButtonInfo btnTest = this.ToolbarRegister.CreateButton("btnTest", "测试连接",
                Globals.LoadBitmap("skin16.ico"), new Size(57, 28), this.OnTestConnect);//按钮的事件
                //在Toolbar上显示
                this._buttons.AddRange(new IButtonInfo[] { btnTest });
            }
            //}
        }

        protected override void InitializeForm()
        {
            try
            {
                _SummaryView = new DevGridView(gvSummary);
                _ActiveEditor = txtNum;
                _DetailGroupControl = gcDetailEditor;
                gvSummary.DoubleClick += new EventHandler(OnGridViewDoubleClick); //主表DoubleClict

                frmGridCustomize.RegisterGrid(gvSummary);
                //frmGridCustomize.AddMenuItem(gvSummary, "测试连接", null, OnTestConnect, true);

                DevStyle.SetGridControlLayout(gcSummary, false);//表格设置   
                DevStyle.SetSummaryGridViewLayout(gvSummary);


              
                ShowSummary(); //下载显示数据.
                BindingSummaryNavigator(controlNavigatorSummary, gcSummary); //Summary导航条.
                ShowSummaryPage(true); //一切初始化完毕後显示SummaryPage        
            }
            catch (Exception ex) { Msg.ShowException(ex); }
        }

        public override void DoSave(IButtonInfo sender)
        {
            try
            {
                if (txtNum.Text == string.Empty)
                {
                    Msg.ShowError("编号不能为空！");
                    txtNum.Focus();
                    return;
                }
                if (txtName.Text == string.Empty)
                {
                    Msg.ShowError("名称不能为空！");
                    txtName.Focus();
                    return;
                }

                if (_UpdateType == UpdateType.Add)
                    if (bllComDataBaseTool.GetTableFieldValue(tb_sys_DbLink.__TableName, tb_sys_DbLink.__KeyName, tb_sys_DbLink.FNumber + "='" + sHead + txtNum.Text + "'") != string.Empty)
                    {
                        Msg.ShowError("编号不能相同，请重新输入编号！");
                        txtNum.Focus();
                        return;
                    }

                UpdateLastControl();

                //保存數據前如修改了原始數據，必需復製數據用于保存．
                _DataProxy.DataBinder.AcceptChanges();
                DataTable forSave = _DataProxy.DataBinder.Copy();
                string sType = txtDbType.GetColumnValue("Sign").ToString();
                if (!bllComDataBaseTool.TestConnection(sType, txtServer.Text, lookUpDataBase.Text, txtUserName.Text, txtPwd.Text))
                {
                    Msg.ShowError("测试没有通过，不能保存！");
                    return;
                }
                //新增用户时可设置密码，修改状态不支持改密码。
                string sSaveDesc = "";
                forSave.Rows[0][tb_sys_DbLink.FNumber] = sHead + txtNum.Text;
                forSave.Rows[0][tb_sys_DbLink.FPwd] = CEncoder.Encode(txtPwd.Text); //可以选择MD5加密 
                forSave.Rows[0][tb_sys_DbLink.FUserID] = Loginer.CurrentUser.Fid;
                if (_UpdateType == UpdateType.Add)
                {
                    forSave.Rows[0][tb_sys_DbLink.__KeyName] = bllComDataBaseTool.GetTableID(tb_sys_DbLink.__TableName, tb_sys_DbLink.__KeyName);
                    sSaveDesc = "新增";
                }
                else
                    sSaveDesc = "修改";
                sSaveDesc += forSave.Rows[0][tb_sys_DbLink.FName] + "(" + forSave.Rows[0][tb_sys_DbLink.FNumber] + ")成功";
                bool ret = _DataProxy.Update(forSave, _UpdateType);
                if (ret)
                {
                    UpdateSummaryRow(forSave.Rows[0]); //刷新表格内的数据. 
                    _DataProxy.DataBinder.Rows[0][tb_sys_DbLink.FNumber] = sHead + txtNum.Text;
                    _DataProxy.DataBinder.Rows[0][tb_sys_DbLink.FPwd] = CEncoder.Encode(txtPwd.Text); 
                    _DataProxy.SummaryTable.AcceptChanges();
                    base.DoSave(sender);
                    bllComDataBaseTool.WriteLogOp(_FunctionID, "0", sSaveDesc); //日志
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

        /// <summary>
        /// 测试数据连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnTestConnect(SG.Interfaces.IButtonInfo sender)
        {
            if(txtServer.Text==string.Empty)
            {
                Msg.Warning("请输入服务器名！");
                txtServer.Focus();
            }
            if(txtUserName.Text==string.Empty)
            {
                Msg.Warning("请输入用户名！");
                txtUserName.Focus();
            }
            string sType = txtDbType.GetColumnValue("Sign").ToString();  //tblDataType.Rows[txtDbType.SelectionLength]["Sign"].ToString();
            if (bllComDataBaseTool.TestConnection(sType, txtServer.Text, lookUpDataBase.Text, txtUserName.Text, txtPwd.Text))
            {
                Msg.ShowInformation("测试成功！");
                IsTestOK = true;
            }
            else
            {
                Msg.Warning("测试失败！");
                IsTestOK = false;
            }
        }

        private void ShowSummary()
        {
            try
            {
                _DataProxy.GetDBLink();
                DoBindingSummaryGrid(_DataProxy.SummaryTable); //绑定主表的Grid
                ShowSummaryPage(true); //显示Summary页面. 
            }
            catch (Exception ex)
            {
                Msg.ShowException(ex);
            }
        }
        /// <summary>
        /// 设置数据类型下拉框
        /// </summary>
        private void SetDbTypeLookUpEdit()
        {
            txtDbType.Properties.Columns.Clear();
            //txtDbType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FID", 0, "FID"));
            txtDbType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 30, "数据类型"));
            txtDbType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sign", 30, "标志"));

            tblDataType.Columns.Add("FID", Type.GetType("System.Int32"));
            tblDataType.Columns[0].AutoIncrement = true;
            tblDataType.Columns[0].AutoIncrementSeed = 1;
            tblDataType.Columns[0].AutoIncrementStep = 1;

            tblDataType.Columns.Add("NAME", Type.GetType("System.String"));
            tblDataType.Columns.Add("Sign", Type.GetType("System.String"));


            tblDataType.Rows.Add(new object[] { null, "SQL Server 2005/2008/2012", "SQLServer" });
            tblDataType.Rows.Add(new object[] { null, "Oracle 9i/10g/11g", "Oracle" });
            //txtDbType.Properties.DataSource = tblDataType;
            //txtDbType.Properties.DisplayMember = "NAME";//要显示的字段      <br>   
            //txtDbType.Properties.ValueMember = "FID";//实际要用的字段
            DataBinder.BindingLookupEditDataSource(txtDbType, tblDataType, "NAME", "FID");
            txtDbType.Properties.NullText="请您选择";
            txtDbType.ItemIndex = 0;
            txtDbType.Update();
        }

        /// <summary>
        /// 设置数据库列表
        /// </summary>
        private void SetDataBase()
        {
            lookUpDataBase.Properties.Columns.Clear();
            if (txtDbType.Text.ToUpper().Contains("SQL"))
                if (txtServer.Text == string.Empty || txtUserName.Text == string.Empty || txtPwd.Text == string.Empty)
                    return;
            lookUpDataBase.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 50, "数据库"));
            DataTable tblDatas = new DataTable("DbType");
            tblDatas.Columns.Add("NAME", Type.GetType("System.String"));
           
            string[] sDblist;
            
            if (txtDbType.Text.ToUpper().Contains("SQL"))
            {
                string strDb = bllComDataBaseTool.GetSQLServerDbListString(txtServer.Text, txtUserName.Text, txtPwd.Text);
                if (strDb != string.Empty)
                {
                    sDblist = strDb.Split(',');
                    for (int i = 0; i < sDblist.Length; i++)
                    {
                        tblDatas.Rows.Add(new object[] { sDblist[i] });
                       
                    }
                }
            }
            else
            {
                sDblist = OracleTNS.iniOracleTNS();
                for (int i = 0; i < sDblist.Length; i++)
                {
                    tblDatas.Rows.Add(new object[] { sDblist[i] });
                    
                }
            }

            DataBinder.BindingLookupEditDataSource(lookUpDataBase, tblDatas, "NAME", "NAME");
                

        }

        /// <summary>
        /// 设置数据库列表
        /// </summary>
        private void SetDataBaseLookUp(string sDbtype,string SServer,string sUser,string sPwd)
        {
            lookUpDataBase.Properties.Columns.Clear();
            if (sDbtype == string.Empty)
                return;
            if (sDbtype.ToUpper().Contains("SQL"))
                if (SServer == string.Empty || sUser == string.Empty || sPwd == string.Empty)
                    return;
            lookUpDataBase.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", 50, "数据库"));
            DataTable tblDatas = new DataTable("DbType");
            tblDatas.Columns.Add("NAME", Type.GetType("System.String"));

            string[] sDblist;

            if (sDbtype.ToUpper().Contains("SQL"))
            {
                string strDb = bllComDataBaseTool.GetSQLServerDbListString(SServer, sUser, sPwd);
                if (strDb != string.Empty)
                {
                    sDblist = strDb.Split(',');
                    for (int i = 0; i < sDblist.Length; i++)
                    {
                        tblDatas.Rows.Add(new object[] { sDblist[i] });

                    }
                }
            }
            else
            {
                sDblist = OracleTNS.iniOracleTNS();
                for (int i = 0; i < sDblist.Length; i++)
                {
                    tblDatas.Rows.Add(new object[] { sDblist[i] });

                }
            }

            DataBinder.BindingLookupEditDataSource(lookUpDataBase, tblDatas, "NAME", "NAME");


        }

        public override void DoAdd(IButtonInfo sender)
        {
            try
            {
                _DataProxy.CreateDataBinder(null);
                DoBindingSummaryEditor(_DataProxy.DataBinder); //显示主表记录详细资料                            
                base.DoAdd(sender);

                ShowDetailPage(true);
            }
            catch (Exception e)
            {
                Msg.ShowException(e);
            }
        }

        protected void DoBindingSummaryEditor(object summary)
        {
            try
            {                
                if (summary == null) return;


                if (((DataTable)summary).Rows.Count ==1)
                {
                    //去掉Head，填写到txtNum中

                    string strNum = ((DataTable)summary).Rows[0][tb_sys_DbLink.FNumber].ToString();
                    if (strNum.Contains(sHead))
                        ((DataTable)summary).Rows[0][tb_sys_DbLink.FNumber] = strNum.Substring(7, strNum.Length - 7);
                    //密码解密
                    string sPwd = ((DataTable)summary).Rows[0][tb_sys_DbLink.FPwd].ToString();
                    ((DataTable)summary).Rows[0][tb_sys_DbLink.FPwd] = CEncoder.Decode(sPwd);
                    //设置数据连接
                    SetDataBaseLookUp(((DataTable)summary).Rows[0]["DbType"].ToString(), ((DataTable)summary).Rows[0][tb_sys_DbLink.FServerName].ToString(), ((DataTable)summary).Rows[0][tb_sys_DbLink.FUser].ToString(), ((DataTable)summary).Rows[0][tb_sys_DbLink.FPwd].ToString());
                }

                DataBinder.BindingTextEdit(txtNum, summary, tb_sys_DbLink.FNumber);
                DataBinder.BindingTextEdit(txtName, summary, tb_sys_DbLink.FName);
                DataBinder.BindingTextEdit(txtServer, summary, tb_sys_DbLink.FServerName);
                DataBinder.BindingTextEdit(txtUserName, summary, tb_sys_DbLink.FUser);
                DataBinder.BindingTextEdit(txtPwd, summary, tb_sys_DbLink.FPwd);
                DataBinder.BindingTextEdit(txtDbType, summary, tb_sys_DbLink.FDataType);
                DataBinder.BindingTextEdit(lookUpDataBase, summary, tb_sys_DbLink.FDatabase);
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }
        public override void DoDelete(IButtonInfo sender)
        {
            try
            {
                if (!Msg.AskQuestion("真的要删除?")) return;

                AssertFocusedRow();

                DataRow summary = _SummaryView.GetDataRow(_SummaryView.FocusedRowHandle);
                string sSaveDesc = "删除" + summary[tb_sys_DbLink.FName] + "(" + summary[tb_sys_DbLink.FNumber] + ")成功";
                bool b = _DataProxy.Delete(summary[tb_sys_DbLink.__KeyName].ToString());
                AssertEqual(b, true, "删除记录时发生错误!");
                bllComDataBaseTool.WriteLogOp(_FunctionID, "0", sSaveDesc); //日志
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
              
                ShowDetailPage(false); //用户点击ViewContent按钮可以显示Summary页                
            }
            catch (Exception ex)
            { Msg.ShowException(ex); }
        }

        protected override void ButtonStateChanged(UpdateType currentState)
        {
            bool accessable = currentState == UpdateType.Add || currentState == UpdateType.Modify;
            base.SetDetailEditorsAccessable(gcDetailEditor, accessable);
            base.ButtonStateChanged(currentState);

           
        }
        public override void DoCancel(IButtonInfo sender)
        {
            if (Msg.AskQuestion("要取消修改吗?"))
            {
                _DataProxy.DataBinder.Rows[0][tb_sys_DbLink.FNumber] = sHead + txtNum.Text;
                _DataProxy.DataBinder.Rows[0][tb_sys_DbLink.FPwd] = CEncoder.Encode(txtPwd.Text); 
                base.DoCancel(sender);
            }
        }
    }
}
