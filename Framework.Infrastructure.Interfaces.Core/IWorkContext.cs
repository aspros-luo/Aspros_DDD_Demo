using Framework.Domain.ValueObjects;

namespace Framework.Infrastructure.Interfaces.Core
{
    public interface IWorkContext
    {
        /// <summary>
        /// 用户ID 
        /// </summary>
        long UserId { get; }

        /// <summary>
        /// 用户名称
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        string UserNick { get; }

        /// <summary>
        /// 用户类型
        /// </summary>
        UserType UserType { get; }
    }
}
