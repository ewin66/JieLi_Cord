using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.ORMTool;

namespace SG.Models.Base
{


/*==========================================
 *   程序说明: tb_sys_AttachFile的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2015/01/31 12:45:19
 *   最后修改: 2015/01/31 12:45:19
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   Copyright 2014-2015 东莞思谷数字技术有限公司
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:sys_AttachFile,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("sys_AttachFile", "FID", true)]
    public sealed class tb_sys_AttachFile
    {
        public static string __TableName ="sys_AttachFile";

        public static string __KeyName = "FID";

        [ORM_FieldAttribute(SqlDbType.Int,4,false,true,true,false,false)]
        public static string FID = "FID"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,20,false,true,false,false,false)]
        public static string FDocID = "FDocID"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,200,false,true,false,false,false)]
        public static string FFileTitle = "FFileTitle"; 

        [ORM_FieldAttribute(SqlDbType.NVarChar,100,false,true,false,false,false)]
        public static string FFileName = "FFileName"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,10,false,true,false,false,false)]
        public static string FFileType = "FFileType"; 

        [ORM_FieldAttribute(SqlDbType.Decimal,9,false,true,false,false,false)]
        public static string FFileSize = "FFileSize"; 

        [ORM_FieldAttribute(SqlDbType.Image,16,false,true,false,false,false)]
        public static string FFileBody = "FFileBody"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,1,false,true,false,false,false)]
        public static string FIsDroped = "FIsDroped";

        [ORM_FieldAttribute(SqlDbType.Image, 0, false, false, false, false, false)]
        public static string IconLarge = "FIconLarge";

        [ORM_FieldAttribute(SqlDbType.Image, 0, false, false, false, false, false)]
        public static string IconSmall = "FIconSmall";
    }
}