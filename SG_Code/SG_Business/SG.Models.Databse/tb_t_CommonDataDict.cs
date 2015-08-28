using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.ORMTool;

namespace SG.Models.Database
{


/*==========================================
 *   程序说明: tb_t_CommonDataDict的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2015/02/02 12:12:10
 *   最后修改: 2015/02/02 12:12:10
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   Copyright 2014-2015 东莞思谷数字技术有限公司
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:t_CommonDataDict,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("t_CommonDataDict", "FID", true)]
    public sealed class tb_t_CommonDataDict
    {
        public static string __TableName ="t_CommonDataDict";

        public static string __KeyName = "FID";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,true,false,false)]
        public static string FID = "FID"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FDataTypeID = "FDataTypeID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string FDataCode = "FDataCode"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,100,false,true,false,false,false)]
        public static string FNativeName = "FNativeName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FEnglishName = "FEnglishName"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string FCreationDate = "FCreationDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string FCreatedBy = "FCreatedBy"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string FLastUpdateDate = "FLastUpdateDate"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string FLastUpdatedBy = "FLastUpdatedBy"; 

    }
}