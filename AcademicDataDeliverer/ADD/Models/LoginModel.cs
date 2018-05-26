using ADD.Models.Utils.Encrypters;
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
        public string Login
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        private IEncrypter encrypter;

        public LoginModel()
        {
            encrypter = new SHA1Encrypter();
        }

        public LoginModel(IEncrypter encrypter)
        {
            this.encrypter = encrypter;
        }

        public bool Login(string login, string password)
        {
            var hashedPassword = encrypter.Encrypt(password);

            //TODO: dodać użytkownika do jakiejś sesji, żeby można było na nim wykonywać operacje później

            return UsersRepository.GetList().Where(x => x.Login == login && x.Password == hashedPassword).ToList().Count > 0;
        }
    }
}
