using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WandelAppWeb.Models
{
    public class Database
    {
        Models.Logger l = new Models.Logger();

        /// <summary>
        /// A string that contains everything you need to create a connection to the database.
        /// </summary>
        private string connectionString = "Data Source = localhost; Initial Catalog = WandelAppDb; Integrated Security = True";

        /// <summary>
        /// Return a single boolean from the query results.
        /// Checks if there are any results from the query.
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
                    l.WriteToLog("Error - ReturnSingleBoolean: " + e);
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
                    l.WriteToLog("Error - ReturnSingleString: " + e);
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
                    l.WriteToLog("Error - ReturnSingleInt: " + e);
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
                            return user = new User()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Username = reader.GetString(2),
                                Password = reader.GetString(3)
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    l.WriteToLog("Error - ReturnUser: " + e);
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Return a Preferences object from the query results.
        /// Returns the first available.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Preferences</returns>
        public Preferences ReturnPreferences(string query)
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
                            return preferences = new Preferences()
                            {
                                Id = reader.GetInt32(0),
                                OwnerId = reader.GetInt32(1),
                                Length = reader.GetDecimal(2),
                                HillType = (HillType)reader.GetInt32(3),
                                Marshiness = reader.GetBoolean(4),
                                ForestDensity = (ForestDensity)reader.GetInt32(5),
                                RouteFlatness = (RouteFlatness)reader.GetInt32(6),
                                RouteAsphalted = reader.GetBoolean(7),
                                RoadSigns = (RoadSigns)reader.GetInt32(8)
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    l.WriteToLog("Error - ReturnPreferences: " + e);
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Return the route object from the query results.
        /// Takes the first one available.
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
                                RouteFlatness = (RouteFlatness)reader.GetInt32(13),
                                RoadSigns = (RoadSigns)reader.GetInt32(14),
                                POIList = this.ReturnPOIList("SELECT * FROM [POI] WHERE [RouteId] = " + reader.GetInt32(0)),
                                SequenceList = this.ReturnRouteSequenceList("SELECT * FROM [RouteSequence] WHERE [RouteId] = " + reader.GetInt32(0))
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    l.WriteToLog("Error - ReturnRoute: " + e);
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Return a list of routes from the query results.
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
                                RouteFlatness = (RouteFlatness)reader.GetInt32(13),
                                RoadSigns = (RoadSigns)reader.GetInt32(14),
                                POIList = this.ReturnPOIList("SELECT * FROM [POI] WHERE [RouteId] = " + reader.GetInt32(0)),
                                SequenceList = this.ReturnRouteSequenceList("SELECT * FROM [RouteSequence] WHERE [RouteId] = " + reader.GetInt32(0))
                            };
                            routeList.Add(route);
                        }
                    }
                    return routeList;
                }
                catch (Exception e)
                {
                    l.WriteToLog("Error - ReturnPreferences: " + e);
                    return null;
                }
            }
        }

        /// <summary>
        /// Return a POI object from the query results.
        /// Will take the first one available.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>POI</returns>
        public POI ReturnPOI(string query)
        {
            POI poi;
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
                            return poi = new POI()
                            {
                                Id = reader.GetInt32(0),
                                RouteId = reader.GetInt32(1),
                                Name = reader.GetString(2),
                                Description = reader.GetString(3),
                                Long = reader.GetDecimal(4),
                                Lat = reader.GetDecimal(5)
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    l.WriteToLog("Error - ReturnPOI: " + e);
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Return a list of POI from the query results.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>POI list</returns>
        public List<POI> ReturnPOIList(string query)
        {
            List<POI> poiList = new List<POI>();
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
                            POI poi = new POI()
                            {
                                Id = reader.GetInt32(0),
                                RouteId = reader.GetInt32(1),
                                Name = reader.GetString(2),
                                Description = reader.GetString(3),
                                Long = reader.GetDecimal(4),
                                Lat = reader.GetDecimal(5)
                            };
                            poiList.Add(poi);
                        }
                    }
                    return poiList;
                }
                catch (Exception e)
                {
                    l.WriteToLog("Error - ReturnPOIList: " + e);
                    return null;
                }
            }
        }

        /// <summary>
        /// Return a RouteSequence object from the query results.
        /// Will return the first one available.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>RouteSequence</returns>
        public RouteSequence ReturnRouteSequence(string query)
        {
            RouteSequence routeSequence;
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
                            return routeSequence = new RouteSequence()
                            {
                                Id = reader.GetInt32(0),
                                RouteId = reader.GetInt32(1),
                                StepNumber = reader.GetInt32(2),
                                Long = reader.GetDecimal(3),
                                Lat = reader.GetDecimal(4)
                            };
                        }
                    }
                }
                catch (Exception e)
                {
                    l.WriteToLog("Error - ReturnRouteSequence: " + e);
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Return a list of RouteSequences from the query results.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>RouteSequence list</returns>
        public List<RouteSequence> ReturnRouteSequenceList(string query)
        {
            List<RouteSequence> routeSequenceList = new List<RouteSequence>();
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
                            RouteSequence routeSequence = new RouteSequence()
                            {
                                Id = reader.GetInt32(0),
                                RouteId = reader.GetInt32(1),
                                StepNumber = reader.GetInt32(2),
                                Long = reader.GetDecimal(3),
                                Lat = reader.GetDecimal(4)
                            };
                            routeSequenceList.Add(routeSequence);
                        }
                    }
                    return routeSequenceList;
                }
                catch (Exception e)
                {
                    l.WriteToLog("Error - ReturnRouteSequenceList: " + e);
                    return null;
                }
            }
        }

        /// <summary>
        /// Add a route to the database.
        /// </summary>
        /// <param name="route"></param>
        /// <returns>Status string</returns>
        public string AddRoute(Models.Route route)
        {
            Models.Logger l = new Models.Logger();
            l.WriteToLog("Addroute!");

            string query = ("INSERT INTO [Route] (OwnerId, Difficulty, Name, Length, StartLong, StartLat, EndLong, EndLat, Marshiness, RouteAsphalted, HillType, ForestDensity, RouteFlatness, RoadSigns) " +
                            "VALUES(@ownerId, @diff, @name, @length, @slong, @slat, @elong, @elat, @marsh, @asph, @hill, @forest, @flat, @sign)");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                    // Create parameters
                    SqlParameter ownerIdParam = new SqlParameter("@ownerId", System.Data.SqlDbType.Int, 255);
                    SqlParameter diffParam = new SqlParameter("@diff", System.Data.SqlDbType.Int, 255);
                    SqlParameter nameParam = new SqlParameter("@name", System.Data.SqlDbType.NVarChar, 255);
                    SqlParameter lengthParam = new SqlParameter("@length", System.Data.SqlDbType.Decimal, 255);
                    SqlParameter slongParam = new SqlParameter("@slong", System.Data.SqlDbType.Decimal, 255);
                    SqlParameter slatParam = new SqlParameter("@slat", System.Data.SqlDbType.Decimal, 255);
                    SqlParameter elongParam = new SqlParameter("@elong", System.Data.SqlDbType.Decimal, 255);
                    SqlParameter elatParam = new SqlParameter("@elat", System.Data.SqlDbType.Decimal, 255);
                    SqlParameter marshParam = new SqlParameter("@marsh", System.Data.SqlDbType.Bit, 1);
                    SqlParameter asphParam = new SqlParameter("@asph", System.Data.SqlDbType.Bit, 1);
                    SqlParameter hillParam = new SqlParameter("@hill", System.Data.SqlDbType.Bit, 1);
                    SqlParameter forestParam = new SqlParameter("@forest", System.Data.SqlDbType.Bit, 1);
                    SqlParameter flatParam = new SqlParameter("@flat", System.Data.SqlDbType.Bit, 1);
                    SqlParameter signParam = new SqlParameter("@sign", System.Data.SqlDbType.Bit, 1);


                    // Fill parameters
                    ownerIdParam.Value = route.OwnerId;
                    diffParam.Value = route.Difficulty;
                    nameParam.Value = route.Name;
                    lengthParam.Value = route.Length;
                    slongParam.Value = route.StartLong;
                    slatParam.Value = route.StartLat;
                    elongParam.Value = route.EndLong;
                    elatParam.Value = route.EndLat;
                    marshParam.Value = Convert.ToInt32(route.Marshiness);
                    asphParam.Value = Convert.ToInt32(route.RouteAsphalted);
                    hillParam.Value = Convert.ToInt32(route.HillType);
                    forestParam.Value = Convert.ToInt32(route.ForestDensity);
                    flatParam.Value = Convert.ToInt32(route.RouteFlatness);
                    signParam.Value = Convert.ToInt32(route.RoadSigns);

                    // Add parameters
                    cmd.Parameters.Add(ownerIdParam);
                    cmd.Parameters.Add(diffParam);
                    cmd.Parameters.Add(nameParam);
                    cmd.Parameters.Add(lengthParam);
                    cmd.Parameters.Add(slongParam);
                    cmd.Parameters.Add(slatParam);
                    cmd.Parameters.Add(elongParam);
                    cmd.Parameters.Add(elatParam);
                    cmd.Parameters.Add(marshParam);
                    cmd.Parameters.Add(asphParam);
                    cmd.Parameters.Add(hillParam);
                    cmd.Parameters.Add(forestParam);
                    cmd.Parameters.Add(flatParam);
                    cmd.Parameters.Add(signParam);

                    cmd.ExecuteNonQuery();

                    AddPOI(route.POIList);
                    AddStep(route.SequenceList);
                }
                catch (Exception e)
                {
                    l.WriteToLog("Error - AddRoute: " + e);
                    return "Er is iets fout gegaan bij het opslaan.";
                }
            }
            return "Succes! De route is opgeslagen.";
        }

        /// <summary>
        /// Add a route sequence to the database.
        /// </summary>
        /// <param name="seq"></param>
        /// <returns></returns>
        public void AddStep(List<Models.RouteSequence> seq)
        {
            Models.Logger l = new Models.Logger();
            l.WriteToLog("AddStep!");

            string query = ("INSERT INTO [RouteSequence] (RouteId, Number, Long, Lat) " +
                            "VALUES(@routeId, @step, @long, @lat)");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();


                    foreach (Models.RouteSequence s in seq)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);

                        // Create parameters
                        SqlParameter routeIdParam = new SqlParameter("@routeId", System.Data.SqlDbType.Int, 255);
                        SqlParameter stepParam = new SqlParameter("@step", System.Data.SqlDbType.Int, 255);
                        SqlParameter longParam = new SqlParameter("@long", System.Data.SqlDbType.Decimal, 255);
                        SqlParameter latParam = new SqlParameter("@lat", System.Data.SqlDbType.Decimal, 255);

                        // Fill parameters
                        routeIdParam.Value = s.RouteId;
                        stepParam.Value = s.StepNumber;
                        longParam.Value = s.Long;
                        latParam.Value = s.Lat;

                        // Add parameters
                        cmd.Parameters.Add(routeIdParam);
                        cmd.Parameters.Add(stepParam);
                        cmd.Parameters.Add(longParam);
                        cmd.Parameters.Add(latParam);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    l.WriteToLog("Error - AddStep: " + e);
                }
            }
        }

        /// <summary>
        /// Add a POI to the database.
        /// </summary>
        /// <param name="poi"></param>
        /// <returns></returns>
        public void AddPOI(List<Models.POI> poi)
        {
            Models.Logger l = new Models.Logger();
            l.WriteToLog("AddStep!");

            string query = ("INSERT INTO [POI] (RouteId, Name, Description, Long, Lat) " +
                            "VALUES(@routeId, @name, @descr, @long, @lat)");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    foreach (Models.POI p in poi)
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);

                        // Create parameters
                        SqlParameter routeIdParam = new SqlParameter("@routeId", System.Data.SqlDbType.Int, 255);
                        SqlParameter nameParam = new SqlParameter("@name", System.Data.SqlDbType.NVarChar, 255);
                        SqlParameter descrParam = new SqlParameter("@descr", System.Data.SqlDbType.NVarChar, 255);
                        SqlParameter longParam = new SqlParameter("@long", System.Data.SqlDbType.Decimal, 255);
                        SqlParameter latParam = new SqlParameter("@lat", System.Data.SqlDbType.Decimal, 255);

                        // Fill parameters
                        routeIdParam.Value = p.RouteId;
                        nameParam.Value = p.Name;
                        descrParam.Value = p.Description;
                        longParam.Value = p.Long;
                        latParam.Value = p.Lat;

                        // Add parameters
                        cmd.Parameters.Add(routeIdParam);
                        cmd.Parameters.Add(nameParam);
                        cmd.Parameters.Add(descrParam);
                        cmd.Parameters.Add(longParam);
                        cmd.Parameters.Add(latParam);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    l.WriteToLog("Error - AddStep: " + e);
                }
            }
        }
    }
}