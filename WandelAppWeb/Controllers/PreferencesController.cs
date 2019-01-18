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
        // GET: api/Preferences
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
