///*************************************************************************/
///*
///* 文件名    ：SGDatabase.cs                                      
///* 程序说明  : 基础数据WCF接口
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

namespace SG.Server.Host.Database
{
    /// <summary>
    /// 基础数据WCF接口
    /// </summary>
     [ServiceContract(Name = "SGDatabase_H",
            Namespace = "SG.Server.Host.Database")]
    public interface ISGDatabase_H
    {
        #region 公共数据字典
         [OperationContract]
         bool AddCommonType(byte[] loginTicket, string sfid,string code, string name);

         [OperationContract]
         byte[] SearchCommonType(byte[] loginTicket, string dataType);
         [OperationContract]
         bool DeleteCommonType(byte[] loginTicket, string code);

         [OperationContract]
         bool IsExistsCommonType(byte[] loginTicket, string code);
        #endregion

        #region 基础资料名称
         [OperationContract]
         byte[] GetItemClass(byte[] loginTicket, string FNumber);
         [OperationContract]
         bool DeleteItemClass(byte[] loginTicket, string FNumber);
         [OperationContract]
         bool IsExistsItemClass(byte[] loginTicket, string FNumber);
        #endregion

        #region 基础资料描述
         [OperationContract]
         /// <summary>
         /// 获取一个基础资料的信息
         /// </summary>
         /// <param name="FNumber"></param>
         /// <returns></returns>
         byte[] GetItemDesc(byte[] loginTicket, string FNumber);
         [OperationContract]
         /// <summary>
         /// 删除一条描述
         /// </summary>
         /// <param name="fid"></param>
         /// <returns></returns>
         bool DeleteItemDesc(byte[] loginTicket, string fid);
         [OperationContract]
         /// <summary>
         /// 调整顺序
         /// </summary>
         /// <param name="Upfid">往上ID</param>
         /// <param name="Downfid">往下ID</param>
         /// <returns></returns>
         bool SetOrder(byte[] loginTicket, string Upfid, string Downfid);
        #endregion
    }
}
