using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Navi.WebApi.Models;

namespace Navi.WebApi.Migrations
{
    [DbContext(typeof(NaviDbContext))]
    [Migration("20160303135431_coordinates")]
    partial class coordinates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Navi.WebApi.Models.Coordinates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Altitude");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Navi.WebApi.Models.Locations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CoordinateId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("LocationName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Navi.WebApi.Models.Locations", b =>
                {
                    b.HasOne("Navi.WebApi.Models.Coordinates")
                        .WithMany()
                        .HasForeignKey("CoordinateId");
                });
        }
    }
}
