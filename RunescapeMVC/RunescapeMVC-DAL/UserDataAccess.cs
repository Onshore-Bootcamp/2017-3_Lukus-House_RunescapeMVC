namespace RunescapeMVC_DAL
{
    using RunescapeMVC_DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class UserDataAccess
    {
        public string _ConnectionString =
            @"Server=ADMIN2-PC\SQLEXPRESS; Database=Runescape; Trusted_Connection=True;";

        public UserDO GetUserByUserName(string iUserName)
        {
            UserDO user = new UserDO();
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand viewCommand = new SqlCommand("VIEW_USER_BY_USERNAME", connToSql))
                    {
                        viewCommand.CommandType = CommandType.StoredProcedure;
                        viewCommand.CommandTimeout = 35;
                        viewCommand.Parameters.AddWithValue("@UserName", iUserName);

                        //Open connection
                        connToSql.Open();
                        //Use reader
                        using (SqlDataReader reader = viewCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.UserID = reader.GetInt64(0);
                                user.UserName = reader.GetString(1);
                                user.Password = reader.GetString(2);
                                user.Role = reader.GetInt32(3);
                                user.FirstName = reader.GetString(4);
                                user.LastName = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        public UserDO GetUserByID(long iUserID)
        {
            UserDO user = new UserDO();
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand viewCommand = new SqlCommand("VIEW_USER_BY_ID", connToSql))
                    {
                        viewCommand.CommandType = CommandType.StoredProcedure;
                        viewCommand.CommandTimeout = 35;
                        viewCommand.Parameters.AddWithValue("@UserID", iUserID);

                        //Open connection
                        connToSql.Open();
                        //Use reader
                        using (SqlDataReader reader = viewCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.UserID = reader.GetInt64(0);
                                user.UserName = reader.GetString(1);
                                user.Password = reader.GetString(2);
                                user.Role = reader.GetInt32(3);
                                user.FirstName = reader.GetString(4);
                                user.LastName = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        public LoginDO GetUserLogin(string iUserName)
        {
            LoginDO loginDO = new LoginDO();
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand viewCommand = new SqlCommand("VIEW_USER_BY_USERNAME", connToSql))
                    {
                        viewCommand.CommandType = CommandType.StoredProcedure;
                        viewCommand.CommandTimeout = 35;
                        viewCommand.Parameters.AddWithValue("@UserName", iUserName);

                        //Open connection
                        connToSql.Open();
                        //Use reader
                        using (SqlDataReader reader = viewCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                loginDO.UserName = reader.GetString(1);
                                loginDO.Password = reader.GetString(2);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return loginDO;
        }

        public List<IUserDO> ViewAllUsers()
        {
            List<IUserDO> listOfUserDOs = new List<IUserDO>();
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand viewCommand = new SqlCommand("VIEW_ALL_USERS", connToSql))
                    {
                        viewCommand.CommandType = CommandType.StoredProcedure;
                        viewCommand.CommandTimeout = 35;
                        //Open connection
                        connToSql.Open();
                        //Use reader
                        using (SqlDataReader reader = viewCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //New instantiation of a DO
                                IUserDO user = new UserDO();
                                //Assign values from reader to new DO
                                user.UserID = reader.GetInt64(0);
                                user.UserName = reader.GetString(1);
                                user.Password = reader.GetString(2);
                                user.Role = reader.GetInt32(3);
                                user.FirstName = reader.GetString(4);
                                user.LastName = reader.GetString(5);

                                //Populate list with DOs
                                listOfUserDOs.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listOfUserDOs;
        }

        public void DeleteUser(long userID)
        {
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand deleteCommand = new SqlCommand("DELETE_USER_BY_ID", connToSql))
                    {
                        try
                        {
                            deleteCommand.CommandType = CommandType.StoredProcedure;
                            deleteCommand.CommandTimeout = 35;
                            deleteCommand.Parameters.AddWithValue("@UserIDNumber", userID);

                            connToSql.Open();
                            deleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void UpdateUser(IUserDO iUser)
        {
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand updateCommand = new SqlCommand("UPDATE_USER_BY_ID", connToSql))
                    { 
                        try
                        {
                            updateCommand.CommandType = CommandType.StoredProcedure;
                            updateCommand.CommandTimeout = 35;
                            updateCommand.Parameters.AddWithValue("@UserIDNumber", iUser.UserID);
                            updateCommand.Parameters.AddWithValue("@UserName", iUser.UserName);
                            updateCommand.Parameters.AddWithValue("@Password", iUser.Password);
                            updateCommand.Parameters.AddWithValue("@Role", iUser.Role);
                            updateCommand.Parameters.AddWithValue("@FirstName", iUser.FirstName);
                            updateCommand.Parameters.AddWithValue("@LastName", iUser.LastName);
                            connToSql.Open();
                            updateCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateUser(IUserDO iUser)
        {
            try
            {
                using (SqlConnection connectionToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("INSERT_USER", connectionToSql))
                    {
                        try
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandTimeout = 15;
                            
                            command.Parameters.AddWithValue("@UserName", iUser.UserName);
                            command.Parameters.AddWithValue("@Password", iUser.Password);
                            command.Parameters.AddWithValue("@FirstName", iUser.FirstName);
                            command.Parameters.AddWithValue("@LastName", iUser.LastName);
                            connectionToSql.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            connectionToSql.Close();
                            connectionToSql.Dispose();
                            command.Dispose();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //Do nothing
            }
        }
    }
}
