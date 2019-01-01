using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WandelAppWeb.Models
{
    public class Database
    {
        private string connectionString = "Data Source = localhost; Initial Catalog = WandelAppDb; Integrated Security = True";

        #region GET
        public bool ReturnSingleBoolean(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    // ignore
                    return false;
                }
            }
            return false;
        }

        public string ReturnSingleString(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            return reader.GetString(0);
                        }
                    }
                }
                catch (Exception e)
                {
                    // ignore
                    return null;
                }
            }
            return null;
        }

        public int ReturnSingleInt(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
                catch (Exception e)
                {
                    // ignore
                    return -1;
                }
            }
            return -1;
        }

        public User ReturnUser(string query)
        {
            User user;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            return user = new User() { Id = reader.GetInt32(0), Name = reader.GetString(1), Username = reader.GetString(2), Password = reader.GetString(3), Preferences = ReturnPreferencesOfUser("SELECT * FROM [dbo].[Preferences] WHERE [Id] = " + reader.GetInt32(0)) };
                        }
                    }
                }
                catch (Exception e)
                {
                    // ignore
                    return null;
                }
            }
            return null;
        }

        public Preferences ReturnPreferencesOfUser(string query)
        {
            Preferences preferences;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            return preferences = new Preferences() { Id = reader.GetInt32(0), Length = reader.GetInt32(1), HillType = (HillType)reader.GetInt32(2),
                                                                     Marshiness = reader.GetBoolean(3), ForestDensity = (ForestDensity)reader.GetInt32(4),
                                                                     RouteFlatness = (RouteFlatness)reader.GetInt32(5), RouteAsphalted = reader.GetBoolean(6),
                                                                     RouteHardened = reader.GetBoolean(7), RoadSigns = (RoadSigns)reader.GetInt32(8) };
                        }
                    }
                }
                catch (Exception e)
                {
                    // ignore
                    return null;
                }
            }
            return null;
        }
        #endregion
    }
}