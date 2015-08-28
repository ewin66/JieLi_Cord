using SG.Client.Bridge;
using SG.Client.Bridge.Base;
using SG.Common;
using SG.Interfaces.Base;
using SG.Models.Base;
///*************************************************************************/
///*
///* 文件名    ：bllDbLink.cs        
///
///* 程序说明  : 数据库连接管理的业务逻辑层
///               
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

namespace SG.Business.Base
{
    public class bllDbLink : bllBaseDataDict
    {
        private IBridge_DbLink _MyBridge;
        private bool _IsAdd = false;
          public bllDbLink()
        {
            _KeyFieldName = tb_sys_DbLink.__KeyName; //主键字段
            _SummaryTableName = tb_sys_DbLink.__TableName;//表名
            _WriteDataLog = false;//是否保存日志                    
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_sys_DbLink));
            _MyBridge = this.CreateBridge();
        }

          /// <summary>
          /// 创建实现了桥接接口的通信通道
          /// </summary>
          /// <returns></returns>
          private IBridge_DbLink CreateBridge()
          {
              if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                  return new ADODirect_DBLink().GetInstance();

              if (BridgeFactory.BridgeType == BridgeType.WebService)
                  return new WcfIISHost_DBLink();

              if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                  return new WcfHost_DBLink();

              return null;
          }

          /// <summary>
          /// 获取所有数据连接
          /// </summary>
          /// <returns></returns>
          public DataTable GetDBLink()
          {
              _SummaryTable = _MyBridge.GetDBLink();

              SetDefault(_SummaryTable);
              return _SummaryTable;
          }

          protected override void SetDefault(DataTable data)
          {
              data.Columns[tb_sys_DbLink.FCreateDate].DefaultValue = DateTime.Now;              
          }


          /// <summary>
          /// 获取指定数据连接
          /// </summary>
          /// <param name="key">ID</param>
          /// <returns></returns>
          public DataTable GetDBLinkByID(string key)
          {
              return _MyBridge.GetDBLinkByID(key);
          }

          /// <summary>
          /// 更新数据
          /// </summary>
          /// <param name="updateType">操作类型</param>
          /// <returns></returns>
          public bool Update(DataTable sSavatb, UpdateType updateType)
          {
              sSavatb.Rows[0][tb_sys_DbLink.FCreateDate] = DateTime.Now;

              sSavatb.AcceptChanges();

              if (updateType == UpdateType.Add)
                  sSavatb.Rows[0].SetAdded();
              else
                  sSavatb.Rows[0].SetModified();

              DataSet ds = new DataSet();
              ds.Tables.Add(sSavatb.Copy());
              bool ret = _DataDictBridge.Update(ds); //调用DAL层更新数据
              //bool ret = base.Update(updateType);
              if (ret)
              {
                  //_SummaryTable.AcceptChanges();
                  _IsAdd = false;
              }

              return ret;
          }
    }
}
