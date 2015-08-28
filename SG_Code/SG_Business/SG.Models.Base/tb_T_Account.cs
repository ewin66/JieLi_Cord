using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.ORMTool;
/*==========================================
 *   程序说明: tb_T_Account的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2014/12/26 12:19:14
 *   最后修改: 2014/12/26 12:19:14
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   Copyright 2014-2015 东莞思谷数字技术有限公司
 *==========================================*/

namespace SG.Models.Base
{
    ///<summary>
    /// ORM模型, 数据表:T_Account,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("T_Account", "FID", true)]
    public sealed class tb_T_Account
    {
        public static string __TableName ="T_Account";

        public static string __KeyName = "FID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, true, false, false)]
        public static string FID = "FID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FNumber = "FNumber"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,200,false,true,false,false,false)]
        public static string FName = "FName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,200,false,true,false,false,false)]
        public static string FDatabase = "FDatabase"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,200,false,true,false,false,false)]
        public static string FServerName = "FServerName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FUser = "FUser"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FPwd = "FPwd"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FDataType = "FDataType"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FOrgID = "FOrgID"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string FCreateDate = "FCreateDate"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string FBackUpDate = "FBackUpDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,200,false,true,false,false,false)]
        public static string FVer = "FVer"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,200,false,true,false,false,false)]
        public static string FProductName = "FProductName"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FOnlineCount = "FOnlineCount"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,200,false,true,false,false,false)]
        public static string FServerIP = "FServerIP"; 

    }
}