﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Presenters
{
    public class NotePresenter
    {
        Models.INoteModel model;
        Views.INoteView view;
        public NotePresenter(Models.INoteModel model, Views.INoteView view)
        {
            this.model = model;
            this.view = view;

            this.view.CollegeGetItems += model.GetColleges;
            this.view.FacultyGetItems += model.GetFacultiesInCollege;
            this.view.SpecializationsGetItems += model.GetSpecializationsOnFaculty;
            this.view.SubjectGetItems += model.GetSubjectsFromSpecialization;
            this.view.MaterialGetItems += model.GetMaterialsFromSubject;
            this.view.SaveToFile += model.SaveToFile;
        }
    }
}
