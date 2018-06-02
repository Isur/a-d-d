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
using ADD.Models.Results;

namespace ADD.UserConrols
{
    public partial class LoginControl : UserControl, ILoginView
    {
        #region FIELDS & PROPERTIES
        private IViewChanger viewChanger;
        #endregion
        #region CONSTRUCTOR
        public LoginControl(IViewChanger viewChanger)
        {
            InitializeComponent();
            this.viewChanger = viewChanger;
        }               
        #endregion
        #region INTERFACE
        public string Login
        {
            get { return textBoxLogin.Text; }
        }

        public string Password
        {
            get { return textBoxPassword.Text; }
        }

        public event Func<string, string, Result> LoginClick;
        #endregion

        #region PUBLIC

        #endregion

        #region PRIVATE
        private async void Login_Click(object sender, EventArgs e)
        {
            loginProgressBar.Visible = true;

            var loginTask = new Task<Result>(() => 
            {
                return LoginClick.Invoke(Login, Password);
            });
            loginTask.Start();

            var loginResult = await loginTask;

            loginProgressBar.Visible = false;

            if (loginResult.Success)
            {
                onSuccessLoginAttempt();
            }
            else
            {
                onFailedLoginAttempt(loginResult);
            }
        }
        #endregion

        private void onFailedLoginAttempt(Result result)
        {
            textBoxLogin.BackColor = Color.Red;
            textBoxPassword.BackColor = Color.Red;

            MessageBox.Show(result.ErrorMessage);
        }

        private void onSuccessLoginAttempt()
        {
            viewChanger.ShowNoteView();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            viewChanger.ShowRegisterView();
        }
    }
}
