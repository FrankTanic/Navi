using Microsoft.AspNet.Mvc;
using Navi.WebApi.Models;
using Navi.WebApi.Repositories;

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
    }
}
