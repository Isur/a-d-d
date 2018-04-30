#region Using Statements	
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
#endregion

namespace DAL
{
    /// <summary>
    /// Summary description for specializations.
    /// </summary>
    public class SpecializationsRepository
    {
        private static string connectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["defaultDatabase"].ConnectionString;
            }
        }

        #region Constants
        private const string SP_GET_ALL = "SELECT  `Id`, `Name`, `Faculty_Id` FROM specializations";
        private const string SP_GET_FILTER = "SELECT  `Id`, `Name`, `Faculty_Id` FROM specializations {0}";
        private const string SP_GET_BYPAGE = "SELECT * FROM specializations {1} ORDER BY {0} LIMIT {2}, {3}; SELECT COUNT(*) FROM specializations {1};";
        private const string SP_GET_BYID = "SELECT  `Id`, `Name`, `Faculty_Id` FROM specializations WHERE Id = @ref_id";
        private const string SP_ADD = "INSERT INTO specializations ( Id, Name, Faculty_Id) VALUES ( @Id, @Name, @Faculty_Id) ";
        private const string SP_ADD1 = "INSERT INTO specializations ( Id, Name, Faculty_Id) VALUES ( @Id, @Name, @Faculty_Id) SELECT @Id = @@IDENTITY";
        private const string SP_UPDATE = "UPDATE specializations SET Name = @Name, Faculty_Id = @Faculty_Id WHERE Id = @Id";
        private const string SP_DELETE = "DELETE FROM specializations WHERE Id=@ref_id";
        private const string SP_DELETE_FILTER = "DELETE FROM specializations {0}";
        private const string SP_GET_LOOKUP = "SELECT Id, Name FROM specializations";
        #endregion

        #region specializations - Constructor
        private SpecializationsRepository()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region specializations - List specializations
        /// <summary>
        /// The purpose of this method is to get all specializations data.
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

        #region specializations - List specializations by Filter Expression
        /// <summary>
        /// The purpose of this method is to get all specializations data based on the Filter Expression criteria.
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

        #region specializations - List specializations by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all specializations data based on filterExpression, sortExpression, pageIndex and pageSize parameters
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

        #region specializations - Get Details for an specializations record
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

        #region specializations - Get Lookup Data
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


        #region specializations - Add Record
        /// <summary>
        /// Creates a new specializations row.
        /// </summary>
        public static int Add(int Id, string Name, int Faculty_Id)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_ADD, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Faculty_Id", Faculty_Id);
                        cn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return (int)cmd.Parameters["@Id"].Value;
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

        #region specializations - Update Record
        /// <summary>
        /// Updates a specializations
        /// </summary>
        public static bool Update(int Id, string Name, int Faculty_Id)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_UPDATE, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Faculty_Id", Faculty_Id);
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

        #region specializations - Delete Record
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
                        //cmd.Parameters.Add("@Id", SqlDbType.int).Value = sRefID;
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

        #region specializations - Delete Records
        /// <summary>
        /// The purpose of this method is to delete all specializations data based on the Filter Expression criteria.
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

        #region specializations - Get List of specializationsData objects
        /// <summary>
        /// Returns a collection with all the specializationsData
        /// </summary>
        /// <returns>List of specializationsData object</returns>
        public static List<Specialization> GetList()
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

                        List<Specialization> objList = new List<Specialization>();
                        while (reader.Read())
                        {
                            //objList.Add(new specializationsData(
                            //	 (int) reader["Id"], (string) reader["Name"], (int) reader["Faculty_Id"]));
                            objList.Add(Specialization.Parse(reader)); // Use this to avoid null issues
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

        public static List<Specialization> GetList(User user)
        {
            try
            {
                var userSpec = UsersSpecializationsRepository.GetList().Where(x => x.User_Id == user.Id);
                return GetList().Where(x => userSpec.Where(y => x.Id == y.Specialization_Id).Count() > 0).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<Specialization> GetList(Faculty faculty)
        {
            try
            {
                return GetList().Where(x => x.Faculty_Id == faculty.Id).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static Specialization GetList(Subject subject)
        {
            try
            {
                return GetList().Where(x => x.Id == subject.Specialization_Id).ToList().First();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


        #region specializations - List specializations by Filter Expression
        /// <summary>
        /// The purpose of this method is to get all specializations data based on the Filter Expression criteria.
        /// </summary>
        /// <param name="filterExpression">A NameValueCollection object that defines various properties.
        /// For example, filterExpression - Where condition to be passed in SQL statement.
        /// </param>
        /// <returns>List of specializationsData object</returns>
        public static List<Specialization> GetList(string filterExpression)
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

                        List<Specialization> objList = new List<Specialization>();
                        while (reader.Read())
                        {
                            //objList.Add(new specializationsData(
                            //	 (int) reader["Id"], (string) reader["Name"], (int) reader["Faculty_Id"]));
                            objList.Add(Specialization.Parse(reader)); // Use this to avoid null issues
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

        #region specializations - List specializations by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all specializations data based on filterExpression, sortExpression, pageIndex and pageSize parameters
        /// </summary>
        /// <param name="filterExpression">Where condition to be passed in SQL statement. DO NOT include WHERE keyword.</param>
        /// <param name="sortExpression">Sort column name with direction. For Example, "ProductID ASC")</param>
        /// <param name="pageIndex">Page number to be retrieved. Default is 0.</param>
        /// <param name="pageSize">Number of rows to be retrived. Default is 10.</param>
        /// <param name="rowsCount">Output: Total number of rows exist for the specified criteria.</param>
        /// <returns>List of specializationsData object</returns>
        public static List<Specialization> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, out int rowsCount)
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

                        List<Specialization> objList = new List<Specialization>();
                        while (reader.Read())
                        {
                            //objList.Add(new specializationsData(
                            //         (int) reader["Id"], (string) reader["Name"], (int) reader["Faculty_Id"]));
                            objList.Add(Specialization.Parse(reader)); // Use this to avoid null issues
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


        #region specializations - Get Details by ID
        /// <summary>
        /// Returns an existing specializationsData object with the specified ID 
        /// </summary>
        public static Specialization GetDetailsByID(int sRefID)
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
                        // return new specializationsData(
                        //	 (int) reader["Id"], (string) reader["Name"], (int) reader["Faculty_Id"]);
                        return Specialization.Parse(reader); // Use this to avoid null issues
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

        #region specializations - Add Record
        /// <summary>
        /// Creates a new specializations
        /// </summary>
        public static int Add(Specialization objspecializations)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_ADD, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", objspecializations.Id);
                        cmd.Parameters.AddWithValue("@Name", objspecializations.Name);
                        cmd.Parameters.AddWithValue("@Faculty_Id", objspecializations.Faculty_Id);
                        cn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return (int)cmd.Parameters["@Id"].Value;
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

        #region specializations - Update Record
        /// <summary>
        /// Updates a specializations
        /// </summary>
        public static bool Update(Specialization objspecializations)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_UPDATE, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", objspecializations.Id);
                        cmd.Parameters.AddWithValue("@Name", objspecializations.Name);
                        cmd.Parameters.AddWithValue("@Faculty_Id", objspecializations.Faculty_Id);
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
