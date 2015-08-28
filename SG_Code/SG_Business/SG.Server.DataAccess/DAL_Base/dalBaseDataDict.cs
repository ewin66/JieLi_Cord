///*************************************************************************/
///*
///* 文件名    ：dalBaseDataDict.cs                                      
///* 程序说明  : 数据字典数据层基类
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using SG.Common;
using SG.Interfaces;
using SG.Interfaces.Base;
using SG.ORMTool;
using SG.Tools.DataOperate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SG.Server.DataAccess
{
    /// <summary>
    /// 数据字典数据层基类
    /// </summary>
    public class dalBaseDataDict : dalBase, IBridge_DataDict
    {
        /// <summary>
        /// ORM模型
        /// </summary>
        protected Type _ModelType = null;

        /// <summary>
        /// 字典表名
        /// </summary>
        protected string _TableName = string.Empty;

        /// <summary>
        /// 主键字段名
        /// </summary>
        protected string _KeyName = string.Empty;

        public Type ORM
        {
            get { return _ModelType; }
            set
            {
                _ModelType = value;

                if (_ModelType == null) throw new Exception("ORM为能为null!");

                object[] attrs = _ModelType.GetCustomAttributes(typeof(ORM_ObjectClassAttribute), false);
                if (attrs.Length == 0) throw new Exception("ORM模型没定义ORM_ObjectClassAttribute属性!");

                _TableName = (attrs[0] as ORM_ObjectClassAttribute).TableName;
                _KeyName = (attrs[0] as ORM_ObjectClassAttribute).PrimaryKey;
            }
        }

        public string TableName { get { return _TableName; } set { _TableName = value; } }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="loginer">当前用户登录信息</param>
        public dalBaseDataDict(Loginer loginer) : base(loginer) { }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="loginer">当前用户登录信息</param>
        /// <param name="ORM">数据字典的ORM类</param>
        public dalBaseDataDict(Loginer loginer, Type ORM_Type)
            : base(loginer)
        {
            this.ORM = ORM_Type;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="loginer">当前用户登录信息</param>
        /// <param name="tableName">字典表名</param>
        public dalBaseDataDict(Loginer loginer, string tableName)
            : base(loginer)
        {
            _TableName = tableName;
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="loginer">当前用户登录信息</param>
        /// <param name="tableName">字典表名</param>
        /// <param name="keyName">主键字段名</param>
        /// <param name="modelType">数据字典的ORM类</param>
        public dalBaseDataDict(Loginer loginer, string tableName, string keyName, Type modelType)
            : base(loginer)
        {
            _ModelType = modelType;
            _TableName = tableName;
            _KeyName = keyName;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="data">需要更新的数据集(只要指定表名与ORM,支持更新多个数据表)</param>
        /// <returns></returns>
        public virtual bool Update(DataSet data)
        {
            //非用户手动事务模式，预设启用事务
            if (_UserManualControlTrans == false) this.BeginTransaction();

            if (_CurrentTrans == null) throw new Exception("用户手动控制事务模式下，但您没有启用事务！");

            try
            {
                foreach (DataTable dt in data.Tables)
                {
                    if (dt.GetChanges() == null) continue; //没有数据更新

                    IGenerateSqlCommand gen = this.CreateSqlGenerator(dt.TableName);
                    if (gen == null) throw new Exception("创建IGenerateSqlCommand失败！");
                    if (_Loginer.DbType == DbAcessTyp.SQLServer)
                    {
                        SqlDataAdapter adp = new SqlDataAdapter();
                        adp.RowUpdating += new SqlRowUpdatingEventHandler(OnAdapterRowUpdating);
                        adp.UpdateCommand = (SqlCommand)GetUpdateCommand(gen, _CurrentTrans);
                        adp.InsertCommand = (SqlCommand)GetInsertCommand(gen, _CurrentTrans);
                        adp.DeleteCommand = (SqlCommand)GetDeleteCommand(gen, _CurrentTrans);
                        adp.Update(dt);
                    }
                    else
                    {
                        OracleDataAdapter adp = new OracleDataAdapter();
                        //adp.RowUpdating += adp_RowUpdating;
                        
                        adp.UpdateCommand = (OracleCommand)GetUpdateCommand(gen, _CurrentTrans);
                        adp.InsertCommand = (OracleCommand)GetInsertCommand(gen, _CurrentTrans);
                        adp.DeleteCommand = (OracleCommand)GetDeleteCommand(gen, _CurrentTrans);
                        adp.Update(dt);
                    }
                    
                }

                if (_UserManualControlTrans == false) this.CommitTransaction(); //提交事务

                return true;
            }
            catch (Exception ex)
            {
                if (_UserManualControlTrans == false) this.RollbackTransaction();//回滚事务

                throw new Exception("更新数据发生错误！Event:Update()\r\n\r\n" + ex.Message);
            }
        }

        //void adp_RowUpdating(object sender, OracleRowUpdatingEventArgs e)
        //{
        //    foreach (OracleParameter p in e.Command.Parameters)
        //    {
        //        if (p.OracleType !=OracleDateTime) continue;
        //        if (string.IsNullOrEmpty(p.Value.ToString()))
        //        { p.Value = DBNull.Value; continue; }
        //        if (DateTime.Parse(p.Value.ToString()).ToString("yyyyMMdd") == DateTime.MinValue.ToString("yyyyMMdd"))
        //        { p.Value = DBNull.Value; continue; }
        //    }
        //}

        /// <summary>
        /// 更新数据的扩展方法，在dalBaseDataDict类作为模板方法，具体类需要重写此方法。
        /// </summary>
        /// <param name="data">需要更新的数据集(只要指定表名与ORM,支持更新多个数据表)</param>
        /// <returns></returns>
        public virtual SaveResultEx UpdateEx(DataSet data)
        {
            bool success = this.Update(data);//调用预设的保存方法

            //返回一个对象类型的结果
            return new SaveResultEx(success ? (int)ResultID.SUCCESS : (int)ResultID.FAILED, "");
        }

        /// <summary>
        /// 根据表名获取该表的ＳＱＬ命令生成器
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        protected virtual IGenerateSqlCommand CreateSqlGenerator(string tableName)
        {
            if (_ModelType == null) throw new Exception("没绑定数据表结构定义!");

            if (tableName == _TableName)
                return new GenerateSqlCmdByTableFields(_ModelType,_Loginer.DbType); //预设
            else
                throw new Exception("创建IGenerateSqlCommand失败！");

            //支持两种SQL命令生成器
            //IGenerateSqlCommand gen = new GenerateSqlCmdByObjectClass(_ModelType);
        }

        /// <summary>
        /// 检查表名是否为空
        /// </summary>
        public void AssertTableName()
        {
            if (_TableName == string.Empty)
                throw new Exception("数据字典未指定表名!");
        }

        /// <summary>
        /// 检查主键是否为空
        /// </summary>
        public void AssertTableKey()
        {
            if ((_TableName == string.Empty) || (_KeyName == string.Empty))
                throw new Exception("数据字典未指定表名或主键!");
        }

        /// <summary>
        /// 获取主表数据
        /// </summary>
        /// <returns></returns>
        public virtual DataTable GetSummaryData()
        {
            this.AssertTableName();
            
            string sql = string.Format("SELECT * FROM {0}", _TableName);
            DataTable RTatatable=new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql);
            RTatatable.TableName = _TableName;
            return RTatatable;
        }

        /// <summary>
        /// 获取指定主键的数据
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public virtual DataTable GetDataByKey(string key)
        {  ;
        string sql = "";
            IDbDataParameter[] sPara = new IDbDataParameter[1];
            if (_Loginer.DbType == DbAcessTyp.SQLServer)
            {
                sql = string.Format("SELECT * FROM {0} WHERE {1}=@KEY", _TableName, _KeyName);
                sPara[0] = DataConverter.GetSqlPara("@KEY", DataConverter.SqlTypeToString(SqlDbType.VarChar));
            }
            else
            {
                sql = string.Format("SELECT * FROM {0} WHERE {1}=:KEY", _TableName, _KeyName);
                sPara[0] = DataConverter.GetOraclePara(":KEY", DataConverter.SqlTypeToString(SqlDbType.VarChar));
            }
            sPara[0].Value = key;

            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql, sPara);
            //return DataProvider.Instance.GetTable(_Loginer.DBName, cmd.SqlCommand, _TableName);
        }

        /// <summary>
        /// 跟据表名取数据字典
        /// </summary>
        /// <param name="tableName">字典表名</param>
        /// <returns></returns>
        public virtual DataTable GetDataDictByTableName(string tableName)
        {
            if (String.IsNullOrEmpty(tableName)) throw new Exception("表名不能为空！");
            string sql = string.Format("SELECT * FROM {0}", tableName);
            //return DataProvider.Instance.GetTable(_Loginer.DBName, sql, tableName);
            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataTable(sql); 
        }

        /// <summary>
        /// 下载所有数据字典
        /// </summary>
        /// <returns></returns>
        public virtual DataSet DownloadDicts()
        {
            string[] sql = new string[9];
            sql[0] = "select * from sys_User";
            sql[1] = "select * from sys_Department";
            sql[2] = "SELECT  d.*, t.FName DbType, u.FUserName FROM sys_DbLink  d INNER JOIN sys_DbType  t ON d.FDataType = t.FID INNER JOIN sys_User  u ON d.FUserID = u.FID order by d.fNumber";
            sql[3] = "select * from   t_CommDataDictType order by fdatatype";
            sql[4] = "SELECT     ty.FDataType, ty.FTypeName, ty.FIssys, t.*  FROM  t_CommDataDictType ty INNER JOIN   t_CommonDataDict t ON ty.Fid = t.FDataTypeID";
            sql[5] = "select t.*,u.FUserName from t_ItemClass t  inner join sys_user u on t.FUserID=u.fid order by t.fnumber ";
            sql[6] = "SELECT   D.*,case D.FDataType when 1 then '逻辑' when 2 then '日期' when 3 then '基础资料' when 4 then '文本' when 5 then '数字' else '' end FDateTypeVal, C.FNumber ClassNum, C.FName ClassName, ";
            if (_Loginer.DbType == DbAcessTyp.SQLServer)
                sql[6] += "isnull(Src.FNumber,'') + isnull(Com.FDataType,'') SrcNum, isnull(Src.FName,'') + isnull(Com.FTypeName,'') SrcName";
            else
                sql[6] += "nvl(Src.FNumber,'') + nvl(Com.FDataType,'') SrcNum, nvl(Src.FName,'') + nvl(Com.FTypeName,'') SrcName";
            sql[6] += " FROM t_ItemPropDesc  D INNER JOIN t_ItemClass C ON D.FItemClassID = C.FID  LEFT OUTER JOIN t_CommDataDictType Com ON D.FScItemClassID = Com.Fid and  D.FSrcTable='t_CommonDataDict' LEFT OUTER JOIN ";
            sql[6] += " t_ItemClass Src ON D.FSrcTable = Src.FSQLTableName AND D.FScItemClassID = Src.FID ";
            sql[7] += "SELECT  *  FROM   sys_Function";
            sql[8] = "SELECT   *  FROM    sys_Fun_MenuBar";
            ArrayList arrSqlList = new ArrayList();
            foreach (string sql1 in sql)
            {
                arrSqlList.Add(sql1);
            }
            return new DataBaseLayer(_Loginer.DBName).ExecuteQueryDataSet(arrSqlList);
        }

        /// <summary>
        /// 检查数据是否存在
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public virtual bool CheckNoExists(string keyValue)
        {

            string sql = "";
            IDbDataParameter[] sPara = new IDbDataParameter[1];
            if (_Loginer.DbType == DbAcessTyp.SQLServer)
            {
                sql = string.Format("SELECT COUNT(*) C FROM {0} WHERE {1}=@KEY", _TableName, _KeyName);
                sPara[0] = DataConverter.GetSqlPara("@KEY", DataConverter.SqlTypeToString(SqlDbType.VarChar));
            }
            else
            {
                sql = string.Format("SELECT COUNT(*) C FROM {0} WHERE {1}=:KEY", _TableName, _KeyName);
                sPara[0] = DataConverter.GetOraclePara(":KEY", DataConverter.SqlTypeToString(SqlDbType.VarChar)); 
            }
            sPara[0].Value = keyValue;
            //SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            //cmd.AddParam("@KEY", SqlDbType.VarChar, keyValue);
            //object o = DataProvider.Instance.ExecuteScalar(_Loginer.DBName, cmd.SqlCommand);
            object o = new DataBaseLayer(_Loginer.DBName).GetSingle(sql, sPara);
            return ConvertEx.ToInt(o) > 0;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public virtual bool Delete(string keyValue)
        {
            string sql = "";
            //SqlCommandBase cmd = SqlBuilder.BuildSqlCommandBase(sql);
            //cmd.AddParam("@KEY", SqlDbType.VarChar, keyValue);
            IDbDataParameter[] sPara = new IDbDataParameter[1];
            if (_Loginer.DbType == DbAcessTyp.SQLServer)
            {
                sql = string.Format("Delete {0} where {1}=@KEY", _TableName, _KeyName);
                sPara[0] = DataConverter.GetSqlPara("@KEY", DataConverter.SqlTypeToString(SqlDbType.VarChar));
            }
            else
            {
                sql = string.Format("Delete {0} where {1}=:KEY", _TableName, _KeyName);
                sPara[0] = DataConverter.GetOraclePara(":KEY", DataConverter.SqlTypeToString(SqlDbType.VarChar));
            }
            sPara[0].Value = keyValue;

            int i = new DataBaseLayer(_Loginer.DBName).ExecuteSql(sql, sPara);  //DataProvider.Instance.ExecuteNoQuery(_Loginer.DBName, cmd.SqlCommand);
            return i != 0;
        }

        #region CreateDataDictDAL

        /// <summary>
        /// 跟据DAL类名创建数据层实例
        /// </summary>
        /// <param name="loginer">当前登录用户</param>
        /// <param name="derivedClassName">DAL类名</param>
        /// <returns></returns>
        public static IBridge_DataDict CreateDalByClassName(Loginer loginer, string derivedClassName)
        {
            Type T = typeof(dalBaseDataDict).Assembly.GetType(derivedClassName, true, true);

            object[] args = new object[] { loginer }; //参数

            object dal = T.Assembly.CreateInstance(derivedClassName, true, BindingFlags.CreateInstance,
                null, args, CultureInfo.CurrentCulture, null);

            return dal as IBridge_DataDict;
        }

        //哈希表, 保存已加载的DAL类的引用地址
        private static Hashtable _LoadedDalTypes = null;

        /// <summary>
        /// 跟据ORM类全名自动创建DAL对象实例
        /// </summary>
        /// <param name="loginer">当前登录用户</param>
        /// <param name="ORM_TypeName">ORM类的命名空间</param>
        /// <returns></returns>
        public static dalBaseDataDict CreateDalByORM(Loginer loginer, string ORM_TypeName)
        {
            if (String.IsNullOrEmpty(ORM_TypeName)) throw new CustomException("ORM类名为空，无法创建实例！");
            if (_LoadedDalTypes == null) _LoadedDalTypes = new Hashtable(); //创建哈希表实例
            Type _DAL_Type = null; //DAL类定义
            bool IsFind = false;

            //哈希表存在该类,从哈希表取出.
            if (_LoadedDalTypes.ContainsKey(ORM_TypeName))
                _DAL_Type = _LoadedDalTypes[ORM_TypeName] as Type;
            else
            {
                //
                //哈希表不存在,表示第一次加载,需要从CSFramework3.Server.DataAccess程序集中查询该类                
                //
                //获取DataAccess程序集中所有Public类  
                //Type[] types = typeof(dalBaseDataDict).Assembly.GetExportedTypes();
                Type[] types ;
                string[] files = System.IO.Directory.GetFiles(SG.Parameters.SGParameter.sAppPath, "SG.Server.DataAccess*.dll");
                for (int i = 0; i < files.Length; i++)
                {
                    Assembly _assembly = Assembly.LoadFrom(files[i]);

                    // 获取程序集中所有公共类型
                    types = _assembly.GetExportedTypes();


                    //枚举程序集中所有Public类  
                    foreach (Type T in types)
                    {
                        //只查找dalBaseDataDict的子类
                        if (false == T.IsSubclassOf(typeof(dalBaseDataDict))) continue;

                        //查找DefaultORM_UpdateMode特性
                        object[] atts = T.GetCustomAttributes(typeof(DefaultORM_UpdateMode), false);
                        if ((atts == null) || (atts.Length == 0)) continue;

                        //该类有定义DefaultORM_UpdateMode特性
                        DefaultORM_UpdateMode att = atts[0] as DefaultORM_UpdateMode;
                        if (false == att.IsOverrideClass) continue; //仅查找具体类(子类)

                        //比较ORM的全名是否相同
                        if (att.ORM.FullName.ToUpper() == ORM_TypeName.ToUpper())
                        {
                            _DAL_Type = T;
                            IsFind = true;
                            break;
                        }
                    }
                    if (IsFind)
                        break;
                }

                //第一次加载后添加到哈希表中, 基于性能优化.
                if (_DAL_Type != null) _LoadedDalTypes.Add(ORM_TypeName, _DAL_Type);
            }

            //没有找到指定的数据层，预设为数据字典基类
            if (_DAL_Type == null) _DAL_Type = typeof(dalBaseDataDict);

            //创建DAL实例
            object instance = _DAL_Type.Assembly.CreateInstance(_DAL_Type.FullName, true,
                BindingFlags.CreateInstance, null,
                 new object[] { loginer }, CultureInfo.CurrentCulture, null);

            if (instance is dalBaseDataDict)
                return instance as dalBaseDataDict;
            else
                //查出的类非dalBaseDataDict派生类,重新生成dalBaseDataDict类实例
                return new dalBaseDataDict(loginer);
        }

        #endregion


    }
}

