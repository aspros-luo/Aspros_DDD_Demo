using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Framework.Common.Core
{
    public static class ContextAccessorExtensions
    {
        public static string GetHeader(this IHttpContextAccessor httpContextAccessor, string key)
        {
            var values = new StringValues();
            httpContextAccessor?.HttpContext?.Request.Headers.TryGetValue(key, out values);
            return !string.IsNullOrWhiteSpace(values) ? values[0] : "";
        }
    }
}
