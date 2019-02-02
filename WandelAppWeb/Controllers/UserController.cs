using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WandelAppWeb.Controllers
{
    /// <summary>
    /// The UserController contains all available methods for the User object.
    /// </summary>
    public class UserController : ApiController
    {
        private Models.Database db = new Models.Database();

        /// <summary>
        /// GET: api/User/GetName?id=1 
        /// Return the name of a found User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Name</returns>
        [Route("api/user/GetName")]
        [HttpGet]
        public string GetName(int id)
        {
            return db.ReturnSingleString("SELECT [Name] FROM [dbo].[User] WHERE [Id] = " + id);
        }

        /// <summary>
        /// GET: api/User/CheckIfUserExists?username=x&password=y
        /// Search for a User in the database.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Return true if found</returns>
        [Route("api/user/CheckIfUserExists")]
        [HttpGet]
        public bool CheckIfUserExists(string username, string password)
        {
            return db.ReturnSingleBoolean("SELECT [Id] FROM [dbo].[User] WHERE [Username] = '" + username + "' AND [Password] = '" + password + "'");
        }

        /// <summary>
        /// GET: api/User/LogIn?username=x&password=y
        /// Return a User object for logging in and transfering data to the application.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>User</returns>
        [Route("api/user/LogIn")]
        [HttpGet]
        public Models.User LogIn(string username, string password)
        {
            return db.ReturnUser("SELECT * FROM [dbo].[User] WHERE [Username] = '" + username + "' AND [Password] = '" + password + "'");
        }
    }
}
