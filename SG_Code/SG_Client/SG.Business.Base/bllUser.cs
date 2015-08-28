
///*************************************************************************/
///*
///* 文件名    ：bllUser.cs        
///
///* 程序说明  : 用户管理的业务逻辑层
///               
///* 原创作者  ：东莞思谷 XW Peng 
///* 
///* Copyright 2014-2015 东莞思谷数字技术有限公司
///**************************************************************************/

using SG.Client.Bridge;
using SG.Client.Bridge.Base;
using SG.Common;
using SG.Interfaces.Base;
using SG.Models.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.Business.Base
{
     public class bllUser : bllBaseDataDict
    {
        private IBridge_User _MyBridge;

        public bllUser()
        {

            _KeyFieldName = tb_sys_User.__KeyName; //主键字段
            _SummaryTableName = tb_sys_User.__TableName;//表名
            _WriteDataLog = false;//是否保存日志                    
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(tb_sys_User));
            _MyBridge = this.CreateBridge();
        }

        /// <summary>
        /// 创建实现了桥接接口的通信通道
        /// </summary>
        /// <returns></returns>
        private IBridge_User CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirect_SGBaseUser().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WCFIISHost_SGBaseUser();

            if (BridgeFactory.BridgeType == BridgeType.WcfHost)
                return new WCFHost_SGBaseUser();

            return null;
        }

        /// <summary>
        /// 获取所有用户数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetUsers()
        {
            _SummaryTable = _MyBridge.Getb_sys_Users();

            SetDefault(_SummaryTable);
            return _SummaryTable;
        }

        protected override void SetDefault(DataTable data)
        {
            data.Columns[tb_sys_User.FIsLocked].DefaultValue = 0;
            data.Columns[tb_sys_User.FCreateTime].DefaultValue = DateTime.Now;
            data.TableName = tb_sys_User.__TableName;
        }

        public override bool Delete(string account)
        {
            return _MyBridge.DeleteUser(account);
        }

        /// <summary>
        /// 获取指定用户数据
        /// </summary>
        /// <param name="account">用户帐号</param>
        /// <returns></returns>
        public DataTable GetUser(string account)
        {
            return _MyBridge.Getb_sys_User(account);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="data">用户数据</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Update(DataTable data, UpdateType type)
        {
            DataSet ds = this.CreateDataset(data, type);
            return _MyBridge.Update(ds);
        }

        public override bool CheckNoExists(string account)
        {
            return _MyBridge.ExistsUser(account);
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="account">用户帐号</param>
        /// <param name="pwd">新密码</param>
        /// <returns></returns>
        public bool ModifyPassword(string account, string pwd)
        {
            return _MyBridge.ModifyPassword(account, pwd);
        }

        /// <summary>
        /// 跟据Novell帐号获取用户登录帐号
        /// </summary>
        /// <param name="novellAccount">Novell帐号</param>
        /// <returns></returns>
        public DataTable GetUserByNovellID(string novellAccount)
        {
            return _MyBridge.Getb_sys_UserByNovellID(novellAccount);
        }

        public void Validate(LoginUser user)
        {
            if (CheckNoExists(user.Account))
                throw new Exception("用户已经存在!");
        }

        public static void ValidateLogin(string userID, string password)
        {
            if (userID.Trim() == "")
                throw new Exception("用户编号不正确或不能为空!");

            if (password.Trim() == "")
                throw new Exception("密码不正确或不能为空!");
        }

        public DataTable GetUserDirect(string account, string DBName)
        {
            return _MyBridge.Getb_sys_UserDirect(account, DBName);
        }

        public bool ModifyPasswordDirect(string account, string pwd, string DBName)
        {
            return _MyBridge.ModifyPwdDirect(account, pwd, DBName);
        }

        public DataTable GetUserGroups(string account)
        {
            return _MyBridge.Getb_sys_UserGroups(account);
        }

        public DataTable Login(LoginUser loginUser, char LoginUserType)
        {
            return _MyBridge.Login(loginUser, LoginUserType);
        }

        public DataTable GetUserAuthorities(Loginer user)
        {
            return _MyBridge.Getb_sys_UserAuthorities(user);
        }

        public void Logout(string account)
        {
            _MyBridge.Logout(account);
        }

        public DataSet GetUserReportData(DateTime createDateFrom, DateTime createDateTo)
        {
            return _MyBridge.Getb_sys_UserReportData(createDateFrom, createDateTo);
        }
    }
}
