using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Navi.WebApi.Models;
using Microsoft.Data.Entity;

namespace Navi.WebApi.Controllers
{
    [Route("api/locations")]
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
            IEnumerable<Locations> locations = _db.Location.Include(c => c.Coordinate).ToList();

            return new HttpOkObjectResult(locations);
        }

        // GET location
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Locations location = _db.Location.Include(c => c.Coordinate).SingleOrDefault(l => l.Id == id);

            if (location == null)
            {
                return new HttpNotFoundResult();
            }

            return new HttpOkObjectResult(location);
        }

        // POST location
        [HttpPost]
        public IActionResult Post([FromBody]Locations location)
        {
            if (location == null)
            {
                return new BadRequestResult();
            }

            location.Created = DateTime.UtcNow;

            _db.Add(location);
            _db.SaveChanges();

            return new CreatedAtActionResult("Post", "Locations", new { id = location.Id }, location);
        }

        // PUT location
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Locations location)
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
            Locations location = _db.Location.SingleOrDefault(l => l.Id == id);

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
