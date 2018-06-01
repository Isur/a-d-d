using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Presenters
{
    public class ProfilePresenter
    {
        Models.IProfileModel model;
        Views.IProfileView view;
        public ProfilePresenter(Models.IProfileModel model, Views.IProfileView view)
        {
            this.model = model;
            this.view = view;

            this.view.CollegeGetItems += model.GetColleges;
            this.view.FacultyGetItems += model.GetFacultiesInCollege;
            this.view.SpecializationsGetItems += model.GetSpecializationsOnFaculty;
            this.view.SubjectGetItems += model.GetSubjectsFromSpecialization;
            this.view.GetUser += model.GetUser;
            this.view.DeleteSubscription += model.CancelSub;
        }
    }
}
