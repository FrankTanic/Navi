using System;

namespace Navi.WebApi.Models
{
    public class Locations
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public DateTime Created { get; set; }
        public Coordinates Coordinate { get; set; }
    }
}