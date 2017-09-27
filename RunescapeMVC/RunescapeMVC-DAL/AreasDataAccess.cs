using RunescapeMVC_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RunescapeMVC_DAL
{
    public class AreasDataAccess
    {
        public string _ConnectionString =
            @"Server=ADMIN2-PC\SQLEXPRESS; Database=Runescape; Trusted_Connection=True;";

        public void InsertArea(IAreaInfoDO iArea)
        {
            try
            {
                using (SqlConnection connectionToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("INSERT_AREA", connectionToSql))
                    {
                        try
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandTimeout = 15;

                            command.Parameters.AddWithValue("@AreaName", iArea.AreaName);
                            command.Parameters.AddWithValue("@Kingdom", iArea.Kingdom);
                            command.Parameters.AddWithValue("@Climate", iArea.Climate);
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

        public IAreaInfoDO ViewAreaByID(long iAreaID)
        {
            IAreaInfoDO areaDO = new AreaInfoDO();
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand viewCommand = new SqlCommand("VIEW_AREA_BY_ID", connToSql))
                    {
                        viewCommand.CommandType = CommandType.StoredProcedure;
                        viewCommand.CommandTimeout = 35;
                        viewCommand.Parameters.AddWithValue("@AreaID", iAreaID);

                        //Open connection
                        connToSql.Open();
                        //Use reader
                        using (SqlDataReader reader = viewCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                areaDO.AreaID = reader.GetInt64(0);
                                areaDO.AreaName = reader.GetString(1);
                                areaDO.Kingdom = reader.GetString(2);
                                areaDO.Climate = reader.GetString(3);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return areaDO;
        }

        public List<IAreaInfoDO> ViewAllAreas()
        {
            List<IAreaInfoDO> listOfAreaDOs = new List<IAreaInfoDO>();
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand viewCommand = new SqlCommand("VIEW_ALL_AREAS", connToSql))
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
                                IAreaInfoDO areaDO = new AreaInfoDO();
                                //Assign values from reader to new DO
                                areaDO.AreaID = reader.GetInt64(0);
                                areaDO.AreaName = reader.GetString(1);
                                areaDO.Kingdom = reader.GetString(2);
                                areaDO.Climate = reader.GetString(3);

                                //Populate list with DOs
                                listOfAreaDOs.Add(areaDO);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listOfAreaDOs;
        }

        public void DeleteArea(long areaID)
        {
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand deleteCommand = new SqlCommand("DELETE_AREA_BY_ID", connToSql))
                    {
                        try
                        {
                            deleteCommand.CommandType = CommandType.StoredProcedure;
                            deleteCommand.CommandTimeout = 35;
                            deleteCommand.Parameters.AddWithValue("@AreaID", areaID);

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

        public void UpdateArea(IAreaInfoDO iArea)
        {
            try
            {
                using (SqlConnection connToSql = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand updateCommand = new SqlCommand("UPDATE_AREA_BY_ID", connToSql))
                    {
                        try
                        {
                            updateCommand.CommandType = CommandType.StoredProcedure;
                            updateCommand.CommandTimeout = 35;
                            updateCommand.Parameters.AddWithValue("@AreaID", iArea.AreaID);
                            updateCommand.Parameters.AddWithValue("@AreaName", iArea.AreaName);
                            updateCommand.Parameters.AddWithValue("@Kingdom", iArea.Kingdom);
                            updateCommand.Parameters.AddWithValue("@Climate", iArea.Climate);

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
