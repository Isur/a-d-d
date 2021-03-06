﻿using ADD.Models.Results;
using ADD.Models.Session;
using ADD.Models.Utils.Encrypters;
using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADD.Models
{
    public class LoginModel : ILoginModel
    {
        private IEncrypter encrypter;
        private ISession session;

        public LoginModel(ISession session)
        {
            encrypter = new SHA1Encrypter();
            this.session = session;
        }

        public LoginModel(ISession session, IEncrypter encrypter)
        {
            this.session = session;
            this.encrypter = encrypter;
        }

        public Result Login(string login, string password)
        {
            try
            {
                return logIn(login, password);
            }
            catch(Exception ex)
            {
                Logger.Warning(string.Format(Properties.Resources.FailedLoginAttempt, login));
                return new Result(false, ex.Message);
            }
        }

        private Result logIn(string login, string password)
        {
            var hashedPassword = encrypter.Encrypt(password);

            var userList = UsersRepository.GetList().Where(x => x.Login == login && x.Password == hashedPassword).ToList();
            var anyMatchingUsers = userList.Count > 0;

            if (!anyMatchingUsers)
            {
                Logger.Warning(string.Format(Properties.Resources.FailedLoginAttempt, login));
                return new Result(false, Properties.Resources.WrongLoginOrPassword);
            }

            session.User = userList.First();
            Logger.Info(string.Format(Properties.Resources.SuccessfulLoginAttempt, login));
            return new Result(true);
        }
    }
}
