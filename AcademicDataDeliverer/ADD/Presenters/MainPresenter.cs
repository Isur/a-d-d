using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Presenters
{
    public class MainPresenter
    {
        Models.Model model;
        Views.IMainView view;
        public MainPresenter(Models.Model model, Views.IMainView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
