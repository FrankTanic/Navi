using Microsoft.AspNet.Mvc;
using Navi.WebApi.Models;
using Navi.WebApi.Repositories;
using System.Collections.Generic;

namespace Navi.WebApi.Controllers
{
    public class LocationController : Controller
    {
        private readonly NaviDbContext _db;

        public LocationController(NaviDbContext db)
        {
            _db = db;
        }

        [Route("api/location")]
        [HttpGet]
        public Location GetLocation()
        {
            LocationRepository location = new LocationRepository(_db);

            var l = location.GetLocation(1);

            return l;
        }
        [Route("api/locations")]
        [HttpGet]
        public IList<Location> GetAllLocation()
        {
            LocationRepository location = new LocationRepository(_db);

            return location.GetAllLocations();
        }
    }
}
