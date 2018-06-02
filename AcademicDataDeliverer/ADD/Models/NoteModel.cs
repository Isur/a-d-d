using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL;
using ADD.Models.Session;
using System.Windows.Forms;

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
            try
            {
                return CollegesRepository.GetList();
            }
            catch (Exception)
            {
                return new List<College>();
            }
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
                if (session.User.AccountType == 0)
                {
                    var resultSpecializations = new List<Specialization>();
                    var userSpecializations = UsersSpecializationsRepository.GetList().Where(x => x.User_Id == session.User.Id);
                    var specializations = SpecializationsRepository.GetList(faculty);

                    foreach (var userSpec in userSpecializations)
                    {
                        resultSpecializations.AddRange(specializations.Where(x => x.Id == userSpec.Specialization_Id));
                    }

                    return resultSpecializations;
                }
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

        public bool SaveToFile(string location, string content)
        {
            try
            {
                File.WriteAllText(location, content);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
