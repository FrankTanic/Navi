using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Navi.WebApi.Models;

namespace Navi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LocationsController : Controller
    {
        private readonly NaviDbContext _db;

        public LocationsController(NaviDbContext db)
        {
            _db = db;
        }

        // Get all locations
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Location> locations = _db.Locations.ToList();

            return new HttpOkObjectResult(locations);
        }

        // GET location
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Location location = _db.Locations.SingleOrDefault(l => l.Id == id);

            if (location == null)
            {
                return new HttpNotFoundResult();
            }

            return new HttpOkObjectResult(location);
        }

        // POST location
        [HttpPost]
        public IActionResult Post([FromBody]Location location)
        {
            if (location == null)
            {
                return new BadRequestResult();
            }

            _db.Add(location);
            _db.SaveChanges();

            return new HttpOkObjectResult(location);
        }

        // PUT location
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Location location)
        {
            if (location == null)
            {
                return new BadRequestResult();
            }

            _db.Update(location);
            _db.SaveChanges();

            return new HttpOkResult();
        }

        // DELETE location
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Location location = _db.Locations.SingleOrDefault(l => l.Id == id);

            if (location == null)
            {
                return new HttpNotFoundResult();
            }

            _db.Remove(location);
            _db.SaveChanges();

            return new HttpOkResult();
        }
    }
}
