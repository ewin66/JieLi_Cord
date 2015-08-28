///*************************************************************************/
///*
///* 文件名    ：frmBaseDialog.cs                              
///* 程序说明  : 对话框窗体基类
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

namespace SG.Client.Library
{
    /// <summary>
    ///  对话框窗体基类. 
    /// </summary>
    public partial class frmBaseDialog : frmBase
    {
        public frmBaseDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
