using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Presenters
{
    public class LoginPresenter
    {
        Models.Model model;
        Views.ILoginView view;
        public LoginPresenter(Models.Model model, Views.ILoginView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
