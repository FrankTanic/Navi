
using System.ComponentModel.DataAnnotations;

namespace Navi.WebApi.Models
{
    public class Coordinates
    {
        [Key]
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }

        public int LocationId { get; set; }
        public Locations Location { get; set; }
    }
}
