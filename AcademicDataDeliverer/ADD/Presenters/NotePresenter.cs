using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Presenters
{
    public class NotePresenter
    {
        Models.NoteModel model;
        Views.INoteView view;
        public NotePresenter(Models.NoteModel model, Views.INoteView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}
