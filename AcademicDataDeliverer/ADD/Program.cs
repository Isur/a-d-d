using DAL;
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

            // Nie rozumiem co tutaj robią te wszystkie rzeczy skoro są lokalne i nic nie robią poza zajmowaniem pamięci o.O
            //var modelLogin = new Models.LoginModel();
            //var modelRegister = new Models.RegisterModel();
            //var modelNote = new Models.NoteModel();
            //var modelProfile = new Models.ProfileModel();

            //var viewLogin = new UserConrols.LoginControl();
            //var viewRegister = new UserConrols.RegisterControl();
            //var viewNote = new UserConrols.NoteControl();
            //var viewProfile = new UserConrols.ProfileControl();

            //var presenterLogin = new Presenters.LoginPresenter(modelLogin, viewLogin);
            //var presenterRegister = new Presenters.RegisterPresenter(modelRegister, viewRegister);
            //var presenterNote = new Presenters.NotePresenter(modelNote, viewNote);
            //var presenterProfile = new Presenters.ProfilePresenter(modelProfile, viewProfile);

            var formMain = new MainForm();


            Application.Run(formMain);
        }
    }
}
