using System;
using System.Data;

namespace DAL
{
    public class User
    {
        #region Constructor
        public User() { }

        public User(string firstname, string lastname, string phonenumber, string mailaddress, string login, string password, int accounttype)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.PhoneNumber = phonenumber;
            this.MailAddress = mailaddress;
            this.Login = login;
            this.Password = password;
            this.AccountType = accounttype;
        }

        public static User Parse(IDataReader objReader)
        {
            User objusersData = new User();

            objusersData.Id = (int)(DBNull.Value.Equals(objReader["Id"]) ? 0 : objReader["Id"]);
            objusersData.FirstName = (string)(DBNull.Value.Equals(objReader["FirstName"]) ? string.Empty : objReader["FirstName"]);
            objusersData.LastName = (string)(DBNull.Value.Equals(objReader["LastName"]) ? string.Empty : objReader["LastName"]);
            objusersData.PhoneNumber = (string)(DBNull.Value.Equals(objReader["PhoneNumber"]) ? string.Empty : objReader["PhoneNumber"]);
            objusersData.MailAddress = (string)(DBNull.Value.Equals(objReader["MailAddress"]) ? string.Empty : objReader["MailAddress"]);
            objusersData.Login = (string)(DBNull.Value.Equals(objReader["Login"]) ? string.Empty : objReader["Login"]);
            objusersData.Password = (string)(DBNull.Value.Equals(objReader["Password"]) ? string.Empty : objReader["Password"]);
            objusersData.AccountType = (int)(DBNull.Value.Equals(objReader["AccountType"]) ? 0 : objReader["AccountType"]);
            return objusersData;
        }
        #endregion

        #region Properties

        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string MailAddress { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int AccountType { get; set; } = 0;
        #endregion

        #region Lookup Objects

        #endregion

        #region Child Objects

        #endregion
    }
}