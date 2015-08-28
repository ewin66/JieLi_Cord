using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.ORMTool;

namespace SG.Models.Database
{


/*==========================================
 *   程序说明: tb_t_ItemPropDesc的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2015/02/06 11:01:28
 *   最后修改: 2015/02/06 11:01:28
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   Copyright 2014-2015 东莞思谷数字技术有限公司
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:t_ItemPropDesc,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("t_ItemPropDesc", "FID", true)]
    public sealed class tb_t_ItemPropDesc
    {
        public static string __TableName ="t_ItemPropDesc";

        public static string __KeyName = "FID";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,true,false,false)]
        public static string FID = "FID"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FItemClassID = "FItemClassID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FSQLColumnName = "FSQLColumnName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FName = "FName"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FDataType = "FDataType"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FBehavior = "FBehavior"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FDefaultValue = "FDefaultValue"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FScItemClassID = "FScItemClassID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FSrcTable = "FSrcTable"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FSrcField = "FSrcField"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FDisplayField = "FDisplayField"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,200,false,true,false,false,false)]
        public static string FSrcFilter = "FSrcFilter"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FPageName = "FPageName"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FOrder = "FOrder"; 

    }
}