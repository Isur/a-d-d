using ADD.Models.Results;
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
        ICollection<Faculty> GetFacultiesInCollege(College college);
        ICollection<Specialization> GetSpecializationsOnFaculty(Faculty faculty);

        Result RegisterNewUser(User newUser, Specialization specialization);
    }
}
