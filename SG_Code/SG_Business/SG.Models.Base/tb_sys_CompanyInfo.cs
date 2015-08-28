using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.ORMTool;

namespace SG.Models.Base
{

/*==========================================
 *   程序说明: tb_sys_CompanyInfo的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2014/12/26 02:00:46
 *   最后修改: 2014/12/26 02:00:46
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   Copyright 2014-2015 东莞思谷数字技术有限公司
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:sys_CompanyInfo,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("sys_CompanyInfo", "FID", true)]
    public sealed class tb_sys_CompanyInfo
    {
        public static string __TableName ="sys_CompanyInfo";

        public static string __KeyName = "FID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, true, false, false)]
        public static string FID = "FID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,30,false,true,false,false,false)]
        public static string FCompanyCode = "FCompanyCode"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,40,false,true,false,false,false)]
        public static string FNativeName = "FNativeName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,40,false,true,false,false,false)]
        public static string FEnglishName = "FEnglishName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,40,false,true,false,false,false)]
        public static string FProgramName = "FProgramName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FReportHead = "FReportHead"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,200,false,true,false,false,false)]
        public static string FAddress = "FAddress"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FTel = "FTel"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FFax = "FFax"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string FCreationDate = "FCreationDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FCreatedBy = "FCreatedBy"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string FLastUpdateDate = "FLastUpdateDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string FLastUpdatedBy = "FLastUpdatedBy"; 

    }
}