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

        #region POST
        /// <summary>
        /// POST: api/User/AddUser?name=x&username=x&password=y
        /// Add a User to the database.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Status</returns>
        [HttpPost]
        public bool AddUser(string username, string password)
        {
            // Add user to db
            return db.ReturnSingleBoolean("SELECT * FROM [dbo].[User]");
        }
        #endregion
        #region GET
        /// <summary>
        /// GET: api/User/GetName?id=1 
        /// Return the name of a found User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A name</returns>
        [HttpGet]
        public string GetName(int id)
        {
            // Get name based off of Id
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
            // Search for user in db, return true if found
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
            // Retrieve User as json from db
            return db.ReturnUser("SELECT * FROM [dbo].[User] WHERE [Username] = '" + username + "' AND [Password] = '" + password + "'");
        }
        #endregion
        #region DELETE
        /// <summary>
        /// DELETE: api/User/DeleteUser
        /// Delete a User from the database.
        /// </summary>
        /// <returns>Status</returns>
        [HttpDelete]
        public bool DeleteUser()
        {
            // Remove user from db
            return false;
        }
        #endregion
        #region PUT
        /// <summary>
        /// PUT: api/User/EditPassword
        /// Edit the password of a User in the database.
        /// </summary>
        /// <returns>Status</returns>
        [HttpPut]
        public bool EditPassword()
        {
            // Edit password of user in db
            return true;
        }
        #endregion
    }
}
