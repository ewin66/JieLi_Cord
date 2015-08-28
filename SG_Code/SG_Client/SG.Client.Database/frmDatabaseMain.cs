
///*************************************************************************/
///*
///* 文件名    ：frmDatabaseMain.cs    
///*
///* 程序说明  :  数据字典模块主窗体(演示用)
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using SG.Interfaces;
using SG.Client.Library;
using SG.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace SG.Client.Database
{
    /// <summary>
    /// 数据字典模块主窗体(演示用)
    /// </summary>
    public partial class frmDatabaseMain : frmModuleBase
    {
        public frmDatabaseMain()
        {
            InitializeComponent();

            _ModuleID = ModuleID.DataBase; //设置模块编号
            _ModuleName = ModuleNames.DataBase;//设置模块名称
            menuMainDataDict.Text = ModuleNames.DataBase; //与AssemblyModuleEntry.ModuleName定义相同
            menuDatabaseSet.Click += menuDatabaseSet_Click;
            this.MainMenuStrip = this.menuStrip1;

            this.SetMenuTag();
        }

       

        public override MenuStrip GetModuleMenu()
        {
            return this.menuStrip1;
        }

        /// <summary>
        /// 设置菜单的权限，窗体的可用权限
        /// 请参考MenuItemTag类定义
        /// </summary>
        private void SetMenuTag()
        {
            menuMainDataDict.Tag = new MenuItemTag(MenuType.ItemOwner, (int)ModuleID.DataBase, AuthorityCategory.NONE);
            menuDataBaseCust.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
            menuDataBaseDep.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
            menuDataBaseEmp.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
            menuDataBaseItem.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
            menuDataBaseStock.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
            menuDataBaseSuply.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
            menuDatabaseSet.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
            menuCommonDataDict.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
            menuProductiondataBom.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
            menuProductiondataProcess.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
            menuProductiondataRouter.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
            menuProductiondataWorkCenter.Tag = new MenuItemTag(MenuType.DataForm, (int)ModuleID.DataBase, AuthorityCategory.MASTER_ACTION);
        }

        /// <summary>
        /// 设置模块主界面的按钮访问权限
        /// </summary>        
        public override void SetSecurity(object securityInfo)
        {
            base.SetSecurity(securityInfo);

            if (securityInfo is ToolStrip)
            {
               // btnSales.Enabled = menuSales.Enabled;
                btnCommonDataDict.Enabled = menuCommonDataDict.Enabled;
              //  btnCustomer.Enabled = menuItemCustomer.Enabled;
             //   btnProduct.Enabled = menuProduct.Enabled;
            }
        }

        // 菜单的Click事件与按钮的Click事件绑定同一个事件.
        private void menuItemCustomer_Click(object sender, EventArgs e)
        {
            //MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmCustomer), menuItemCustomer);
        }

        private void menuSales_Click(object sender, EventArgs e)
        {
            //MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmPerson), menuSales);
        }

        private void menuCommonDataDict_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmCommonDataDict), menuCommonDataDict);
            else
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmCommonDataDict), menuCommonDataDict as ToolStripMenuItem, this.menuCommonDataDict.Name);

        }

        private void menuProduct_Click(object sender, EventArgs e)
        {
            //MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmProduct), menuProduct);
        }

        private void menuLevel3_Click(object sender, EventArgs e)
        {
            Msg.ShowInformation("三级菜单打开窗体");
        }

        private void menuItemTestChild_Click(object sender, EventArgs e)
        {
            //MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmTestChild), menuItemTestChild);
        }

        void menuDatabaseSet_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmDatabaseSet), menuDatabaseSet);
            else
                MdiTools.OpenChildForm(this.MdiParent as IMdiForm, typeof(frmDatabaseSet), menuDatabaseSet as ToolStripMenuItem, this.menuDatabaseSet.Name);

        }
    }
}

