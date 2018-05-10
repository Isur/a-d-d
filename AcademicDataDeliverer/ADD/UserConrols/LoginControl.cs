using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADD.UserConrols
{
    public partial class LoginControl : UserControl, Views.ILoginView
    {

        #region FIELDS & PROPERTIES

        #endregion
        #region CONSTRUCTOR
        public LoginControl()
        {
            InitializeComponent();
        }               
        #endregion
        #region INTERFACE
        public string Login
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Password
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public event Func<string, string, bool> LoginClick;
        #endregion
        #region PUBLIC

        #endregion
        #region PRIVATE

        #endregion
    }
}
