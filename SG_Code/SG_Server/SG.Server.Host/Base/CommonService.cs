using SG.Common;
using SG.Server.DataAccess.Base;
using SG.Server.DataAccess;
///*************************************************************************/
///*
///* 文件名    ：CommonService.cs                                      
///* 程序说明  : 公共处理WCF实现类
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

namespace SG.Server.Host.Base
{
    /// <summary>
    /// 公共处理WCF实现类
    /// </summary>
    public class CommonService : ICommonService_H
    {
        public byte[] GetSystemOrganization(byte[] validationTicket)
        {
            bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

            //检查校验码成功,有效的登录请求.
            if (pass)
            {
                DataTable data = new dalCommon(null).GetSystemOrganization();
                return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
            }
            else
                return null;
        }

        public byte[] GetSystemDataSet(byte[] validationTicket)
        {
            bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

            //检查校验码成功,有效的登录请求.
            if (pass)
            {
                DataTable data = new dalCommon(null).GetSystemDataSet();
                return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
            }
            else
                return null;
        }

        public byte[] GetSystemDataSetByOrg(byte[] validationTicket, string sOrgID)
        {
            bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

            //检查校验码成功,有效的登录请求.
            if (pass)
            {
                DataTable data = new dalCommon(null).GetSystemDataSetByOrg(sOrgID);
                return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
            }
            else
                return null;
        }

        public byte[] SearchLog(byte[] loginTicket, string sFilter)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalCommon(loginer).SearchLog(sFilter);  //dalLog.GetLog(loginer, sFilter); 
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
        }

        public void WriteLogOP(byte[] loginTicket, string sFunID, string sFSubunID, string sFdesc, string sSql)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            //dalLog.InsertLog(loginer, sFunID, sFSubunID, sFdesc, sSql);
            new dalCommon(loginer).WriteLogOP(sFunID, sFSubunID, sFdesc, sSql);
        }

        public bool TestConnection(byte[] validationTicket)
        {
            bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

            //检查校验码成功,有效的登录请求.
            if (pass)
            {

                return new dalCommon(null).TestConnection();
            }
            else
                return false;
        }

        public bool TestConnectionD(byte[] validationTicket, string dbType, string Server, string database, string user, string password)
        {
            bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

            //检查校验码成功,有效的登录请求.
            if (pass)
            {
                return new dalCommon(null).TestConnection(dbType, Server, database, user, password);
            }
            else
                return false;
        }
        public byte[] GetModules(byte[] loginTicket)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalCommon(loginer).GetModules();
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
        }



        public void WriteLog(byte[] loginTicket, string logID, byte[] originalData, byte[] changes,
       string tableName, string keyFieldName, bool isMaster)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet dsOriginal = ZipTools.DecompressionDataSet(originalData);
            DataSet dsChanges = ZipTools.DecompressionDataSet(changes);

            new dalEditLogHistory(loginer).WriteLog(logID,
                dsOriginal.Tables[0], dsChanges.Tables[0], tableName, keyFieldName, isMaster);
        }


        public byte[] SearchLogData(byte[] loginTicket, string logUser, string tableName, DateTime dateFrom, DateTime dateTo)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = new dalEditLogHistory(loginer).SearchLog(logUser, tableName, dateFrom, dateTo);
            return ZipTools.CompressionDataSet(data);
        }


        public bool SaveFieldDef(byte[] loginTicket, byte[] data)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            DataSet ds = ZipTools.DecompressionDataSet(data);
            return new dalEditLogHistory(loginer).SaveFieldDef(ds.Tables[0]);
        }

        public byte[] GetLogFieldDef(byte[] loginTicket, string tableName)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalEditLogHistory(loginer).GetLogFieldDef(tableName);
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
        }

        public string[] GetTracedFields(byte[] loginTicket, string tableName)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalEditLogHistory(loginer).GetTracedFields(tableName);
        }


        public string C_GetTableID(byte[] loginTicket, string sTableName, string sFieldID)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalCommon(loginer).GetTableID(sTableName, sFieldID);
        }


        public string C_GetTableFieldValue(byte[] loginTicket, string sTableName, string sField, string SCon)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);
            return new dalCommon(loginer).GetTableFieldValue(sTableName,sField,SCon);
        }


        public byte[] GetDBLink(byte[] loginTicket)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalDbLink(loginer).GetDBLink();
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
        }

        public byte[] GetDBLinkByID(byte[] loginTicket, string key)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalDbLink(loginer).GetDBLinkByID(key);
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
        }


        public string GetSQLServerDbListString(byte[] validationTicket, string sServerName, string sUser, string sPwd)
        {
            bool pass = WebServiceSecurity.ValidateLoginIdentity(validationTicket);

            //检查校验码成功,有效的登录请求.
            if (pass)
            {

                return new dalCommon(null).GetSQLServerDbListString(sServerName,sUser,sPwd);
            }
            else
                return "";
        }


        public byte[] G_GetSystemProfile(byte[] loginTicket)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = new dalSystemProfile(loginer).GetSystemProfile();
            return ZipTools.CompressionDataSet(data);
        }

        public string G_GetSystemProfileVal(byte[] loginTicket, string key)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            return new dalSystemProfile(loginer).GetSystemProfileVal(key);
            
        }


        public byte[] GetAttachedFiles(byte[] loginTicket, string docID)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalAttachFile(loginer).GetAttachFileData(docID);
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
        }


        public byte[] getTable(byte[] loginTicket, string sTable)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalCommon(loginer).getTable(sTable);
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
        }

        public byte[] getField(byte[] loginTicket, string sTableName)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalCommon(loginer).getField(sTableName);
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
        }

        public byte[] getDataTableSQL(byte[] loginTicket, string sql)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalCommon(loginer).getDataTableSQL(sql);
            return ZipTools.CompressionDataSet(DataConverter.TableToDataSet(data));
        }
    }
}
