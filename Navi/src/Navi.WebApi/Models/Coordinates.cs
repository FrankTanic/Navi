
namespace Navi.WebApi.Models
{
    public class Coordinates
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }
        public int LocationForeignKey { get; set; }
        public Locations Location { get; set; }
    }
}
