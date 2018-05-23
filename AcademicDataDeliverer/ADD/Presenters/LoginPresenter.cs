using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Presenters
{
    public class LoginPresenter
    {
        Models.LoginModel model;
        Views.ILoginView view;
        public LoginPresenter(Models.LoginModel model, Views.ILoginView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
