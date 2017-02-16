using Framework.Domain.Core;

namespace Aspros_DDD_Domain.UserItem
{
    public class UserDetail : IAggregateRoot
    {
        #region Properties
        public long Id { get; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 是否有店
        /// </summary>
        public int HasShop { get; set; }

        /// <summary>
        /// 可选值:authentication(实名认证),not authentication(没有认证)
        /// </summary>
        public int PromotedType { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        public string Weixin { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCardNo { get; set; }

        /// <summary>
        /// 银行卡的拥有者姓名
        /// </summary>
        public string BankCardOwnerName { get; set; }

        /// <summary>
        /// 创建时的IP
        /// </summary>
        public string CreateLocation { get; set; }

        /// <summary>
        /// 支付宝账号
        /// </summary>
        public string AlipayId { get; set; }

        /// <summary>
        /// 是否已绑定邮箱
        /// </summary>
        public int HasBindEmail { get; set; }

        #endregion

        #region Public Methods

        #endregion

    }
}
