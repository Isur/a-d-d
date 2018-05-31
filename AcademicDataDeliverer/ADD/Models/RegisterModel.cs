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

        public ICollection<Faculty> GetFacultiesInCollege(College college)
        {
            try
            {
                return FacultiesRepository.GetList(college);
            }
            catch(Exception)
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
            catch(Exception)
            {
                return new List<Specialization>();
            }
        }

        public bool RegisterNewUser(User newUser, Specialization specialization)
        {
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
