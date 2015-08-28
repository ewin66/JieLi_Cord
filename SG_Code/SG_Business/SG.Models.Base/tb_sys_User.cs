/*==========================================
 *   程序说明: tb_sys_User的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2014/12/26 12:22:05
 *   最后修改: 2014/12/26 12:22:05
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   Copyright 2014-2015 东莞思谷数字技术有限公司
 *==========================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.ORMTool;

namespace SG.Models.Base
{

    ///<summary>
    /// ORM模型, 数据表:sys_User,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("sys_User", "FID", true)]
    public sealed class tb_sys_User
    {
        public static string __TableName ="sys_User";

        public static string __KeyName = "FID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, true, false, false)]
        public static string FID = "FID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string FAccount = "FAccount"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,100,false,true,false,false,false)]
        public static string FNovellAccount = "FNovellAccount"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,100,false,true,false,false,false)]
        public static string FDomainName = "FDomainName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FUserName = "FUserName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,100,false,true,false,false,false)]
        public static string FAddress = "FAddress"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FTel = "FTel"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,30,false,true,false,false,false)]
        public static string FMail = "FMail"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,30,false,true,false,false,false)]
        public static string FPassword = "FPassword"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string FLastLoginTime = "FLastLoginTime"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string FLastLogoutTime = "FLastLogoutTime"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FIsLocked = "FIsLocked"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string FCreateTime = "FCreateTime"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FFlagAdmin = "FFlagAdmin"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FFlagOnline = "FFlagOnline"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FLoginCounter = "FLoginCounter"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FDepartMentID = "FDepartMentID"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FWorkConterID = "FWorkConterID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,-1,false,true,false,false,false)]
        public static string FNote = "FNote"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,500,false,true,false,false,false)]
        public static string FDataSets = "FDataSets";

        [ORM_FieldAttribute(SqlDbType.VarChar, 100, false, true, false, false, false)]
        public static string FCardNo = "FCardNo"; 
    }
}