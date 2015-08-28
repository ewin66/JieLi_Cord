using SG.Common;
///*************************************************************************/
///*
///* 文件名    ：dalUserGroup.cs                                
///* 程序说明  : 用户组数据字典的DAL层
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Interfaces.Base;
using SG.Models.Base;
using SG.ORMTool;
using SG.Server.DataAccess;
using SG.Tools.DataOperate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.DataAccess.Base
{
     [DefaultORM_UpdateMode(typeof(tb_sys_UserGroup), true)]
   public class dalUserGroup : dalBaseDataDict, IBridge_UserGroup
    {
        public dalUserGroup(Loginer loginer)
            : base(loginer)
        { }

        /// <summary>
        /// 根据表名获取该表的ＳＱＬ命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_sys_UserGroup.__TableName) ORM = typeof(tb_sys_UserGroup);
            if (tableName == tb_sys_User_Group.__TableName) ORM = typeof(tb_sys_User_Group);
            if (tableName == tb_sys_UG_Auth.__TableName) ORM = typeof(tb_sys_UG_Auth);
            if (tableName == tb_sys_Models.__TableName) ORM = typeof(tb_sys_Models);
            if (tableName == tb_sys_Function.__TableName) ORM = typeof(tb_sys_Function);
            if (tableName == tb_sys_Fun_MenuBar.__TableName) ORM = typeof(tb_sys_Fun_MenuBar);
            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            //支持两种SQL命令生成器
            return new GenerateSqlCmdByTableFields(ORM,_Loginer.DbType);
        }
       /// <summary>
        /// 获取权限功能点定义(已过滤相同的)
       /// </summary>
       /// <returns></returns>
        public System.Data.DataTable GetAuthorityItem()
        {
            string sql = "SELECT   *  FROM    sys_Fun_MenuBar order by FName";

            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
        }
       /// <summary>
        /// 获取所有用户组
       /// </summary>
       /// <returns></returns>
        public System.Data.DataTable GetUserGroup()
        {
            string sql = "SELECT      FID, FNumber, FName, FNote FROM  sys_UserGroup order by FName";
            
            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
        }
       /// <summary>
        /// 获取用户组的权限信息，包括组的用户，组的权限
       /// </summary>
       /// <param name="groupCode"></param>
       /// <returns></returns>
        public System.Data.DataSet GetUserGroup(string groupCode)
        {
            ArrayList arrSqlList = new ArrayList();
            arrSqlList.Add("SELECT      FID, FNumber, FName, FNote FROM  sys_UserGroup where fnumber ='" + groupCode + "' order by FName");
            arrSqlList.Add("SELECT    UG.*, U.FAccount, U.FUserName, G.FNumber, G.FName FROM   sys_User_Group  UG INNER JOIN " +
                      " sys_User  U ON UG.FUserID = U.FID INNER JOIN sys_UserGroup  G ON UG.FUserGroupID = G.FID where g.Fnumber ='" + groupCode + "'");
            arrSqlList.Add("SELECT UA.FID, UA.FUGID, UA.FunctionID, UA.FAuths, UA.FModelID,UA.FMenu, G.FNumber AS GNum, G.FName  GName, F.FNumber  FNum, F.FName FName, F.FModelID,  F.FAuths " +
                     " FROM   sys_UG_Auth  UA INNER JOIN sys_UserGroup  G ON UA.FUGID = G.FID LEFT OUTER JOIN sys_Function  F ON UA.FunctionID = F.FID where g.Fnumber ='" + groupCode + "'");
            arrSqlList.Add("select FID,FAccount,FUserName from sys_User where fid not in (select UG.FUserID from sys_UserGroup G inner join sys_User_Group UG on UG.FUserGroupID=G.FID where G.Fnumber='" + groupCode + "')");

            DataSet ds = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataSet(arrSqlList);
            ds.Tables[BusinessDataSetIndex.Groups].TableName = tb_sys_UserGroup.__TableName;
            ds.Tables[BusinessDataSetIndex.GroupUsers].TableName = tb_sys_User_Group.__TableName;
            ds.Tables[BusinessDataSetIndex.GroupAuthorities].TableName = tb_sys_UG_Auth.__TableName;
            ds.Tables[BusinessDataSetIndex.GroupAvailableUser].TableName = "GroupAvailableUser";
            return ds;

        }

       /// <summary>
        /// 获取自定义按钮名称
       /// </summary>
       /// <returns></returns>
        public System.Data.DataTable GetFormTagCustomName()
        {
            string sql = "SELECT  *  FROM    sys_Fun_MenuBar  order by FName";

            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
        }

       /// <summary>
       /// 删除用户组
       /// </summary>
       /// <param name="groupCode">fid</param>
       /// <returns></returns>
        public bool DeleteGroupByKey(string groupCode)
        {
         
            ArrayList sqlList = new ArrayList();
            sqlList.Add("delete from sys_User_Group where FUserGroupID='" + groupCode + "'");
            sqlList.Add("delete from sys_UG_Auth where FUGID='" + groupCode + "'");
            sqlList.Add("delete from sys_UserGroup where FID='" + groupCode + "'");
            try
            {
                new DataBaseLayer(_Loginer.DBName).ExecuteSqlTran(sqlList);  //DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            }
            catch
            {
                return false;
            }
            return true;
        }
      
       /// <summary>
        /// 获取权限功能点定义(某一个功能菜单的)
       /// </summary>
       /// <param name="sFunID"></param>
       /// <returns></returns>
        public System.Data.DataTable GetAuthorityItem(string sFunID)
        {
            string sql = "SELECT  *  FROM    sys_Fun_MenuBar where FFunctionID='" + sFunID + "' order by FName";

            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
        }
        /// <summary>
        /// 检查用户组是否存在
        /// </summary>
        /// <param name="groupCode">用户组编号</param>
        /// <returns></returns>
        public bool CheckNoExists(string groupCode)
        {
            string sql = "select count(*) from  sys_UserGroup where FNumber='" + groupCode + "'";

            object o = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);
            return int.Parse(o.ToString()) > 0;
        }
       /// <summary>
        /// 获取窗体的可用权限值
       /// </summary>
       /// <param name="account"></param>
       /// <param name="moduleID"></param>
       /// <returns></returns>
        public int GetFormAuthority(string account, int moduleID)
        {
            string sql = "SELECT  UA.FAuths  FROM  sys_UG_Auth  UA INNER JOIN sys_UserGroup  U ON UA.FUGID = U.FID INNER JOIN  sys_Function  F ON UA.FunctionID = F.FID " +
                         "  where UA.FUGID in (SELECT     UG.FUserGroupID  FROM  sys_User_Group  UG INNER JOIN    sys_User  U ON UG.FUserID = U.FID  WHERE     (U.FAccount = '" + account + "') ) and f.fid=" + moduleID.ToString();

            object o = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);  //DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return int.Parse(o.ToString()) ;
        }

        public int GetFormShow(string account, int moduleID)
        {
            string sql = "SELECT     FAuths    FROM    sys_UG_Auth   WHERE     (FUserType = 1) AND (FUGID = '" + account + "') AND (FMainInterfacesID = '" + moduleID.ToString() + "')";

            object o = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);  //DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return int.Parse(o.ToString());
        }

        public int GetMenuAuthority(string account, int moduleID)
        {
            string sql = "SELECT     FIsAuth    FROM    sys_UG_Auth_Menu   WHERE     (FUserType = 1) AND (FUGID = '" + account + "') AND (FMainInterfacesID = '" + moduleID.ToString() + "')";

            object o = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);  //DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return int.Parse(o.ToString());
        }

        public int GetMenuShow(string account, int moduleID)
        {
            string sql = "SELECT     FIsShow    FROM    sys_UG_Auth_Menu   WHERE     (FUserType = 1) AND (FUGID = '" + account + "') AND (FMainInterfacesID = '" + moduleID.ToString() + "')";

            object o = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);  //DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return int.Parse(o.ToString());
        }
    }
}
