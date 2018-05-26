using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Models.Utils.Encrypters
{
    public class SHA1Encrypter : IEncrypter
    {
        private SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

        public string Encrypt(string text)
        {
            var data = Encoding.ASCII.GetBytes(text);
            var sha1data = sha1.ComputeHash(data);
            var hashed = Encoding.ASCII.GetString(sha1data);
            return hashed;
        }
    }
}
