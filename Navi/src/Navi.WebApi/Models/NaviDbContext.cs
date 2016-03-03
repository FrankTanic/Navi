﻿using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace Navi.WebApi.Models
{
    public class NaviDbContext : DbContext
    {
        public NaviDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Locations> Location { get; set; }
        public DbSet<Coordinates> Coordinate { get; set; }
    }
}