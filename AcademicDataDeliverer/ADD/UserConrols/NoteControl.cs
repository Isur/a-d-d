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
    public partial class NoteControl : UserControl, Views.INoteView
    {
        #region FIELDS & PROPERTIES
        IViewChanger viewChanger;
        #endregion
        #region CONSTRUCTOR
        public NoteControl(IViewChanger viewChanger)
        {
            InitializeComponent();
            this.viewChanger = viewChanger;
        }
        #endregion

        #region INTERFACE

        #endregion

        #region PUBLIC

        #endregion

        #region PRIVATE

        #endregion

        private void wYLOGUJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewChanger.ShowLoginView();
           
        }

        private void NoteControl_Load(object sender, EventArgs e)
        {

        }
    }
}
