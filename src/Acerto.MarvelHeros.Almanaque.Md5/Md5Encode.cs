using Acerto.MarvelHeros.Almanaque.Md5.Abstractions;
using System.Security.Cryptography;

namespace Acerto.MarvelHeros.Almanaque.Md5
{
    public class Md5Encode : IMd5Encode
    {
        #region [+] Métodos Públicos

        public string EncodeHash(int timestamp, string privateKey, string publicKey)
        {
            string hash = "";
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, (timestamp.ToString()+ privateKey+ publicKey));
            }

            return hash.ToLower();
        }

        #endregion

        #region [+] Métodos Privados

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        #endregion
    }
}