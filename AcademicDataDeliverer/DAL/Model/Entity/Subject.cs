using System;
using System.Data;

namespace DAL
{
    public class Subject
    {
        #region Constructor
        public Subject() { }

        public Subject(string name, int semester, int lecturer_id, int specialization_id)
        {
            this.Name = name;
            this.Semester = semester;
            this.Lecturer_Id = lecturer_id;
            this.Specialization_Id = specialization_id;
        }

        public static Subject Parse(IDataReader objReader)
        {
            Subject objsubjectsData = new Subject();

            objsubjectsData.Id = (int)(DBNull.Value.Equals(objReader["Id"]) ? 0 : objReader["Id"]);
            objsubjectsData.Name = (string)(DBNull.Value.Equals(objReader["Name"]) ? string.Empty : objReader["Name"]);
            objsubjectsData.Semester = (int)(DBNull.Value.Equals(objReader["Semester"]) ? 0 : objReader["Semester"]);
            objsubjectsData.Lecturer_Id = (int)(DBNull.Value.Equals(objReader["Lecturer_Id"]) ? 0 : objReader["Lecturer_Id"]);
            objsubjectsData.Specialization_Id = (int)(DBNull.Value.Equals(objReader["Specialization_Id"]) ? 0 : objReader["Specialization_Id"]);
            return objsubjectsData;
        }
        #endregion

        #region Properties

        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public int Semester { get; set; } = 0;
        public int Lecturer_Id { get; set; } = 0;
        public int Specialization_Id { get; set; } = 0;
        #endregion

        #region Lookup Objects

        #endregion

        #region Child Objects

        #endregion
    }
}