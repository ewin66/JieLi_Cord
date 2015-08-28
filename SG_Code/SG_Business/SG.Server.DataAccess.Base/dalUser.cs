///*************************************************************************/
///*
///* 文件名    ：dalUser.cs                                      
///* 程序说明  : 用户数据字典的DAL层
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using SG.Common;
using SG.Interfaces.Base;
using SG.ORMTool;
using SG.Server.DataAccess;
using SG.Tools.DataOperate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Models.Base;
using System.Collections;

namespace SG.Server.DataAccess.Base
{
    /// <summary>
    /// 用户数据字典的DAL层
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_sys_User), true)]
    public class dalUser : dalBaseDataDict, IBridge_User
    {
        public dalUser(Loginer loginer)
            : base(loginer)
        {
            _KeyName = tb_sys_User.__KeyName; //主键字段
            _TableName = tb_sys_User.__TableName;//表名
            _ModelType = typeof(tb_sys_User);
        }

        /// <summary>
        /// 跟据表名创建SQL命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_sys_User.__TableName) ORM = typeof(tb_sys_User);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM,_Loginer.DbType);
        }

        /// <summary>
        /// 获取所有用户列表
        /// </summary>
        /// <returns></returns>
        public DataTable Getb_sys_Users()
        {
            string sql = "select * from sys_User";

            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
            
        }

        /// <summary>
        /// 检查用户是否存在
        /// </summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public bool ExistsUser(string account)
        {
            string sql = "";
            IDbDataParameter[] sPara = new IDbDataParameter[1];
            if (_Loginer.DbType == DbAcessTyp.SQLServer)
            {
                sql = "select count(*) from sys_User where FAccount=@Account";
                sPara[0] = DataConverter.GetSqlPara("@Account", DataConverter.SqlTypeToString(SqlDbType.VarChar));
            }
            else
            {
                sql = "select count(*) from sys_User where FAccount=:Account";
                sPara[0] = DataConverter.GetOraclePara("Account", DataConverter.SqlTypeToString(SqlDbType.VarChar));
            }
            sPara[0].Value = account;

            object o = new DataBaseLayer(_Loginer.DBName).GetSingle(sql, sPara);
            return int.Parse(o.ToString()) > 0;
           
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="account">登录帐号</param>
        public void Logout(string account)
        {
          new dalCommon(_Loginer).WriteLogOP( "0", "0", "退出系统", "");
            string sql ="";
            if (_Loginer.DbType == DbAcessTyp.SQLServer)
                sql = "UPDATE sys_User SET FFlagOnline='0',FLastLogoutTime=GetDate() WHERE FAccount='" + _Loginer.Account + "'";
            else
                sql = "UPDATE sys_User SET FFlagOnline='0',FLastLogoutTime=sysdate WHERE FAccount='" + _Loginer.Account + "'";
            new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginUser">登录用户信息</param>
        /// <param name="LoginUserType">登录类型</param>
        /// <returns></returns>
        public DataTable Login(LoginUser loginUser, char LoginUserType)
        {
            string strErr = "";
            string sql = "";
            //用户名为空
            if (loginUser.Account == string.Empty)
            {
                strErr = "帐户不能为空！";
            }

            if(!"S,W,N".Contains(LoginUserType.ToString()))
            {
                strErr = "无法识别的登录类型！";
            }

            //Windows域
            if(LoginUserType=='W')
            {
                sql = "select * from sys_user where fdomainName like '%" + loginUser.Account + "@%'";
            }
            //Novell域
            if (LoginUserType == 'N')
            {
                sql = "select * from sys_user where fnovellaccount like '%" + loginUser.Account + ".%'";
            }

            //系统
            if (LoginUserType == 'S')
            {
                sql = "select * from sys_user where faccount ='" + loginUser.Account + "' and fpassword='" + loginUser.Password + "'";
            }

          

            if(strErr.Trim()!=string.Empty)
                throw new CustomException(strErr); //抛出异常

            DataTable ds = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
            if (ds.Rows.Count == 1)
            {                
                if (_Loginer.DbType == DbAcessTyp.SQLServer)
                    sql = "UPDATE sys_User SET FFlagOnline='1',FLastLoginTime=GetDate(),FLoginCounter=isnull(FLoginCounter,0) + 1 WHERE FAccount='" + loginUser.Account + "'";
                else
                    sql = "UPDATE sys_User SET FFlagOnline='1',FLastLoginTime=sysdate,FLoginCounter=nvl(FLoginCounter,0) + 1 WHERE FAccount='" + loginUser.Account + "'";
                new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);
 
                return ds;
            }
            else
                throw new CustomException("请检查用户名和密码！"); //抛出异常
            
        }

        /// <summary>
        /// 用户刷卡登录
        /// </summary>
        /// <param name="loginUser">登录用户信息</param>
        /// <param name="LoginUserType">登录类型</param>
        /// <returns></returns>
        public DataTable LoginByCard(LoginUser loginUser, char LoginUserType)
        {
            string strErr = "";
            string sql = "";
            //用户名为空
            if (loginUser.CardNo == string.Empty)
            {
                strErr = "卡号不能为空！";
            }

            if (!"S,W,N".Contains(LoginUserType.ToString()))
            {
                strErr = "无法识别的登录类型！";
            }

            //Windows域
            if (LoginUserType == 'W')
            {
                if (loginUser.DbType == DbAcessTyp.SQLServer)
                {
                    sql = "select * from sys_user where fdomainName like '%'+(select FAccount from sys_User where FCardNo='" + loginUser.CardNo + "')+'@%'";
                }
                else if (loginUser.DbType == DbAcessTyp.Oracle)
                {
                    sql = "select * from sys_user where fdomainName like '%'||(select FAccount from sys_User where FCardNo='" + loginUser.CardNo + "')||'@%'";
                }
            }
            //Novell域
            if (LoginUserType == 'N')
            {
                if (loginUser.DbType == DbAcessTyp.SQLServer)
                {
                    sql = "select * from sys_user where fnovellaccount like '%'+(select FAccount from sys_User where FCardNo='" + loginUser.CardNo + "')+'.%'";
                }
                else if (loginUser.DbType == DbAcessTyp.Oracle)
                {
                    sql = "select * from sys_user where fnovellaccount like '%'||(select FAccount from sys_User where FCardNo='" + loginUser.CardNo + "')||'.%'";
                }
            }

            //系统
            if (LoginUserType == 'S')
            {
                sql = "select * from sys_User where FCardNo='" + loginUser.CardNo + "'";
            }



            if (strErr.Trim() != string.Empty)
                throw new CustomException(strErr); //抛出异常

            DataTable ds = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
            if (ds.Rows.Count == 1)
            {
                if (_Loginer.DbType == DbAcessTyp.SQLServer)
                    sql = "UPDATE sys_User SET FFlagOnline='1',FLastLoginTime=GetDate(),FLoginCounter=isnull(FLoginCounter,0) + 1 WHERE FCardNo='" + loginUser.CardNo + "'";
                else
                    sql = "UPDATE sys_User SET FFlagOnline='1',FLastLoginTime=sysdate,FLoginCounter=nvl(FLoginCounter,0) + 1 WHERE FCardNo='" + loginUser.CardNo + "'";
                new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);

                return ds;
            }
            else
                throw new CustomException("请检查卡号！"); //抛出异常

        }

        /// <summary>
        /// 跟据Novell网帐号获取系统帐号
        /// </summary>
        /// <param name="novellAccount">Novell网帐号</param>
        /// <returns></returns>
        public DataTable Getb_sys_UserByNovellID(string novellAccount)
        {
            string sql = "select * from sys_User where FNovellAccount='" + novellAccount + "'";

            DataTable dt = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);  //DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_sys_User.__TableName);
            return dt;
        }

        /// <summary>
        /// 获取当前用户的系统权限
        /// </summary>
        /// <param name="user">当前用户</param>
        /// <returns></returns>
        public DataTable Getb_sys_UserAuthorities(Loginer user)
        {
            string sql = "SELECT UA.FID, UA.FUGID, UA.FunctionID, UA.FAuths, UA.FModelID,UA.FMenu, U.FNumber  GNumber, U.FName  GName, F.FNumber  FNum, F.FName FName,F.FMODELID  FROM  sys_UG_Auth  UA INNER JOIN sys_UserGroup  U ON UA.FUGID = U.FID left outer JOIN  sys_Function  F ON UA.FunctionID = F.FID " +
                         "  where UA.FUGID in (SELECT     UG.FUserGroupID  FROM  sys_User_Group  UG INNER JOIN    sys_User  U ON UG.FUserID = U.FID  WHERE     (U.FID = '" + user.Fid + "')) ";

            DataTable dt = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 获取用户所属组
        /// </summary>
        /// <param name="account">当前用户</param>
        /// <returns></returns>
        public DataTable Getb_sys_UserGroups(string account)
        {
            string sql = "SELECT      g.FID, g.FNumber, g.FName, g.FNote FROM   sys_User_Group  ug INNER JOIN   sys_UserGroup  g ON ug.FUserGroupID = g.FID INNER JOIN    sys_User  u ON ug.FUserID = u.FID  WHERE     (u.FAccount = '" + account + "')";

            DataTable dt = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);  //DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_sys_UserGroup.__TableName);
            return dt;
        }

        /// <summary>
        /// 获取用户数据
        /// </summary>
        /// <param name="account">帐号</param>
        /// <returns></returns>
        public DataTable Getb_sys_User(string account)
        {
            string sql = "select * from sys_User where FAccount='" + account + "'";

            DataTable dt = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);  //DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, tb_sys_User.__TableName);
            return dt;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="account">帐号</param>
        /// <returns></returns>
        public bool DeleteUser(string account)
        {
            ArrayList sqlList = new ArrayList();
            sqlList.Add("delete from sys_User_Group where FUserID in (select fid from sys_User where FAccount='" + account + "')");
            sqlList.Add("delete from sys_UG_Auth where FUGID in (select fid from sys_User where FAccount='" + account + "')");
            sqlList.Add("Delete from sys_User where FAccount='" + account + "'");
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
        /// 修改用户密码
        /// </summary>
        /// <param name="account">帐号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool ModifyPassword(string account, string pwd)
        {
            string sql = "update sys_User set Fpassword='" + pwd + "' where Faccount='" + account + "'";

            object o = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);  //DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return int.Parse(o.ToString()) != 0;
        }

        public DataTable Getb_sys_UserDirect(string account, string DBName)
        {
            string sql = "select * from sys_User where FAccount='"+ account +"'";
            //SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            //cmd.AddParam("@Account", SqlDbType.VarChar, account);
            DataTable dt = new DataBaseLayer(DBName).ExecuteQueryDataTable(sql);  //DataProvider.Instance.GetTable(DBName, cmd.SqlCommand, tb_sys_User.__TableName);
            return dt;
        }

        public bool ModifyPwdDirect(string account, string pwd, string DBName)
        {
            string sql = "update sys_User set Fpassword='" + pwd + "' where Faccount='" + account + "'";

            object o = new DataBaseLayer(DBName).ExecuteSql(sql); //DataProvider.Instance.ExecuteNoQuery(DBName, cmd.SqlCommand);
            return int.Parse(o.ToString()) != 0;
        }


        public DataSet Getb_sys_UserReportData(DateTime createDateFrom, DateTime createDateTo)
        {
            StringBuilder sb = new StringBuilder("select * from sys_User where 1=1 ");
            if (_Loginer.DbType == DbAcessTyp.SQLServer)
            {
                if (createDateFrom.Year > 1901)
                    sb.Append(" AND CONVERT(VARCHAR,FCreateTime,112)>='" + createDateFrom.ToString("yyyyMMdd") + "'");

                if (createDateTo.Year > 1901)
                    sb.Append(" AND CONVERT(VARCHAR,FCreateTime,112)<='" + createDateTo.ToString("yyyyMMdd") + "'");
            }
            else
            {
                if (createDateFrom.Year > 1901)
                    sb.Append(" AND FCreateTime >=to_date(" + createDateFrom + ", 'yyyy-mm-dd hh24:mi:ss')");

                if (createDateTo.Year > 1901)
                    sb.Append(" AND FCreateTime<=to_date(" + createDateTo + ", 'yyyy-mm-dd hh24:mi:ss'");

            }

            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataSet(sb.ToString()); //DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
        }
    }
}
