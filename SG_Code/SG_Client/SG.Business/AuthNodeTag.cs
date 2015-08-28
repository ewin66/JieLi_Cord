
///*************************************************************************/
///*
///* 文件名    ：AuthNodeTag.cs        
///
///* 程序说明  : 用于标志增加或删除权限
///               树结点与对应的权限记录建立映射关系,用于标志增加或删除权限.
///               当选中树结点表示新增权限，取消选中表示删除权限.
///               
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG.Business
{
    /// <summary>
    /// 树结点与对应的权限记录建立映射关系,用于标志增加或删除权限.
    /// 当选中树结点表示新增权限，取消选中表示删除权限.
    /// 
    /// </summary>
    public class AuthNodeTag
    {
        private string _AuthID;//对应菜单名称
        private DataRow _DataRow;//数据行
        private ToolStripItem _MenuItem;//对应菜单
        private string _FunctionID; //对应菜单的FunctionID

        public AuthNodeTag() { }

        public AuthNodeTag(string authID, DataRow dataRow, ToolStripItem menuItem)
        {
            _AuthID = authID;
            _DataRow = dataRow;
            _MenuItem = menuItem;

        }

        /// <summary>
        /// 菜单类型
        /// </summary>
        public MenuType MenuType
        {
            get
            {
                if (_MenuItem != null && _MenuItem.Tag != null)
                    return (_MenuItem.Tag as MenuItemTag).MenuType;
                return MenuType.Unknow;
            }
        }

        /// <summary>
        /// 菜单
        /// </summary>
        public ToolStripItem MenuItem
        {
            get { return _MenuItem; }
            set { _MenuItem = value; }
        }

        /// <summary>
        /// 权限编号,实为菜单名称
        /// </summary>
        public string AuthID
        {
            get { return _AuthID; }
            set { _AuthID = value; }
        }
        /// <summary>
        /// 对应菜单的FunctionID
        /// </summary>
        public string FUnctionID
        {
            get { return _FunctionID; }
            set { _FunctionID = value; }
        }

        /// <summary>
        /// 树结点对应的权限记录
        /// 当选中树结点时新增一条记录，取消选中时该变量为null.
        /// </summary>
        public DataRow DataRow
        {
            get { return _DataRow; }
            set { _DataRow = value; }
        }
    }
}
