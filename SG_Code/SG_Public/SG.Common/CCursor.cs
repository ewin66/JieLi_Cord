
///*************************************************************************/
///*
///* 文件名    ：CCursor.cs                                      
///* 程序说明  : 光标显示类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG.Common
{ /// <summary>
    /// 显示等待光标
    /// </summary>
    public class CCursor
    {
        [DllImport("user32.dll")]
        public static extern long GetCursorPos(ref System.Drawing.Point lpPoint);

        /// <summary>
        /// 显示等待光标
        /// </summary>
        public static void ShowWaitCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
        }

        /// <summary>
        /// 显示预设光标
        /// </summary>
        public static void ShowDefaultCursor()
        {
            Cursor.Current = Cursors.Default;
            Cursor.Show();
        }
    }
}
