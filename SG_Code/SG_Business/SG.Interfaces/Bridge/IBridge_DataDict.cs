///*************************************************************************/
///*
///* 文件名    ：IBridge_DataDict.cs                                      
///* 程序说明  : 桥接。
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces
{
    public interface IBridge_DataDict
    {

        DataTable GetDataByKey(string key);
        DataTable GetSummaryData();
        DataTable GetDataDictByTableName(string tableName);
        DataSet DownloadDicts();

        bool Update(DataSet data);
        SaveResultEx UpdateEx(DataSet data);
        bool Delete(string keyValue);
        bool CheckNoExists(string keyValue);

        Type ORM { get; set; }
        string TableName { get; set; }
    }
}
