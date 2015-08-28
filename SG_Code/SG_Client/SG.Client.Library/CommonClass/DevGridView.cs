using DevExpress.XtraGrid.Views.Grid;
using SG.Interfaces;
///*************************************************************************/
///*
///* 文件名    ：DevGridView.cs                              
///* 程序说明  : DevGridView代理类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Client.Library
{
    /// <summary>
    /// Dev GridView代理类
    /// </summary>
    public class DevGridView : ISummaryView
    {
        private GridView _view;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="view">GridView控件</param>
        public DevGridView(GridView view)
        {
            _view = view;
        }

        #region ISummaryView Members

        /// <summary>
        /// GridView控件
        /// </summary>
        public object View { get { return _view; } }


        /// <summary>
        /// 记录数
        /// </summary>
        public int RowCount
        {
            get { return _view.RowCount; }
        }

        /// <summary>
        /// 当前选中的资料行
        /// </summary>
        public int FocusedRowHandle
        {
            get
            {
                return _view.FocusedRowHandle;
            }
            set
            {
                _view.FocusedRowHandle = value;
            }
        }

        /// <summary>
        /// 数据源
        /// </summary>
        public object DataSource
        {
            get
            {
                return _view.GridControl.DataSource;
            }
            set
            {
                _view.GridControl.DataSource = null;
                _view.GridControl.DataSource = value;
            }
        }

        /// <summary>
        /// 获取指定资料行
        /// </summary>
        /// <param name="rowHandle">资料行索引</param>
        /// <returns></returns>
        public System.Data.DataRow GetDataRow(int rowHandle)
        {
            return _view.GetDataRow(rowHandle);
        }

        /// <summary>
        /// 刷新数据源，重新显示数据
        /// </summary>
        public void RefreshDataSource()
        {
            _view.GridControl.RefreshDataSource();
        }

        public void MoveFirst()
        {
            _view.MoveFirst();
        }

        public void MovePrior()
        {
            _view.MovePrev();
        }

        public void MoveNext()
        {
            _view.MoveNext();
        }

        public void MoveLast()
        {
            _view.MoveLast();
        }

        public void SetFocus()
        {
            if (_view.GridControl.CanFocus)
                _view.GridControl.Focus();
        }

        public void BindingDoubleClick(EventHandler eventHandler)
        {
            _view.DoubleClick += new EventHandler(eventHandler);
        }

        /// <summary>
        /// 资料行索引是否有效
        /// </summary>
        /// <param name="rowHandle">资料行索引</param>
        /// <returns></returns>
        public bool IsValidRowHandle(int rowHandle)
        {
            return _view.IsValidRowHandle(rowHandle);
        }

        /// <summary>
        /// 刷新资料行的数据
        /// </summary>
        /// <param name="rowHandle">资料行索引</param>
        public void RefreshRow(int rowHandle)
        {
            _view.RefreshRow(rowHandle);
        }

        #endregion
    }
}
