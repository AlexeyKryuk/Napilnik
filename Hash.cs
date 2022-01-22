using System.Security.Cryptography;
using System.Text;

namespace Napilnik
{
    public abstract class Hash
    {
        protected abstract byte[] Calculate(byte[] inputBytes);

        public string Create(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = Calculate(inputBytes);

            var sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }

    public class HashMD5 : Hash
    {
        protected override byte[] Calculate(byte[] inputBytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(inputBytes);
            }
        }
    }

    public class HashSHA1 : Hash
    {
        protected override byte[] Calculate(byte[] inputBytes)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(inputBytes);
            }
        }
    }
}
