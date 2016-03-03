using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Navi.WebApi.Migrations
{
    public partial class coordinatesrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Locations_Coordinates_CoordinateId", table: "Locations");
            migrationBuilder.DropColumn(name: "CoordinateId", table: "Locations");
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Coordinates",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Coordinates_Locations_LocationId",
                table: "Coordinates",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Coordinates_Locations_LocationId", table: "Coordinates");
            migrationBuilder.DropColumn(name: "LocationId", table: "Coordinates");
            migrationBuilder.AddColumn<int>(
                name: "CoordinateId",
                table: "Locations",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Coordinates_CoordinateId",
                table: "Locations",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
