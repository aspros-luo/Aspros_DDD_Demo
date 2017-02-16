using Framework.Domain.Core;

namespace Aspros_DDD_Domain.UserItem
{
    public class UserShippingAddress:IAggregateRoot
    {
        #region Properties
        public long Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 收货人的姓名
        /// </summary>
        public string ReceiverName { get; set; }

        /// <summary>
        /// 收货人国籍
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 收货人的所在省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 因为国家对于城市和地区的划分的有：省直辖市和省直辖县级行政区（区级别的）划分的
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 收货人的所在乡镇
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// 收货人街道地址
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 收货人的详细地址
        /// </summary>
        public string DetailAddress { get; set; }

        /// <summary>
        /// 收货人的邮编
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// 收货人的手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 收货人的电话号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 是否默认
        /// </summary>
		public bool IsDefault { get; set; }

        #endregion
    }
}
