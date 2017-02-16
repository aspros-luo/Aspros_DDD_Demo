using Framework.Domain.Core;

namespace Aspros_DDD_Domain.UserItem
{
    public class UserSupplier : IAggregateRoot
    {
        #region propertites
        public long Id { get; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankNumber { get; set; }
        #endregion
    }
}
