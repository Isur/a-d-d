using System;
using System.Data;

namespace DAL
{
    public class Lecturer
    {
        #region Constructor
        public Lecturer() { }

        public Lecturer(string name, string surname, string emailaddress)
        {
            this.Name = name;
            this.Surname = surname;
            this.EmailAddress = emailaddress;
        }

        public static Lecturer Parse(IDataReader objReader)
        {
            Lecturer objlecturersData = new Lecturer();

            objlecturersData.Id = (int)(DBNull.Value.Equals(objReader["Id"]) ? 0 : objReader["Id"]);
            objlecturersData.Name = (string)(DBNull.Value.Equals(objReader["Name"]) ? string.Empty : objReader["Name"]);
            objlecturersData.Surname = (string)(DBNull.Value.Equals(objReader["Surname"]) ? string.Empty : objReader["Surname"]);
            objlecturersData.EmailAddress = (string)(DBNull.Value.Equals(objReader["EmailAddress"]) ? string.Empty : objReader["EmailAddress"]);
            return objlecturersData;
        }
        #endregion

        #region Properties

        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        #endregion

        #region Lookup Objects

        #endregion

        #region Child Objects

        #endregion
    }
}