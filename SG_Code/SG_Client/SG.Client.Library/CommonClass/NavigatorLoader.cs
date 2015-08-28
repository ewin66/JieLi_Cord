///*************************************************************************/
///*
///* 文件名    ：NavigatorLoader.cs                            
///* 程序说明  : 导航组件生成器,由系统菜单自动生成导航组件
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraNavBar;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using SG.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG.Client.Library
{
    /// <summary>
    /// 导航组件样式
    /// </summary>
    public enum NavigatorStyle
    {
        /// <summary>
        /// 项目列表
        /// </summary>
        BarItem,

        /// <summary>
        /// 树形显示
        /// </summary>
        BarContainer
    }

    /// <summary>
    /// 导航组件生成器接口
    /// </summary>
    public interface INavigatorStyle
    {
        void CreateNavigator(MenuStrip mainMenu, NavBarControl navBar);
    }

    /// <summary>
    /// 导航组件生成器基类
    /// </summary>
    public class NavigatorBase : INavigatorStyle
    {

        /// <summary>
        /// 模块管理器, 主要用于获取所有已加载的模块列表
        /// </summary>
        protected ModuleManager _ModuleManager = null;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="moduleManager">模块管理器</param>
        public NavigatorBase(ModuleManager moduleManager)
        {
            _ModuleManager = moduleManager;
        }

        /// <summary>
        /// 实现接口, 创建NavBarControl组件
        /// </summary>
        /// <param name="mainMenu">系统主菜单</param>
        /// <param name="navBar">NavBarControl组件</param>
        public virtual void CreateNavigator(MenuStrip mainMenu, NavBarControl navBar)
        {
            try
            {
                navBar.BeginUpdate();
                navBar.Groups.Clear();
                navBar.Items.Clear();

                //枚举系统主菜单的模块菜单
                foreach (ToolStripMenuItem moduleMenu in mainMenu.Items)
                {
                    //取到菜单,然后递归所有子菜单项创建NavBarControl
                    if (moduleMenu != null && moduleMenu.Enabled)//创建该模块的NavBarButton.
                        this.CreateNavBarButton(navBar, moduleMenu, moduleMenu.Text);
                }

                //没有任何模块(Groups数目为0)则创建一个空的Group, 注:每个Group对应一个模块.
                if (navBar.Groups.Count == 0) navBar.Groups.Add(new NavBarGroup(""));

                navBar.EndUpdate();
            }
            catch (Exception ex) { Msg.ShowException(ex); }
        }

        /// <summary>
        /// 模板方法
        /// </summary>
        /// <param name="navBar">NavBarControl</param>
        /// <param name="moduleMenu">模块的主菜单</param>
        /// <param name="moduleDisplayName">模块的名称</param>
        protected virtual void CreateNavBarButton(NavBarControl navBar,
            ToolStripMenuItem moduleMenu, string moduleDisplayName) { }

        ///// <summary>
        ///// 当点击导航组件的组按钮时触发事件
        ///// </summary>
        //protected void OnActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        //{
        //    try
        //    {
        //        string moduleName = e.Group.Caption.ToString();

        //        //显示模块主窗体
        //        _ModuleManager.ActiveModule(moduleName);
        //    }
        //    catch (Exception ex) { Msg.ShowException(ex); }
        //}


        /// <summary>
        /// 点击导航分组按钮时触发该事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnNavBar_MouseClick(object sender, MouseEventArgs e)
        {
            NavBarControl nav = (sender as NavBarControl);//取到NavBarControl对象引用
            NavBarHitInfo hit = nav.CalcHitInfo(e.Location);//计算点击区域的对象
            if (hit.InGroup && hit.InGroupCaption)//点击导航分组按钮
            {
                try
                {
                    nav.ActiveGroup = hit.Group; //立即设置为激活的组
                    string moduleName = hit.Group.Caption.ToString();//取组按钮的标题(模块的名称)
                    _ModuleManager.ActiveModule(moduleName);//激活显示模块
                }
                catch (Exception ex)
                { Msg.ShowException(ex); }
            }
        }
    }

    /// <summary>
    /// 生成项目列表样式的导航组件
    /// </summary>
    public class NavigatorBarList : NavigatorBase
    {
        public NavigatorBarList(ModuleManager moduleManager) : base(moduleManager) { }

        /// <summary>
        /// 创建导航组件的组按钮(NavBarControl.NavBarGroup)
        /// </summary>
        /// <param name="navBar">NavBarControl对象</param>
        /// <param name="moduleMenu">模块主菜单</param>
        /// <param name="moduleDisplayName">模块名称</param>
        protected override void CreateNavBarButton(NavBarControl navBar, ToolStripMenuItem moduleMenu, string moduleDisplayName)
        {
            //绑定事件,当组按钮的Index改变时触发
            //navBar.ActiveGroupChanged += new NavBarGroupEventHandler(this.OnActiveGroupChanged);
            navBar.MouseClick += new MouseEventHandler(this.OnNavBar_MouseClick);

            NavBarGroup group = CreateNavBarGroup(navBar, moduleDisplayName); //根据模块名创建NavBarGroup(组按钮)

            //创建组的子按钮
            foreach (ToolStripItem menuItem in moduleMenu.DropDownItems)
            {
                if (menuItem is ToolStripSeparator) continue;
                if (MenuStripUtils.IsSubMenuOwner(menuItem))
                {
                    CreateLinkByMenu(navBar, group, menuItem, 0, true);
                    CreateLinkSubItem(navBar, group, menuItem);
                }
                else
                {
                    CreateLinkByMenu(navBar, group, menuItem, 1, false);
                }
            }
        }

        /// <summary>
        /// 创建子按钮
        /// </summary>
        /// <param name="navBar">NavBarControl</param>
        /// <param name="group">NavBarGroup</param>
        /// <param name="menuItem">ToolStripItem,当前菜单项</param>
        private void CreateLinkSubItem(NavBarControl navBar, NavBarGroup group, ToolStripItem menuItem)
        {
            if (menuItem is ToolStripMenuItem)
            {
                ToolStripMenuItem item = menuItem as ToolStripMenuItem;
                foreach (ToolStripItem subItem in item.DropDownItems)
                {
                    CreateLinkByMenu(navBar, group, subItem, -1, true);
                }
            }
        }

        /// <summary>
        /// 跟据菜单项创建NavBarItem
        /// </summary>
        /// <param name="navBar">NavBarControl</param>
        /// <param name="group">NavBarGroup</param>
        /// <param name="menuItem">ToolStripItem,当前菜单项</param>
        /// <param name="imageIndex">图片ID</param>
        /// <param name="isSubItem">是否子按钮(标记)</param>
        private void CreateLinkByMenu(NavBarControl navBar, NavBarGroup group,
            ToolStripItem menuItem, int imageIndex, bool isSubItem)
        {
            if (menuItem.Enabled)
            {
                NavBarItem item = CreateNavBarItem(navBar, menuItem, isSubItem);
                item.SmallImageIndex = imageIndex;//Sub Function
                group.ItemLinks.Add(item);
            }
        }

        /// <summary>
        /// 由菜单创建导航控件按钮NavBarItem
        /// </summary>
        private NavBarItem CreateNavBarItem(NavBarControl navBar, ToolStripItem item, bool isSubItem)
        {
            NavBarItem newItem = new NavBarItem();
            if (isSubItem)
                newItem.Caption = "  ● " + item.Text;
            else
                newItem.Caption = item.Text;
            newItem.Tag = item; //绑定一个菜单项,newItem.Click事件会使用这个菜单项            
            newItem.LinkClicked += new NavBarLinkEventHandler(this.OnNavBarLinkClick);
            navBar.Items.Add(newItem);
            return newItem;
        }

        /// <summary>
        /// 创建导航控件的按钮组NavBarGroup
        /// </summary>
        private NavBarGroup CreateNavBarGroup(NavBarControl navBar, string caption)
        {
            NavBarGroup group = navBar.Groups.Add();//增加一个Button组.
            group.Caption = caption; //模块的显示名称
            group.LargeImageIndex = 0;
            if (group.Caption.Equals(string.Empty)) group.Caption = "Unknown Name";
            return group;
        }

        /// <summary>
        /// 导航组件的按钮事件.
        /// </summary>
        private void OnNavBarLinkClick(object sender, NavBarLinkEventArgs e)
        {
            if (e.Link.Item.Tag is ToolStripItem)
            {
                ToolStripItem item = (ToolStripItem)(e.Link.Item.Tag);
                if (null != item) item.PerformClick(); //执行菜单事件.
            }
        }
    }

    /// <summary>
    /// 生成树样式的导航组件
    /// </summary>
    public class NavigatorTreeView : NavigatorBase
    {
        public NavigatorTreeView(ModuleManager moduleManager) : base(moduleManager) { }

        /// <summary>
        /// 创建导航控件按钮组NavBarGroup
        /// </summary>
        private NavBarGroup CreateNavBarGroup(NavBarControl navBar, string caption)
        {
            NavBarGroup group = navBar.Groups.Add();//增加一个Button组.
            group.Caption = caption; //模块的显示名称
            group.LargeImageIndex = 0;
            group.GroupStyle = NavBarGroupStyle.ControlContainer;
            if (group.Caption.Equals(string.Empty)) group.Caption = "Unknown Name";
            return group;
        }

        /// <summary>
        /// 创建导航组件按钮(包括创建按钮组(NavBarGroup)和按钮(BarItem)
        /// </summary>
        /// <param name="navBar">NavBarControl对象</param>
        /// <param name="moduleMenu">模块主菜单</param>
        /// <param name="moduleDisplayName">模块名称</param>
        protected override void CreateNavBarButton(NavBarControl navBar, ToolStripMenuItem moduleMenu, string moduleDisplayName)
        {
            //navBar.ActiveGroupChanged += new NavBarGroupEventHandler(this.OnActiveGroupChanged);
            navBar.MouseClick += new MouseEventHandler(this.OnNavBar_MouseClick);

            NavBarGroup group = CreateNavBarGroup(navBar, moduleDisplayName); //根据模块名称创建Group            

            CreateGroupTreeView(group, moduleMenu);
        }

        /// <summary>
        /// 初始化树的显示样式
        /// </summary>
        /// <param name="treeList">树组件</param>
        private void InitTreeList(TreeList treeList)
        {
            treeList.BackColor = Color.Transparent;
            treeList.BorderStyle = BorderStyles.NoBorder;
            treeList.Dock = DockStyle.Fill;
            treeList.MouseClick += new MouseEventHandler(tv_MouseClick);

            treeList.Appearance.Empty.BackColor = Color.Transparent;
            treeList.Appearance.Row.BackColor = Color.Transparent;

            //树视图其它设置
            treeList.OptionsView.ShowCheckBoxes = false;
            treeList.OptionsView.ShowColumns = false;
            treeList.OptionsView.ShowIndicator = false;
            treeList.OptionsView.ShowHorzLines = false;
            treeList.OptionsView.ShowVertLines = false;
            treeList.OptionsView.ShowRoot = false;

            //不显示菜单
            treeList.OptionsMenu.EnableColumnMenu = false;
            treeList.OptionsMenu.EnableFooterMenu = false;

            //操作行为属性设置
            treeList.OptionsBehavior.DragNodes = false;
            treeList.OptionsBehavior.Editable = false;
            treeList.OptionsBehavior.AllowExpandOnDblClick = false;
            treeList.OptionsBehavior.AutoChangeParent = false;
            treeList.OptionsBehavior.AutoFocusNewNode = false;
            treeList.OptionsBehavior.AutoNodeHeight = false;
            treeList.OptionsBehavior.CanCloneNodesOnDrop = false;
            treeList.OptionsBehavior.DragNodes = true;
            treeList.OptionsBehavior.Editable = false;
            treeList.OptionsBehavior.KeepSelectedOnClick = true;
            treeList.OptionsBehavior.MoveOnEdit = false;
            treeList.OptionsBehavior.PopulateServiceColumns = false;
            treeList.OptionsBehavior.ResizeNodes = true;
            treeList.OptionsBehavior.ShowEditorOnMouseUp = false;
            treeList.OptionsBehavior.ShowToolTips = false;
            treeList.OptionsBehavior.SmartMouseHover = true;
            treeList.OptionsBehavior.UseTabKey = false;

            //显示样式
            treeList.Appearance.FocusedCell.BackColor = Color.FromArgb(239, 235, 156);
            treeList.Appearance.FocusedCell.Options.UseBackColor = true;
            treeList.Appearance.FocusedRow.BackColor = Color.FromArgb(230, 230, 250);
            treeList.Appearance.FocusedRow.Options.UseBackColor = true;
            treeList.Appearance.HideSelectionRow.BackColor = Color.FromArgb(212, 212, 223);
            treeList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            treeList.Appearance.HorzLine.BackColor = Color.Silver;
            treeList.Appearance.HorzLine.Options.UseBackColor = true;
            treeList.Appearance.VertLine.BackColor = Color.Silver;
            treeList.Appearance.VertLine.Options.UseBackColor = true;

            treeList.OptionsBehavior.AllowExpandOnDblClick = true;
        }

        /// <summary>
        /// 将模块主菜单转换为树视图,一个按钮组对应一个模块
        /// </summary>
        /// <param name="group">按钮组</param>
        /// <param name="menuItem">模块主菜单</param>
        private void CreateGroupTreeView(NavBarGroup group, ToolStripMenuItem menuItem)
        {
            ImageList il = new ImageList();
            il.ImageSize = new Size(19, 19);
            il.Images.Add(Globals.LoadImage("m1.ico"));
            il.Images.Add(Globals.LoadImage("submodule.ico"));

            TreeList tv = new TreeList();
            tv.StateImageList = il;

            tv.BeginUnboundLoad();
            this.InitTreeList(tv);

            TreeListColumn col = tv.Columns.Add();
            col.Visible = true;
            col.Fixed = FixedStyle.Left;

            //子模块主菜单结点
            TreeListNode moduleRoot = tv.AppendNode(new object[] { menuItem.Text }, null);
            moduleRoot.StateImageIndex = 0;
            moduleRoot.Tag = menuItem;

            foreach (ToolStripItem item in menuItem.DropDownItems)
            {
                if (item is ToolStripSeparator) continue;
                if (item.Enabled == false) continue;

                TreeListNode node = tv.AppendNode(new object[] { item.Text }, moduleRoot);
                node.StateImageIndex = 1;
                node.Tag = item;

                if (item is ToolStripMenuItem && (item as ToolStripMenuItem).DropDownItems.Count > 0)
                {
                    node.StateImageIndex = 0;
                    CreateGroupTreeViewChild(tv, item as ToolStripMenuItem, node);
                }
            }
            tv.ExpandAll();//扩展所有结点
            tv.EndUnboundLoad();

            group.ControlContainer.Controls.Add(tv);
        }

        /// <summary>
        /// 递归程序的子程序
        /// </summary>
        /// <param name="tv"></param>
        /// <param name="parent"></param>
        /// <param name="parentNode"></param>
        private void CreateGroupTreeViewChild(TreeList tv, ToolStripMenuItem parent, TreeListNode parentNode)
        {
            foreach (ToolStripItem item in parent.DropDownItems)
            {
                if (item is ToolStripSeparator) continue;
                if (item.Enabled == false) continue;

                TreeListNode node = tv.AppendNode(new object[] { item.Text }, parentNode);
                node.StateImageIndex = 1;

                node.Tag = item;

                if (item is ToolStripMenuItem && (item as ToolStripMenuItem).DropDownItems.Count > 0)
                    CreateGroupTreeViewChild(tv, item as ToolStripMenuItem, node);
            }
        }

        /// <summary>
        /// TreeNode.Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tv_MouseClick(object sender, MouseEventArgs e)
        {
            if ((sender as TreeList).FocusedNode != null)
            {
                TreeListNode node = (sender as TreeList).FocusedNode;
                if (node.Tag != null && node.Tag is ToolStripItem)
                {
                    node.Selected = true;
                    (node.Tag as ToolStripItem).PerformClick();
                }
            }
        }

        /// <summary>
        /// 当用户点击不同的树结点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tv_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag is ToolStripItem)
                (e.Node.Tag as ToolStripItem).PerformClick();
        }

        /// <summary>
        /// 当用户点击树结点
        /// </summary>
        private void OnNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag is ToolStripItem)
                (e.Node.Tag as ToolStripItem).PerformClick();
        }
    }

}
