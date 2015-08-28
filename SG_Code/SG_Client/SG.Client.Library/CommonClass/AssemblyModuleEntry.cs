///*************************************************************************/
///*
///* 文件名    ：AssemblyModuleEntry.cs                                
///* 程序说明  : 模块入口自定义特性.
///*              继承Attribute特性，用于标记该DLL是否系统或业务模块.
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using SG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Client.Library
{
    /// <summary>
    /// 模块入口自定义特性
    /// </summary>
    public class AssemblyModuleEntry : Attribute
    {
        private ModuleID _moduleID;
        private string _moduleName;
        private string _moduleEntryNameSpace;

        /// <summary>
        /// 模块编号
        /// </summary>
        public ModuleID ModuleID { get { return _moduleID; } }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get { return _moduleName; } }

        /// <summary>
        /// 模块名字空间
        /// </summary>
        public string ModuleEntryNameSpace { get { return _moduleEntryNameSpace; } }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="moduleID">模块编号</param>
        /// <param name="moduleName">模块名称</param>
        /// <param name="moduleEntryNameSpace">模块名字空间</param>
        public AssemblyModuleEntry(ModuleID moduleID, string moduleName, string moduleEntryNameSpace)
        {
            _moduleID = moduleID;
            _moduleName = moduleName;
            _moduleEntryNameSpace = moduleEntryNameSpace;
        }

    }

}
