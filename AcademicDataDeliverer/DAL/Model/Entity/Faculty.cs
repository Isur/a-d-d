using System;
using System.Data;

namespace DAL
{
    public class Faculty
    {
        #region Constructor
        public Faculty() { }

        public Faculty(string name, int college_id)
        {
            this.Name = name;
            this.College_Id = college_id;
        }

        public static Faculty Parse(IDataReader objReader)
        {
            Faculty objfacultiesData = new Faculty();

            objfacultiesData.Id = (int)(DBNull.Value.Equals(objReader["Id"]) ? 0 : objReader["Id"]);
            objfacultiesData.Name = (string)(DBNull.Value.Equals(objReader["Name"]) ? string.Empty : objReader["Name"]);
            objfacultiesData.College_Id = (int)(DBNull.Value.Equals(objReader["College_Id"]) ? 0 : objReader["College_Id"]);
            return objfacultiesData;
        }
        #endregion

        #region Properties

        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int College_Id { get; set; } = 0;
        #endregion

        #region Lookup Objects

        #endregion

        #region Child Objects

        #endregion
    }
}