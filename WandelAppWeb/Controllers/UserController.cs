using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WandelAppWeb.Controllers
{
    public class UserController : ApiController
    {
        private Models.Database db = new Models.Database();

        // POST: api/User/AddUser?name=x&username=x&password=y
        [HttpPost]
        public bool AddUser(string username, string password)
        {
            // Add user to db
            return db.ReturnSingleBoolean("SELECT * FROM [dbo].[User]");
        }

        // GET: api/User/GetName?id=1
        [HttpGet]
        public string GetName(int id)
        {
            // Get name based off of Id
            return db.ReturnSingleString("SELECT [Name] FROM [dbo].[User] WHERE [Id] = " + id);
        }

        // GET: api/User/CheckIfUserExists?username=x&password=y
        [Route("api/user/CheckIfUserExists")]
        [HttpGet]
        public bool CheckIfUserExists(string username, string password)
        {
            // Search user in db
            return db.ReturnSingleBoolean("SELECT [Id] FROM [dbo].[User] WHERE [Username] = '" + username + "' AND [Password] = '" + password + "'");
        }

        // GET: api/User/LogIn?username=x&password=y
        [Route("api/user/LogIn")]
        [HttpGet]
        public Models.User LogIn(string username, string password)
        {
            // Retrieve User as json from db
            return db.ReturnUser("SELECT * FROM [dbo].[User] WHERE [Username] = '" + username + "' AND [Password] = '" + password + "'");
        }

        // DELETE: api/User/DeleteUser
        [HttpDelete]
        public bool DeleteUser()
        {
            // Remove user from db
            return false;
        }

        // PUT: api/User/EditPassword
        [HttpPut]
        public bool EditPassword()
        {
            // Edit password of user in db
            return true;
        }
    }
}
