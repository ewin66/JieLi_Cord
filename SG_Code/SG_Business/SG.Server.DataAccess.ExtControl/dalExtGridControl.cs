using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.Interfaces.ExtControl;
using SG.Tools.DataOperate;
using SG.Common;

namespace SG.Server.DataAccess.ExtControl
{
    public class dalExtGridControl : dalBase, IBridge_ExtGridControl
    {
        public dalExtGridControl(Loginer loginer)
            : base(loginer)
        {
            
        }

        /// <summary>
        /// 获取报表列信息
        /// </summary>
        /// <param name="sReportName">报表名称</param>
        /// <returns></returns>
        public DataTable GetReportFiled(string sReportName)
        {
            string sql = string.Format(@"select v.FName as ReportName,v.FDBLink,v.FSelectType,u.FID,u.FFunSqlID,u.FColName,(case when u.FHeadText is null then u.FColName else u.FHeadText end) as FHeadText,u.FHeadOneText,u.FStartIndex,u.FEndIndex,
(case when uc.FColWidth is null then u.FColWidth else uc.FColWidth end) as FColWidth,(case when uc.FOrderID is null OR uc.FOrderID=-1 then u.FOrderID else uc.FOrderID end) as FOrderID,
u.FIsfixed,u.FIsSum,u.FDataType,u.FIsVisible,u.FIsMerge,u.FIsLock,u.FFormat,u.FConType,u.FConSQL,u.FIsRequired,u.FIsCon,u.FIsConDouble,u.FSourceMember,u.FFetchMember
from Sys_Fun_SQL v inner join
sys_Fun_ColInfo u on v.FID=u.FFunSqlID left join
sys_Fun_ColInfo_User uc on v.FID=uc.FFunSqlID and u.FColName=uc.FColName and uc.FUserID='{0}'
where v.FName='{1}' order by (case when uc.FOrderID is null OR uc.FOrderID=-1 then u.FOrderID else uc.FOrderID end)", _Loginer.Fid, sReportName);
            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
        }

        /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <param name="sReportName">报表名称</param>
        /// <param name="sFilter">过滤条件</param>
        /// <param name="bIsGetCount">是否获取记录总数</param>
        /// <param name="nPageIndex">当前页数</param>
        /// <returns></returns>
        public DataTable GetRportData(string sReportName, string sFilter, bool bIsGetCount, int nPageIndex)
        {
            DataTable dtResult = new DataTable();
            string sql="";
            if (_Loginer.DbType == DbAcessTyp.SQLServer)
                sql = string.Format(@"select isnull(FSQL,'') as FSQL,FIsPage,isnull(FPageSize,0) as FPageSize from Sys_Fun_SQL where FName='{0}'", sReportName);
            else if(_Loginer.DbType == DbAcessTyp.Oracle)
                sql = string.Format(@"select nvl(FSQL,'') as FSQL,FIsPage,nvl(FPageSize,0) as FPageSize from Sys_Fun_SQL where FName='{0}'", sReportName);
            DataTable dtSql = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
            if(dtSql.Rows.Count>0)
            {
                bool bIsPagination = dtSql.Rows[0]["FIsPage"].ToString() == "0" ? false : true;
                int nPageSize = Convert.ToInt32(dtSql.Rows[0]["FPageSize"]);
                string sExeSql="";
                string sRepSql = dtSql.Rows[0]["FSQL"].ToString();
                if (sFilter.Trim() != "")
                    sFilter = " where 1=1 and " + sFilter;
                if (_Loginer.DbType == DbAcessTyp.SQLServer)
                    sExeSql = "select 0 as val_selected,Row_Number() over (order by getdate()) as val_keyid,aa.* from(" + sRepSql + ") aa" + sFilter;
                else if (_Loginer.DbType == DbAcessTyp.Oracle)
                    sExeSql = "select 0 as val_selected,Row_Number() over (order by sysdate) as val_keyid,aa.* from(" + sRepSql + ") aa" + sFilter;

                if (bIsPagination) //启用分页
                {
                    if (bIsGetCount) //是获取记录总数
                    {
                        if (_Loginer.DbType == DbAcessTyp.SQLServer)
                            sExeSql = "select isnull(COUNT(1),0) as recordercount,isnull(CEILING((COUNT(1)+0.0)/" + nPageSize + "),0) as totalpagecount," + nPageSize + " as FPageSize from (" + sExeSql + ") cc ";
                        else if (_Loginer.DbType == DbAcessTyp.Oracle)
                            sExeSql = "select nvl(COUNT(1),0) as recordercount,nvl(ceil((COUNT(1)+0.0)/" + nPageSize + "),0) as totalpagecount," + nPageSize + " as FPageSize from (" + sExeSql + ") cc ";
                    }
                    else
                    {
                        if (nPageIndex == 1) //首页
                        {
                            sExeSql = "select top " + nPageSize + " * from (" + sExeSql + ") cc";
                        }
                        else
                        {
                            sExeSql = "select top " + nPageSize + " * from (" + sExeSql + ") cc WHERE val_keyid > " + (nPageIndex - 1) * nPageSize;
                        }
                    }
                }

                if (!bIsGetCount) //不是获取记录总数
                {
                    //if (sOrder.IndexOf("Order by") > 0)
                    //    sExeSql += sOrder;
                }
                dtResult = new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sExeSql);
            }
            return dtResult;
        }

        /// <summary>
        /// 通过SQL获取DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public DataTable GetDataTableBySQL(string sql)
        {
            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
        }
    }
}
