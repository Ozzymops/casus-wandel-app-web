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
        /// Return a route by its id.
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
        /// Return a route by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>POI</returns>
        [HttpGet]
        [Route("api/POI/GetPOIOfRoute")]
        public List<Models.POI> GetPOIOfRoute(int routeId)
        {
            return db.ReturnPOIList("SELECT * FROM [POI] WHERE [RouteId] = " + routeId);
        }

        // POST: api/POI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/POI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/POI/5
        public void Delete(int id)
        {
        }
    }
}
