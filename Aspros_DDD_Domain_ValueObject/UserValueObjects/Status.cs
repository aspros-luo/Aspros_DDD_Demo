namespace Aspros_DDD_Domain_ValueObject.UserValueObjects
{
    public enum Status
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 未激活
        /// </summary>
        Inactive = 1,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 2,
        /// <summary>
        /// 冻结
        /// </summary>
        Reeze = 3,
        /// <summary>
        /// 监管
        /// </summary>
        Supervise = 4
    }
}
