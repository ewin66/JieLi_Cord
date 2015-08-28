///*************************************************************************/
///*
///* 文件名    ：ISGBaseDict_W.cs                                      
///* 程序说明  : 数据字典数据层WCF接口类
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

namespace SG.Server.IISHost.Base
{
    [ServiceContract(Name = "SGBaseDict_W",
                 Namespace = "SG.Server.IISHost.Base")]
    public interface ISGBaseDict_W
    {
        [OperationContract]
        byte[] GetDataByKey(byte[] loginTicket, string ORM_TypeName, string key);
        [OperationContract]
        byte[] GetSummaryData(byte[] loginTicket, string ORM_TypeName);
        [OperationContract]
        byte[] GetDataDictByTableName(byte[] loginTicket, string tableName);
        [OperationContract]
        byte[] DownloadDicts(byte[] loginTicket);    
        [OperationContract]
        bool Update(byte[] loginTicket, byte[] bs, string ORM_TypeName);
        [OperationContract]
        byte[] UpdateEx(byte[] loginTicket, byte[] bs, string ORM_TypeName);
        [OperationContract]
        bool Delete(byte[] loginTicket, string keyValue, string ORM_TypeName);
        [OperationContract]
        bool CheckNoExists(byte[] loginTicket, string keyValue, string ORM_TypeName);

    }
}
