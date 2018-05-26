using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Presenters
{
    public class RegisterPresenter
    {
        Models.IRegisterModel model;
        Views.IRegisterView view;
        public RegisterPresenter(Models.IRegisterModel model, Views.IRegisterView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
