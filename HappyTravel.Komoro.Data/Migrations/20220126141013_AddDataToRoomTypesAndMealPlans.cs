using System;
using HappyTravel.Komoro.Data.Models.Statics;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyTravel.Komoro.Data.Migrations
{
    public partial class AddDataToRoomTypesAndMealPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "RoomTypes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "RoomTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "Rooms",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "Properties",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "MealPlans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "CancellationPolicies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            var mealPlans = "MealPlans";
            migrationBuilder.InsertData(mealPlans, new string[] { "Id", "Name", "Created" }, new object[,]
                {
                    { 1, "Room Only", DateTimeOffset.UtcNow },
                    { 2, "Bed & Breakfast", DateTimeOffset.UtcNow }
                });

            var roomTypes = "RoomTypes";
            migrationBuilder.InsertData(roomTypes, new string[] { "Id", "Name", "Category", "Created" }, new object[,]
                {
                    { 1, "Armani Deluxe Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 2, "Armani Classic Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 3, "Armani Premiere Suite", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 4, "Armani Fountain Suite", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 5, "Armani Executive Suite", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 6, "Armani Signature Suite", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 7, "Armani One Bedroom Residence", RoomCategories.ResidenceRoom, DateTimeOffset.UtcNow },
                    { 8, "Deluxe Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 9, "Premier Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 10, "Premier Fountain View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 11, "Club Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 12, "Club Fountain View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 13, "Executive Suite", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 14, "Studio Residence", RoomCategories.ResidenceRoom, DateTimeOffset.UtcNow },
                    { 15, "One Bedroom Residence Fountain View", RoomCategories.ResidenceRoom, DateTimeOffset.UtcNow },
                    { 16, "One Bedroom Residence City View", RoomCategories.ResidenceRoom, DateTimeOffset.UtcNow },
                    { 17, "Deluxe Boulevard Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 18, "Superior Boulevard Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 19, "Premier Club", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 20, "Junior Suite", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 21, "Premier Suite", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 22, "Studio Residence STB", RoomCategories.ResidenceRoom, DateTimeOffset.UtcNow },
                    { 23, "One Bedroom Residence", RoomCategories.ResidenceRoom, DateTimeOffset.UtcNow },
                    { 24, "Two Bedroom Residence", RoomCategories.ResidenceRoom, DateTimeOffset.UtcNow },
                    { 25, "Three Bedroom Residence", RoomCategories.ResidenceRoom, DateTimeOffset.UtcNow },
                    { 26, "Deluxe Lake View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 27, "Deluxe Fountain View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 28, "Palace Lake View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 29, "Palace Fountain View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 30, "Junior Suite Lake View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 31, "Diplomatic Suite Lake View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 32, "Palace Suite Lake View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 33, "Palace Suite Fountain View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 34, "Deluxe Room Marina View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 35, "Grand Room Marina View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 36, "Premier Suite Marina View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 37, "Studio Residence", RoomCategories.ResidenceRoom, DateTimeOffset.UtcNow },
                    { 38, "Boulevard Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 39, "Boulevard Suite", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 40, "Executive Downtown Suite", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 41, "Premier Suite Fountain View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 42, "Executive Suite Fountain View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 43, "Premier Room Twin", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 44, "Premier King Sky View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 45, "Premier Twin Sky View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 46, "Club King Burj View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 47, "Club Twin Burj View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 48, "Executive Suite Sky View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 49, "Deluxe Golf View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 50, "Premier Suite Golf View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 51, "Executive Suite Golf View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 52, "Grand Executive Suite Golf View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 53, "Deluxe Marina View Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 54, "Deluxe Marina View Room Twin", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 55, "Deluxe Marina View with Balcony", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 56, "Premier Suite Corner Marina View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 57, "Executive Suite Marina View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 58, "Deluxe", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 59, "Deluxe Garden View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 60, "Deluxe Pool View ", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 61, "Executive Room", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 62, "Two Bedroom Boulevard Suite", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 63, "Deluxe Burj View", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 64, "Burj View Suite", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 65, "Deluxe Room King", RoomCategories.HotelRoom, DateTimeOffset.UtcNow },
                    { 66, "Deluxe Room Twin", RoomCategories.HotelRoom, DateTimeOffset.UtcNow }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "RoomTypes");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "RoomTypes",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "Rooms",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "Properties",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "MealPlans",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Modified",
                table: "CancellationPolicies",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");
        }
    }
}
