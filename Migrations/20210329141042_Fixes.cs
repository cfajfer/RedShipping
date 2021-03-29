using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RedShipping.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carriers");

            migrationBuilder.DropTable(
                name: "Freights");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropColumn(
                name: "carrier",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "endLoc",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "shipper",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "startLoc",
                table: "Shipments");

            migrationBuilder.AddColumn<int>(
                name: "endLocation",
                table: "Shipments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Shipments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "startLocation",
                table: "Shipments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "weight",
                table: "Shipments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endLocation",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "startLocation",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "Shipments");

            migrationBuilder.AddColumn<int>(
                name: "freight",
                table: "Shippers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "location",
                table: "Shippers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "carrier",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Shipments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "endLoc",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "shipper",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "startLoc",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cost = table.Column<int>(type: "int", nullable: false),
                    hazard = table.Column<bool>(type: "bit", nullable: false),
                    location = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Freights",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hazard = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freights", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });
        }
    }
}
