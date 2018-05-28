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

namespace ADD
{
    public partial class MainForm : Form, IViewChanger
    {
        UserControl activeControl;
        // Obiekt ten przechowuje zalogowanego użytkownika
        // Modele na podstawie tego obiektu będą wiedziały np czyje notatki wyświetlać
        ISession session = new Session();

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
        #endregion

        #region Eventy z foremki
        /* Przy wczytaniu zaczynamy od okienka logowania */
        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowLoginView();
        }

        /* Przy zmianie rozmiaru okna, będzie zawsze wyśrodkowany UserControl */
        private void MainForm_Resize(object sender, EventArgs e)
        {
            activeControl.Left = (this.Width - activeControl.Width) / 2;
            activeControl.Top = (this.Height - activeControl.Height) / 2;
        }
        #endregion
   
        public void ShowLoginView()
        {
            var view = new LoginControl(this);
            var model = new LoginModel(session);
            var presenter = new LoginPresenter(model, view);

            showView(view);
            centerActualView();
        }

        public void ShowNoteView()
        {
            var view = new NoteControl();
            var model = new NoteModel();
            var presenter = new NotePresenter(model, view);

            showView(view);
            centerActualView();
        }

        public void ShowProfileView()
        {
            throw new NotImplementedException();
        }

        public void ShowRegisterView()
        {
            throw new NotImplementedException();
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
        
