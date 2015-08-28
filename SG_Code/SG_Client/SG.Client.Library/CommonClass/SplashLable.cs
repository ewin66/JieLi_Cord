using SG.Interfaces;
///*************************************************************************/
///*
///* 文件名    ：StatusLable.cs                              
///* 程序说明  : 加载模块时进度显示
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG.Client.Library
{
    /// <summary>
    /// 加载模块时进度显示
    /// </summary>
    public class LoadStatus : IMsg
    {
        private Label _lbl = null;
        public LoadStatus(Label lbl)
        {
            _lbl = lbl;
        }

        public void UpdateMessage(string msg)
        {
            _lbl.Text = msg;
            _lbl.Update();
        }
    }
}
