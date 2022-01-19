using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyTravel.Komoro.Data.Migrations
{
    public partial class AddRelationToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "RoomTypes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Modified",
                table: "RoomTypes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealPlanId",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "MealPlans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Modified",
                table: "MealPlans",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_MealPlanId",
                table: "Rooms",
                column: "MealPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_StandardMealPlanId",
                table: "Rooms",
                column: "StandardMealPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_CancellationPolicies_Properties_PropertyId",
                table: "CancellationPolicies",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_MealPlans_MealPlanId",
                table: "Rooms",
                column: "MealPlanId",
                principalTable: "MealPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Properties_StandardMealPlanId",
                table: "Rooms",
                column: "StandardMealPlanId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CancellationPolicies_Properties_PropertyId",
                table: "CancellationPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_MealPlans_MealPlanId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Properties_StandardMealPlanId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomTypes_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_MealPlanId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_StandardMealPlanId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "MealPlanId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "MealPlans");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "MealPlans");
        }
    }
}
