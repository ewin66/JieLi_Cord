///*************************************************************************/
///*
///* 文件名    ：IMdiForm.cs                                
///* 程序说明  : MDI主窗体接口
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG.Interfaces
{
    /// <summary>
    /// MDI主窗体接口
    /// </summary>
    public interface IMdiForm
    {
        /// <summary>
        ///主窗体的工具栏 
        /// </summary>
        IToolbarRegister MdiToolbar { get; set; }

        /// <summary>
        /// 主窗体的观察者
        /// </summary>
        IObserver[] MdiObservers { get; }

        /// <summary>
        /// 注册主窗体工具栏的按钮
        /// </summary>
        void RegisterMdiButtons();

        /// <summary>
        /// 主窗体上的按钮集合
        /// </summary>
        IList MdiButtons { get; }

        /// <summary>
        /// 所有模块主菜单的集合
        /// </summary>
        MenuStrip MainMenu { get; }

        /// <summary>
        /// 显示模块的主窗体
        /// </summary>
        void ShowModuleContainerForm();
    }
}
