#region Using Statements	
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
#endregion

namespace DAL
{
    /// <summary>
    /// Summary description for userspecializations.
    /// </summary>
    public class UsersSpecializationsRepository
    {
        private static string connectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["defaultDatabase"].ConnectionString;
            }
        }

        #region Constants
        private const string SP_GET_ALL = "SELECT  `User_Id`, `Specialization_Id` FROM userspecializations";
        private const string SP_GET_FILTER = "SELECT  `User_Id`, `Specialization_Id` FROM userspecializations {0}";
        private const string SP_GET_BYPAGE = "SELECT * FROM userspecializations {1} ORDER BY {0} LIMIT {2}, {3}; SELECT COUNT(*) FROM userspecializations {1};";
        private const string SP_GET_BYID = "SELECT  `User_Id`, `Specialization_Id` FROM userspecializations WHERE User_Id = @ref_id";
        private const string SP_ADD = "INSERT INTO userspecializations ( User_Id, Specialization_Id) VALUES ( @User_Id, @Specialization_Id) ";
        private const string SP_ADD1 = "INSERT INTO userspecializations ( User_Id, Specialization_Id) VALUES ( @User_Id, @Specialization_Id) SELECT @User_Id = @@IDENTITY";
        private const string SP_UPDATE = "UPDATE userspecializations SET Specialization_Id = @Specialization_Id WHERE User_Id = @User_Id";
        private const string SP_DELETE = "DELETE FROM userspecializations WHERE User_Id=@ref_id";
        private const string SP_DELETE_FILTER = "DELETE FROM userspecializations {0}";
        private const string SP_GET_LOOKUP = "SELECT User_Id, User_Id FROM userspecializations";
        #endregion

        #region userspecializations - Constructor
        private UsersSpecializationsRepository()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region userspecializations - List userspecializations
        /// <summary>
        /// The purpose of this method is to get all userspecializations data.
        /// </summary>
        /// <returns>DataSet object</returns>
        public static DataSet GetData()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        using (MySqlCommand cmd = new MySqlCommand(SP_GET_ALL, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            DataSet ds = new DataSet();

                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion

        #region userspecializations - List userspecializations by Filter Expression
        /// <summary>
        /// The purpose of this method is to get all userspecializations data based on the Filter Expression criteria.
        /// </summary>
        /// <param name="filterExpression">A NameValueCollection object that defines various properties.
        /// For example, filterExpression - Where condition to be passed in SQL statement.
        /// </param>
        /// <returns>DataSet object</returns>
        public static DataSet GetData(string filterExpression)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        filterExpression = (string.IsNullOrEmpty(filterExpression) ? string.Empty : "WHERE " + filterExpression.Trim());
                        string strSQL = string.Format(SP_GET_FILTER, filterExpression);
                        using (MySqlCommand cmd = new MySqlCommand(strSQL, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            DataSet ds = new DataSet();
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion

        #region userspecializations - List userspecializations by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all userspecializations data based on filterExpression, sortExpression, pageIndex and pageSize parameters
        /// </summary>
        /// <param name="filterExpression">Where condition to be passed in SQL statement. DO NOT include WHERE keyword.</param>
        /// <param name="sortExpression">Sort column name with direction. For Example, "ProductID ASC")</param>
        /// <param name="pageIndex">Page number to be retrieved. Default is 0.</param>
        /// <param name="pageSize">Number of rows to be retrived. Default is 10.</param>
        /// <param name="rowsCount">Output: Total number of rows exist for the specified criteria.</param>
        /// <returns>DataSet object</returns>
        public static DataSet GetData(string filterExpression, string sortExpression, int pageIndex, int pageSize, out int rowsCount)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        filterExpression = (string.IsNullOrEmpty(filterExpression) ? string.Empty : "WHERE " + filterExpression.Trim());
                        int lbound = ((pageIndex - 1) * pageSize);
                        string strSQL = string.Format(SP_GET_BYPAGE, sortExpression, filterExpression, lbound, pageSize);
                        using (MySqlCommand cmd = new MySqlCommand(strSQL, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            DataSet ds = new DataSet();
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            rowsCount = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
                            return ds;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion

        #region userspecializations - Get Details for an userspecializations record
        /// <summary>
        /// The purpose of this method is to get the data based on specified primary key value
        /// </summary>
        /// <param name="sRefID">Primary key value</param>
        /// <returns></returns>
        public static DataSet GetDetails(string sRefID)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        string strSQL = string.Format(SP_GET_BYID, sRefID);
                        using (MySqlCommand cmd = new MySqlCommand(strSQL, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@ref_id", sRefID);
                            DataSet ds = new DataSet();
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion

        #region userspecializations - Get Lookup Data
        /// <summary>
        /// The purpose of this method is to get the lookup data
        /// </summary>
        /// <returns>returns Lookup Data as DataSet</returns>
        public static DataSet GetLookup()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        using (MySqlCommand cmd = new MySqlCommand(SP_GET_LOOKUP, cn))
                        {
                            cmd.CommandType = CommandType.Text;
                            DataSet ds = new DataSet();

                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion


        #region userspecializations - Add Record
        /// <summary>
        /// Creates a new userspecializations row.
        /// </summary>
        public static int Add(int User_Id, int Specialization_Id)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_ADD, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@User_Id", User_Id);
                        cmd.Parameters.AddWithValue("@Specialization_Id", Specialization_Id);
                        cn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return (int)cmd.Parameters["@User_Id"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion

        #region userspecializations - Update Record
        /// <summary>
        /// Updates a userspecializations
        /// </summary>
        public static bool Update(int User_Id, int Specialization_Id)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_UPDATE, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@User_Id", User_Id);
                        cmd.Parameters.AddWithValue("@Specialization_Id", Specialization_Id);
                        cn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return (rowsAffected == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion

        #region userspecializations - Delete Record
        /// <summary>
        /// The purpose of this method is to delete the record based on specified primary key value
        /// </summary>
        /// <param name="sRefID">Primary key value</param>
        /// <returns></returns>
        public static bool Delete(string sRefID)
        {
            try
            {
                bool bDeleted = false;
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_DELETE, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        //cmd.Parameters.Add("@User_Id", SqlDbType.int).Value = sRefID;
                        cmd.Parameters.AddWithValue("@ref_id", sRefID);
                        cn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        bDeleted = (rowsAffected == 1);
                    }
                }
                return bDeleted;
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion

        #region userspecializations - Delete Records
        /// <summary>
        /// The purpose of this method is to delete all userspecializations data based on the Filter Expression criteria.
        /// </summary>
        /// <param name="filterExpression">A NameValueCollection object that defines various properties.
        /// For example, filterExpression - Where condition to be passed in SQL statement.
        /// </param>
        /// <returns>Returns the number of rows deleted</returns>
        public static int DeleteFilter(string filterExpression)
        {
            try
            {
                int rowsAffected = 0;
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    filterExpression = (string.IsNullOrEmpty(filterExpression) ? string.Empty : "WHERE " + filterExpression.Trim());
                    string strSQL = string.Format(SP_DELETE_FILTER, filterExpression);
                    using (MySqlCommand cmd = new MySqlCommand(strSQL, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion

        #region userspecializations - Get List of userspecializationsData objects
        /// <summary>
        /// Returns a collection with all the userspecializationsData
        /// </summary>
        /// <returns>List of userspecializationsData object</returns>
        public static List<UserSpecialization> GetList()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_GET_ALL, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        IDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                        List<UserSpecialization> objList = new List<UserSpecialization>();
                        while (reader.Read())
                        {
                            //objList.Add(new userspecializationsData(
                            //	 (int) reader["User_Id"], (int) reader["Specialization_Id"]));
                            objList.Add(UserSpecialization.Parse(reader)); // Use this to avoid null issues
                        }
                        return objList;
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion


        #region userspecializations - List userspecializations by Filter Expression
        /// <summary>
        /// The purpose of this method is to get all userspecializations data based on the Filter Expression criteria.
        /// </summary>
        /// <param name="filterExpression">A NameValueCollection object that defines various properties.
        /// For example, filterExpression - Where condition to be passed in SQL statement.
        /// </param>
        /// <returns>List of userspecializationsData object</returns>
        public static List<UserSpecialization> GetList(string filterExpression)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    filterExpression = (string.IsNullOrEmpty(filterExpression) ? string.Empty : "WHERE " + filterExpression.Trim());
                    string strSQL = string.Format(SP_GET_FILTER, filterExpression);
                    using (MySqlCommand cmd = new MySqlCommand(strSQL, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        IDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                        List<UserSpecialization> objList = new List<UserSpecialization>();
                        while (reader.Read())
                        {
                            //objList.Add(new userspecializationsData(
                            //	 (int) reader["User_Id"], (int) reader["Specialization_Id"]));
                            objList.Add(UserSpecialization.Parse(reader)); // Use this to avoid null issues
                        }
                        return objList;
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion

        #region userspecializations - List userspecializations by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all userspecializations data based on filterExpression, sortExpression, pageIndex and pageSize parameters
        /// </summary>
        /// <param name="filterExpression">Where condition to be passed in SQL statement. DO NOT include WHERE keyword.</param>
        /// <param name="sortExpression">Sort column name with direction. For Example, "ProductID ASC")</param>
        /// <param name="pageIndex">Page number to be retrieved. Default is 0.</param>
        /// <param name="pageSize">Number of rows to be retrived. Default is 10.</param>
        /// <param name="rowsCount">Output: Total number of rows exist for the specified criteria.</param>
        /// <returns>List of userspecializationsData object</returns>
        public static List<UserSpecialization> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, out int rowsCount)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    filterExpression = (string.IsNullOrEmpty(filterExpression) ? string.Empty : "WHERE " + filterExpression.Trim());
                    int lbound = ((pageIndex - 1) * pageSize);
                    string strSQL = string.Format(SP_GET_BYPAGE, sortExpression, filterExpression, lbound, pageSize);
                    using (MySqlCommand cmd = new MySqlCommand(strSQL, cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cn.Open();
                        IDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                        List<UserSpecialization> objList = new List<UserSpecialization>();
                        while (reader.Read())
                        {
                            //objList.Add(new userspecializationsData(
                            //         (int) reader["User_Id"], (int) reader["Specialization_Id"]));
                            objList.Add(UserSpecialization.Parse(reader)); // Use this to avoid null issues
                        }
                        reader.NextResult();
                        reader.Read();
                        rowsCount = Convert.ToInt32(reader[0]);
                        reader.Close();

                        return objList;
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion


        #region userspecializations - Get Details by ID
        /// <summary>
        /// Returns an existing userspecializationsData object with the specified ID 
        /// </summary>
        public static UserSpecialization GetDetailsByID(int sRefID)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(SP_GET_BYID, cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ref_id", sRefID);
                    cn.Open();

                    IDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.Read())
                    {
                        // return new userspecializationsData(
                        //	 (int) reader["User_Id"], (int) reader["Specialization_Id"]);
                        return UserSpecialization.Parse(reader); // Use this to avoid null issues
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion

        #region userspecializations - Add Record
        /// <summary>
        /// Creates a new userspecializations
        /// </summary>
        public static int Add(UserSpecialization objuserspecializations)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_ADD, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@User_Id", objuserspecializations.User_Id);
                        cmd.Parameters.AddWithValue("@Specialization_Id", objuserspecializations.Specialization_Id);
                        cn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return (int)cmd.Parameters["@User_Id"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion

        #region userspecializations - Update Record
        /// <summary>
        /// Updates a userspecializations
        /// </summary>
        public static bool Update(UserSpecialization objuserspecializations)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_UPDATE, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@User_Id", objuserspecializations.User_Id);
                        cmd.Parameters.AddWithValue("@Specialization_Id", objuserspecializations.Specialization_Id);
                        cn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return (rowsAffected == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                // Put your code for Execption Handling here
                // 1. Log the error
                // 2. Handle or Throw Exception
                // This is my code...Customized!!!!
                // Note: You may modify code generation template by editing ExceptionHandler CodeBlock
                throw ex;
            }
        }
        #endregion
    }
}
