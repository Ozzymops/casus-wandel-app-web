using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WandelAppWeb.Controllers
{
    public class POIController : ApiController
    {
        Models.Database db = new Models.Database();

        /// <summary>
        /// GET: api/POI/GetPOI?id=1 
        /// Return a point-of-interest by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>POI</returns>
        [HttpGet]
        [Route("api/POI/GetPOI")]
        public Models.POI GetPOI(int id)
        {
            return db.ReturnPOI("SELECT * FROM [POI] WHERE [Id] = " + id);
        }

        /// <summary>
        /// GET: api/POI/GetPOIOfRoute?routeId=1 
        /// Return a POI bound to a route by a route's id.
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns>POI</returns>
        [HttpGet]
        [Route("api/POI/GetPOIOfRoute")]
        public List<Models.POI> GetPOIOfRoute(int routeId)
        {
            return db.ReturnPOIList("SELECT * FROM [POI] WHERE [RouteId] = " + routeId);
        }
    }
}
