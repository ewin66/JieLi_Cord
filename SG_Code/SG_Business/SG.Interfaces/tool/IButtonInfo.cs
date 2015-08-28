///*************************************************************************/
///*
///* 文件名    ：IButtonInfo.cs                                
///* 程序说明  : 自定义按钮接口
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces
{
    /// <summary>
    /// 点击按钮触发的Click事件
    /// </summary>    
    public delegate void OnButtonClick(IButtonInfo sender);

    /// <summary>
    /// 自定义按钮接口
    /// </summary>
    public interface IButtonInfo
    {
        /// <summary>
        /// 按钮名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 按钮标题
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        /// 按钮图片
        /// </summary>
        Image Image { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// 按钮对象
        /// </summary>
        object Button { get; }

        /// <summary>
        /// 禁止/可用
        /// </summary>
        bool Enable { get; set; }

        /// <summary>
        /// 按钮权限值
        /// </summary>
        int Authority { get; set; }

        /// <summary>
        /// 自定义标记
        /// </summary>
        object Tag { get; set; }

        /// <summary>
        /// 本次Click事件是否发生错误
        /// </summary>
        bool ErrorOccurred { get; set; }
    }

}
