///*************************************************************************/
///*
///* 文件名    ：frmBase.cs                              
///* 程序说明  : 所有窗体基类,继承XtraForm用于设置皮肤
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///*************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SG.Common;
using SG.Interfaces;
using SG.Models.Base;
using SG.Business;
using System.IO;

namespace SG.Client.Library
{
    public partial class frmBase : XtraForm, IFormBase
    {
        public DevExpress.LookAndFeel.DefaultLookAndFeel DefaultLookAndFeel;
       
        public frmBase()
        {
            InitializeComponent();
            
            this.DefaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.LoadSkin();
            this.SetIcon();
        }

        #region IFormBase 成員

        /// <summary>
        /// 加载皮肤
        /// </summary>
        public void LoadSkin()
        {
            if (SystemConfig.CurrentConfig != null) SetSkin(SystemConfig.CurrentConfig.SkinName);
        }
       
        /// <summary>
        /// 设置窗体皮肤
        /// </summary>
        /// <param name="skinName">名称</param>
        public void SetSkin(string skinName)
        {
            this.DefaultLookAndFeel.LookAndFeel.SkinName = skinName;
        }

       

        /// <summary>
        /// 设置图标
        /// </summary>
        public void SetIcon()
        {
            if (File.Exists(Application.StartupPath + @"\image\logo.ico"))
            {
                Icon icon = new Icon(Application.StartupPath + @"\image\logo.ico");
                this.Icon = icon;
            }
        }

        #endregion
    }
}