///*************************************************************************/
///*
///* 文件名    ：IBridge_ItemPropDesc.cs                                      
///* 程序说明  : 基础资料描述接口
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

namespace SG.Interfaces.Database
{
    /// <summary>
    /// 基础资料描述接口
    /// </summary>
  
     public interface IBridge_ItemPropDesc
    {
         /// <summary>
         /// 获取一个基础资料的信息
         /// </summary>
         /// <param name="FNumber"></param>
         /// <returns></returns>
         DataSet GetItemDesc(string FNumber);
         /// <summary>
         /// 删除一条描述
         /// </summary>
         /// <param name="fid"></param>
         /// <returns></returns>
        bool DeleteItemDesc(string fid);
         /// <summary>
         /// 调整顺序
         /// </summary>
         /// <param name="Upfid">往上ID</param>
         /// <param name="Downfid">往下ID</param>
         /// <returns></returns>
        bool SetOrder(string Upfid,string Downfid);
    }
}
