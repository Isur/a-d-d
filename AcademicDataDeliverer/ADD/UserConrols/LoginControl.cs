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
            clearForm();
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
        private void Login_Click(object sender, EventArgs e)
        {
            login();
        }

        private async void login()
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

        private void onEnterClick(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                login();
            }
        }
        #endregion

        private void onFailedLoginAttempt(Result result)
        {
            textBoxLogin.BackColor = Color.Red;
            textBoxPassword.BackColor = Color.Red;

            clearForm();

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

        private void clearForm()
        {
            textBoxLogin.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            textBoxLogin.Focus();
        }

        private void LoginControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            onEnterClick(e);
        }

        private void textBoxLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            onEnterClick(e);
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            onEnterClick(e);
        }
    }
}
