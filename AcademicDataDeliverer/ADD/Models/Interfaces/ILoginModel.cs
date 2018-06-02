using ADD.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ADD.Models
{
    public interface ILoginModel
    {
        Result Login(string login, string password);
    }
}
