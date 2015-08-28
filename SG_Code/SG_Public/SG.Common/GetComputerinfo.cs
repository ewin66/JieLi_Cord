///*************************************************************************/
///*
///* 文件名    ：GetComputerinfo.cs        
///
///* 程序说明  : 获取机器名和IP            
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SG.Common
{
   public class GetComputerinfo
    {
       /// <summary>
       /// 获取IP
       /// </summary>
       /// <returns></returns>
       public static string GetIP()   //获取本地IP
       {
           IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
           IPAddress ipAddr = ipHost.AddressList[0];
           return ipAddr.ToString();
       }
       /// <summary>
       /// 获取机器名
       /// </summary>
       /// <returns></returns>
       public static string GetHostName()
       {
           return System.Net.Dns.GetHostName(); 
       }
    }
}
