using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WandelAppWeb.Controllers
{
    public class RouteController : ApiController
    {
        private Models.Database db = new Models.Database();

        /// <summary>
        /// GET: api/Route/GetRoute?id=1 
        /// Return a route by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Route</returns>
        [HttpGet]
        [Route("api/route/GetRoute")]
        public Models.Route GetRoute(int id)
        {
            return db.ReturnRoute("SELECT * FROM [Route] WHERE [Id] = " + id);
        }

        /// <summary>
        /// GET: api/Route/GetAllRoutes
        /// Return all available Routes
        /// </summary>
        /// <returns>Route list</returns>
        [HttpGet]
        [Route("api/route/GetAllRoutes")]
        public List<Models.Route> GetAllRoutes()
        {
            return db.ReturnRouteList("SELECT * FROM [Route]");
        }

        /// <summary>
        /// GET: api/Route/GetRoutesOfUser?id=1 
        /// Return a list of routes made by a user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Route list</returns>
        [HttpGet]
        [Route("api/route/GetRoutesOfUser")]
        public List<Models.Route> GetRoutesOfUser(int id)
        {
            return db.ReturnRouteList("SELECT * FROM [Route] WHERE [OwnerId] = " + id);
        }

        /// <summary>
        /// GET: api/Route/GetLastId
        /// Return the id of the last route in the database.
        /// </summary>
        /// <returns>id</returns>
        [HttpGet]
        [Route("api/route/GetLastId")]
        public int GetLastId()
        {
            return db.ReturnSingleInt("SELECT TOP 1 [Id] FROM [Route] ORDER BY ID DESC");
        }

        /// <summary>
        /// POST: api/Route/AddRoute?json=...
        /// Save a route to the database including its sequence and points-of-interest.
        /// </summary>
        /// <param name="json"></param>
        /// <returns>Status string</returns>
        [HttpPost]
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [Route("api/route/AddRoute")]
        public string AddRoute(string json)
        {
            Models.Route route = JsonConvert.DeserializeObject<Models.Route>(json);
            Models.Logger l = new Models.Logger();
            l.WriteToLog(route.Name);
            return db.AddRoute(route);
        }
    }
}
