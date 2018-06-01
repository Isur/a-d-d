using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace ADD.Models
{
    public interface ISubscribeModel
    {
        ICollection<College> GetColleges();
        ICollection<Faculty> GetFacultiesInCollege(College college);
        ICollection<Specialization> GetSpecializationsOnFaculty(Faculty faculty);

        bool Subscribe(User user, Specialization specialization);
    }
}
