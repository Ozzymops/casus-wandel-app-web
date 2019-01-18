using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WandelAppWeb.Controllers
{
    /// <summary>
    /// The RouteController contains all available methods for the Route object.
    /// </summary>
    public class RouteController : ApiController
    {
        // GET: api/Route
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Route/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Route
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Route/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Route/5
        public void Delete(int id)
        {
        }
    }
}
