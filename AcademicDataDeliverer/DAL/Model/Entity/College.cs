using System;
using System.Data;

namespace DAL
{
    public class College
    {
        #region Constructor
        public College() { }

        public College(string name)
        {
            this.Name = name;
        }

        public static College Parse(IDataReader objReader)
        {
            College objcollegesData = new College();

            objcollegesData.Id = (int)(DBNull.Value.Equals(objReader["Id"]) ? 0 : objReader["Id"]);
            objcollegesData.Name = (string)(DBNull.Value.Equals(objReader["Name"]) ? string.Empty : objReader["Name"]);
            return objcollegesData;
        }
        #endregion

        #region Properties

        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        #endregion

        #region Lookup Objects

        #endregion

        #region Child Objects

        #endregion
    }
}