///*************************************************************************/
///*
///* 文件名    ：dalAttachFile.cs                                
///* 程序说明  : 附件数据处理层
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Common;
using SG.Interfaces.Base;
using SG.Models.Base;
using SG.ORMTool;
using SG.Tools.DataOperate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.DataAccess.Base
{
    [DefaultORM_UpdateMode(typeof(tb_sys_AttachFile), true)]
    public class dalAttachFile : dalBaseDataDict, IBridge_AttachFile
    {
         /// <summary>
         /// 构造器
         /// </summary>
         /// <param name="loginer">当前登录用户</param>
        public dalAttachFile(Loginer loginer)
             : base(loginer)
         {
             _KeyName = tb_sys_AttachFile.__KeyName; //主键字段
             _TableName = tb_sys_AttachFile.__TableName;//表名
             _ModelType = typeof(tb_sys_AttachFile);
         }

         /// <summary>
         /// 根据表名获取该表的SQL命令生成器
         /// </summary>
         /// <param name="tableName">表名</param>
         /// <returns></returns>
         //protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
         //{
         //  Type ORM = null;
         //  if (tableName == tb_sys_AttachFile.__TableName) ORM = typeof(tb_sys_AttachFile);
         //  if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");
         //  return new GenerateSqlCmdByTableFields(ORM, _Loginer.DbType);
         //}
         /// <summary>
         /// 获取指定单据的附件数据
         /// </summary>
         /// <param name="docID">单据号码</param>
         /// <returns></returns>
        public DataTable GetAttachFileData(string docID)
         {
             string sql = "select * from tb_AttachFile where FDocID='" + docID + "'";

             DataTable dt = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
             return dt;
         }
    }
}
