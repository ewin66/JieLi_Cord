﻿using SG.Common;
///*************************************************************************/
///*
///* 文件名    ：IDataOperatable.cs                                
///* 程序说明  : 支持数据操作的接口
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces
{
     /// <summary>
    ///  支持数据操作的接口
    /// </summary>
    public interface IDataOperatable
    {
        /// <summary>
        /// 返回数据操作窗体的按钮
        /// </summary>
        /// <returns></returns>
        IButtonInfo[] GetDataOperatableButtons();

        /// <summary>
        /// 查看/显示数据
        /// </summary>
        /// <param name="button"></param>
        void DoViewContent(IButtonInfo button);//查看数据

        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="button"></param>
        void DoAdd(IButtonInfo button);

        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="button"></param>
        void DoEdit(IButtonInfo button);

        /// <summary>
        /// 取消新增或修改
        /// </summary>
        /// <param name="button"></param>
        void DoCancel(IButtonInfo button);

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="button"></param>
        void DoSave(IButtonInfo button);

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="button"></param>
        void DoDelete(IButtonInfo button);

        /// <summary>
        /// 当前操作状态
        /// </summary>
        UpdateType UpdateType { get; }

        /// <summary>
        /// 是否修改了数据
        /// </summary>
        bool DataChanged { get; }

        /// <summary>
        /// 是否允许数据操作
        /// </summary>
        bool AllowDataOperate { get; set; }
    }
}
