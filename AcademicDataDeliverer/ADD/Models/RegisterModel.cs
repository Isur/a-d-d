using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ADD.Models.Utils.Encrypters;

namespace ADD.Models
{
    public class RegisterModel : IRegisterModel
    {
        IEncrypter encrypter;

        public RegisterModel()
        {
            this.encrypter = new SHA1Encrypter();
        }

        public RegisterModel(IEncrypter encrypter)
        {
            this.encrypter = encrypter;
        }

        public ICollection<College> GetColleges()
        {
            return CollegesRepository.GetList();
        }

        public ICollection<Faculty> GetFacultiesInCollege(string collegeName)
        {
            var college = CollegesRepository.GetList().Where(x => x.Name == collegeName).First();
            return FacultiesRepository.GetList(college);
        }

        public ICollection<Specialization> GetSpecializationsOnFaculty(string facultyName)
        {
            var faculty = FacultiesRepository.GetList().Where(x => x.Name == facultyName).First();
            return SpecializationsRepository.GetList(faculty);
        }

        public bool RegisterNewUser(User newUser, string specializationName)
        {
            var specialization = SpecializationsRepository.GetList().Where(x => x.Name == specializationName).First();
            var user = newUser;
            user.Password = encrypter.Encrypt(user.Password);

            // Muszę zapisać użytkownika do bazy, a potem go pobrać, żeby miał przydzielony przez bazę ID
            UsersRepository.Add(user);
            user = UsersRepository.GetList().Where(x => x.Login == user.Login && x.Password == user.Password).First();

            var userSpecialization = new UserSpecialization(user.Id, specialization.Id);
            UsersSpecializationsRepository.Add(userSpecialization);

            return true;
        }
    }
}
