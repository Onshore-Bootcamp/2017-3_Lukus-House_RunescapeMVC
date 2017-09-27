namespace RunescapeMVC_DAL
{
    using RunescapeMVC_DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class MasterDataAccess
    {
        public string _ConnectionString =
           @"Server=ADMIN2-PC\SQLEXPRESS; Database=Runescape; Trusted_Connection=True;";

        public void InsertMaster(IMasterDO iMaster)
        {
            try
            {
                using (SqlConnection connectionToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("INSERT_SLAYER_MASTER", connectionToSql))
                    {
                        try
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandTimeout = 15;

                            command.Parameters.AddWithValue("@MasterName", iMaster.MasterName);
                            command.Parameters.AddWithValue("@ReqSlayerLevel", iMaster.ReqSlayerLevel);
                            command.Parameters.AddWithValue("@ReqCombatLevel", iMaster.RequiredCombatLevel);
                            command.Parameters.AddWithValue("@ReqQuests", iMaster.RequiredQuests);
                            command.Parameters.AddWithValue("@Location", iMaster.Location);
                           
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

        public IMasterDO ViewMasterByID(long iSlayerMasterID)
        {
            IMasterDO masterDO = new MasterDO();
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand viewCommand = new SqlCommand("VIEW_MASTER_BY_ID", connToSql))
                    {
                        viewCommand.CommandType = CommandType.StoredProcedure;
                        viewCommand.CommandTimeout = 35;
                        viewCommand.Parameters.AddWithValue("@SlayerMasterID", iSlayerMasterID);

                        //Open connection
                        connToSql.Open();
                        //Use reader
                        using (SqlDataReader reader = viewCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                masterDO.SlayerMasterID = reader.GetInt64(0);
                                masterDO.MasterName = reader.GetString(1);
                                masterDO.ReqSlayerLevel = reader.GetInt32(2);
                                masterDO.RequiredCombatLevel = reader.GetInt32(3);
                                masterDO.RequiredQuests = reader.GetString(4);
                                masterDO.Location = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return masterDO;
        }

        public List<IMasterDO> ViewAllMasters()
        {
            List<IMasterDO> listOfmasterDOs = new List<IMasterDO>();
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand viewCommand = new SqlCommand("VIEW_ALL_SLAYER_MASTERS", connToSql))
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
                                IMasterDO masterDO = new MasterDO();
                                //Assign values from reader to new DO
                                masterDO.SlayerMasterID = reader.GetInt64(0);
                                masterDO.MasterName = reader.GetString(1);
                                masterDO.ReqSlayerLevel = reader.GetInt32(2);
                                masterDO.RequiredCombatLevel = reader.GetInt32(3);
                                masterDO.RequiredQuests = reader.GetString(4);
                                masterDO.Location = reader.GetString(5);

                                //Populate list with DOs
                                listOfmasterDOs.Add(masterDO);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listOfmasterDOs;
        }

        public void DeleteMaster(long iSlayerMasterID)
        {
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand deleteCommand = new SqlCommand("DELETE_SLAYER_MASTER_BY_ID", connToSql))
                    {
                        try
                        {
                            deleteCommand.CommandType = CommandType.StoredProcedure;
                            deleteCommand.CommandTimeout = 35;
                            deleteCommand.Parameters.AddWithValue("@SlayerMasterID", iSlayerMasterID);

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

        public void UpdateMaster(IMasterDO iMaster)
        {
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand updateCommand = new SqlCommand("UPDATE_SLAYER_MASTER_BY_ID", connToSql))
                    {
                        try
                        {
                            updateCommand.CommandType = CommandType.StoredProcedure;
                            updateCommand.CommandTimeout = 35;
                            updateCommand.Parameters.AddWithValue("@SlayerMasterID", iMaster.SlayerMasterID);
                            updateCommand.Parameters.AddWithValue("@MasterName", iMaster.MasterName);
                            updateCommand.Parameters.AddWithValue("@ReqSlayerLevel", iMaster.ReqSlayerLevel);
                            updateCommand.Parameters.AddWithValue("@ReqCombatLevel", iMaster.RequiredCombatLevel);
                            updateCommand.Parameters.AddWithValue("@ReqQuests", iMaster.RequiredQuests);
                            updateCommand.Parameters.AddWithValue("@Location", iMaster.Location);

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
