namespace RunescapeMVC_DAL
{
    using RunescapeMVC_DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    
    public class BeastDataAccess
    {
        //Sql Connection string for accessing Runescape Database
        public string _ConnectionString =
           @"Server=ADMIN2-PC\SQLEXPRESS; Database=Runescape; Trusted_Connection=True;";

        //Method to Create a new beast into database by passing form data
        public void InsertBeast(IBeastDO iBeast)
        {
            try
            {
                //connect to sql and create command
                using (SqlConnection connectionToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("INSERT_BEAST", connectionToSql))
                    {
                        try
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandTimeout = 15;

                            //pass parameters to SQL
                            command.Parameters.AddWithValue("@Name", iBeast.Name);
                            command.Parameters.AddWithValue("@SlayerLevelReq", iBeast.SlayerLevelReq);
                            command.Parameters.AddWithValue("@BeastCombatLevel", iBeast.BeastCombatLevel);
                            command.Parameters.AddWithValue("@Lifepoints", iBeast.Lifepoints);
                            command.Parameters.AddWithValue("@Weakness", iBeast.Weakness);
                            command.Parameters.AddWithValue("@AttackStyles", 1);
                            command.Parameters.AddWithValue("@Members", iBeast.Members);
                            command.Parameters.AddWithValue("@AreaID", iBeast.AreaID);
                            command.Parameters.AddWithValue("@SpecialGearRequired", iBeast.Gear);
                            command.Parameters.AddWithValue("@ExperiencePerKill", iBeast.ExpPerKill);
                            command.Parameters.AddWithValue("@AssignedBy", iBeast.AssignedBy);

                            connectionToSql.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            //ensure connection and and command are disposed of
                            connectionToSql.Close();
                            connectionToSql.Dispose();
                            command.Dispose();
                        }
                    }
                }
            }
            catch (Exception)
            {
                //log ex on each layer
                throw;
            }
            finally
            {
                //Do nothing
            }
        }

        //Method to get data for beast by passing it's ID
        public IBeastDO ViewBeastByID(long iBeastID)
        {
            IBeastDO beastDO = new BeastDO();
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand viewCommand = new SqlCommand("VIEW_BEAST_BY_ID", connToSql))
                    {
                        viewCommand.CommandType = CommandType.StoredProcedure;
                        viewCommand.CommandTimeout = 35;
                        //pass ID to SQL
                        viewCommand.Parameters.AddWithValue("@BeastID", iBeastID);

                        //Open connection
                        connToSql.Open();
                        //Use reader to assing values to beastDO
                        using (SqlDataReader reader = viewCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                beastDO.BeastID = reader.GetInt64(0);
                                beastDO.Name = reader.GetString(1);
                                beastDO.SlayerLevelReq = reader.GetInt32(2);
                                beastDO.BeastCombatLevel = reader.GetInt32(3);
                                beastDO.Lifepoints = reader.GetInt64(4);
                                beastDO.Weakness = reader.GetString(5);
                                beastDO.AttackStyles = reader.GetString(6);
                                beastDO.Members = reader.GetBoolean(7);
                                beastDO.AreaID = reader.GetInt64(8);
                                beastDO.Gear = reader.GetString(9);
                                beastDO.ExpPerKill = reader.GetString(10);
                                beastDO.AssignedBy = reader.GetInt64(11);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return beastDO;
        }

        //Method to view all beasts
        public List<IBeastDO> ViewAllBeasts()
        {
            List<IBeastDO> listOfbeastDOs = new List<IBeastDO>();
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand viewCommand = new SqlCommand("VIEW_ALL_BEASTS", connToSql))
                    {
                        viewCommand.CommandType = CommandType.StoredProcedure;
                        viewCommand.CommandTimeout = 35;
                        //Open connection
                        connToSql.Open();
                        //Use reader to assign data from SQL to beastDO
                        using (SqlDataReader reader = viewCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //New instantiation of a DO
                                IBeastDO beastDO = new BeastDO();
                                //Assign values from reader to new DO
                                beastDO.BeastID = reader.GetInt64(0);
                                beastDO.Name = reader.GetString(1);
                                beastDO.SlayerLevelReq = reader.GetInt32(2);
                                beastDO.BeastCombatLevel = reader.GetInt32(3);
                                beastDO.Lifepoints = reader.GetInt64(4);
                                beastDO.Weakness = reader.GetString(5);
                                beastDO.AttackStyles = reader.GetString(6);
                                beastDO.Members = reader.GetBoolean(7);
                                beastDO.AreaID = reader.GetInt64(8);
                                beastDO.AreaName = reader.GetString(9);
                                beastDO.Gear = reader.GetString(10);
                                beastDO.ExpPerKill = reader.GetString(11);
                                beastDO.AssignedBy = reader.GetInt64(12);
                                beastDO.MasterName = reader.GetString(13);

                                //Populate list with DOs
                                listOfbeastDOs.Add(beastDO);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listOfbeastDOs;
        }
        
        //method to delete beast by ID
        public void DeleteBeast(long iBeastID)
        {
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand deleteCommand = new SqlCommand("DELETE_BEAST_BY_ID", connToSql))
                    {
                        try
                        {
                            deleteCommand.CommandType = CommandType.StoredProcedure;
                            deleteCommand.CommandTimeout = 35;
                            deleteCommand.Parameters.AddWithValue("@BeastID", iBeastID);

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

        //Method to update beast by passing form data
        public void UpdateBeast(IBeastDO iBeast)
        {
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand updateCommand = new SqlCommand("UPDATE_BEAST_BY_ID", connToSql))
                    {
                        try
                        {
                            updateCommand.CommandType = CommandType.StoredProcedure;
                            updateCommand.CommandTimeout = 35;
                            //pass all parameter to SQL to update beast
                            updateCommand.Parameters.AddWithValue("@BeastID", iBeast.BeastID);
                            updateCommand.Parameters.AddWithValue("@Name", iBeast.Name);
                            updateCommand.Parameters.AddWithValue("@SlayerLevelReq", iBeast.SlayerLevelReq);
                            updateCommand.Parameters.AddWithValue("@BeastCombatLevel", iBeast.BeastCombatLevel);
                            updateCommand.Parameters.AddWithValue("@Lifepoints", iBeast.Lifepoints);
                            updateCommand.Parameters.AddWithValue("@Weakness", iBeast.Weakness);
                            updateCommand.Parameters.AddWithValue("@AttackStyles", 1);
                            updateCommand.Parameters.AddWithValue("@Members", iBeast.Members);
                            updateCommand.Parameters.AddWithValue("@AreaID", iBeast.AreaID);
                            updateCommand.Parameters.AddWithValue("@SpecialGearRequired", iBeast.Gear);
                            updateCommand.Parameters.AddWithValue("@ExperiencePerKill", iBeast.ExpPerKill);
                            updateCommand.Parameters.AddWithValue("@AssignedBy", iBeast.AssignedBy);

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
    }
}
