///*************************************************************************/
///*
///* 文件名    ：ucDT_UserLookup.cs                              
///* 程序说明  : 用户Lookup自定义控件.
///* 原创作者  ：武汉金泰迪 XW Peng 
///* 
///* Copyright 2014-2015 武汉金泰迪信息技术有限公司
///*************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using JTD.Business;


namespace JTD.Client.Library.UserControls
{
    /// <summary>
    /// 用户Lookup自定义控件
    /// </summary>
    public partial class ucDT_UserLookup : UserControl
    {
        private string _ValueMember = "Account";
        private string _DisplayMember = "UserName";

        public ucDT_UserLookup()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return (string)this.EditValue;
            }
            set
            {
                this.EditValue = value;
            }
        }

        public object EditValue
        {
            get
            {
                return lookUpEdit.EditValue;
            }
            set
            {
                lookUpEdit.EditValue = value;
            }
        }

        [Description("下拉窗体的栏位列表")]
        public LookUpColumnInfoCollection VisibleColumns
        {
            get { return lookUpEdit.Properties.Columns; }
        }

        [Description("用于取值的字段名称")]
        public string defValueMember
        {
            get { return _ValueMember; }
            set { _ValueMember = value; }
        }

        [Description("用于显示的字段名称")]
        public string defDisplayMember
        {
            get { return _DisplayMember; }
            set { _DisplayMember = value; }
        }

        /// <summary>
        /// 获取客户数据
        /// </summary>
        public void DoRetriveData()
        {
            DataTable data = DataDictCache.Cache.User;
            this.DoBindingDataSource(data);
        }

        /// <summary>
        /// 绑定自定义数据
        /// </summary>
        /// <param name="datasource"></param>
        public void DoBindingDataSource(DataTable datasource)
        {
            lookUpEdit.Properties.Columns[1].FieldName = _DisplayMember;//客户名称
            lookUpEdit.Properties.ValueMember = _ValueMember;
            lookUpEdit.Properties.DisplayMember = _DisplayMember;
            lookUpEdit.Properties.DataSource = datasource;
        }
    }
}
