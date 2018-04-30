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
    /// Summary description for users.
    /// </summary>
    public class UsersRepository
    {
        private static string connectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["defaultDatabase"].ConnectionString;
            }
        }

        #region Constants
        private const string SP_GET_ALL = "SELECT  `Id`, `FirstName`, `LastName`, `PhoneNumber`, `MailAddress`, `Login`, `Password`, `AccountType` FROM users";
        private const string SP_GET_FILTER = "SELECT  `Id`, `FirstName`, `LastName`, `PhoneNumber`, `MailAddress`, `Login`, `Password`, `AccountType` FROM users {0}";
        private const string SP_GET_BYPAGE = "SELECT * FROM users {1} ORDER BY {0} LIMIT {2}, {3}; SELECT COUNT(*) FROM users {1};";
        private const string SP_GET_BYID = "SELECT  `Id`, `FirstName`, `LastName`, `PhoneNumber`, `MailAddress`, `Login`, `Password`, `AccountType` FROM users WHERE Id = @ref_id";
        private const string SP_ADD = "INSERT INTO users ( Id, FirstName, LastName, PhoneNumber, MailAddress, Login, Password, AccountType) VALUES ( @Id, @FirstName, @LastName, @PhoneNumber, @MailAddress, @Login, @Password, @AccountType) ";
        private const string SP_ADD1 = "INSERT INTO users ( Id, FirstName, LastName, PhoneNumber, MailAddress, Login, Password, AccountType) VALUES ( @Id, @FirstName, @LastName, @PhoneNumber, @MailAddress, @Login, @Password, @AccountType) SELECT @Id = @@IDENTITY";
        private const string SP_UPDATE = "UPDATE users SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, MailAddress = @MailAddress, Login = @Login, Password = @Password, AccountType = @AccountType WHERE Id = @Id";
        private const string SP_DELETE = "DELETE FROM users WHERE Id=@ref_id";
        private const string SP_DELETE_FILTER = "DELETE FROM users {0}";
        private const string SP_GET_LOOKUP = "SELECT Id, FirstName FROM users";
        #endregion

        #region users - Constructor
        private UsersRepository()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region users - List users
        /// <summary>
        /// The purpose of this method is to get all users data.
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

        #region users - List users by Filter Expression
        /// <summary>
        /// The purpose of this method is to get all users data based on the Filter Expression criteria.
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

        #region users - List users by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all users data based on filterExpression, sortExpression, pageIndex and pageSize parameters
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

        #region users - Get Details for an users record
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

        #region users - Get Lookup Data
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


        #region users - Add Record
        /// <summary>
        /// Creates a new users row.
        /// </summary>
        public static int Add(int Id, string FirstName, string LastName, string PhoneNumber, string MailAddress, string Login, string Password, int AccountType)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_ADD, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@FirstName", FirstName);
                        cmd.Parameters.AddWithValue("@LastName", LastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        cmd.Parameters.AddWithValue("@MailAddress", MailAddress);
                        cmd.Parameters.AddWithValue("@Login", Login);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@AccountType", AccountType);
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

        #region users - Update Record
        /// <summary>
        /// Updates a users
        /// </summary>
        public static bool Update(int Id, string FirstName, string LastName, string PhoneNumber, string MailAddress, string Login, string Password, int AccountType)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_UPDATE, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@FirstName", FirstName);
                        cmd.Parameters.AddWithValue("@LastName", LastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        cmd.Parameters.AddWithValue("@MailAddress", MailAddress);
                        cmd.Parameters.AddWithValue("@Login", Login);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@AccountType", AccountType);
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

        #region users - Delete Record
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

        #region users - Delete Records
        /// <summary>
        /// The purpose of this method is to delete all users data based on the Filter Expression criteria.
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

        #region users - Get List of usersData objects
        /// <summary>
        /// Returns a collection with all the usersData
        /// </summary>
        /// <returns>List of usersData object</returns>
        public static List<User> GetList()
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

                        List<User> objList = new List<User>();
                        while (reader.Read())
                        {
                            //objList.Add(new usersData(
                            //	 (int) reader["Id"], (string) reader["FirstName"], (string) reader["LastName"], (string) reader["PhoneNumber"], (string) reader["MailAddress"], (string) reader["Login"], (string) reader["Password"], (int) reader["AccountType"]));
                            objList.Add(User.Parse(reader)); // Use this to avoid null issues
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

        public static List<User> GetList(Specialization specialization)
        {
            try
            {
                var userSpec = UsersSpecializationsRepository.GetList().Where(x => x.Specialization_Id == specialization.Id);
                return GetList().Where(x => userSpec.Where(y => x.Id == y.User_Id).Any()).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region users - List users by Filter Expression
        /// <summary>
        /// The purpose of this method is to get all users data based on the Filter Expression criteria.
        /// </summary>
        /// <param name="filterExpression">A NameValueCollection object that defines various properties.
        /// For example, filterExpression - Where condition to be passed in SQL statement.
        /// </param>
        /// <returns>List of usersData object</returns>
        public static List<User> GetList(string filterExpression)
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

                        List<User> objList = new List<User>();
                        while (reader.Read())
                        {
                            //objList.Add(new usersData(
                            //	 (int) reader["Id"], (string) reader["FirstName"], (string) reader["LastName"], (string) reader["PhoneNumber"], (string) reader["MailAddress"], (string) reader["Login"], (string) reader["Password"], (int) reader["AccountType"]));
                            objList.Add(User.Parse(reader)); // Use this to avoid null issues
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

        #region users - List users by filterExpression, sortExpression, pageIndex and pageSize
        /// <summary>
        /// The purpose of this method is to get all users data based on filterExpression, sortExpression, pageIndex and pageSize parameters
        /// </summary>
        /// <param name="filterExpression">Where condition to be passed in SQL statement. DO NOT include WHERE keyword.</param>
        /// <param name="sortExpression">Sort column name with direction. For Example, "ProductID ASC")</param>
        /// <param name="pageIndex">Page number to be retrieved. Default is 0.</param>
        /// <param name="pageSize">Number of rows to be retrived. Default is 10.</param>
        /// <param name="rowsCount">Output: Total number of rows exist for the specified criteria.</param>
        /// <returns>List of usersData object</returns>
        public static List<User> GetList(string filterExpression, string sortExpression, int pageIndex, int pageSize, out int rowsCount)
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

                        List<User> objList = new List<User>();
                        while (reader.Read())
                        {
                            //objList.Add(new usersData(
                            //         (int) reader["Id"], (string) reader["FirstName"], (string) reader["LastName"], (string) reader["PhoneNumber"], (string) reader["MailAddress"], (string) reader["Login"], (string) reader["Password"], (int) reader["AccountType"]));
                            objList.Add(User.Parse(reader)); // Use this to avoid null issues
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


        #region users - Get Details by ID
        /// <summary>
        /// Returns an existing usersData object with the specified ID 
        /// </summary>
        public static User GetDetailsByID(int sRefID)
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
                        // return new usersData(
                        //	 (int) reader["Id"], (string) reader["FirstName"], (string) reader["LastName"], (string) reader["PhoneNumber"], (string) reader["MailAddress"], (string) reader["Login"], (string) reader["Password"], (int) reader["AccountType"]);
                        return User.Parse(reader); // Use this to avoid null issues
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

        #region users - Add Record
        /// <summary>
        /// Creates a new users
        /// </summary>
        public static int Add(User objusers)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_ADD, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", objusers.Id);
                        cmd.Parameters.AddWithValue("@FirstName", objusers.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", objusers.LastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", objusers.PhoneNumber);
                        cmd.Parameters.AddWithValue("@MailAddress", objusers.MailAddress);
                        cmd.Parameters.AddWithValue("@Login", objusers.Login);
                        cmd.Parameters.AddWithValue("@Password", objusers.Password);
                        cmd.Parameters.AddWithValue("@AccountType", objusers.AccountType);
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

        #region users - Update Record
        /// <summary>
        /// Updates a users
        /// </summary>
        public static bool Update(User objusers)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(SP_UPDATE, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", objusers.Id);
                        cmd.Parameters.AddWithValue("@FirstName", objusers.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", objusers.LastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", objusers.PhoneNumber);
                        cmd.Parameters.AddWithValue("@MailAddress", objusers.MailAddress);
                        cmd.Parameters.AddWithValue("@Login", objusers.Login);
                        cmd.Parameters.AddWithValue("@Password", objusers.Password);
                        cmd.Parameters.AddWithValue("@AccountType", objusers.AccountType);
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
