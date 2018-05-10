using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Presenters
{
    public class ProfilePresenter
    {
        Models.Model model;
        Views.IProfileView view;
        public ProfilePresenter(Models.Model model, Views.IProfileView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
