///*************************************************************************/
///*
///* 文件名    ：IGenerateSqlCommand.cs                                      
///* 程序说明  : SQL生成器接口
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.ORMTool
{
    /// <summary>
    /// SQL生成器接口
    /// </summary>
    public interface IGenerateSqlCommand
    {
        /// <summary>
        /// 生成插入记录的SQL命令
        /// </summary>
        /// <param name="tran">事务</param>
        /// <returns></returns>

        IDbCommand GetInsertCommand(IDbTransaction tran);
        
        /// <summary>
        /// 生成更新记录的SQL命令
        /// </summary>
        /// <param name="tran"></param>
        /// <returns></returns>
        IDbCommand GetUpdateCommand(IDbTransaction tran);

        /// <summary>
        /// 生成删除记录的SQL命令
        /// </summary>
        /// <param name="tran"></param>
        /// <returns></returns>
        IDbCommand GetDeleteCommand(IDbTransaction tran);

        /// <summary>
        /// 生成插入记录用SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyName">主键</param>
        /// <param name="field">字段列表</param>
        /// <returns></returns>
        string GernerateInsertSql(string tableName, string keyName, IList field, string DbType);

        /// <summary>
        /// 生成更新记录用SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyName">主键</param>
        /// <param name="field">字段列表</param>
        /// <returns></returns>
        string GernerateUpdateSql(string tableName, string keyName, IList field, string DbType);

        /// <summary>
        /// 生成删除记录用SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="keyName">主键</param>
        /// <param name="field">字段列表</param>
        /// <returns></returns>
        string GernerateDeleteSql(string tableName, string keyName, IList field, string DbType);

        /// <summary>
        /// 单据号码
        /// </summary>
        /// <returns></returns>
        string GetDocNoFieldName();

        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        string GetPrimaryFieldName();

        /// <summary>
        /// 外键
        /// </summary>
        /// <returns></returns>
        string GetForeignFieldName();

        /// <summary>
        /// 是否主表
        /// </summary>
        /// <returns></returns>
        bool IsSummary();
    }
}
