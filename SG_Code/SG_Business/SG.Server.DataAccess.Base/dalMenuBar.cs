using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.Common;
using SG.ORMTool;
using SG.Models.Base;


/*==========================================
 *   程序说明: MenuBar的数据访问层
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2014/12/31 10:41:02
 *   最后修改: 2014/12/31 10:41:02
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   Copyright 2014-2015 东莞思谷数字技术有限公司
 *==========================================*/

namespace SG.Server.DataAccess.Base
{
    /// <summary>
    /// dalMenuBar
    /// </summary>
     [DefaultORM_UpdateMode(typeof(tb_sys_Fun_MenuBar), true)]
    public class dalMenuBar : dalBaseDataDict
    {
         /// <summary>
         /// 构造器
         /// </summary>
         /// <param name="loginer">当前登录用户</param>
         public dalMenuBar(Loginer loginer): base(loginer)
         {
             _KeyName = tb_sys_Fun_MenuBar.__KeyName; //主键字段
             _TableName = tb_sys_Fun_MenuBar.__TableName;//表名
             _ModelType = typeof(tb_sys_Fun_MenuBar);
         }

         /// <summary>
         /// 根据表名获取该表的SQL命令生成器
         /// </summary>
         /// <param name="tableName">表名</param>
         /// <returns></returns>
         protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
         {
           Type ORM = null;
           if (tableName == tb_sys_Fun_MenuBar.__TableName) ORM = typeof(tb_sys_Fun_MenuBar);
           if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");
           return new GenerateSqlCmdByTableFields(ORM,_Loginer.DbType);
         }

     }
}
