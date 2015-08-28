///*************************************************************************/
///*
///* 文件名    ：IBridge_AttachFile.cs                                
///* 程序说明  : 附件接口
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interfaces.Base
{
   public interface IBridge_AttachFile
    {
       DataTable GetAttachFileData(string docID);
    }
}
