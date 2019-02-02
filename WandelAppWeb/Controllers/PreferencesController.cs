using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WandelAppWeb.Controllers
{
    public class PreferencesController : ApiController
    {
        private Models.Database db = new Models.Database();

        /// <summary>
        /// GET: api/Preferences/GetPreferences?id=1 
        /// Return a Preferences object by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Preferences</returns>
        [HttpGet]
        [Route("api/Preferences/GetPreferences")]
        public Models.Preferences GetPreferences(int id)
        {
            return db.ReturnPreferences("SELECT * FROM [Preferences] WHERE [Id] = " + id);
        }

        /// <summary>
        /// GET: api/Preferences/GetPreferencesOfOwner?id=1 
        /// Return a Preferences object by its owner's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Preferences</returns>
        [HttpGet]
        [Route("api/Preferences/GetPreferencesOfOwner")]
        public Models.Preferences GetPreferencesOfOwner(int ownerId)
        {
            return db.ReturnPreferences("SELECT * FROM [Preferences] WHERE [OwnerId] = " + ownerId);
        }
    }
}
