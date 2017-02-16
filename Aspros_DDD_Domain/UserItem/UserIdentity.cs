using Framework.Domain.Core;

namespace Aspros_DDD_Domain.UserItem
{
    public class UserIdentity:IAggregateRoot
    {
        #region Properties
        public long Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 收货人的证件号
        /// </summary>
        public string IdentityId { get; set; }

        /// <summary>
        /// 收货人的身份证正面
        /// </summary>
        public string IdentityPicFront { get; set; }

        /// <summary>
        /// 收货人的身份证反面
        /// </summary>
        public string IdentityPicBack { get; set; }

        /// <summary>
        /// 是否默认
        /// </summary>
		public bool IsDefault { get; set; }

        /// <summary>
        /// 是否认证
        /// </summary>
        public bool IsAuthenticate { get; set; } = true;

        #endregion
    }
}
