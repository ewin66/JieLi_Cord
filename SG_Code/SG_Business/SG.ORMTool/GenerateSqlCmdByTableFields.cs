///*************************************************************************/
///*
///* 文件名    ：GenerateSqlCmdByTableFields.cs                                      
///* 程序说明  : 由表结构字段定义类创建SQL命令生成器
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SG.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.Common;


namespace SG.ORMTool
{
    /// <summary>
    /// 由表结构字段定义类创建SQL命令生成器
    /// </summary>
    public class GenerateSqlCmdByTableFields : GenerateSqlCmdBase
    {
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="tableStructure">表结构字段定义类</param>
        public GenerateSqlCmdByTableFields(Type tableStructure,string sDbType)
        {
            object[] attrClass = tableStructure.GetCustomAttributes(typeof(ORM_ObjectClassAttribute), false);
            if (attrClass != null && attrClass.Length == 0) throw new Exception("ORM_ObjectClassAttribute未定义!");
            ORM_ObjectClassAttribute classAttribute = attrClass[0] as ORM_ObjectClassAttribute;
            _IsSummary = classAttribute.IsSummaryTable;

            //生成一个新的对象
            object obj = tableStructure.Assembly.CreateInstance(tableStructure.FullName);

            //获取类中的所有属性
            FieldInfo[] infosSelf = tableStructure.GetFields();
            FieldInfo[] infosBase = tableStructure.BaseType.GetFields();

            FieldInfo[] infos = null;
            if (infosBase.Length == 0)
                infos = infosSelf;
            else
            {
                //相加两数组
                int iLength = infosBase.Length;
                Array.Resize<FieldInfo>(ref infosBase, infosBase.Length + infosSelf.Length);
                infosSelf.CopyTo(infosBase, iLength);
                infos = infosBase;
            }

            ArrayList fieldArr = new ArrayList();
            if (sDbType == DbAcessTyp.SQLServer)
            {
                _cmdInsert = new SqlCommand();
                _cmdUpdate = new SqlCommand();
                _cmdDelete = new SqlCommand();
            }
            else
            {
                _cmdInsert = new OracleCommand();
                _cmdUpdate = new OracleCommand();
                _cmdDelete = new OracleCommand();
            }
            _cmdInsert.CommandType = CommandType.Text;
            _cmdUpdate.CommandType = CommandType.Text;
            _cmdDelete.CommandType = CommandType.Text;

            foreach (FieldInfo info in infos)
            {
                object[] attrField = info.GetCustomAttributes(typeof(ORM_FieldAttribute), false);
                string fieldName = info.GetValue(obj).ToString().ToUpper();

                if (attrField != null && attrField.Length > 0)
                {
                    ORM_FieldAttribute fieldAttr = attrField[0] as ORM_FieldAttribute;

                    //用作构造sql语句中的参数
                    if (fieldAttr.IsAddOrUpdate)
                    {
                        //取得最多的参数，与生成的sql语句作匹配,构造SQL参数语句                                             
                        if (!_cmdInsert.Parameters.Contains("@" + fieldName))
                        {
                            if(sDbType==DbAcessTyp.Oracle)
                            {
                                OracleParameter para = new OracleParameter( fieldName, DataConverter.SqlTypeToString(fieldAttr.Type));
                                para.SourceColumn = fieldName;
                                _cmdInsert.Parameters.Add(para);
                            }
                            else
                            {
                                SqlParameter spara = new SqlParameter("@" + fieldName, DataConverter.SqlTypeToString(fieldAttr.Type));
                                spara.SourceColumn = fieldName;
                                _cmdInsert.Parameters.Add(spara);
                            }
                        }
                        if (!_cmdUpdate.Parameters.Contains("@" + fieldName))
                            if (sDbType == DbAcessTyp.Oracle)
                            {
                                OracleParameter para = new OracleParameter( fieldName, DataConverter.SqlTypeToString(fieldAttr.Type));
                                para.SourceColumn = fieldName;
                                _cmdUpdate.Parameters.Add(para);
                            }
                            else
                            {
                                SqlParameter spara = new SqlParameter("@" + fieldName, DataConverter.SqlTypeToString(fieldAttr.Type));
                                spara.SourceColumn = fieldName;
                                _cmdUpdate.Parameters.Add(spara);
                            } 
                        

                        ColoumnProperty colProper = new ColoumnProperty(fieldName, fieldAttr.IsPrimaryKey ? true : false);
                        fieldArr.Add(colProper);
                    }

                    if (fieldAttr.IsPrimaryKey)
                    {
                        if (!_cmdUpdate.Parameters.Contains("@" + fieldName))
                            if (sDbType == DbAcessTyp.Oracle)
                            {
                                OracleParameter para = new OracleParameter( fieldName, DataConverter.SqlTypeToString(fieldAttr.Type));
                                para.SourceColumn = fieldName;
                                _cmdUpdate.Parameters.Add(para);
                            }
                            else
                            {
                                SqlParameter spara = new SqlParameter("@" + fieldName, DataConverter.SqlTypeToString(fieldAttr.Type));
                                spara.SourceColumn = fieldName;
                                _cmdUpdate.Parameters.Add(spara);
                            } 
                       
                        if (!_cmdDelete.Parameters.Contains("@" + fieldName))
                            if (sDbType == DbAcessTyp.Oracle)
                            {
                                OracleParameter para = new OracleParameter( fieldName, DataConverter.SqlTypeToString(fieldAttr.Type));
                                para.SourceColumn = fieldName;
                                _cmdDelete.Parameters.Add(para);
                            }
                            else
                            {
                                SqlParameter spara = new SqlParameter("@" + fieldName, DataConverter.SqlTypeToString(fieldAttr.Type));
                                spara.SourceColumn = fieldName;
                                _cmdDelete.Parameters.Add(spara);
                            } 
                            
                        _PrimaryFieldName = fieldName;
                    }

                    if (fieldAttr.IsDocFieldName) _DocNoFieldName = fieldName;
                    if (fieldAttr.IsForeignKey) _ForeignFieldName = fieldName;
                }
            }

            _sqlInsert = GernerateInsertSql(classAttribute.TableName, classAttribute.PrimaryKey, fieldArr, sDbType);
            _sqlUpdate = GernerateUpdateSql(classAttribute.TableName, classAttribute.PrimaryKey, fieldArr, sDbType);
            _sqlDelete = GernerateDeleteSql(classAttribute.TableName, classAttribute.PrimaryKey, fieldArr, sDbType);

        }
    }

}
