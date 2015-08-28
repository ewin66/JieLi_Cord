///*************************************************************************/
///*
///* 文件名    ：ICommonService_H.cs                                      
///* 程序说明  : 公共处理WCF接口类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.Host.Base
{
    
    // 注意: 如果更改此处的接口名称 "ICommonService"，也必须更新 Web.config 中对 "ICommonService" 的引用。
    [ServiceContract(Name = "CommonService_H",
                     Namespace = "SG.Server.Host.Base")]
    public interface ICommonService_H
    {
        [OperationContract]
        byte[] GetSystemOrganization(byte[] validationTicket);

        [OperationContract]
        byte[] GetSystemDataSet(byte[] validationTicket);

        [OperationContract]
        byte[] GetSystemDataSetByOrg(byte[] validationTicket, string sOrgID);
      
        [OperationContract]
        byte[] SearchLog(byte[] loginTicket, string sFilter);

        [OperationContract]
        bool TestConnection(byte[] validationTicket);
        [OperationContract]
        bool TestConnectionD(byte[] validationTicket, string dbType, string Server, string database, string user, string password);

        [OperationContract]
        void WriteLogOP(byte[] loginTicket,string sFunID,string sFSubunID,string sFdesc,string sSql);

        [OperationContract]
        byte[] GetModules(byte[] loginTicket);

        [OperationContract]
        void WriteLog(byte[] loginTicket, string logID, byte[] originalData, byte[] changes, string tableName, string keyFieldName, bool isMaster);

        [OperationContract]
        byte[] SearchLogData(byte[] loginTicket, string logUser, string tableName, DateTime dateFrom, DateTime dateTo);

        [OperationContract]
        bool SaveFieldDef(byte[] loginTicket, byte[] data);


        [OperationContract]
        byte[] GetLogFieldDef(byte[] loginTicket, string tableName);


        [OperationContract]
        string[] GetTracedFields(byte[] loginTicket, string tableName);

        [OperationContract]
        string C_GetTableID(byte[] loginTicket, string sTableName, string sFieldID);

        [OperationContract]
        string C_GetTableFieldValue(byte[] loginTicket, string sTableName, string sField, string SCon);
        [OperationContract]

        string GetSQLServerDbListString(byte[] validationTicket,string sServerName, string sUser, string sPwd);

        #region 数据连接配置
        [OperationContract]
        byte[] GetDBLink(byte[] loginTicket);
        [OperationContract]
        byte[] GetDBLinkByID(byte[] loginTicket,string key);
        #endregion

        #region 系统参数
        [OperationContract]
        byte[] G_GetSystemProfile(byte[] loginTicket);
        [OperationContract]
        string G_GetSystemProfileVal(byte[] loginTicket, string key);
        #endregion
        /// <summary>
        /// 附件
        /// </summary>
        /// <param name="loginTicket"></param>
        /// <param name="docID"></param>
        /// <returns></returns>
        [OperationContract]
        byte[] GetAttachedFiles(byte[] loginTicket, string docID);

        #region 获取表和列
        [OperationContract]
        /// <summary>
        /// 获取数据库表（为空则为全部，模糊查找）
        /// </summary>
        /// <param name="sTable"></param>
        /// <returns></returns>
        byte[] getTable(byte[] loginTicket, string sTable);
        [OperationContract]
        /// <summary>
        /// 获取数据表字段
        /// </summary>
        /// <param name="sTableName"></param>
        /// <returns></returns>
        byte[] getField(byte[] loginTicket, string sTableName);

        #endregion
        [OperationContract]
        /// <summary>
        /// 通过SQL语句获取datattable
        /// </summary>
        /// <param name="loginTicket"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        byte[] getDataTableSQL(byte[] loginTicket, string sql);
    }
}