using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var model = new Models.Model();

            var viewLogin = new UserConrols.LoginControl();
            var viewRegister = new UserConrols.RegisterControl();
            var viewNote = new UserConrols.NoteControl();
            var viewProfile = new UserConrols.ProfileControl();
            var viewMain = new UserConrols.MainControl();

            var presenterLogin = new Presenters.LoginPresenter(model, viewLogin);
            var presenterRegister = new Presenters.RegisterPresenter(model, viewRegister);
            var presenterNote = new Presenters.NotePresenter(model, viewNote);
            var presenterProfile = new Presenters.ProfilePresenter(model, viewProfile);
            var presenterMain = new Presenters.MainPresenter(model, viewMain);

            var formMain = new MainForm();


            Application.Run(formMain);
        }
    }
}
