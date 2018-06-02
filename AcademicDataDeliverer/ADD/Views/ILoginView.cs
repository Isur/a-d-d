using ADD.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Views
{
    public interface ILoginView
    {
        string Login { get; }
        string Password { get; }
        event Func<string, string, Result> LoginClick;
    }
}
