using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Presenters
{
    public class SubscribePresenter
    {
        Models.ISubscribeModel model;
        Views.ISubscribeView view;
        public SubscribePresenter(Models.ISubscribeModel model, Views.ISubscribeView view)
        {
            this.model = model;
            this.view = view;

            this.view.CollegeComboBoxDropDown += this.model.GetColleges;
            this.view.FacultyComboBoxDropDown += this.model.GetFacultiesInCollege;
            this.view.SpecializationComboBoxDropDown += this.model.GetSpecializationsOnFaculty;
            this.view.SubscribeClick += this.model.Subscribe;
        }
    }
}
