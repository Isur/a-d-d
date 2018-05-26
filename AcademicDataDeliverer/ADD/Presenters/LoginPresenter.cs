using ADD.Models;
using ADD.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Presenters
{
    public class LoginPresenter
    {
        LoginModel model;
        ILoginView view;
        public LoginPresenter(LoginModel model, ILoginView view)
        {
            this.model = model;
            this.view = view;

            this.view.LoginClick += this.model.Login;
        }
    }
}
