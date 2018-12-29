using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Diagnostics;

using WandelAppWeb.Models;

namespace WandelAppWeb.Services
{
    public class UserRepository
    {
        public User GetCorrectUser(string username, string password)
        {
            //return new User { Id = 1, Name = "Justin Muris" };
            string query = "SELECT [Id], [Name] FROM [dbo].[User] WHERE [Username] = '" + username + "' AND [Password] = '" + password + "'";
            string connString = "Data Source = localhost; Initial Catalog = WandelAppDb; Integrated Security = True";
            using (SqlConnection conn = new SqlConnection(connString))
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
                            return new User { Id = reader.GetInt32(0), Name = reader.GetString(1) };
                        }
                    }
                }
                catch (Exception e)
                {
                    // ignore
                    Debug.WriteLine("Foutje!" + e);
                }
            }
            return null;
        }
    }
}