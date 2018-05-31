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

namespace ADD.UserConrols
{
    public partial class ProfileControl : UserControl, Views.IProfileView
    {

        #region FIELDS & PROPERTIES
        IViewChanger viewChanger;
        public string FirstName
        {
            get
            {
                return textBoxUserName.Text.Split(' ')[0];
            }
        }

        public string LastName
        {
            get
            {
                return textBoxUserName.Text.Split(' ')[1];
            }
        }

        public string Mail
        {
            get
            {
                return textBoxUserMail.Text;
            }
        }

        public string Phone
        {
            get
            {
                return textBoxUserPhone.Text;
            }
        }
        #endregion
        #region CONSTRUCTOR
        public ProfileControl(IViewChanger viewChanger)
        {
            InitializeComponent();
            this.viewChanger = viewChanger;
        }



        #endregion

        #region INTERFACE
        public event Func<ICollection<College>> CollegeGetItems;
        public event Func<string, ICollection<Faculty>> FacultyGetItems;
        public event Func<string, ICollection<Specialization>> SpecializationsGetItems;
        public event Func<string, ICollection<Subject>> SubjectGetItems;
        public event Func<Specialization, bool> AddSubscription;
        public event Func<Specialization, bool> DeleteSubscription;
        public event Func<User> GetUser;
        #endregion

        #region PUBLIC

        #endregion

        #region PRIVATE

        #endregion

        private async void ProfileControl_Load(object sender, EventArgs e)
        {
            loadingProgressBar.Visible = true;

            User user = GetUser();

            textBoxUserLogin.Text = user.Login;
            textBoxUserName.Text = user.FirstName + " " + user.LastName;
            textBoxUserPhone.Text = user.PhoneNumber;
            textBoxUserMail.Text = user.MailAddress;
            
            var task = new Task<ICollection<College>>(() =>
            {
                return CollegeGetItems.Invoke();
            });
            task.Start();

            var colleges = await task;

            foreach (var college in colleges)
            {
                TreeNode nodeCollege = treeViewSubscribed.Nodes.Add(college.Name);
                var taskFac = new Task<ICollection<Faculty>>(() => { return FacultyGetItems.Invoke(college.Name); });
                taskFac.Start();

                var faculties = await taskFac;
                foreach (var faculty in faculties)
                {
                    TreeNode nodeFaculty = nodeCollege.Nodes.Add(faculty.Name);
                    var taskSpec = new Task<ICollection<Specialization>>(() => { return SpecializationsGetItems.Invoke(faculty.Name); });
                    taskSpec.Start();

                    var specializations = await taskSpec;
                    if (specializations.Count < 1)
                    {
                        treeViewSubscribed.Nodes.Remove(nodeFaculty);
                    }
                    foreach (var specialization in specializations)
                    {
                        TreeNode nodeSpecialization = nodeFaculty.Nodes.Add(specialization.Name);
                        var taskSubject = new Task<ICollection<Subject>>(() => { return SubjectGetItems.Invoke(specialization.Name); });
                        taskSubject.Start();

                        var subjects = await taskSubject;
                        foreach (var subject in subjects)
                        {
                            TreeNode nodeSubject = nodeSpecialization.Nodes.Add(subject.Name);
                        }
                    }
                }
            }



            loadingProgressBar.Visible = false;
        }

        private void buttonBackToNote_Click(object sender, EventArgs e)
        {
            viewChanger.ShowNoteView();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            viewChanger.ShowLoginView();
        }
    }
}
