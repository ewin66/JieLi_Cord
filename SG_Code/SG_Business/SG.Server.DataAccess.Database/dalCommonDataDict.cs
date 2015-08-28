using SG.Common;
using SG.Interfaces.Database;
using SG.ORMTool;
using SG.Tools.DataOperate;
///*************************************************************************/
///*
///* 文件名    ：dalCommonDataDict.cs                                      
///* 程序说明  : 数据字典的DAL层
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interfaces.Database;
using SG.Models.Database;

namespace SG.Server.DataAccess.Database
{
    /// <summary>
    /// 公共数据字典数据层
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_t_CommonDataDict), true)]
    public class dalCommonDataDict : dalBaseDataDict, IBridge_CommonDataDict
    {
        public dalCommonDataDict(Loginer loginer)
            : base(loginer)
        {
            _KeyName = tb_t_CommonDataDict.__KeyName; //主键字段
            _TableName = tb_t_CommonDataDict.__TableName;//表名
            _ModelType = typeof(tb_t_CommonDataDict);//字典表ORM
        }

        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_t_CommonDataDict.__TableName) ORM = typeof(tb_t_CommonDataDict);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM, _Loginer.DbType);
        }

        /// <summary>
        /// 数据字典：手动控制事务及自动生成流水号
        /// </summary>
        /// <param name="data">用户提交的数据</param>
        /// <returns></returns>
        public override SaveResultEx UpdateEx(DataSet data)
        {
            SaveResultEx result = new SaveResultEx((int)ResultID.SUCCESS, "");

            try
            {
                this.BeginTransaction();//启动事务

                DataTable summary = data.Tables[tb_t_CommonDataDict.__TableName];//取出主表数据
                string dataType = ConvertEx.ToString(summary.Rows[0][tb_t_CommonDataDict.FDataTypeID]);//取数据类型
                if (summary.Rows[0][tb_t_CommonDataDict.FDataCode].ToString() == string.Empty)
                {
                    string dataCode = DocNoTool.GetDataSN(_Loginer.DBName, tb_t_CommonDataDict.__TableName, true, true);//在同一事务内取流水号
                    summary.Rows[0][tb_t_CommonDataDict.FDataCode] = dataCode;
                }

                result = base.UpdateEx(data);//提交数据
                result.PrimaryKey = summary.Rows[0][tb_t_CommonDataDict.FDataCode].ToString(); //summary.Rows[0][tb_t_CommonDataDict.__KeyName].ToString();//返回自动生成的主键

                this.CommitTransaction();//提交事务
            }
            catch
            {
                this.RollbackTransaction();//回滚
            }

            return result;
        }

        

        /// <summary>
        /// 搜索指定类型的数据
        /// </summary>
        /// <param name="DataType">数据类型</param>
        /// <returns></returns>
        public System.Data.DataTable SearchBy(string dataType)
        {
            string sql = "select * from t_CommonDataDict where FDataTypeID=" + dataType;
            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql); 
        }

        /// <summary>
        /// 添加一个类型
        /// </summary>
        /// <param name="fid"></param>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool AddCommonType(string fid, string code, string name)
        {
            string sql = "insert into  t_CommDataDictType(Fid, FDataType, FTypeName, FIssys) values(" + fid.ToString() + ",'" + code + "','" + name + "',0)";

            object o = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);
            return int.Parse(o.ToString()) > 0;
        }
        /// <summary>
        /// 删除一个类型
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool DeleteCommonType(string code)
        {
            string sql = "select FIssys  from t_CommDataDictType where   FDataType=" + code;
            object x = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);
            if(x.ToString()=="1")
            {
                throw new CustomException("不能删除系统的数据！"); //抛出异常
            }
             sql = "delete from t_CommDataDictType where FDataType='" + code + "'";

            object o = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);
            return int.Parse(o.ToString()) > 0;
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool IsExistsCommonType(string code)
        {
            string sql = "select count(*)  from t_CommDataDictType where   FDataType='" + code + "'";
            object x = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);
            return int.Parse(x.ToString()) > 0;
        }
        
     
    }
}
