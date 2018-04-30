using System;
using System.Data;

namespace DAL
{
    public class Material
    {
        #region Constructor
        public Material() { }

        public Material(string content, int subject_id)
        {
            this.Content = content;
            this.Subject_Id = subject_id;
        }

        public static Material Parse(IDataReader objReader)
        {
            Material objmaterialsData = new Material();

            objmaterialsData.Id = (int)(DBNull.Value.Equals(objReader["Id"]) ? 0 : objReader["Id"]);
            objmaterialsData.Content = (string)(DBNull.Value.Equals(objReader["Content"]) ? string.Empty : objReader["Content"]);
            objmaterialsData.Subject_Id = (int)(DBNull.Value.Equals(objReader["Subject_Id"]) ? 0 : objReader["Subject_Id"]);
            return objmaterialsData;
        }
        #endregion

        #region Properties

        public int Id { get; set; } = 0;
        public string Content { get; set; } = string.Empty;
        public int Subject_Id { get; set; } = 0;
        #endregion

        #region Lookup Objects

        #endregion

        #region Child Objects

        #endregion
    }
}