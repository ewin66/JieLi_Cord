///*************************************************************************/
///*
///* 文件名    ：dalCompanyInfo.cs                                      
///* 程序说明  : 公司资料设置
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Common;
using SG.Models;
using SG.Models.Base;
using SG.ORMTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.DataAccess.Base
{
    /// <summary>
    /// 公司资料设置
    /// </summary>
    [DefaultORM_UpdateMode(typeof(tb_sys_CompanyInfo), true)]
    public class dalCompanyInfo : dalBaseDataDict
    {
        public dalCompanyInfo(Loginer loginer)
            : base(loginer)
        {
            _TableName = tb_sys_CompanyInfo.__TableName;
            _KeyName = tb_sys_CompanyInfo.__KeyName;
            _ModelType = typeof(tb_sys_CompanyInfo);
        }
    }
}
