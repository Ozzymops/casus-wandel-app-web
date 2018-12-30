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
        #endregion
    }
}