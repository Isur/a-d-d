using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Views
{
    public interface IRegisterView
    {
        string Login { get; }
        string Password { get; }
        string FirstName { get; }
        string Surname { get; }
        string PhoneNumber { get; }
        string Email { get; }
        string CollegeName { get; }
        string FacultyName { get; }
        string SpecializationName { get; }

        event Func<ICollection<College>> CollegeComboBoxDropDown;
        event Func<string, ICollection<Faculty>> FacultyComboBoxDropDown;
        event Func<string, ICollection<Specialization>> SpecializationComboBoxDropDown;

        event Func<User, string, bool> RegisterClick;
    }
}
