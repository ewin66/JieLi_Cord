using SG.Common;
using SG.Server.DataAccess.Set;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;

namespace SG.Server.IISHost.Set
{
     [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class SGSetFunSQL : ISGSetFunSQL_W
    {
        
        public bool F_DeleteFunSQL(byte[] loginTicket, string key)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            return new dalFunSQL(loginer).DeleteFunSQL(key);

        }

        public byte[] F_GetFunSQL(byte[] loginTicket)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalFunSQL(loginer).GetFunSQL();
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }

        public byte[] F_GetFunSQLByID(byte[] loginTicket, string key)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = new dalFunSQL(loginer).GetFunSQLByID(key);
            return ZipTools.CompressionObject(data);
        }
        public byte[] F_GetFunSQLByUser(byte[] loginTicket, string key)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = new dalFunSQL(loginer).GetFunSQLByUser(key);
            return ZipTools.CompressionObject(data);
        }
        public byte[] F_GetFunSQLData(byte[] loginTicket, string sCon, string sKey)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = new dalFunSQL(loginer).GetFunSQLData(sCon, sKey);
            return ZipTools.CompressionObject(data);
        }

        public bool F_CheckFunNoExists(byte[] loginTicket, string FunNum)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            return new dalFunSQL(loginer).CheckFunNoExists(FunNum);
        }
        public byte[] F_GetSysFun(byte[] loginTicket)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalFunSQL(loginer).GetSysFun();
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }

        public byte[] F_GetAllFunModel(byte[] loginTicket)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalFunSQL(loginer).GetAllFunModel();
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }

        public bool S_DeleteRPTColInfoScheme(byte[] loginTicket, string key)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            return new dalRPTColInfoScheme(loginer).DeleteRPTColInfoScheme(key);
        }

        public byte[] S_GetRPTScheme(byte[] loginTicket, string key)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataTable data = new dalRPTColInfoScheme(loginer).GetRPTScheme(key);
            return ZipTools.CompressionObject(DataConverter.TableToDataSet(data));
        }

        public byte[] S_GetRPTColInfoScheme(byte[] loginTicket, string key)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = new dalRPTColInfoScheme(loginer).GetRPTColInfoScheme(key);
            return ZipTools.CompressionObject(data);
        }

        public byte[] S_GetRPTColInfoSchemetmp(byte[] loginTicket, string key)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            DataSet data = new dalRPTColInfoScheme(loginer).GetRPTColInfoSchemetmp(key);
            return ZipTools.CompressionObject(data);
        }

        public bool S_CheckRPTNoExists(byte[] loginTicket, string FName)
        {
            Loginer loginer = WebServiceSecurity.ValidateLoginer(loginTicket);

            return new dalRPTColInfoScheme(loginer).CheckRPTNoExists(FName);
        }



    }
}
