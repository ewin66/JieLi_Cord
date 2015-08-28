///*************************************************************************/
///*
///* 文件名    ：bllMenuMgr.cs                              
///* 程序说明  : 系统菜单数据管理类。
///
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using DevExpress.Utils;
using DevExpress.XtraBars;
using SG.Client.Bridge;
using SG.Common;
using SG.Interfaces;
using SG.Interfaces.Base;
using SG.Models.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG.Business
{
    /// <summary>
    /// 系统菜单数据管理类
    /// </summary>
    public class bllMenuMgr : bllBaseDataDict
    {
        private int _LastUpdated = 0;//最后一次导入菜单更新的记录数
        private int _LastInserted = 0;//最后一次导入菜单数

        private int _ButtonUpdated = 0; //按钮更新数
        private int _ButtonInserted = 0;//添加按钮数
        private int _MaxAuthorID = 1; //最大权限ID
        private DataTable _AuthorityItem = null; //功能点数据
        private DataTable _FormTagCustomName = null; //功能点自定义名称
        protected IBridge_DataDict _BarDataDictBridge = null;
        private IBridge_UserGroup _MyBridge;

        public bllMenuMgr()
        {
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_sys_Function));
            _BarDataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_sys_Fun_MenuBar));
            _KeyFieldName = tb_sys_Function.__KeyName;
            _SummaryTableName = tb_sys_Function.__TableName;

            _MyBridge = BridgeFactory.CreateUserGroupBridge();
            _AuthorityItem = _MyBridge.GetAuthorityItem(); //Actions Master Data   
            _AuthorityItem.TableName = tb_sys_Fun_MenuBar.__TableName;
            _FormTagCustomName = _MyBridge.GetFormTagCustomName(); //自定义功能名称
        }

        /// <summary>
        /// 功能点数据
        /// </summary>
        public DataTable AuthorityItem { get { return _AuthorityItem; } }

        /// <summary>
        /// 功能点自定义名称数据
        /// </summary>
        public DataTable FormTagCustomName { get { return _FormTagCustomName; } }

        /// <summary>
        /// 最后一次导入菜单更新的记录数
        /// </summary>
        public int LastUpdated { get { return _LastUpdated; } }

        /// <summary>
        /// 最后一次导入菜单数
        /// </summary>
        public int LastInserted { get { return _LastInserted; } }

        /// <summary>
        /// 更新按钮数
        /// </summary>
        public int ButtonUpdated { get { return _ButtonUpdated; } }
        /// <summary>
        /// 更新按钮数
        /// </summary>
        public int ButtonInserted { get { return _ButtonInserted; } }
        /// <summary>
        /// 导入按钮
        /// </summary>
        /// <param name="barList"></param>
        /// <param name="clearOldData"></param>
        /// <returns></returns>
        public bool ImportButton(IList<BarItem> barList, string sFunid, bool clearOldData)
        {
            bool ret=false;
            _ButtonInserted = 0;
            _ButtonUpdated = 0;
            if (clearOldData) MakeDeletedBarFunction(sFunid); //删除按钮
            GetMaxAuthorid(sFunid); //获取授权码
            for (int i = 0; i < barList.Count;i++ )
            {
                UpdateButton((BarItem)barList[i], sFunid);
            }

            DataTable dt = _AuthorityItem.GetChanges();

            if (dt != null)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                bool success = _BarDataDictBridge.Update(ds); //保存数据
                if (success) _AuthorityItem.AcceptChanges();
                ret = success;
            }
            else 
                ret =true;
            return ret;
        }

        /// <summary>
        /// 删除该功能下的Buttion
        /// </summary>
        private void MakeDeletedBarFunction(string sfunid)
        {

            for(int i=0;i<_AuthorityItem.Rows.Count;i++)
            {
                if (_AuthorityItem.Rows[i][tb_sys_Fun_MenuBar.FFunctionID].ToString() == sfunid)
                    _AuthorityItem.Rows[i].Delete();
            }
            
        }

        /// <summary>
        /// 更新按钮
        /// </summary>
        /// <param name="item"></param>
        private void UpdateButton(BarItem item,string sFunid)
        {     
            
            string filter = string.Format(tb_sys_Fun_MenuBar.FNumber + "='{0}' and " + tb_sys_Fun_MenuBar.FFunctionID + "={1}", item.Name,sFunid);
            DataRow[] exists =_AuthorityItem.Select(filter);
            if (exists.Length > 0)
            {
                string caption = ConvertEx.ToString(exists[0][tb_sys_Fun_MenuBar.FName]);
                if (caption != item.Caption)
                {
                    _ButtonUpdated += 1;
                    exists[0][tb_sys_Fun_MenuBar.FName] = item.Caption; //更新菜单标题.
                }
            }
            else
            {
                DataRow append = _AuthorityItem.NewRow(); ;
                append[tb_sys_Fun_MenuBar.FID] = Convert.ToInt32(BridgeFactory.CreateCommonServiceBridge().GetTableID(tb_sys_Fun_MenuBar.__TableName, tb_sys_Fun_MenuBar.__KeyName)) + _ButtonInserted;
                append[tb_sys_Fun_MenuBar.FNumber] = item.Name;
                append[tb_sys_Fun_MenuBar.FName] = item.Caption;
                append[tb_sys_Fun_MenuBar.FFunctionID] = sFunid;
                append[tb_sys_Fun_MenuBar.FAuthority] = _MaxAuthorID;
                _MaxAuthorID = _MaxAuthorID * 2;
                _AuthorityItem.Rows.Add(append);

                _ButtonInserted += 1;
            }
        }

        /// <summary>
        /// 获取最大权限ID
        /// </summary>
        /// <param name="sFunid"></param>
        /// <returns></returns>
        private void GetMaxAuthorid(string sFunid)
        {
            DataTable dt = _AuthorityItem.Copy();
            dt.DefaultView.Sort=tb_sys_Fun_MenuBar.FAuthority + " Desc";
            dt.AcceptChanges();
            string filter =string.Format(tb_sys_Fun_MenuBar.FFunctionID + "={0}" , sFunid);
            DataRow[] exists = dt.Select(filter);
            if (exists.Length > 0)
                _MaxAuthorID = Convert.ToInt32(exists[0][tb_sys_Fun_MenuBar.FAuthority]) * 2;

        }

        /// <summary>
        /// 导入菜单数据
        /// </summary>
        /// <param name="mainMenu">系统主菜单</param>
        /// <param name="clearOldData">是否清除旧的菜单数据</param>
        /// <returns></returns>
        public bool ImportMenu(MenuStrip mainMenu, bool clearOldData)
        {
            try
            {
                _LastInserted = 0;
                _LastUpdated = 0;

                if (clearOldData) this.MakeDeletedAll();//清除旧的菜单数据

                foreach (ToolStripItem item in mainMenu.Items)
                {
                    if (item is ToolStripSeparator) continue; //菜单分隔符不处理
                    if (ConvertEx.ToString(item.Tag).ToUpper() == "IsSystemMenu".ToUpper()) continue; //系统菜单不处理

                    if (item is ToolStripMenuItem && (item as ToolStripMenuItem).DropDownItems.Count > 0)
                    {
                        ImportMenuChild(item as ToolStripMenuItem);
                    }
                }

                DataTable dt = _SummaryTable.GetChanges();

                if (dt != null)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    bool success = _DataDictBridge.Update(ds); //保存数据
                    if (success) _SummaryTable.AcceptChanges();
                    return success;
                }
                else return true;
            }
            catch
            {
                _SummaryTable.RejectChanges();
                return false;
            }
        }

        /// <summary>
        /// 打开删除标记
        /// </summary>
        private void MakeDeletedAll()
        {
            while (_SummaryTable.Rows.Count > 0)
                _SummaryTable.Rows[0].Delete();
        }

        /// <summary>
        /// 剃归导入子菜单
        /// </summary>
        /// <param name="parent">父级菜单</param>
        private void ImportMenuChild(ToolStripMenuItem parent)
        {
            foreach (ToolStripItem item in parent.DropDownItems)
            {
                if (item is ToolStripSeparator) continue; //不导入分隔符

                if ((item.Tag != null) && (item.Tag is MenuItemTag))
                    this.UpdateMenu(item);

                //剃归导入子菜单
                if (item is ToolStripMenuItem && (item as ToolStripMenuItem).DropDownItems.Count > 0)
                    ImportMenuChild(item as ToolStripMenuItem);
            }
        }

        /// <summary>
        /// 更新菜单标题
        /// </summary>
        /// <param name="item"></param>
        private void UpdateMenu(ToolStripItem item)
        {
            MenuItemTag tag = item.Tag as MenuItemTag;
            string filter = string.Format("FNumber='{0}' and FModelID={1}", item.Name, tag.ModuleID);
            DataRow[] exists = _SummaryTable.Select(filter);
            if (exists.Length > 0)
            {
                string caption = ConvertEx.ToString(exists[0][tb_sys_Function.FName]);
                if (caption != item.Text)
                {
                    _LastUpdated += 1;
                    exists[0][tb_sys_Function.FName] = item.Text; //更新菜单标题.
                }
            }
            else
            {
                DataRow append = _SummaryTable.NewRow();
                append[tb_sys_Function.FID] = Convert.ToInt32(BridgeFactory.CreateCommonServiceBridge().GetTableID(tb_sys_Function.__TableName, tb_sys_Function.__KeyName)) + _LastInserted;
                append[tb_sys_Function.FAuths] = tag.FormAuthorities;
                append[tb_sys_Function.FName] = item.Text;
                append[tb_sys_Function.FNumber] = item.Name;
                append[tb_sys_Function.FMenuType] = tag.MenuType.ToString();
                append[tb_sys_Function.FModelID] = tag.ModuleID;
                _SummaryTable.Rows.Add(append);

                _LastInserted += 1;
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="updateType"></param>
        /// <returns></returns>
        public override bool Update(UpdateType updateType)
        {
            DataSet data = new DataSet();
            data.Tables.Add(_SummaryTable.Copy());
            data.Tables.Add(_FormTagCustomName.Copy());
            bool success = _DataDictBridge.Update(data);
            if (success)
                _FormTagCustomName = _MyBridge.GetFormTagCustomName(); //自定义功能名称
            return success;
        }
    }
}
