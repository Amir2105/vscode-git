using System.Security.Cryptography;
using System.Text;
using RayaneGostar.Application.Interfaces;

namespace RayaneGostar.Application.Services
{
    public class PasswordHelper : IPasswordHelper
    {
        public string EncodePasswordMd5(string pass)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);

        }

    }
}