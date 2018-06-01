using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace ADD.Views
{
    public interface IProfileView
    {
        event Func<ICollection<College>> CollegeGetItems;
        event Func<string, ICollection<Faculty>> FacultyGetItems;
        event Func<string, ICollection<Specialization>> SpecializationsGetItems;
        event Func<string, ICollection<Subject>> SubjectGetItems;
        event Func<Specialization, bool> DeleteSubscription;
        event Func<User> GetUser;
        void Reload();
        string FirstName { get; }
        string LastName { get; }
        string Mail { get; }
        string Phone { get; }
    }
}
