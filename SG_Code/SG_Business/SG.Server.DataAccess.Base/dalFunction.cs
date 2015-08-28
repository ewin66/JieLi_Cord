///*************************************************************************/
///*
///* 文件名    ：dalFunction.cs                                      
///* 程序说明  : 权限设置
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using SG.Common;
using SG.Models.Base;
using SG.ORMTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.DataAccess.Base
{
    /// <summary>
    /// 功能菜单
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_sys_Function), true)]
     public class dalFunction:dalBaseDataDict
    {
        public dalFunction(Loginer loginer)
            : base(loginer)
        {
            _TableName = tb_sys_Function.__TableName;
            _KeyName = tb_sys_Function.__KeyName;
            _ModelType = typeof(tb_sys_Function);
        }

        /// <summary>
        /// 根据表名获取该表的SQL命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;
            if (tableName == tb_sys_Function.__TableName) ORM = typeof(tb_sys_Function);
            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");
            return new GenerateSqlCmdByTableFields(ORM, _Loginer.DbType);
        }

    }
}
