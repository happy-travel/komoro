using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyTravel.Komoro.Data.Migrations
{
    public partial class SupplierIdChangedToSupplierCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Properties_SupplierId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SupplierCode",
                table: "Properties",
                column: "SupplierCode");

            migrationBuilder.Sql("UPDATE \"Properties\" SET \"SupplierCode\" = 'travelClick'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Properties_SupplierCode",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Properties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SupplierId",
                table: "Properties",
                column: "SupplierId");
        }
    }
}
