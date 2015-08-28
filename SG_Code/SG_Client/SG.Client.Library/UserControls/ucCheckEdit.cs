﻿///*************************************************************************/
///*
///* 文件名    ：ucCheckEdit.cs                              
///* 程序说明  : 自定义CheckEdit控件
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///*************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SG.Client.Library.UserControls
{
    /// <summary>
    /// 自定义CheckEdit控件
    /// </summary>
    public partial class ucCheckEdit : UserControl
    {
        public ucCheckEdit()
        {
            InitializeComponent();
        }

        private void ucCheckEdit_SizeChanged(object sender, EventArgs e)
        {
            _ButtonEdit.Width = this.Width - _CheckEdit.Width;
        }

        private void ucCheckEdit_Load(object sender, EventArgs e)
        {
            ucCheckEdit_SizeChanged(this, e);
        }

        public TextEdit InnerEditor { get { return _ButtonEdit; } }
        public CheckEdit InnerCheckEdit { get { return _CheckEdit; } }

        public bool IsChecked { get { return _CheckEdit.Checked; } set { _CheckEdit.Checked = value; } }
        public string CheckText { get { return _ButtonEdit.Text; } set { _ButtonEdit.Text = value; } }

        public void SetValue(bool checkValue, string text)
        {
            _ButtonEdit.Text = text;
            _CheckEdit.Checked = checkValue;
        }

        private void _CheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            _ButtonEdit.Enabled = _CheckEdit.Checked;
        }

    }
}
