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

            var utcNow = DateTimeOffset.UtcNow;
            var mealPlans = "MealPlans";
            migrationBuilder.InsertData(mealPlans, new string[] { "Id", "Name", "Created", "Modified" }, new object[,]
                {
                    { 1, "Room Only", utcNow, utcNow },
                    { 2, "Bed & Breakfast", utcNow, utcNow }
                });

            var roomTypes = "RoomTypes";
            migrationBuilder.InsertData(roomTypes, new string[] { "Id", "Name", "Category", "Created", "Modified" }, new object[,]
                {
                    { 1, "Armani Deluxe Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 2, "Armani Classic Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 3, "Armani Premiere Suite", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 4, "Armani Fountain Suite", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 5, "Armani Executive Suite", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 6, "Armani Signature Suite", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 7, "Armani One Bedroom Residence", (int)RoomCategories.ResidenceRoom, utcNow, utcNow },
                    { 8, "Deluxe Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 9, "Premier Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 10, "Premier Fountain View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 11, "Club Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 12, "Club Fountain View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 13, "Executive Suite", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 14, "Studio Residence", (int)RoomCategories.ResidenceRoom, utcNow, utcNow },
                    { 15, "One Bedroom Residence Fountain View", (int)RoomCategories.ResidenceRoom, utcNow, utcNow },
                    { 16, "One Bedroom Residence City View", (int)RoomCategories.ResidenceRoom, utcNow, utcNow },
                    { 17, "Deluxe Boulevard Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 18, "Superior Boulevard Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 19, "Premier Club", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 20, "Junior Suite", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 21, "Premier Suite", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 22, "Studio Residence STB", (int)RoomCategories.ResidenceRoom, utcNow, utcNow },
                    { 23, "One Bedroom Residence", (int)RoomCategories.ResidenceRoom, utcNow, utcNow },
                    { 24, "Two Bedroom Residence", (int)RoomCategories.ResidenceRoom, utcNow, utcNow },
                    { 25, "Three Bedroom Residence", (int)RoomCategories.ResidenceRoom, utcNow, utcNow },
                    { 26, "Deluxe Lake View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 27, "Deluxe Fountain View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 28, "Palace Lake View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 29, "Palace Fountain View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 30, "Junior Suite Lake View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 31, "Diplomatic Suite Lake View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 32, "Palace Suite Lake View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 33, "Palace Suite Fountain View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 34, "Deluxe Room Marina View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 35, "Grand Room Marina View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 36, "Premier Suite Marina View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 37, "Studio Residence", (int)RoomCategories.ResidenceRoom, utcNow, utcNow },
                    { 38, "Boulevard Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 39, "Boulevard Suite", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 40, "Executive Downtown Suite", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 41, "Premier Suite Fountain View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 42, "Executive Suite Fountain View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 43, "Premier Room Twin", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 44, "Premier King Sky View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 45, "Premier Twin Sky View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 46, "Club King Burj View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 47, "Club Twin Burj View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 48, "Executive Suite Sky View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 49, "Deluxe Golf View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 50, "Premier Suite Golf View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 51, "Executive Suite Golf View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 52, "Grand Executive Suite Golf View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 53, "Deluxe Marina View Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 54, "Deluxe Marina View Room Twin", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 55, "Deluxe Marina View with Balcony", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 56, "Premier Suite Corner Marina View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 57, "Executive Suite Marina View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 58, "Deluxe", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 59, "Deluxe Garden View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 60, "Deluxe Pool View ", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 61, "Executive Room", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 62, "Two Bedroom Boulevard Suite", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 63, "Deluxe Burj View", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 64, "Burj View Suite", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 65, "Deluxe Room King", (int)RoomCategories.HotelRoom, utcNow, utcNow },
                    { 66, "Deluxe Room Twin", (int)RoomCategories.HotelRoom, utcNow, utcNow }
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
