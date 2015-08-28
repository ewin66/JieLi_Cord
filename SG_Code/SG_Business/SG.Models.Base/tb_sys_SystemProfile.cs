using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.ORMTool;

namespace SG.Models.Base
{


/*==========================================
 *   程序说明: tb_sys_SystemProfile的ORM模型
 *   作者姓名: C/S框架网 www.csframework.com
 *   创建日期: 2015/01/20 04:38:57
 *   最后修改: 2015/01/20 04:38:57
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   Copyright 2014-2015 东莞思谷数字技术有限公司
 *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:sys_SystemProfile,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("sys_SystemProfile", "FID", true)]
    public sealed class tb_sys_SystemProfile
    {
        public static string __TableName ="sys_SystemProfile";

        public static string __KeyName = "FID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, true, false, false)]
        public static string FID = "FID";

        [ORM_FieldAttribute(SqlDbType.VarChar, 30, false, false, false, false, false)]
        public static string FCategory = "FCategory";

        [ORM_FieldAttribute(SqlDbType.VarChar, 20, false, false, false, false, false)]
        public static string Fkey = "Fkey"; 

        [ORM_FieldAttribute(SqlDbType.VarChar,255,false,true,false,false,false)]
        public static string FValue = "FValue";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, false, false, false, false)]
        public static string FReadonly = "FReadonly";

        [ORM_FieldAttribute(SqlDbType.VarChar, 255, false, false, false, false, false)]
        public static string FDescription = "FDescription";

        [ORM_FieldAttribute(SqlDbType.VarChar, 1, false, false, false, false, false)]
        public static string FLevel = "FLevel";

        [ORM_FieldAttribute(SqlDbType.VarChar, 255, false, false, false, false, false)]
        public static string FExplanation = "FExplanation";

        [ORM_FieldAttribute(SqlDbType.VarChar, 255, false, false, false, false, false)]
        public static string FType = "FType";

        [ORM_FieldAttribute(SqlDbType.Decimal, 5, false, false, false, false, false)]
        public static string FSort = "FSort"; 

    }
}