///*************************************************************************/
///*
///* 文件名    ：frmSystemMain.cs                   
///* 程序说明  : 系统管理模块主窗体
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
using System.Reflection;
using DevExpress.XtraEditors;
using SG.Client.Library;
using SG.Interfaces;
using SG.Common;

namespace SG.Client.SystemModule
{
    /// <summary>
    /// 系统管理模块主窗体
    /// </summary>
    public partial class frmSystemMain : frmModuleBase
    {
        public frmSystemMain()
        {
            InitializeComponent();
            
            _ModuleID = ModuleID.SystemManage; //设置模块编号
            _ModuleName = ModuleNames.SystemManage;//设置模块名称
            menuStrip1.Text = ModuleNames.SystemManage; //与AssemblyModuleEntry.ModuleName定义相同
            menuItemDataBaseSet.Click += menuItemDataBaseSet_Click;            
            this.MainMenuStrip = this.menuStrip1;

            SetMenuTag();
        }


       

        public override MenuStrip GetModuleMenu()
        {
            return this.menuStrip1;
        }

        private void SetMenuTag()
        {
            menuSystemManager.Tag = new MenuItemTag(MenuType.ItemOwner, (int)ModuleID.SystemManage, AuthorityCategory.NONE);
            menuItemUserMgr.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SystemManage, AuthorityCategory.MASTER_ACTION);
            menuItemAuth.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SystemManage, AuthorityCategory.MASTER_ACTION);
            menuItemSetup.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SystemManage, AuthorityCategory.MASTER_ACTION);
            menuCompanyInfo.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SystemManage, AuthorityCategory.MASTER_ACTION);
            menuCustomMenuAuth.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SystemManage, AuthorityCategory.DATA_ACTION_VALUE + ButtonAuthority.EX_01);
            menuItemDataBaseSet.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.SystemManage, AuthorityCategory.MASTER_ACTION);
            menuItemlogRep.Tag = new MenuItemTag(MenuType.ItemOwner, (int)ModuleID.SystemManage, AuthorityCategory.NONE);
            menuItemLogOp.Tag = new MenuItemTag(MenuType.Report, (int)ModuleID.SystemManage, AuthorityCategory.REPORT_ACTION_VALUE);
            menuItemDataUpLog.Tag = new MenuItemTag(MenuType.Report, (int)ModuleID.SystemManage, AuthorityCategory.REPORT_ACTION_VALUE);
        }

        public override void SetSecurity(object securityInfo)
        {
            base.SetSecurity(securityInfo);

            if (securityInfo is ToolStrip)
            {
                //SetButtonSecurity(btnUser, menuItemUserMgr);
                //SetButtonSecurity(btnAuth, menuItemAuth);
                //SetButtonSecurity(btnSetup, menuItemSetup);
                //SetButtonSecurity(btnLog, menuLog);
                //SetButtonSecurity(btnCompanyInfo, menuCompanyInfo);
                //SetButtonSecurity(btnCustomMenuAuth, menuCustomMenuAuth);
            }
        }

        private void menuItemUserMgr_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmUser), sender as ToolStripMenuItem);
            else
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmUser), menuItemUserMgr as ToolStripMenuItem, this.menuItemUserMgr.Name);
        }

        private void menuItemAuth_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmGroup), sender as ToolStripMenuItem);
            else
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmGroup), menuItemAuth as ToolStripMenuItem, this.menuItemAuth.Name);
        }

        private void menuCompanyInfo_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmCompanyInfo), sender as ToolStripMenuItem);
            else
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmCompanyInfo), menuCompanyInfo as ToolStripMenuItem, this.menuCompanyInfo.Name);
        }

        private void menuCustomMenuAuth_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmMenuAuth), sender as ToolStripMenuItem);
            else
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmMenuAuth), menuCustomMenuAuth as ToolStripMenuItem, this.menuCustomMenuAuth.Name);
        }

        private void menuItemSetup_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmSystemProfile), sender as ToolStripMenuItem);
            else
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmSystemProfile), menuItemSetup as ToolStripMenuItem, this.menuItemSetup.Name);

        }

        private void menuLog_Click(object sender, EventArgs e)
        {
            //frmLogConfig.Execute("");
        }

       private void menuItemDataBaseSet_Click(object sender, EventArgs e)
       {
           if (sender is ToolStripMenuItem)
               MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmDbLink), sender as ToolStripMenuItem);
           else
               MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmDbLink), menuItemDataBaseSet as ToolStripMenuItem, this.menuItemDataBaseSet.Name);
       }

      
    }
}

