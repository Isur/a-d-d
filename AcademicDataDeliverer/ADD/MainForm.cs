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
    public partial class MainForm : Form
    {
        UserControl activeControl;
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
            showLoginView();
            activeControl.Left = (this.Width - activeControl.Width)/2;
            activeControl.Top = (this.Height - activeControl.Height) / 2;
            this.Controls.Add(activeControl);
        }

        /* Przy zmianie rozmiaru okna, będzie zawsze wyśrodkowany UserControl */
        private void MainForm_Resize(object sender, EventArgs e)
        {
            activeControl.Left = (this.Width - activeControl.Width) / 2;
            activeControl.Top = (this.Height - activeControl.Height) / 2;
        }
        #endregion

        private void showLoginView()
        {
            var view = new LoginControl();
            var model = new LoginModel(session);
            var controller = new LoginPresenter(model, view);

            activeControl = view;
        }
    }
}
