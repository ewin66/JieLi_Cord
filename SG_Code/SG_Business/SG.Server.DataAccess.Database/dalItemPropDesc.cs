using SG.Common;
using SG.Interfaces.Database;
///*************************************************************************/
///*
///* 文件名    ：dalItemPropDesc.cs                                      
///* 程序说明  : 基础资料描述DAL层
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
    /// 基础资料描述DAL层
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_t_ItemPropDesc), true)]
    public class dalItemPropDesc : dalBaseDataDict, IBridge_ItemPropDesc 
    {
        public dalItemPropDesc(Loginer loginer)
            : base(loginer)
        {
            _KeyName = tb_t_ItemPropDesc.__KeyName; //主键字段
            _TableName = tb_t_ItemPropDesc.__TableName;//表名
            _ModelType = typeof(tb_t_ItemPropDesc);//字典表ORM
        }

        protected override IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            Type ORM = null;

            if (tableName == tb_t_ItemPropDesc.__TableName) ORM = typeof(tb_t_ItemPropDesc);

            if (ORM == null) throw new Exception(tableName + "表没有ORM模型！");

            return new GenerateSqlCmdByTableFields(ORM, _Loginer.DbType);
        }

        public System.Data.DataSet GetItemDesc(string FNumber)
        {
            ArrayList sql = new ArrayList();
            sql.Add("select t.*,u.FUserName from t_ItemClass t  inner join sys_user u on t.FUserID=u.fid where t.FNumber='" + FNumber + "' order by t.fnumber ");
            sql.Add("SELECT   D.*, C.FNumber ClassNum, C.FName ClassName  FROM t_ItemPropDesc  D INNER JOIN t_ItemClass C ON D.FItemClassID = C.FID where d.FItemClassID in (select fid from t_ItemClass where FNumber='" + FNumber + "'");
            DataSet ds = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataSet(sql);
            ds.Tables[0].TableName = tb_t_ItemClass.__TableName;
            ds.Tables[1].TableName = tb_t_ItemPropDesc.__TableName;
            return ds;
        }

        public bool DeleteItemDesc(string fid)
        {
            string sql = "delete from t_ItemPropDesc where fid=" + fid;

            object o = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql);
            return int.Parse(o.ToString()) > 0;
        }

        public bool SetOrder(string Upfid, string Downfid)
        {
            ArrayList sqlList = new ArrayList();
            sqlList.Add("update set t_ItemPropDesc set FOrder=Forder+1  where FID=" + Upfid );
            sqlList.Add("update set t_ItemPropDesc set FOrder=Forder-1  where FID=" + Downfid);
            
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
    }
}
