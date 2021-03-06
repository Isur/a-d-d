﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADD.Views;
using DAL;
using System.Collections;
using System.Text.RegularExpressions;
using ADD.Models.Results;

namespace ADD.UserConrols
{
    public partial class RegisterControl : UserControl, IRegisterView
    {
        #region FIELDS & PROPERTIES
        IViewChanger viewChanger;

        bool _isLoginValid = false;
        bool _isPasswordValid = false;
        bool _isFirstNameValid = false;
        bool _isSurnameValid = false;
        bool _isPhoneNumberValid = false;
        bool _isEmailValid = false;
        bool _isCollegeNameValid = false;
        bool _isFacultyNameValid = false;
        bool _isSpecializationNameValid = false;
        #endregion
        #region CONSTRUCTOR
        public RegisterControl(IViewChanger viewChanger)
        {
            InitializeComponent();
            this.viewChanger = viewChanger;
        }

        #endregion
        #region INTERFACE
        #region VALUES
        public string FirstName
        {
            get { return textBoxFirstName.Text; }
        }
        public string Login
        {
            get { return textBoxLogin.Text; }
        }

        public string Password
        {
            get { return textBoxPassword.Text; }
        }

        public string PhoneNumber
        {
            get { return textBoxPhone.Text; }
        }

        public string SpecializationName
        {
            get { return comboBoxSpecialization.SelectedItem?.ToString(); }
        }

        public string Surname
        {
            get { return textBoxLastName.Text; }
        }

        public string CollegeName
        {
            get { return comboBoxCollege.SelectedItem?.ToString(); }
        }

        public string Email
        {
            get { return textBoxMail.Text; }
        }

        public string FacultyName
        {
            get { return comboBoxFaculty.SelectedItem?.ToString(); }
        }
        #endregion

        #region VALIDATION
        public bool IsLoginValid
        {
            get { return _isLoginValid; }
            private set
            {
                _isLoginValid = value;
                setControlValidationColor(textBoxLogin, value);
            }
        }

        public bool IsPasswordValid
        {
            get { return _isPasswordValid; }
            private set
            {
                _isPasswordValid = value;
                setControlValidationColor(textBoxPassword, value);
            }
        }

        public bool IsFirstNameValid
        {
            get { return _isFirstNameValid; }
            private set
            {
                _isFirstNameValid = value;
                setControlValidationColor(textBoxFirstName, value);
            }
        }

        public bool IsSurnameValid
        {
            get { return _isSurnameValid; }
            private set
            {
                _isSurnameValid = value;
                setControlValidationColor(textBoxLastName, value);
            }
        }

        public bool IsPhoneNumberValid
        {
            get { return _isPhoneNumberValid; }
            private set
            {
                _isPhoneNumberValid = value;
                setControlValidationColor(textBoxPhone, value);
            }
        }

        public bool IsEmailValid
        {
            get { return _isEmailValid; }
            private set
            {
                _isEmailValid = value;
                setControlValidationColor(textBoxMail, value);
            }
        }

        public bool IsCollegeNameValid
        {
            get { return _isCollegeNameValid; }
            private set
            {
                _isCollegeNameValid = value;
                setControlValidationColor(comboBoxCollege, value);
            }
        }

        public bool IsFacultyNameValid
        {
            get { return _isFacultyNameValid; }
            private set
            {
                _isFacultyNameValid = value;
                setControlValidationColor(comboBoxFaculty, value);
            }
        }

        public bool IsSpecializationNameValid
        {
            get { return _isSpecializationNameValid; }
            private set
            {
                _isSpecializationNameValid = value;
                setControlValidationColor(comboBoxSpecialization, value);
            }
        }
        #endregion

        #region EVENTS
        public event Func<ICollection<College>> CollegeComboBoxDropDown;
        public event Func<College, ICollection<Faculty>> FacultyComboBoxDropDown;
        public event Func<Faculty, ICollection<Specialization>> SpecializationComboBoxDropDown;
        public event Func<User, Specialization, Result> RegisterClick;
        #endregion
        public bool AreAllValuesValid()
        {
            return (IsLoginValid && IsPasswordValid && IsFirstNameValid && IsSurnameValid && IsPhoneNumberValid &&
                    IsEmailValid && IsCollegeNameValid && IsFacultyNameValid && IsSpecializationNameValid);
        }
        #endregion

        #region PRIVATE
        private void setControlValidationColor(Control control, bool isValid)
        {
            if (isValid)
                control.BackColor = Color.White;
            else
                control.BackColor = Color.Red;
        }

        private async void register()
        {
            progressBar.Visible = true;

            var specialization = comboBoxSpecialization.SelectedItem as Specialization;
            var userToCreate = new User(FirstName, Surname, PhoneNumber, Email, Login, Password, 0);
            var task = new Task<Result>(() =>
            {
                return RegisterClick.Invoke(userToCreate, specialization);
            });
            task.Start();

            var registerResult = await task;

            progressBar.Visible = false;

            if (!registerResult.Success)
            {
                MessageBox.Show(registerResult.ErrorMessage);
            }
            else
            {
                MessageBox.Show(Properties.Resources.RegisterSuccess);
                viewChanger.ShowLoginView();
            }
        }
        #endregion

        #region DROP_DOWN_EVENTS
        private async void comboBoxCollege_DropDown(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            var task = new Task<ICollection<College>>(() => {
                return CollegeComboBoxDropDown.Invoke();
            });
            task.Start();

            var colleges = await task;
            progressBar.Visible = false;

            comboBoxCollege.Items.Clear();
            foreach (var college in colleges)
            {
                comboBoxCollege.Items.Add(college);
            }
        }

        private async void comboBoxFaculty_DropDown(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            var college = comboBoxCollege.SelectedItem as College;
            var task = new Task<ICollection<Faculty>>(() => {
                return FacultyComboBoxDropDown.Invoke(college);
            });
            task.Start();

            var faculties = await task;
            progressBar.Visible = false;

            comboBoxFaculty.Items.Clear();
            foreach (var faculty in faculties)
            {
                comboBoxFaculty.Items.Add(faculty);
            }
        }

        private async void comboBoxSpecialization_DropDown(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            var faculty = comboBoxFaculty.SelectedItem as Faculty;
            var task = new Task<ICollection<Specialization>>(() => {
                return SpecializationComboBoxDropDown.Invoke(faculty);
            });
            task.Start();

            var specializations = await task;
            progressBar.Visible = false;

            comboBoxSpecialization.Items.Clear();
            foreach (var specialization in specializations)
            {
                comboBoxSpecialization.Items.Add(specialization);
            }
        }
        #endregion
        #region CLICK_EVENTS
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (AreAllValuesValid())
            {
                register();
            }
            else
            {
                MessageBox.Show(Properties.Resources.RegisterNotAllValuesAreValid);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            viewChanger.ShowLoginView();
        }
        #endregion
        #region ON_CHANGE_EVENTS
        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            var content = textBoxLogin.Text;
            var valid = content != string.Empty;
            IsLoginValid = valid;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            var content = textBoxPassword.Text;
            var valid = content != string.Empty;
            IsPasswordValid = valid;
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            var content = textBoxFirstName.Text;
            var valid = content != string.Empty && Regex.Match(content, "^[A-Z][a-z]*$").Success;
            IsFirstNameValid = valid;
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            var content = textBoxLastName.Text;
            var valid = content != string.Empty && Regex.Match(content, "^[A-Z][a-z]*$").Success;
            IsSurnameValid = valid;
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
            var content = textBoxPhone.Text;
            var valid = content.Length == 9 && Regex.Match(content, "^[0-9]*$").Success;
            IsPhoneNumberValid = valid;
        }

        private void textBoxMail_TextChanged(object sender, EventArgs e)
        {
            var content = textBoxMail.Text;
            bool valid;
            try
            {
                var addr = new System.Net.Mail.MailAddress(content);
                valid = addr.Address == content;
            }
            catch(Exception)
            {
                valid = false;
            }
            
            IsEmailValid = valid;
        }

        private void comboBoxCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = comboBoxCollege.SelectedItem;
            var content = selectedItem != null ? selectedItem.ToString() : string.Empty;
            var valid = content != string.Empty;
            IsCollegeNameValid = valid;
            comboBoxFaculty.SelectedItem = null;
            comboBoxSpecialization.SelectedItem = null;
        }

        private void comboBoxFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = comboBoxFaculty.SelectedItem;
            var content = selectedItem != null ? selectedItem.ToString() : string.Empty;
            var valid = content != string.Empty;
            IsFacultyNameValid = valid;
            comboBoxSpecialization.SelectedItem = null;
        }

        private void comboBoxSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = comboBoxSpecialization.SelectedItem;
            var content = selectedItem != null ? selectedItem.ToString() : string.Empty;
            var valid = content != string.Empty;
            IsSpecializationNameValid = valid;
        }
        #endregion       
    }
}
