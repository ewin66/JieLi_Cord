///*************************************************************************/
///*
///* 文件名    ：bllBusinessLog.cs                                 
///* 程序说明  : 数据更新日志
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using SG.Bridge;
using SG.Client.Bridge;
using SG.Common;
using SG.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Business
{

    public class bllBusinessLog
    {
        public static DataSet SearchLog(string logUser, string tableName, DateTime dateFrom, DateTime dateTo)
        {
            IBridge_EditLogHistory bridge = CreateEditLogHistoryBridge();
            return bridge.SearchLog(logUser, tableName, dateFrom, dateTo);
        }

        public static bool SaveFieldDef(DataTable data)
        {
            IBridge_EditLogHistory bridge = CreateEditLogHistoryBridge();
            return bridge.SaveFieldDef(data);
        }

        public static DataTable GetLogFieldDef(string tableName)
        {
            IBridge_EditLogHistory bridge = CreateEditLogHistoryBridge();
            return bridge.GetLogFieldDef(tableName);
        }

        /// <summary>
        /// 创建修改历史记录的数据层桥接实例
        /// </summary>
        /// <returns></returns>
        public static IBridge_EditLogHistory CreateEditLogHistoryBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_Log().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WCFIISHost_Log();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WcfHost_Log();
            throw new CustomException("UNKNOW_BRIDGE_TYPE:CreateEditLogHistoryBridge()");
        }

    }
}
