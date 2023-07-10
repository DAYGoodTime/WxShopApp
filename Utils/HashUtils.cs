using System.Security.Cryptography;
using System.Text;

namespace EBike.Utils
{
    public class HashUtils
    {
        private static readonly SHA384 _sha384 = SHA384.Create();

        public static string HashStr(string str)
        {
            return Convert.ToBase64String(_sha384.ComputeHash(Encoding.UTF8.GetBytes(str)));
        }
    }
}
