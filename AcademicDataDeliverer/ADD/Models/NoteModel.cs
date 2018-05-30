using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ADD.Models
{
    public class NoteModel : INoteModel
    {
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
                return SpecializationsRepository.GetList(faculty);
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
