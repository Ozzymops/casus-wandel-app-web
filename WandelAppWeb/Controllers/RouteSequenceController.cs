using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WandelAppWeb.Controllers
{
    public class RouteSequenceController : ApiController
    {
        Models.Database db = new Models.Database();

        /// <summary>
        /// GET: api/RouteSequence/GetRouteSequence?id=1 
        /// Return a route sequence by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>RouteSequence</returns>
        [HttpGet]
        [Route("api/RouteSequence/GetRouteSequence")]
        public Models.RouteSequence GetRouteSequence(int id)
        {
            return db.ReturnRouteSequence("SELECT * FROM [RouteSequence] WHERE [Id] = " + id);
        }

        /// <summary>
        /// GET: api/POI/GetRouteSequenceOfRoute?routeId=1 
        /// Return a list of route sequences bound to a route.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>RouteSequence list</returns>
        [HttpGet]
        [Route("api/RouteSequence/GetRouteSequenceOfRoute")]
        public List<Models.RouteSequence> GetRouteSequenceOfRoute(int routeId)
        {
            return db.ReturnRouteSequenceList("SELECT * FROM [RouteSequence] WHERE [RouteId] = " + routeId);
        }
    }
}
