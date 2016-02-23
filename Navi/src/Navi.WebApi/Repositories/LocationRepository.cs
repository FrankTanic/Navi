using System.Linq;
using Navi.WebApi.Models;

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
    }
}
