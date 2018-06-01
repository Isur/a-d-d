using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using ADD.Views;
namespace ADD
{
    public partial class Subscribe : Form, Views.ISubscribeView
    {
        User user;
        IProfileView profile;
        public Subscribe(User user, IProfileView profile)
        {
            InitializeComponent();
            this.user = user;
            this.profile = profile;
        }
        #region INTERFACE
        public event Func<ICollection<College>> CollegeComboBoxDropDown;
        public event Func<College, ICollection<Faculty>> FacultyComboBoxDropDown;
        public event Func<Faculty, ICollection<Specialization>> SpecializationComboBoxDropDown;
        public event Func<User, Specialization, bool> SubscribeClick;
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

        private async void buttonSubscribe_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            var specialization = comboBoxSpecialization.SelectedItem as Specialization;
            var task = new Task<bool>(() =>
            {
                return SubscribeClick.Invoke(user, specialization);
            });
            task.Start();

            var subscribeResult = await task;

            progressBar.Visible = false;

            if (subscribeResult)
            {
                MessageBox.Show("Nowy kierunek zasubskrybowany!");
                profile.Reload();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nowy kierunek nie został zasubskrybowany!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
