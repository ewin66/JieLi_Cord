///*************************************************************************/
///*
///* 文件名    ：Msg.cs                                      
///* 程序说明  : 菜单类型定义
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SG.Common
{
    /// <summary>
    /// 系统消息提示窗体
    /// </summary>
    public class Msg
    {

        /// <summary>
        /// 打开对话框
        /// </summary>
        /// <param name="msg">本次对话内容</param>
        /// <returns></returns>
        public static bool AskQuestion(string msg)
        {
            DialogResult r;
            r = MessageBox.Show(msg, "确认",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            return (r == DialogResult.Yes);
        }

        /// <summary>
        /// 显示系统异常
        /// </summary>
        /// <param name="e">系统异常</param>
        public static void ShowException(Exception e)
        {
            string s = e.Message;
            string innerMsg = string.Empty;

            if (e.InnerException != null)
            {
                innerMsg = e.InnerException.Message;
                s += "\n" + innerMsg;
            }

            Warning(s);
        }

        public static void ShowException(Exception ex, string customMessage)
        {
            if (ex is CustomException)
                ShowException(ex);
            else if (customMessage != "")
                Warning(customMessage);
            else
                Warning(ex.Message);
        }

        /// <summary>
        /// 警告提示框
        /// </summary>
        /// <param name="msg">警告内容</param>
        public static void Warning(string msg)
        {
            MessageBox.Show(msg, "警告",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 错误消息提示框
        /// </summary>
        /// <param name="msg">错误消息内容</param>
        public static void ShowError(string msg)
        {
            MessageBox.Show(msg, "警告",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 信息提示框
        /// </summary>
        /// <param name="msg">本次显示的消息</param>
        public static void ShowInformation(string msg)
        {
            MessageBox.Show(msg, "信息",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1);
        }




    }

    /// <summary>
    /// 显示定时关闭的消息对话框
    /// </summary>
    public class MessageBoxTimeOut
    {
        private string _caption;
        private string username;
        private string pwd;
        public DialogResult Show(int timeout, string text, string caption, MessageBoxButtons buttons)
        {
            this._caption = caption;
            StartTimer(timeout);
            DialogResult dr = MessageBox.Show(text, caption, buttons, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            return dr;
        }
        private void StartTimer(int interval)
        {
            Timer timer = new Timer();
            timer.Interval = interval;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Enabled = true;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            KillMessageBox();
            //停止计时器
            ((Timer)sender).Enabled = false;
        }
        [DllImport("User32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        public const int WM_CLOSE = 0x10;
        public void KillMessageBox()
        {
            //查找MessageBox的弹出窗口,注意对应标题
            IntPtr ptr = FindWindow(null, this._caption);
            if (ptr != IntPtr.Zero)
            {
                //查找到窗口则关闭
                PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            }
        }
    }

}
