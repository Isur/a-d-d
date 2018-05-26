using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Presenters
{
    public class LoginPresenter
    {
        Models.ILoginModel model;
        Views.ILoginView view;
        public LoginPresenter(Models.ILoginModel model, Views.ILoginView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
