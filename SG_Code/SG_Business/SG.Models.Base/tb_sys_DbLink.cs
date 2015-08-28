using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.ORMTool;

namespace SG.Models.Base
{


/*==========================================
 *   程序说明: tb_sys_DbLink的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2015/01/05 05:24:21
 *   最后修改: 2015/01/05 05:24:21
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   Copyright 2014-2015 东莞思谷数字技术有限公司
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:sys_DbLink,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("sys_DbLink", "FID", true)]
    public sealed class tb_sys_DbLink
    {
        public static string __TableName ="sys_DbLink";

        public static string __KeyName = "FID";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,true,false,false)]
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

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string FCreateDate = "FCreateDate"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FUserID = "FUserID"; 

    }
}