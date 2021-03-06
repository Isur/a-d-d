﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ADD.Models.Utils.Encrypters;
using ADD.Models.Results;

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
            try
            {
                return CollegesRepository.GetList();
            }
            catch (Exception)
            {
                return new List<College>();
            }
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

        public Result RegisterNewUser(User newUser, Specialization specialization)
        {
            try
            {
                return register(newUser, specialization);
            }
            catch(Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        private Result register(User newUser, Specialization specialization)
        {
            if(loginAlreadyExists(newUser.Login))
            {
                return new Result(false, Properties.Resources.LoginIsAlreadyTaken);
            }
            if (mailAlreadyExists(newUser.MailAddress))
            {
                return new Result(false, Properties.Resources.MailIsAlreadyTaken);
            }

            var user = newUser;
            user.Password = encrypter.Encrypt(user.Password);

            // Muszę zapisać użytkownika do bazy, a potem go pobrać, żeby miał przydzielony przez bazę ID
            UsersRepository.Add(user);
            user = UsersRepository.GetList().Where(x => x.Login == user.Login && x.Password == user.Password).First();

            var userSpecialization = new UserSpecialization(user.Id, specialization.Id);
            UsersSpecializationsRepository.Add(userSpecialization);

            return new Result(true);
        }

        private bool loginAlreadyExists(string login)
        {
            var users = UsersRepository.GetList().Where(x => x.Login == login);
            return users.Count() > 0;
        }

        private bool mailAlreadyExists(string mail)
        {
            var users = UsersRepository.GetList().Where(x => x.MailAddress == mail);
            return users.Count() > 0;
        }
    }
}
