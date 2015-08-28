using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.ORMTool;

namespace SG.Models.Database
{


/*==========================================
 *   程序说明: tb_t_ItemClass的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2015/02/06 11:00:37
 *   最后修改: 2015/02/06 11:00:37
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   Copyright 2014-2015 东莞思谷数字技术有限公司
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:t_ItemClass,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("t_ItemClass", "FID", true)]
    public sealed class tb_t_ItemClass
    {
        public static string __TableName ="t_ItemClass";

        public static string __KeyName = "FID";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,true,false,false)]
        public static string FID = "FID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FNumber = "FNumber"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FName = "FName";

        [ORM_FieldAttribute(SqlDbType.VarChar, 500, false, true, false, false, false)]
        public static string FNote = "FNote"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FSQLTableName = "FSQLTableName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,50,false,true,false,false,false)]
        public static string FSQLClassTableName = "FSQLClassTableName"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FIsSys = "FIsSys"; 

        [ORM_FieldAttribute(SqlDbType.DateTime,8,false,true,false,false,false)]
        public static string FCreateDate = "FCreateDate"; 

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,false,false,false)]
        public static string FUserID = "FUserID"; 

    }
}