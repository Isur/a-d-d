using System;
using System.Data;

namespace DAL
{
    public class Specialization
    {
        #region Constructor
        public Specialization() { }

        public Specialization(string name, int faculty_id)
        {
            this.Name = name;
            this.Faculty_Id = faculty_id;
        }

        public static Specialization Parse(IDataReader objReader)
        {
            Specialization objspecializationsData = new Specialization();

            objspecializationsData.Id = (int)(DBNull.Value.Equals(objReader["Id"]) ? 0 : objReader["Id"]);
            objspecializationsData.Name = (string)(DBNull.Value.Equals(objReader["Name"]) ? string.Empty : objReader["Name"]);
            objspecializationsData.Faculty_Id = (int)(DBNull.Value.Equals(objReader["Faculty_Id"]) ? 0 : objReader["Faculty_Id"]);
            return objspecializationsData;
        }
        #endregion

        #region Properties

        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int Faculty_Id { get; set; } = 0;
        #endregion

        #region Lookup Objects

        #endregion

        #region Child Objects

        #endregion
    }
}