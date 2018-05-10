using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Views
{
    public interface ILoginView
    {
        string Login { get; set; }
        string Password { get; set; }
        event Func<string, string, bool> LoginClick;
    }
}
