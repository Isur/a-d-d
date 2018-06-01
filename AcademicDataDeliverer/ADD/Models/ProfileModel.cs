using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ADD.Models.Session;
namespace ADD.Models
{
    public class ProfileModel : IProfileModel
    {
        private ISession session;
        public ProfileModel(ISession session)
        {
            this.session = session;
        }

        public bool CancelSub(Specialization specialization)
        {
            try
            {
                UsersSpecializationsRepository.DeleteFilter(string.Format("User_id = {0} AND Specialization_Id = {1}", session.User.Id, specialization.Id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ICollection<College> GetColleges()
        {
            return CollegesRepository.GetList();
        }

        public ICollection<Faculty> GetFacultiesInCollege(string collegeName)
        {
            try
            {
                var college = CollegesRepository.GetList().Where(x => x.Name == collegeName).First();
                return FacultiesRepository.GetList(college);
            }
            catch (Exception)
            {
                return new List<Faculty>();
            }
        }

        public ICollection<Specialization> GetSpecializationsOnFaculty(string facultyName)
        {
            try
            {
                var faculty = FacultiesRepository.GetList().Where(x => x.Name == facultyName).First();
                var userspec = UsersSpecializationsRepository.GetDetailsByID(session.User.Id);
                if (session.User.AccountType == 0)
                    return SpecializationsRepository.GetList(faculty).Where(x => x.Id == userspec.Specialization_Id).ToList();
                else return SpecializationsRepository.GetList(faculty);
            }
            catch (Exception)
            {
                return new List<Specialization>();
            }
        }

        public ICollection<Subject> GetSubjectsFromSpecialization(string specializationName)
        {
            try
            {
                var specialization = SpecializationsRepository.GetList().Where(x => x.Name == specializationName).First();
                return SubjectsRepository.GetList(specialization);

            }
            catch (Exception)
            {
                return new List<Subject>();
            }
        }

        public User GetUser()
        {
            return session.User;
        }
    }
}
