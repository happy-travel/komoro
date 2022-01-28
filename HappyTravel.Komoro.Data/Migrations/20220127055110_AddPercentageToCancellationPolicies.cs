using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyTravel.Komoro.Data.Migrations
{
    public partial class AddPercentageToCancellationPolicies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Percentage",
                table: "CancellationPolicies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.DeleteData("RoomTypes", "Id", 37);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "CancellationPolicies");
        }
    }
}
