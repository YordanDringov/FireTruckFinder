using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FireTruckFinder.Data.Migrations
{
    public partial class ChangeModelentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireTrucks_FirePumps_PumpId",
                table: "FireTrucks");

            migrationBuilder.DropForeignKey(
                name: "FK_FireTrucks_Sales_SaleId",
                table: "FireTrucks");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_FireTrucks_PumpId",
                table: "FireTrucks");

            migrationBuilder.DropIndex(
                name: "IX_FireTrucks_SaleId",
                table: "FireTrucks");

            migrationBuilder.DropColumn(
                name: "PumpId",
                table: "FireTrucks");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "FireTrucks");

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "FireTrucks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerId",
                table: "FirePumps",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FireExtinguishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(nullable: false),
                    SellerId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireExtinguishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireExtinguishers_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FireTrucks_SellerId",
                table: "FireTrucks",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_FirePumps_SellerId",
                table: "FirePumps",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_FireExtinguishers_SellerId",
                table: "FireExtinguishers",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirePumps_AspNetUsers_SellerId",
                table: "FirePumps",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FireTrucks_AspNetUsers_SellerId",
                table: "FireTrucks",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirePumps_AspNetUsers_SellerId",
                table: "FirePumps");

            migrationBuilder.DropForeignKey(
                name: "FK_FireTrucks_AspNetUsers_SellerId",
                table: "FireTrucks");

            migrationBuilder.DropTable(
                name: "FireExtinguishers");

            migrationBuilder.DropIndex(
                name: "IX_FireTrucks_SellerId",
                table: "FireTrucks");

            migrationBuilder.DropIndex(
                name: "IX_FirePumps_SellerId",
                table: "FirePumps");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "FireTrucks");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "FirePumps");

            migrationBuilder.AddColumn<int>(
                name: "PumpId",
                table: "FireTrucks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "FireTrucks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FireTruckId = table.Column<int>(nullable: false),
                    SellerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FireTrucks_PumpId",
                table: "FireTrucks",
                column: "PumpId");

            migrationBuilder.CreateIndex(
                name: "IX_FireTrucks_SaleId",
                table: "FireTrucks",
                column: "SaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SellerId",
                table: "Sales",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FireTrucks_FirePumps_PumpId",
                table: "FireTrucks",
                column: "PumpId",
                principalTable: "FirePumps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireTrucks_Sales_SaleId",
                table: "FireTrucks",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
