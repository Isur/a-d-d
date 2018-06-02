using ADD.Models.Results;
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
        #region FormControlsValue
        string Login { get; }
        string Password { get; }
        string FirstName { get; }
        string Surname { get; }
        string PhoneNumber { get; }
        string Email { get; }
        string CollegeName { get; }
        string FacultyName { get; }
        string SpecializationName { get; }
        #endregion

        #region FormValidation
        bool IsLoginValid { get; }
        bool IsPasswordValid { get; }
        bool IsFirstNameValid { get; }
        bool IsSurnameValid { get; }
        bool IsPhoneNumberValid { get; }
        bool IsEmailValid { get; }
        bool IsCollegeNameValid { get; }
        bool IsFacultyNameValid { get; }
        bool IsSpecializationNameValid { get; }

        bool AreAllValuesValid();
        #endregion

        #region Events
        event Func<ICollection<College>> CollegeComboBoxDropDown;
        event Func<College, ICollection<Faculty>> FacultyComboBoxDropDown;
        event Func<Faculty, ICollection<Specialization>> SpecializationComboBoxDropDown;

        event Func<User, Specialization, Result> RegisterClick;
        #endregion
    }
}
