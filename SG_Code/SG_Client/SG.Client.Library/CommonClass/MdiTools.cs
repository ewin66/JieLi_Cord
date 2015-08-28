﻿using SG.Business;
using SG.Business.Base;
using SG.Client.Core;
///*************************************************************************/
///*
///* 文件名    ：MdiTools.cs                              
///* 程序说明  : 主窗体工具类, 打开子窗体
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Common;
using SG.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG.Client.Library
{
    /// <summary>
    /// 主窗体工具类, 打开子窗体
    /// </summary>
    public class MdiTools
    {

        /// <summary>
        /// 取应用程序的主窗体
        /// </summary>
        public static Form MdiMainForm
        {
            get
            {
                foreach (Form form in Application.OpenForms)
                    if (form.IsMdiContainer) return form;
                return null;
            }
        }

        public static Form FindForm(string formTypeFullName)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().FullName.ToUpper() == formTypeFullName.ToUpper())
                    return form;
            }
            return null;
        }


        //打开IE浏览器或打开Outlook
        public static void OpenIE(string url)
        {
            //url= mailto:jonnysun@csframework.com 打开Outlook
            System.Diagnostics.Process.Start(url);
        }

        /// <summary>
        /// 打开子窗体.
        /// </summary>
        /// <param name="mdi">MDI主窗体</param>
        /// <param name="formType">子窗体的类型</param>
        /// <param name="ToolStripMenuItem">打开窗体的菜单项</param>
        public static Form OpenChildForm(IMdiForm mdi, Type formType, ToolStripMenuItem sender)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Form form = ActiveChildForm(mdi as Form, formType.ToString()); //试图激活已打开的子窗体
                if (form != null) { form.Show(); return form; } //如子窗体已打开显示子窗体并退出

                //通过反射创建窗体实例.
                form = (Form)formType.Assembly.CreateInstance(formType.FullName);

                //创建窗体实例失败
                if (form == null) throw new Exception("未知窗体类型!");

                //是系统定义的子窗体
                if (form is IMdiChildForm)
                {
                    form.MdiParent = (Form)mdi; //设置主窗体

                    (form as IMdiChildForm).ToolbarRegister = mdi.MdiToolbar; //绑定主窗体的Toolbar对象
                    (form as IMdiChildForm).RegisterObserver(mdi.MdiObservers); //注册子窗体的观察者
                }

                //支持权限控制的子窗体
                if (form is IPurviewControllable)
                {
                    if (sender != null && sender.Tag is MenuItemTag)
                    {
                        MenuItemTag tag = sender.Tag as MenuItemTag;
                        //int auth = new bllGroupAuthority().GetFormAuthority(Loginer.CurrentUser.Account, tag.ModuleID, sender.Name); //获取窗体的权限
                        //if (auth < 1 && (!Loginer.CurrentUser.IsAdmin()))
                        //{
                        int auth = 0;
                        int authShow = 0;
                        DataRow[] rows = SystemAuthentication.UserAuthorities.Select(string.Format("FNUM='{0}' ", sender.Name));
                        //int auth = new bllGroupAuthority().GetFormAuthority(Loginer.CurrentUser.Account, tag.ModuleID, sender.Name); //获取窗体的权限
                        if (rows.Length < 1 && (!Loginer.CurrentUser.IsAdmin()))
                        {
                            Msg.ShowError("您没有" + sender.Text + "的权限");
                            return null;
                        }
                        else
                        {
                            if (rows.Length > 0)
                                auth = Convert.ToInt32(rows[0]["FAUTHS"]);

                            DataRow[] rs = DataDictCache.Cache.Function.Select(string.Format("FNumber='{0}'", sender.Name));
                            if (rs.Length > 0)
                            {
                                if (auth == 0)
                                    auth = Convert.ToInt32(rs[0]["FAUTHS"]);
                                authShow = Convert.ToInt32(rs[0]["FAUTHS"]);
                            }
                            (form as IPurviewControllable).FormAuthorities = auth; //本窗体工具栏的权限值
                            (form as IPurviewControllable).FormAuthoritiesShow = authShow; //本窗体工具栏的权限值
                            (form as IPurviewControllable).FormMenuName = sender.Name;//绑定打开窗体的菜单名
                            (form as IPurviewControllable).FunctionID = bllComDataBaseTool.GetFunctionID(sender.Name);//功能ID
                        }
                    }
                }
                
                form.Show();//显示窗体
                return form;
            }
            catch (Exception ex)
            {
                Msg.Warning("打开窗体时出现错误！\r\n" + ex.Message);
                return null;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 打开子窗体.
        /// </summary>
        /// <param name="mdi">MDI主窗体</param>
        /// <param name="formType">子窗体的类型</param>
        /// <param name="ToolStripMenuItem">打开窗体的菜单项</param>
        public static Form OpenChildForm(IMdiForm mdi, Type formType, ToolStripMenuItem sender, string sFormMenuName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Form form = ActiveChildForm(mdi as Form, formType.ToString()); //试图激活已打开的子窗体
                if (form != null) { form.Show(); return form; } //如子窗体已打开显示子窗体并退出

                //通过反射创建窗体实例.
                form = (Form)formType.Assembly.CreateInstance(formType.FullName);

                //创建窗体实例失败
                if (form == null) throw new Exception("未知窗体类型!");

                //是系统定义的子窗体
                if (form is IMdiChildForm)
                {
                    form.MdiParent = (Form)mdi; //设置主窗体

                    (form as IMdiChildForm).ToolbarRegister = mdi.MdiToolbar; //绑定主窗体的Toolbar对象
                    (form as IMdiChildForm).RegisterObserver(mdi.MdiObservers); //注册子窗体的观察者
                }

                //支持权限控制的子窗体
                if (form is IPurviewControllable)
                {
                    if (sender != null && sender.Tag is MenuItemTag)
                    {
                        MenuItemTag tag = sender.Tag as MenuItemTag;
                        int auth = 0;
                        int authShow = 0;
                        DataRow[] rows = SystemAuthentication.UserAuthorities.Select(string.Format("FNUM='{0}' ", sender.Name));
                        //int auth = new bllGroupAuthority().GetFormAuthority(Loginer.CurrentUser.Account, tag.ModuleID, sender.Name); //获取窗体的权限
                        if (rows.Length < 1 && (!Loginer.CurrentUser.IsAdmin()))
                        {
                            Msg.ShowError("您没有" + sender.Text + "的权限");
                            return null;
                        }
                        else
                        {
                            if (rows.Length > 0)
                                auth = Convert.ToInt32(rows[0]["FAUTHS"]);

                            DataRow[] rs = DataDictCache.Cache.Function.Select(string.Format("FNumber='{0}'", sender.Name));
                            if (rs.Length > 0)
                            {
                                if (auth == 0)
                                    auth = Convert.ToInt32(rs[0]["FAUTHS"]);
                                authShow = Convert.ToInt32(rs[0]["FAUTHS"]);
                            }

                            (form as IPurviewControllable).FormAuthorities = auth; //本窗体的权限值
                            (form as IPurviewControllable).FormAuthoritiesShow = authShow; //本窗体工具栏的权限值
                            (form as IPurviewControllable).FormMenuName = sender.Name;//绑定打开窗体的菜单名
                            (form as IPurviewControllable).FunctionID = bllComDataBaseTool.GetFunctionID(sender.Name);//功能ID
                        }
                    }
                    else
                        (form as IPurviewControllable).FormMenuName = sFormMenuName;
                }

                form.Show();//显示窗体
                return form;
            }
            catch (Exception ex)
            {
                Msg.Warning("打开窗体时出现错误！\r\n" + ex.Message);
                return null;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 打开MDI子窗体
        /// </summary>
        /// <param name="mdi">MDI主窗体</param>
        /// <param name="formType">子窗体的类型</param>
        /// <returns></returns>
        public static Form OpenChildForm(IMdiForm mdi, Type formType)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Form child = ActiveChildForm(mdi as Form, formType.ToString());
                if (child != null) { child.Show(); return child; }

                Form form = (Form)formType.Assembly.CreateInstance(formType.FullName);
                if (form != null && form is Form)
                {
                    child = form as Form;

                    if (form is IMdiChildForm)
                    {
                        (child as IMdiChildForm).ToolbarRegister = mdi.MdiToolbar;
                        (child as IMdiChildForm).RegisterObserver(mdi.MdiObservers);
                        child.MdiParent = (Form)mdi;
                    }
                    child.Show();
                    return child;
                }
                else
                    throw new Exception("未知窗体类型!");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 如果窗体已经打开激活即可.
        /// </summary>
        /// <param name="mdiParent">主窗体对象引用</param>
        /// <param name="formTypeName">子窗体的命名空间全名</param>
        /// <returns></returns>
        public static Form ActiveChildForm(Form mdiParent, string formTypeName)
        {
            for (int x = 0; x < mdiParent.MdiChildren.Length; x++)
            {
                string ss = mdiParent.MdiChildren[x].GetType().ToString().ToUpper();//名字空间
                if (ss == formTypeName.ToUpper()) //找到字窗体
                {
                    IMdiChildForm child = mdiParent.MdiChildren[x] as IMdiChildForm;
                    if (child.AllowMultiInstatnce) continue; //跳过窗体副本
                    mdiParent.MdiChildren[x].Activate();
                    return mdiParent.MdiChildren[x];
                }
            }
            return null;
        }

    }
}
