using System.Linq;
using Navi.WebApi.Models;
using System.Collections.Generic;

namespace Navi.WebApi.Repositories
{
    public class LocationRepository
    {
        private readonly NaviDbContext _db;

        public LocationRepository(NaviDbContext db)
        {
            _db = db;
        }

        public Location GetLocation(int id)
        {
            var location = _db.Locations.Single(x => x.Id == id);

            return location ?? null;
        }

        public IList<Location> GetAllLocations()
        {

            return _db.Locations.ToList();
        }
    }
}
