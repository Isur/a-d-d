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

            this.view.CollegeComboBoxDropDown += this.model.GetColleges;
            this.view.FacultyComboBoxDropDown += this.model.GetFacultiesInCollege;
            this.view.SpecializationComboBoxDropDown += this.model.GetSpecializationsOnFaculty;
            this.view.RegisterClick += this.model.RegisterNewUser;
        }
    }
}
