using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ADD.Models
{
    class SubscribeModel : ISubscribeModel
    {
        public ICollection<College> GetColleges()
        {
            return CollegesRepository.GetList();
        }

        public ICollection<Faculty> GetFacultiesInCollege(College college)
        {
            try
            {
                return FacultiesRepository.GetList(college);
            }
            catch (Exception)
            {
                return new List<Faculty>();
            }
        }

        public ICollection<Specialization> GetSpecializationsOnFaculty(Faculty faculty)
        {
            try
            {
                return SpecializationsRepository.GetList(faculty);
            }
            catch (Exception)
            {
                return new List<Specialization>();
            }
        }

        public bool Subscribe(User user, Specialization specialization)
        {
            try
            {
                var userSpecialization = new UserSpecialization(user.Id, specialization.Id);
                UsersSpecializationsRepository.Add(userSpecialization);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
