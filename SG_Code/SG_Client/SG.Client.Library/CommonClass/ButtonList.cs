///*************************************************************************/
///*
///* 文件名    ：ButtonList.cs                            
///* 程序说明  : 按钮列表类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Client.Library
{
    /// <summary>
    /// 窗体的按钮列表
    /// </summary>
    public class ButtonList : IButtonList
    {
        private IList _Buttons = new ArrayList();

        /// <summary>
        ///  添加一组按钮
        /// </summary>
        /// <param name="buttons">按钮对象数组</param>
        public void AddRange(IButtonInfo[] buttons)
        {
            foreach (IButtonInfo btn in buttons) if (btn != null) this._Buttons.Add(btn);
        }

        /// <summary>
        /// 添加一组按钮
        /// </summary>
        /// <param name="buttons">按钮对象集合</param>
        public void AddRange(IList buttons)
        {
            foreach (IButtonInfo btn in buttons) if (btn != null) this._Buttons.Add(btn);
        }

        /// <summary>
        /// 添加一组按钮,在指定按钮后面
        /// </summary>
        /// <param name="buttons">按钮对象集合</param>
        public void AddRange(IList buttons, string btName)
        {
            int btIndex=0;
            int i=0;
            foreach(IButtonInfo selbtn in this._Buttons)
            {
                if(selbtn.Name==btName)
                {
                    btIndex=i;
                    break;
                }
                i++;
            }
            
            foreach (IButtonInfo btn in buttons)
            {
                if (btn != null)
                    this._Buttons.Insert(btIndex+1, btn);
                    //this._Buttons.Add(btn); 
            }
        }
        /// <summary>
        /// 跟据名称获取某个按钮
        /// </summary>
        /// <param name="name">按钮名称</param>
        /// <returns></returns>
        public IButtonInfo GetButtonByName(string name)
        {
            foreach (IButtonInfo b in _Buttons)
                if (b.Name == name) return b;
            return new NullButton();
        }

        /// <summary>
        /// 转换为按钮数组
        /// </summary>
        /// <returns></returns>
        public IButtonInfo[] ToArray()
        {
            IButtonInfo[] ret = new IButtonInfo[_Buttons.Count];
            for (int i = 0; i <= _Buttons.Count - 1; i++)
                ret[i] = (IButtonInfo)_Buttons[i];
            return ret;
        }

        /// <summary>
        /// 转换为按钮对象集合
        /// </summary>
        /// <returns></returns>
        public IList ToList()
        {
            return _Buttons;
        }


    }

    /// <summary>
    /// 引用NullObject模式,避免程序因访问null对象引发异常
    /// </summary>
    public class NullButton : IButtonInfo
    {
        #region IButtonInfo 成員

        public string Name { get { return ""; } set { } }
        public string Caption { get { return ""; } set { } }
        public Image Image { get { return null; } set { } }
        public int Index { get { return 0; } set { } }
        public object Button { get { return null; } set { } }
        public bool Enable { get { return false; } set { } }
        public int Authority { get { return 0; } set { } }
        public object Tag { get { return null; } set { } }
        public bool ErrorOccurred { get { return false; } set { } }
        #endregion
    }
}
