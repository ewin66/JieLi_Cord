using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.Models;
using SG.Common;
using SG.ORMTool;
using SG.Models.Base;
using SG.Interfaces.Base;
using SG.Tools.DataOperate;


/*==========================================
 *   程序说明: DbLink的数据访问层
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2015/01/05 05:24:42
 *   最后修改: 2015/01/05 05:24:42
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   Copyright 2014-2015 东莞思谷数字技术有限公司
 *==========================================*/

namespace SG.Server.DataAccess.Base
{
    /// <summary>
    /// 配置数据连接
    /// </summary>
   [DefaultORM_UpdateMode(typeof(tb_sys_DbLink), true)]
    public class dalDbLink : dalBaseDataDict, IBridge_DbLink
    {
         /// <summary>
         /// 构造器
         /// </summary>
         /// <param name="loginer">当前登录用户</param>
         public dalDbLink(Loginer loginer): base(loginer)
         {
             _KeyName = tb_sys_DbLink.__KeyName; //主键字段
             _TableName = tb_sys_DbLink.__TableName;//表名
             _ModelType = typeof(tb_sys_DbLink);
         }

         /// <summary>
         /// 根据表名获取该表的SQL命令生成器
         /// </summary>
         /// <param name="tableName">表名</param>
         /// <returns></returns>
         protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
         {
           Type ORM = null;
           if (tableName == tb_sys_DbLink.__TableName) ORM = typeof(tb_sys_DbLink);
           if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");
           return new GenerateSqlCmdByTableFields(ORM, _Loginer.DbType);
         }



         public DataTable GetDBLink()
         {
             string sql = "SELECT     d.*, t.FName DbType, u.FUserName FROM sys_DbLink  d INNER JOIN sys_DbType  t ON d.FDataType = t.FID INNER JOIN sys_User  u ON d.FUserID = u.FID order by d.fNumber";
             DataTable dt = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
             dt.TableName = tb_sys_DbLink.__TableName;
             return dt;
         }


         public DataTable GetDBLinkByID(string key)
         {
             string sql = "SELECT     d.*, t.FName DbType, u.FUserName FROM sys_DbLink  d INNER JOIN sys_DbType  t ON d.FDataType = t.FID INNER JOIN sys_User  u ON d.FUserID = u.FID where d.fid='" + key + "' order by d.fNumber";
             DataTable dt = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
             dt.TableName = tb_sys_DbLink.__TableName;
             return dt;
         }
    }
}
