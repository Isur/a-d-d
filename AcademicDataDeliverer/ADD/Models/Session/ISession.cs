using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Models.Session
{
    public interface ISession
    {
        User User { get; set; }
        void EndSession();
    }
}
