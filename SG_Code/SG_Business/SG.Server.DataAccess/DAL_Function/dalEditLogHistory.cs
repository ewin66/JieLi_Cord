///*************************************************************************/
///*
///* 文件名    ：dalEditLogHistory.cs                                
///* 程序说明  : 修改历史记录的数据层
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Common;
using SG.Interfaces;
using SG.Tools.DataOperate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace SG.Server.DataAccess
{
    /// <summary>
    /// 修改历史记录的数据层
    /// </summary>
    public class dalEditLogHistory : IBridge_EditLogHistory
    {
        private Loginer _Loginer = null;

        public dalEditLogHistory(Loginer loginer)
        {
            _Loginer = loginer;
        }

        /// <summary>
        /// 保存跟踪的字段定义数据字典
        /// </summary>
        public bool SaveFieldDef(DataTable data)
        {
            string sqlAdd="";
            string sqlEdt = "";
            string sqlDel = "";
            int ret = 0;
            IDbConnection conn = DataProvider.Instance.CreateConnection(_Loginer.DBName);
            if (_Loginer.DbType == DbAcessTyp.SQLServer)
            {
                sqlAdd = "INSERT INTO sys_Log_TableFields(fid,TableName,FieldName) VALUES (@fid,@TableName,@FieldName)";
                sqlEdt = "UPDATE sys_Log_TableFields SET TableName=@TableName,FieldName=@FieldName WHERE Fid=@fid ";
                sqlDel = "DELETE sys_Log_TableFields WHERE fid=@fid";
                SqlCommand cmdUpdate = new SqlCommand(sqlEdt, (SqlConnection)conn);
                cmdUpdate.Parameters.Add("@TableName", SqlDbType.VarChar, 50, "TableName");
                cmdUpdate.Parameters.Add("@FieldName", SqlDbType.VarChar, 20, "FieldName");
                cmdUpdate.Parameters.Add("@fid", SqlDbType.Int, 4, "fid");

                SqlCommand cmdDelete = new SqlCommand(sqlDel, (SqlConnection)conn);
                cmdDelete.Parameters.Add("@fid", SqlDbType.Int, 4, "fid");

                SqlCommand cmdInsert = new SqlCommand(sqlAdd, (SqlConnection)conn);
                cmdInsert.Parameters.Add("@TableName", SqlDbType.VarChar, 50, "TableName");
                cmdInsert.Parameters.Add("@FieldName", SqlDbType.VarChar, 20, "FieldName");
                cmdInsert.Parameters.Add("@fid", SqlDbType.Int, 4, "fid");
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.UpdateCommand = cmdUpdate;
                adp.DeleteCommand = cmdDelete;
                adp.InsertCommand = cmdInsert;
                ret = adp.Update(data);
            }
            else
            {
                sqlAdd = "INSERT INTO sys_Log_TableFields(fid,TableName,FieldName) VALUES (:TableName,:FieldName)";
                sqlEdt = "UPDATE sys_Log_TableFields SET TableName=:TableName,FieldName=:FieldName WHERE Fid=:isid ";
                sqlDel = "DELETE sys_Log_TableFields WHERE fid=:isid";
                OracleCommand cmdUpdate = new OracleCommand(sqlEdt, (OracleConnection)conn);
                OracleCommand cmdDelete = new OracleCommand(sqlDel, (OracleConnection)conn);
                OracleCommand cmdInsert = new OracleCommand(sqlAdd, (OracleConnection)conn);
                OracleParameter para = new OracleParameter("TableName", OleDbType.VarChar);
                para.SourceColumn = "TableName";
                cmdUpdate.Parameters.Add(para);
                cmdInsert.Parameters.Add(para);
                para = new OracleParameter("FieldName", OleDbType.VarChar);
                para.SourceColumn = "FieldName";
                cmdUpdate.Parameters.Add(para);
                cmdInsert.Parameters.Add(para);
                para = new OracleParameter("fid", OleDbType.VarChar);
                para.SourceColumn = "fid";
                cmdUpdate.Parameters.Add(para);               
                cmdDelete.Parameters.Add(para);
                cmdInsert.Parameters.Add(para);

                OracleDataAdapter adp = new OracleDataAdapter();
                adp.UpdateCommand = cmdUpdate;
                adp.DeleteCommand = cmdDelete;
                adp.InsertCommand = cmdInsert;
                ret = adp.Update(data);
            }
           
           
            return ret > 0;
        }

        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="log"></param>
        private void WriteLog(LogDef log)
        {
            string sql1 = ""; 
             string sql2 = "";

             if (_Loginer.DbType == DbAcessTyp.SQLServer)
             {
                 sql1 = "INSERT INTO sys_Log_Table(fid,GUID32 ,LogUser ,LogDate ,OPType ,DocNo ,TableName ,KeyFieldName,IsMaster) " +
                              "           VALUES (@fid,@GUID32,@LogUser,@LogDate,@OPType,@DocNo,@TableName,@KeyFieldName,@IsMaster)";
                 sql2 = "INSERT INTO sys_Log_TableDtl (fid,GUID32,TableName,FieldName,OldValue,NewValue) VALUES(@fid,@GUID32,@TableName,@FieldName,@OldValue,@NewValue)";
             }
             else
             {
                 sql1 = "INSERT INTO sys_Log_Table(fid,GUID32 ,LogUser ,LogDate ,OPType ,DocNo ,TableName ,KeyFieldName,IsMaster) " +
                              "           VALUES (:fid,:GUID32,:LogUser,:LogDate,:OPType,:DocNo,:TableName,:KeyFieldName,:IsMaster)";
                 sql2 = "INSERT INTO sys_Log_TableDtl (fid,GUID32,TableName,FieldName,OldValue,NewValue) VALUES(:fid,:GUID32,:TableName,:FieldName,:OldValue,:NewValue)";
             }

            IDbConnection conn = DataProvider.Instance.CreateConnection(_Loginer.DBName);
            IDbCommand cmd = null;
            IDbCommand cmdDtl = null;
            try
            {
                if (_Loginer.DbType == DbAcessTyp.SQLServer)
                {
                    if (log.IsMaster == true) //注意! 只有主表才写入tb_Log表
                    {
                        cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql1;
                        cmd.Connection = conn;
                        SqlParameter spara = new SqlParameter("@fid", SqlDbType.VarChar);
                        spara.Value = DocNoTool.GetTableID(_Loginer.DBName, "sys_Log_Table", "fid", _Loginer);
                        cmd.Parameters.Add(spara);
                        spara = new SqlParameter("@GUID32", SqlDbType.VarChar);
                        spara.Value = log.GUID32;
                        cmd.Parameters.Add(spara);
                        spara = new SqlParameter("@LogUser", SqlDbType.VarChar);
                        spara.Value = log.LogUser;
                        cmd.Parameters.Add(spara);
                        spara = new SqlParameter("@LogDate", SqlDbType.DateTime);
                        spara.Value = log.LogDate;
                        cmd.Parameters.Add(spara);
                        spara = new SqlParameter("@OPType", SqlDbType.Int);
                        spara.Value = log.OPType;
                        cmd.Parameters.Add(spara);
                        spara = new SqlParameter("@DocNo", SqlDbType.VarChar);
                        spara.Value = log.DocNo;
                        cmd.Parameters.Add(spara);
                        spara = new SqlParameter("@TableName", SqlDbType.VarChar);
                        spara.Value = log.TableName;
                        cmd.Parameters.Add(spara);
                        spara = new SqlParameter("@KeyFieldName", SqlDbType.VarChar);
                        spara.Value = log.KeyFieldName;
                        cmd.Parameters.Add(spara);
                        spara = new SqlParameter("@IsMaster", SqlDbType.VarChar);
                        spara.Value = log.IsMaster ? "Y" : "N";
                        cmd.Parameters.Add(spara);

                        cmd.ExecuteNonQuery();
                    }

                    //log明细
                    foreach (LogDefDtl d in log.Details)
                    {
                        cmdDtl = new SqlCommand(); ;
                        cmdDtl.CommandType = CommandType.Text;
                        cmdDtl.CommandText = sql2;
                        cmdDtl.Connection = conn;
                        SqlParameter spara = new SqlParameter("@fid", SqlDbType.VarChar);
                        spara.Value = DocNoTool.GetTableID(_Loginer.DBName, "sys_Log_TableDtl", "fid", _Loginer);
                        cmdDtl.Parameters.Add(spara);
                        spara = new SqlParameter("@GUID32", SqlDbType.VarChar);
                        spara.Value = d.GUID32;
                        cmdDtl.Parameters.Add(spara);
                        spara = new SqlParameter("@TableName", SqlDbType.VarChar);
                        spara.Value = d.TableName;
                        cmdDtl.Parameters.Add(spara);
                        spara = new SqlParameter("@FieldName", SqlDbType.VarChar);
                        spara.Value = d.FieldName;
                        cmdDtl.Parameters.Add(spara);
                        spara = new SqlParameter("@OldValue", SqlDbType.VarChar);
                        spara.Value = d.OldValue;
                        cmdDtl.Parameters.Add(spara);
                        spara = new SqlParameter("@NewValue", SqlDbType.VarChar);
                        spara.Value = d.NewValue;
                        cmdDtl.Parameters.Add(spara);
                        cmdDtl.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (log.IsMaster == true) //注意! 只有主表才写入tb_Log表
                    {
                        cmd = new OracleCommand ();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql1;
                        cmd.Connection = conn;
                        OleDbParameter spara = new OleDbParameter("fid", OleDbType.VarChar);
                        spara.Value = DocNoTool.GetTableID(_Loginer.DBName, "sys_Log_Table", "fid", _Loginer);
                        cmd.Parameters.Add(spara);
                        spara = new OleDbParameter("GUID32", OleDbType.VarChar);
                        spara.Value = log.GUID32;
                        cmd.Parameters.Add(spara);
                        spara = new OleDbParameter("LogUser", OleDbType.VarChar);
                        spara.Value = log.LogUser;
                        cmd.Parameters.Add(spara);
                        spara = new OleDbParameter("LogDate", OleDbType.Date);
                        spara.Value = log.LogDate;
                        cmd.Parameters.Add(spara);
                        spara = new OleDbParameter("OPType", OleDbType.Integer);
                        spara.Value = log.OPType;
                        cmd.Parameters.Add(spara);
                        spara = new OleDbParameter("DocNo", OleDbType.VarChar);
                        spara.Value = log.DocNo;
                        cmd.Parameters.Add(spara);
                        spara = new OleDbParameter("TableName", OleDbType.VarChar);
                        spara.Value = log.TableName;
                        cmd.Parameters.Add(spara);
                        spara = new OleDbParameter("KeyFieldName", OleDbType.VarChar);
                        spara.Value = log.KeyFieldName;
                        cmd.Parameters.Add(spara);
                        spara = new OleDbParameter("IsMaster", OleDbType.VarChar);
                        spara.Value = log.IsMaster ? "Y" : "N";
                        cmd.Parameters.Add(spara);

                        cmd.ExecuteNonQuery();
                    }

                    //log明细
                    foreach (LogDefDtl d in log.Details)
                    {
                        cmdDtl = new SqlCommand(); ;
                        cmdDtl.CommandType = CommandType.Text;
                        cmdDtl.CommandText = sql2;
                        cmdDtl.Connection = conn;
                        OleDbParameter spara = new OleDbParameter("fid", OleDbType.VarChar);
                        spara.Value = DocNoTool.GetTableID(_Loginer.DBName, "sys_Log_TableDtl", "fid", _Loginer);
                        cmdDtl.Parameters.Add(spara);
                        spara = new OleDbParameter("GUID32", OleDbType.VarChar);
                        spara.Value = d.GUID32;
                        cmdDtl.Parameters.Add(spara);
                        spara = new OleDbParameter("TableName", OleDbType.VarChar);
                        spara.Value = d.TableName;
                        cmdDtl.Parameters.Add(spara);
                        spara = new OleDbParameter("FieldName", OleDbType.VarChar);
                        spara.Value = d.FieldName;
                        cmdDtl.Parameters.Add(spara);
                        spara = new OleDbParameter("OldValue", OleDbType.VarChar);
                        spara.Value = d.OldValue;
                        cmdDtl.Parameters.Add(spara);
                        spara = new OleDbParameter("NewValue", OleDbType.VarChar);
                        spara.Value = d.NewValue;
                        cmdDtl.Parameters.Add(spara);
                        cmdDtl.ExecuteNonQuery();
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 比较新/旧数据,如有修改则生成对应的修改日志.
        /// </summary>
        /// <param name="changes">修改后的数据</param>       
        /// <param name="tracedFields">跟踪的字段列表</param>
        /// <param name="keyField">记录主键,比较新旧数据时用于定位</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        private IList CompareTable(string logID, DataTable originalData, DataTable changes, string[] tracedFields, string keyField, string tableName, bool isMaster)
        {
            IList logs = new ArrayList();

            #region 循环原始数据比较修改后的数据
            foreach (DataRow row in originalData.Rows)
            {
                string keyValue = row[keyField].ToString();//主键值
                DataRow[] current = changes.Select(keyField + "='" + keyValue + "'");
                if (current.Length == 0) continue;//没有记录,不写日志

                LogDef log = new LogDef();
                log.GUID32 = logID;
                log.DocNo = keyValue;
                log.KeyFieldName = keyField;
                log.LogDate = DateTime.Now;
                log.LogUser = _Loginer.Account; //当前登录用户
                log.OPType = LogOPType.LogEdit;//新增或修改
                log.TableName = tableName;
                log.IsMaster = isMaster;

                if (current[0].RowState == DataRowState.Deleted) continue;//已经删除,不写入日志

                foreach (string fieldName in tracedFields)
                {
                    //if (IsNumbericField(row.Table.Columns[fieldName].DataType))
                    string c1 = ConvertEx.ToString(row[fieldName]); //取原始数据
                    string c2 = ConvertEx.ToString(current[0][fieldName]);//取最新修改值

                    //数字类型要特别处理
                    if (CompareNumbericField(row.Table.Columns[fieldName], c1, c2))
                        log.AppendDetail(tableName, fieldName, c1, c2);//对比有差异\
                    else if (c1 != c2)
                        log.AppendDetail(tableName, fieldName, c1, c2);//对比有差异
                }

                if (log.HasDetail) logs.Add(log); //有修改记录
            }
            #endregion

            return logs;
        }

        /// <summary>
        /// 比较数字类型值1和值2
        /// </summary>
        /// <param name="dataColumn">列</param>
        /// <param name="c1">值1</param>
        /// <param name="c2">值2</param>
        /// <returns></returns>
        private bool CompareNumbericField(DataColumn dataColumn, string c1, string c2)
        {
            if ((c1 == "") && (c2 == "")) return false;
            if ((c1 == "") && (c2 != "")) return true;
            if ((c1 != "") && (c2 == "")) return true;

            double result1;
            double result2;
            if (double.TryParse(c1, out result1) && double.TryParse(c2, out result2))
            {
                return result1 != result2;
            }

            return false;
        }

        /// <summary>
        /// 获取指定表需要跟踪的字段列表
        /// </summary>
        /// <param name="tableName">数据表</param>
        /// <returns></returns>
        public string[] GetTracedFields(string tableName)
        {
            DataTable tracedFields = this.GetLogFieldDef(tableName);
            string[] fields = new string[tracedFields.Rows.Count];
            for (int i = 0; i <= tracedFields.Rows.Count - 1; i++)
                fields[i] = tracedFields.Rows[i]["FieldName"].ToString();
            return fields;
        }

        /// <summary>
        /// 获取跟踪的字段
        /// </summary>
        /// <param name="tableName">表名</param>        
        public DataTable GetLogFieldDef(string tableName)
        {
            string sql = "select * from sys_Log_TableFields where TableName='" + tableName + "'";
            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql); //DataProvider.Instance.GetTable(_Loginer.DBName, sql, "tb_LogFields");
        }

        /// <summary>
        /// 记录单表日志
        /// </summary>
        /// <param name="changes">修改后的数据</param>
        /// <param name="tableName">表名</param>
        /// <param name="keyFieldName">记录的主键,比较新旧数据时用于定位</param>
        public void WriteLog(string logID, DataTable originalData, DataTable changes, string tableName, string keyFieldName, bool isMaster)
        {
            if ((changes == null) || (changes.Rows.Count == 0)) return;

            string[] tracedFields = this.GetTracedFields(tableName);
            IList logs = this.CompareTable(logID, originalData, changes, tracedFields, keyFieldName, tableName, isMaster);

            foreach (LogDef log in logs) this.WriteLog(log); //写入数据库
        }

        /// <summary>
        /// 搜索系统日志数据
        /// </summary>
        /// <param name="logUser">用户</param>
        /// <param name="tableName">数据表名</param>
        /// <param name="dateFrom">日志日期：由</param>
        /// <param name="dateTo">日志日期：至</param>
        /// <returns></returns>
        public DataSet SearchLog(string logUser, string tableName, DateTime dateFrom, DateTime dateTo)
        {
            //SqlCommandBase cmd = SqlBuilder.BuildSqlProcedure("sp_SearchLog");
            //cmd.AddParam("@LogUser", SqlDbType.VarChar, logUser);
            //cmd.AddParam("@TableName", SqlDbType.VarChar, tableName);
            //cmd.AddParam("@LogDateFrom", SqlDbType.VarChar, ConvertEx.ToCharYYYYMMDD(dateFrom));
            //cmd.AddParam("@LogDateTo", SqlDbType.VarChar, ConvertEx.ToCharYYYYMMDD(dateTo));
            //return DataProvider.Instance.GetDataSet(_Loginer.DBName, cmd.SqlCommand);
            return null;
        }
    }
}
