///*************************************************************************/
///*
///* 文件名    ：dalBase.cs                                      
///* 程序说明  : 数据操作层基类定义
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using SG.Common;
using SG.ORMTool;
using SG.Tools.DataOperate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.DataAccess
{
    /// <summary>
    /// 数据操作层基类定义
    /// </summary>
    public class dalBase
    {
        /// <summary>
        /// 当前登录的用户信息
        /// </summary>
        protected Loginer _Loginer = null;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="loginer">当前登录的用户</param>
        public dalBase(Loginer loginer)
        {
            _Loginer = loginer;
        }

        /// <summary>
        /// 生成删除命令
        /// </summary>
        /// <param name="gen">SQL 生成器</param>
        /// <param name="tran">事务</param>
        /// <returns>返回SqlCommand对象</returns>
        protected IDbCommand GetDeleteCommand(IGenerateSqlCommand gen, IDbTransaction tran)
        {
            return gen.GetDeleteCommand(tran);
        }

        /// <summary>
        /// 生成资料更新命令
        /// </summary>
        /// <param name="gen">SQL 生成器</param>
        /// <param name="tran">事务</param>
        /// <returns>返回SqlCommand对象</returns>
        protected IDbCommand GetUpdateCommand(IGenerateSqlCommand gen, IDbTransaction tran)
        {
            return gen.GetUpdateCommand(tran);
        }

        /// <summary>
        /// 生成插入记录命令
        /// </summary>
        /// <param name="gen">SQL 生成器</param>
        /// <param name="tran">事务</param>
        /// <returns>返回SqlCommand对象</returns>
        protected IDbCommand GetInsertCommand(IGenerateSqlCommand gen, IDbTransaction tran)
        {
            return gen.GetInsertCommand(tran);
        }

        /// <summary>
        /// 日期类型需要转换
        /// </summary>
        protected void OnAdapterRowUpdating(object sender, SqlRowUpdatingEventArgs e)
        {
            foreach (SqlParameter p in e.Command.Parameters)
            {
                if (p.SqlDbType != SqlDbType.DateTime) continue;
                if (string.IsNullOrEmpty(p.Value.ToString()))
                { p.Value = DBNull.Value; continue; }
                if (DateTime.Parse(p.Value.ToString()).ToString("yyyyMMdd") == DateTime.MinValue.ToString("yyyyMMdd"))
                { p.Value = DBNull.Value; continue; }
            }
        }

        /// <summary>
        /// DataTable转换为DataSet
        /// </summary>
        /// <param name="table">DataTable</param>
        /// <returns></returns>
        public static DataSet TableToDataSet(DataTable table)
        {
            if (table.DataSet != null)
                return table.DataSet;
            else
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(table);
                return ds;
            }
        }

        #region 事务控制

        /// <summary>
        /// 用户自己启用事务控制模式，在保存数据前设置此参数。
        /// </summary>
        protected bool _UserManualControlTrans = false;

        /// <summary>
        /// 当前启用的事务
        /// </summary>
        protected IDbTransaction _CurrentTrans = null;

        /// <summary>
        /// 启用事务控制
        /// </summary>
        protected virtual void BeginTransaction()
        {
            IDbConnection conn = new DataBaseLayer(_Loginer.DBName).GetConnection();   //DataProvider.Instance.CreateConnection(_Loginer.DBName);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            _CurrentTrans = conn.BeginTransaction();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        protected virtual void CommitTransaction()
        {
            try
            {
                if (_CurrentTrans != null)
                {
                    _CurrentTrans.Commit();
                    _CurrentTrans = null;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        protected virtual void RollbackTransaction()
        {
            try
            {
                if (_CurrentTrans != null)
                {
                    _CurrentTrans.Rollback();
                    _CurrentTrans = null;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

    }

}
