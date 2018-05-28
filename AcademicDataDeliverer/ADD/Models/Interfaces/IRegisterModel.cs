using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Models
{
    public interface IRegisterModel
    {
        ICollection<College> GetColleges();
        ICollection<Faculty> GetFacultiesInCollege(string collegeName);
        ICollection<Specialization> GetSpecializationsOnFaculty(string facultyName);

        bool RegisterNewUser(User newUser, string specializationName);
    }
}
