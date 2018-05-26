using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Models.Utils.Encrypters
{
    public interface IEncrypter
    {
        string Encrypt(string text);
    }
}
