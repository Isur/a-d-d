using System;
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

namespace ADD.UserConrols
{
    public partial class RegisterControl : UserControl, IRegisterView
    {
        #region FIELDS & PROPERTIES
        IViewChanger viewChanger;
        #endregion
        #region CONSTRUCTOR
        public RegisterControl(IViewChanger viewChanger)
        {
            InitializeComponent();
            this.viewChanger = viewChanger;
        }

        #endregion
        #region INTERFACE
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
            get { return comboBoxSpecialization.SelectedItem.ToString(); }
        }

        public string Surname
        {
            get { return textBoxLastName.Text; }
        }

        public string CollegeName
        {
            get { return comboBoxCollege.SelectedItem.ToString(); }
        }

        public string Email
        {
            get { return textBoxMail.Text; }
        }

        public string FacultyName
        {
            get { return comboBoxFaculty.SelectedItem.ToString(); }
        }

        public event Func<ICollection<College>> CollegeComboBoxDropDown;
        public event Func<string, ICollection<Faculty>> FacultyComboBoxDropDown;
        public event Func<string, ICollection<Specialization>> SpecializationComboBoxDropDown;
        public event Func<User, string, bool> RegisterClick;

        #endregion

        #region PUBLIC

        #endregion

        #region PRIVATE

        #endregion

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
                comboBoxCollege.Items.Add(college.Name);
            }
        }

        private async void comboBoxFaculty_DropDown(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            var collegeName = CollegeName;
            var task = new Task<ICollection<Faculty>>(() => {
                return FacultyComboBoxDropDown.Invoke(collegeName);
            });
            task.Start();

            var faculties = await task;
            progressBar.Visible = false;

            comboBoxFaculty.Items.Clear();
            foreach (var faculty in faculties)
            {
                comboBoxFaculty.Items.Add(faculty.Name);
            }
        }

        private async void comboBoxSpecialization_DropDown(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            var facultyName = FacultyName;
            var task = new Task<ICollection<Specialization>>(() => {
                return SpecializationComboBoxDropDown.Invoke(facultyName);
            });
            task.Start();

            var specializations = await task;
            progressBar.Visible = false;

            comboBoxSpecialization.Items.Clear();
            foreach (var specialization in specializations)
            {
                comboBoxSpecialization.Items.Add(specialization.Name);
            }
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;

            var specializationName = SpecializationName;
            var userToCreate = new User(FirstName, Surname, PhoneNumber, Email, Login, Password, 0);
            var task = new Task<bool>(() =>
            { 
                return RegisterClick.Invoke(userToCreate, specializationName);
            });
            task.Start();

            var registerResult = await task;

            progressBar.Visible = false;

            if(registerResult)
            {
                viewChanger.ShowLoginView();
            }
            else
            {
                //TODO: obsługa błędów (może model powinien zwracać coś więcej niż bool, żeby się dało identyfikować problem...)
            }
        }
    }
}
