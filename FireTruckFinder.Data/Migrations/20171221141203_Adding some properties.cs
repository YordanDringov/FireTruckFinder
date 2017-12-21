using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FireTruckFinder.Data.Migrations
{
    public partial class Addingsomeproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "FirePumps",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "FirePumps",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "FireExtinguishers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "FirePumps");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FirePumps");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "FireExtinguishers");
        }
    }
}
