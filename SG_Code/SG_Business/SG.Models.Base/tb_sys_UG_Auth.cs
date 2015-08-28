using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SG.ORMTool;

namespace SG.Models.Base
{


    /*==========================================
     *   程序说明: tb_sys_UG_Auth的ORM模型
     *   作者姓名: C/S框架网 www.csframework.com
     *   创建日期: 2014/12/26 12:21:55
     *   最后修改: 2014/12/26 12:21:55
     *   
     *   注: 本代码由ClassGenerator自动生成
     *   Copyright 2014-2015 东莞思谷数字技术有限公司
     *==========================================*/

    ///<summary>
    /// ORM模型, 数据表:sys_UG_Auth,由ClassGenerator自动生成
    /// </summary>
    [ORM_ObjectClassAttribute("sys_UG_Auth", "FID", true)]
    public sealed class tb_sys_UG_Auth
    {
        public static string __TableName = "sys_UG_Auth";

        public static string __KeyName = "FID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, true, false, false)]
        public static string FID = "FID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string FUGID = "FUGID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string FunctionID = "FunctionID";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string FAuths = "FAuths";

        [ORM_FieldAttribute(SqlDbType.Int, 4, false, true, false, false, false)]
        public static string FModelID = "FModelID";

        [ORM_FieldAttribute(SqlDbType.VarChar, 50, false, true, false, false, false)]
        public static string FMenu = "FMenu";
    }
}