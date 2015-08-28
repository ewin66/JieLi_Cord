///*************************************************************************/
///*
///* 文件名    ：IToolbarRegister.cs                                
///* 程序说明  : 主窗体工具条按钮注册接口
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces
{
    /// <summary>
    /// 主窗体工具条按钮注册接口
    /// </summary>
    public interface IToolbarRegister : IDisposable
    {
        /// <summary>
        /// 注册按钮
        /// </summary>
        /// <param name="buttons">按钮列表</param>
        void RegisteButton(IList buttons);

        /// <summary>
        /// 重置工具栏按钮
        /// </summary>
        void Dispose();

        /// <summary>
        /// 创建按钮分隔条
        /// </summary>
        /// <returns></returns>
        IButtonInfo CreateSeperator();

        /// <summary>
        /// 创建主窗体工具条的按钮.
        /// </summary>
        /// <param name="name">按钮名称:如btnSave,btnClose</param>
        /// <param name="caption">按钮名称</param>
        /// <param name="image">按钮图片</param>
        /// <param name="size">按钮大小</param>
        /// <param name="clickEvent">按钮的Click事件</param>
        /// <returns></returns>
        IButtonInfo CreateButton(string name, string caption, Bitmap image, Size size, OnButtonClick clickEvent);
        /// <summary>
        /// 创建主窗体工具条的按钮.
        /// </summary>
        /// <param name="name">按钮名称:如btnSave,btnClose</param>
        /// <param name="caption">按钮名称</param>
        /// <param name="image">按钮图片</param>
        /// <param name="size">按钮大小</param>
        /// <param name="clickEvent">按钮的Click事件</param>
        /// <param name="tag">按钮的tag</param>
        /// <returns></returns>
        IButtonInfo CreateButton(string name, string caption, Bitmap image, Size size, OnButtonClick clickEvent,string tag);
    }
}
