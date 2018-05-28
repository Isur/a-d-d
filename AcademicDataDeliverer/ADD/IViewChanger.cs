using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD
{
    public interface IViewChanger
    {
        void ShowLoginView();
        void ShowNoteView();
        void ShowProfileView();
        void ShowRegisterView();
    }
}
