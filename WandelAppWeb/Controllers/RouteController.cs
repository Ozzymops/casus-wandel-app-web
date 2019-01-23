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
        private Models.Database db = new Models.Database();

        /// <summary>
        /// GET: api/Route/GetRoute?id=1 
        /// Return a route by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A name</returns>
        [HttpGet]
        [Route("api/route/GetRoute")]
        public Models.Route GetRoute(int id)
        {
            // Get name based off of Id
            return db.ReturnRoute("SELECT * FROM [Route] WHERE [Id] = " + id);
        }

        /// <summary>
        /// Return all available Routes
        /// </summary>
        /// <returns>Route list</returns>
        [HttpGet]
        [Route("api/route/GetAllRoutes")]
        public List<Models.Route> GetAllRoutes()
        {
            // return all Routes
            return db.ReturnRouteList("SELECT * FROM [Route]");
        }

        /// <summary>
        /// GET: api/Route/GetRouteList?id=1 
        /// Return a list of routes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A name</returns>
        [HttpGet]
        [Route("api/route/GetRouteList")]
        public List<Models.Route> GetRoutesOfUser(int id)
        {
            // Get name based off of Id
            return db.ReturnRouteList("SELECT * FROM [Route] WHERE [OwnerId] = " + id);
        }

        /// <summary>
        /// GET: api/Route/GetRoute?id=1 
        /// Return the name of a found User.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A name</returns>
        [HttpGet]
        [Route("api/route/GetRoutesByDifficulty")]
        public List<Models.Route> GetRoutesByDifficulty(int difficulty)
        {
            // Get name based off of Id
            return db.ReturnRouteList("SELECT * FROM [Route] WHERE [Difficulty] >= " + (difficulty-1) + "AND [Difficulty] <= " + (difficulty+1));
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
