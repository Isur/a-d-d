using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Models.Session
{
    public class Session : ISession
    {
        public User User { get; set; }

        public Session()
        {
            User = null;
        }

        public Session(User user)
        {
            User = user;
        }

        public void EndSession()
        {
            User = null;
        }
    }
}
