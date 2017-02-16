using System;
using Framework.Domain.Core;

namespace Aspros_DDD_Domain.UserItem
{
    public class UserShoppingCart : IAggregateRoot
    {
        #region Contructor
        public UserShoppingCart()
        {
            GmtCreated = DateTime.Now;
            GmtModified = DateTime.Now;
        }
        #endregion

        #region Properties
        public long Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public long ItemId { get; set; }

        /// <summary>
        /// SKUID
        /// </summary>
        public long SkuId { get; set; }

        /// <summary>
        /// SKU的值
        /// </summary>
        public string SkuPropertiesName { get; set; }

        /// <summary>
        /// 取值范围:大于零的整数
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime GmtCreated { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime GmtModified { get; set; }


        #endregion
    }
}
