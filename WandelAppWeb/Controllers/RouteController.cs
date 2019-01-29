using Newtonsoft.Json;
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
        /// GET: api/Route/GetRoutesByDifficulty?difficulty=1
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

        [HttpPost]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [Route("api/route/AddRoute")]
        public string AddRoute(string json)
        {
            // decode json
            Models.Route route = JsonConvert.DeserializeObject<Models.Route>(json);
            Models.Logger l = new Models.Logger();
            l.WriteToLog(route.Name);
            //return db.AddRoute ("INSERT INTO [Route] (OwnerId, Difficulty, Name, Length, StartLong, StartLat, EndLong, EndLat, Marshiness, RouteAsphalted, HillType, ForestDensity, RouteFlatness, RoadSigns) " +
            //                   "VALUES(" + route.OwnerId + ", '" + route.Difficulty + "', '" + route.Name + "', '" + route.Length + "', '" + route.StartLong + "', '" + route.StartLat + "', '" + route.EndLong + "', '" + route.EndLat + "', 1, 1, 1, 1, 1, 1)");
            return db.AddRoute(route);
        }
    }
}
