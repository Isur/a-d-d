using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADD.UserConrols;
using ADD.Models;
using ADD.Presenters;
using ADD.Models.Session;
using ADD.Models.Utils.Encrypters;

namespace ADD
{
    public partial class MainForm : Form, IViewChanger
    {
        UserControl activeControl;
        // Obiekt ten przechowuje zalogowanego użytkownika
        // Modele na podstawie tego obiektu będą wiedziały np czyje notatki wyświetlać
        ISession session = new Session();
        IEncrypter encrypter = new SHA1Encrypter();

        public MainForm()
        {
            InitializeComponent();
        }


        #region PRIVATE
        /* Ukrywanie okienka przed wrzuceniem nowego. */
        private void clearWindow()
        {
            activeControl.Hide();
        }

        private void logout()
        {
            if (session.User != null)
                session.EndSession();
        }
        #endregion

        #region Eventy z foremki
        /* Przy wczytaniu zaczynamy od okienka logowania */
        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowLoginView();
            //ShowRegisterView();
        }

        /* Przy zmianie rozmiaru okna, będzie zawsze wyśrodkowany UserControl */
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if(activeControl != null)
            {
                activeControl.Left = (this.Width - activeControl.Width) / 2;
                activeControl.Top = (this.Height - activeControl.Height) / 2;
            }
        }
        #endregion
   
        public void ShowLoginView()
        {
            logout();
            var view = new LoginControl(this);
            var model = new LoginModel(session, encrypter);
            var presenter = new LoginPresenter(model, view);

            showView(view);
            centerActualView();
        }

        public void ShowNoteView()
        {
            var view = new NoteControl(this);
            var model = new NoteModel();
            var presenter = new NotePresenter(model, view);

            showView(view);
            centerActualView();
        }

        public void ShowProfileView()
        {
            var view = new ProfileControl();
            var model = new ProfileModel();
            var presenter = new ProfilePresenter(model, view);

            showView(view);
            centerActualView();
        }

        public void ShowRegisterView()
        {
            var view = new RegisterControl(this);
            var model = new RegisterModel(encrypter);
            var presenter = new RegisterPresenter(model, view);

            showView(view);
            centerActualView();
        }

        private void centerActualView()
        {
            activeControl.Left = (this.Width - activeControl.Width) / 2;
            activeControl.Top = (this.Height - activeControl.Height) / 2;
        }

        private void showView(UserControl view)
        {
            Controls.Remove(activeControl);
            activeControl = view;
            Controls.Add(activeControl);
        }
    }
}
        
