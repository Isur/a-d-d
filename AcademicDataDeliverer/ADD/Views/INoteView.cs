using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace ADD.Views
{
    public interface INoteView
    {
        #region EVENTS
        event Func<ICollection<College>> CollegeGetItems;
        event Func<string, ICollection<Faculty>> FacultyGetItems;
        event Func<string, ICollection<Specialization>> SpecializationsGetItems;
        event Func<string, ICollection<Subject>> SubjectGetItems;
        event Func<string, ICollection<Material>> MaterialGetItems;
        #endregion
    }
}
