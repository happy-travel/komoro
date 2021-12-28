using System;
using System.Collections.Generic;
using HappyTravel.Komoro.Data.Models.Statics;
using HappyTravel.Money.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HappyTravel.Komoro.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CancellationPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    FromDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ToDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SeasonalityOrEvent = table.Column<string>(type: "text", nullable: true),
                    Deadline = table.Column<int>(type: "integer", nullable: false),
                    NoShow = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancellationPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SupplierId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<Address>(type: "jsonb", nullable: false),
                    Coordinates = table.Column<Point>(type: "geometry", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    StarRating = table.Column<int>(type: "integer", nullable: false),
                    PrimaryContact = table.Column<Contact>(type: "jsonb", nullable: false),
                    ReservationEmail = table.Column<string>(type: "text", nullable: false),
                    CheckInTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CheckOutTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    PassengerAge = table.Column<PassengerAge>(type: "jsonb", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    RoomTypeId = table.Column<int>(type: "integer", nullable: false),
                    StandardMealPlanId = table.Column<int>(type: "integer", nullable: false),
                    StandardOccupancy = table.Column<Occupancy>(type: "jsonb", nullable: false),
                    MaximumOccupancy = table.Column<List<Occupancy>>(type: "jsonb", nullable: false),
                    ExtraAdultSupplement = table.Column<MoneyAmount>(type: "jsonb", nullable: true),
                    ChildSupplement = table.Column<MoneyAmount>(type: "jsonb", nullable: true),
                    InfantSupplement = table.Column<MoneyAmount>(type: "jsonb", nullable: true),
                    RatePlans = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CancellationPolicies_PropertyId",
                table: "CancellationPolicies",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SupplierId",
                table: "Properties",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PropertyId",
                table: "Rooms",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancellationPolicies");

            migrationBuilder.DropTable(
                name: "MealPlans");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
