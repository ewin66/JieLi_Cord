///*************************************************************************/
///*
///* 文件名    ：HexCryptString.cs                                      
///* 程序说明  : 十六进制字符串转换工具
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Common
{
    /// <summary>
    /// 十六进制字符串转换工具
    /// </summary>
    public class HexCryptString
    {
        /// <summary>
        /// 返回16进制字符
        /// </summary>
        private static string GetHexChar(string value)
        {
            string sReturn = string.Empty;
            switch (value)
            {
                case "10":
                    sReturn = "A";
                    break;
                case "11":
                    sReturn = "B";
                    break;
                case "12":
                    sReturn = "C";
                    break;
                case "13":
                    sReturn = "D";
                    break;
                case "14":
                    sReturn = "E";
                    break;
                case "15":
                    sReturn = "F";
                    break;
                default:
                    sReturn = value;
                    break;
            }
            return sReturn;
        }

        /// <summary>
        /// 返回16进制
        /// </summary>
        public static string ConvertHex(string value)
        {
            string sReturn = string.Empty;
            try
            {

                while (int.Parse(value) > 16)
                {
                    int v = int.Parse(value);
                    sReturn = GetHexChar((v % 16).ToString()) + sReturn;
                    value = Math.Floor(Convert.ToDouble(v / 16)).ToString();
                }
                sReturn = GetHexChar(value) + sReturn;
            }
            catch
            {
                sReturn = "###Valid Value!###";
            }
            return sReturn;
        }
    }
}
