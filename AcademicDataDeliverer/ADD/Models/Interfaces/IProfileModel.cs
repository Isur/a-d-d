using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace ADD.Models
{
    public interface IProfileModel
    {
        ICollection<College> GetColleges();
        ICollection<Faculty> GetFacultiesInCollege(string collegeName);
        ICollection<Specialization> GetSpecializationsOnFaculty(string facultyName);
        ICollection<Subject> GetSubjectsFromSpecialization(string specializationName);

        User GetUser();
        bool CancelSub(Specialization specialization);
    }
}
