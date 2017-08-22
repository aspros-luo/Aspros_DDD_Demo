using Framework.Common.Core;
using Framework.Domain.ValueObjects;
using Framework.Infrastructure.Interfaces.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace Framework.Infrastructure.Core
{
    public class WorkContext:IWorkContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long UserId
        {
            get
            {
                var value=_httpContextAccessor.GetHeader("X-User-Id");
                return string.IsNullOrWhiteSpace(value) ? 0 : long.Parse(value);
            }
        }

        public string UserName => WebUtility.UrlDecode(_httpContextAccessor.GetHeader("X-User-Name"));
        public string UserNick => WebUtility.UrlDecode(_httpContextAccessor.GetHeader("X-User-Nick"));

        public UserType UserType
        {
            get
            {
                var value = _httpContextAccessor.GetHeader("X-User-Type");
                return string.IsNullOrWhiteSpace(value) ? UserType.B : (UserType)Enum.Parse(typeof(UserType), value, true);
            }
        }
    }
}
