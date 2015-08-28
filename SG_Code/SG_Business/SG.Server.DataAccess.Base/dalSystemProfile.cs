///*************************************************************************/
///*
///* 文件名    ：dalSystemProfile.cs                                
///* 程序说明  : 系统参数数据层
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Common;
using SG.Interfaces.Base;
using SG.Models;
using SG.Models.Base;
using SG.ORMTool;
using SG.Tools.DataOperate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SG.Server.DataAccess.Base
{
     [DefaultORM_UpdateMode(typeof(tb_sys_SystemProfile), true)]
    public class dalSystemProfile : dalBaseDataDict, IBridge_SystemProfile
    {
         /// <summary>
         /// 构造器
         /// </summary>
         /// <param name="loginer">当前登录用户</param>
         public dalSystemProfile(Loginer loginer)
             : base(loginer)
         {
             _KeyName = tb_sys_SystemProfile.__KeyName; //主键字段
             _TableName = tb_sys_SystemProfile.__TableName;//表名
             _ModelType = typeof(tb_sys_SystemProfile);
         }

         /// <summary>
         /// 根据表名获取该表的SQL命令生成器
         /// </summary>
         /// <param name="tableName">表名</param>
         /// <returns></returns>
         protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
         {
           Type ORM = null;
           if (tableName == tb_sys_SystemProfile.__TableName) ORM = typeof(tb_sys_SystemProfile);
           if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");
           return new GenerateSqlCmdByTableFields(ORM, _Loginer.DbType);
         }


        public System.Data.DataSet GetSystemProfile()
        {
            ArrayList arrSqlList = new ArrayList();
            arrSqlList.Add("select distinct FCategory from sys_SystemProfile order by FCategory ");
            arrSqlList.Add("select  FID, FCategory, Fkey, FValue, FReadonly, FDescription, FLevel, FExplanation, FType, FSort,case when FType=2 then case when FValue='0' then '否' else '是' end else FValue end FSValue,0 IsUp  from sys_SystemProfile order by FSort ");
           
            DataSet ds = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataSet(arrSqlList);
            ds.Tables[1].TableName = tb_sys_SystemProfile.__TableName;
           
            return ds;
        }

        public string GetSystemProfileVal(string key)
        {
            string sql = "select FValue from sys_SystemProfile where Fkey='" + key + "'";
            return new DataBaseLayer(_Loginer.DBName).GetSingle(sql).ToString();
        }


    }


}
