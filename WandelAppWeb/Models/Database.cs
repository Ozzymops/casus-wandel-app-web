using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WandelAppWeb.Models
{
    /// <summary>
    /// Database contains the connection string for the database and contains some queries.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// A string that contains everything you need to create a connection to the database.
        /// </summary>
        private string connectionString = "Data Source = localhost; Initial Catalog = WandelAppDb; Integrated Security = True";

        #region GET
        /// <summary>
        /// Return a single boolean from the query results.
        /// Check if there are any results from the query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// Return a single string from the query results.
        /// Will take the first result available.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>string</returns>
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

        /// <summary>
        /// Return a single int from the query results.
        /// Will take the first result available.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>int</returns>
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

        /// <summary>
        /// Return a single User from the query results.
        /// Will take the first available, if multiple return.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>User</returns>
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
                            return user = new User() { Id = reader.GetInt32(0), Name = reader.GetString(1), Username = reader.GetString(2), Password = reader.GetString(3) };
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

        /// <summary>
        /// Return the Preferences of a User.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Preferences</returns>
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

        /// <summary>
        /// Return the route corresponding to the query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Route</returns>
        public Route ReturnRoute(string query)
        {
            Route route;
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
                            return route = new Route()
                            {
                                Id = reader.GetInt32(0),
                                OwnerId = reader.GetInt32(1),
                                Difficulty = reader.GetInt32(2),
                                Name = reader.GetString(3),
                                Length = reader.GetDecimal(4),
                                StartLong = reader.GetDecimal(5),
                                StartLat = reader.GetDecimal(6),
                                EndLong = reader.GetDecimal(7),
                                EndLat = reader.GetDecimal(8),
                                Marshiness = reader.GetBoolean(9),
                                RouteAsphalted = reader.GetBoolean(10),
                                HillType = (HillType)reader.GetInt32(11),
                                ForestDensity = (ForestDensity)reader.GetInt32(12),
                                RouteFlatness = (RouteFlatness)reader.GetInt32(13)
                            };
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

        /// <summary>
        /// Return a list of routes corresponding to the query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Route list</returns>
        public List<Route> ReturnRouteList(string query)
        {
            List<Route> routeList = new List<Route>();
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
                            Route route = new Route()
                            {
                                Id = reader.GetInt32(0),
                                OwnerId = reader.GetInt32(1),
                                Difficulty = reader.GetInt32(2),
                                Name = reader.GetString(3),
                                Length = reader.GetDecimal(4),
                                StartLong = reader.GetDecimal(5),
                                StartLat = reader.GetDecimal(6),
                                EndLong = reader.GetDecimal(7),
                                EndLat = reader.GetDecimal(8),
                                Marshiness = reader.GetBoolean(9),
                                RouteAsphalted = reader.GetBoolean(10),
                                HillType = (HillType)reader.GetInt32(11),
                                ForestDensity = (ForestDensity)reader.GetInt32(12),
                                RouteFlatness = (RouteFlatness)reader.GetInt32(13)
                            };
                            routeList.Add(route);
                        }
                    }
                    return routeList;
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