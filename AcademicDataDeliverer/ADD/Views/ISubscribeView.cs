using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ADD.Views
{
    public interface ISubscribeView
    {
        event Func<ICollection<College>> CollegeComboBoxDropDown;
        event Func<College, ICollection<Faculty>> FacultyComboBoxDropDown;
        event Func<Faculty, ICollection<Specialization>> SpecializationComboBoxDropDown;

        event Func<User, Specialization, bool> SubscribeClick;
    }
}
