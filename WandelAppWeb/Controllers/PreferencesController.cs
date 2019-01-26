using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WandelAppWeb.Controllers
{
    /// <summary>
    /// The PreferencesController contains all available methods for the Preferences object.
    /// </summary>
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
            // Get name based off of Id
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
            // Get name based off of Id
            return db.ReturnPreferences("SELECT * FROM [Preferences] WHERE [OwnerId] = " + ownerId);
        }

        // GET: api/Preferences/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Preferences
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Preferences/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Preferences/5
        public void Delete(int id)
        {
        }
    }
}
