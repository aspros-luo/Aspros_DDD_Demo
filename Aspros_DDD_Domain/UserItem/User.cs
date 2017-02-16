using System;
using Framework.Domain.Core;
using System.Collections.Generic;
using Aspros_DDD_Infrastructure.Utility.Security;
using Aspros_DDD_Domain_ValueObject.UserValueObjects;

namespace Aspros_DDD_Domain.UserItem
{
    public class User : IAggregateRoot
    {
        #region Constructor
        public User()
        {
            LoginPwdSalt = DateTime.Now.Ticks.ToString();
            AccountType = 1;
            LoginPwdEncryption = 2;
            GmtCreated = DateTime.Now;
            GmtModified = DateTime.Now;
            ShippingAddress = new List<UserShippingAddress>();
            Identitys = new List<UserIdentity>();
        }
        #endregion

        #region Properties
        public long Id { get; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户头像地址
        /// </summary>
        public string AvatarUrl { get; set; }

        /// <summary>
        /// 可选值:normal(正常),inactive(未激活),delete(删除),reeze(冻结),supervise(监管)
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// 可选值:B(B商家),C(C商家)
        /// </summary>
        public UserTypes UserType { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string LoginPwd { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 1、代表单纯MD5，2：代表单一Salt的MD5，3、代表根据记录不同后的MD5
        /// </summary>
        public int LoginPwdEncryption { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 密码salt
        /// </summary>
        public string LoginPwdSalt { get; set; }

        /// <summary>
        /// 默认 1
        /// </summary>
        public int AccountType { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime GmtCreated { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime GmtModified { get; set; }

        /// <summary>
        /// 用户详细信息
        /// </summary>
	    public UserDetail UserDetail { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        public List<UserShippingAddress> ShippingAddress { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public List<UserIdentity> Identitys { get; set; }

        /// <summary>
        /// 供应商信息
        /// </summary>
        public UserSupplier UserSupplier { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// 加密用户密码
        /// </summary>
        public void EncryptPwd()
        {
            LoginPwd = EncryptPwd(LoginPwd);
        }

        /// <summary>
        /// 验证用户密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
	    public bool VerifyPwd(string pwd)
        {
            return LoginPwd == EncryptPwd(pwd);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 加密用户密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        private string EncryptPwd(string pwd)
        {
            return SecureHelper.Md5(pwd + SecureHelper.Md5(LoginPwdSalt));
        }

        #endregion
    }
}
