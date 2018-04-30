using System;
using System.Data;

namespace DAL
{
    public class UserSpecialization
    {
        #region Constructor
        public UserSpecialization() { }

        public UserSpecialization(int user_id, int specialization_id)
        {
            this.User_Id = user_id;
            this.Specialization_Id = specialization_id;
        }

        public static UserSpecialization Parse(IDataReader objReader)
        {
            UserSpecialization objuserspecializationsData = new UserSpecialization();

            objuserspecializationsData.User_Id = (int)(DBNull.Value.Equals(objReader["User_Id"]) ? 0 : objReader["User_Id"]);
            objuserspecializationsData.Specialization_Id = (int)(DBNull.Value.Equals(objReader["Specialization_Id"]) ? 0 : objReader["Specialization_Id"]);
            return objuserspecializationsData;
        }
        #endregion

        #region Properties

        public int User_Id { get; set; } = 0;
        public int Specialization_Id { get; set; } = 0;
        #endregion

        #region Lookup Objects

        #endregion

        #region Child Objects

        #endregion
    }
}