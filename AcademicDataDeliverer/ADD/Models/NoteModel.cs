using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ADD.Models.Session;
namespace ADD.Models
{
    public class NoteModel : INoteModel
    {
        private ISession session;
        public NoteModel(ISession session)
        {
            this.session = session;
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

        public ICollection<Material> GetMaterialsFromSubject(string subjectName)
        {
            try
            {
                var subject = SubjectsRepository.GetList().Where(x => x.Name == subjectName).First();
                return MaterialsRepository.GetList(subject);
            }
            catch(Exception)
            {
                return new List<Material>();
            }
        }

        public ICollection<Specialization> GetSpecializationsOnFaculty(string facultyName)
        {
            try
            {
                var faculty = FacultiesRepository.GetList().Where(x => x.Name == facultyName).First();
                var userspec = UsersSpecializationsRepository.GetDetailsByID(session.User.Id);
                // Console.WriteLine(string.Format("Spec ID: {0}",userspec.Specialization_Id));
                var userType = UsersRepository.GetDetailsByID(userspec.User_Id).AccountType;
                // Console.WriteLine(string.Format("User {0} {1}", UsersRepository.GetDetailsByID(userspec.User_Id).FirstName, userType));
                if (userType == 0)
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
            catch(Exception)
            {
                return new List<Subject>();
            }
        }
    }
}
