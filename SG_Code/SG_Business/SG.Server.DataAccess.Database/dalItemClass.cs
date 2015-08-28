using SG.Common;
using SG.Interfaces.Database;
///*************************************************************************/
///*
///* 文件名    ：dalItemClass.cs                                      
///* 程序说明  : 基础资类型述DAL层
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Models.Database;
using SG.ORMTool;
using SG.Tools.DataOperate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.DataAccess.Database
{
    /// <summary>
    /// 基础资料类型数据操作类
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_t_ItemClass), true)]
    public class dalItemClass : dalBaseDataDict, IBridge_ItemClass
    {
        public dalItemClass(Loginer loginer)
            : base(loginer)
        {
            _KeyName = tb_t_ItemClass.__KeyName; //主键字段
            _TableName = tb_t_ItemClass.__TableName;//表名
            _ModelType = typeof(tb_t_ItemClass);//字典表ORM
        }

        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_t_ItemClass.__TableName) ORM = typeof(tb_t_ItemClass);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM, _Loginer.DbType);
        }

        public System.Data.DataTable GetItemClass(string FNumber)
        {
            string sql =  "select t.*,u.FUserName from t_ItemClass t  inner join sys_user u on t.FUserID=u.fid where t.FNumber='" + FNumber + "' order by t.fnumber ";
           DataTable dt = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
            dt.TableName = tb_t_ItemClass.__TableName;
           
            return dt;
        }

        public bool DeleteItemClass(string FNumber)
        {
            ArrayList sqlList = new ArrayList();
            sqlList.Add("delete from t_ItemPropDesc  where FItemClassID in (select fid from t_ItemClass where FNumber='" + FNumber + "'");
            sqlList.Add("delete from t_ItemClass where FNumber='" + FNumber + "'");

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

        public bool IsExistsItemClass(string FNumber)
        {
            string sql = "select count(*)  from t_ItemClass where   FNumber='" + FNumber + "'";
            object x = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);
            return int.Parse(x.ToString()) > 0;
        }
    }
}
