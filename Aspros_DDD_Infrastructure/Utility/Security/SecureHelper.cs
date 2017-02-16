using System.Text;
using System.Security.Cryptography;

namespace Aspros_DDD_Infrastructure.Utility.Security
{
    public class SecureHelper
    {
        public static string Md5(string inputStr)
        {
            var md5 = MD5.Create();
            var hashByte = md5.ComputeHash(Encoding.UTF8.GetBytes(inputStr));
            var sb = new StringBuilder();
            foreach (var item in hashByte)
                sb.Append(item.ToString("x").PadLeft(2, '0'));
            return sb.ToString();
        }
    }
}
