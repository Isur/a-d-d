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
    public partial class RegisterControl : UserControl, Views.IRegisterView
    {
        #region FIELDS & PROPERTIES

        #endregion
        #region CONSTRUCTOR
        public RegisterControl()
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
        #endregion
        #region PUBLIC

        #endregion
        #region PRIVATE

        #endregion
    }
}
