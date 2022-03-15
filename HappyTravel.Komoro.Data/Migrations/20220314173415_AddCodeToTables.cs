using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyTravel.Komoro.Data.Migrations
{
    public partial class AddCodeToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RoomTypes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_Code",
                table: "RoomTypes",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Code",
                table: "Properties",
                column: "Code");

            var tableProperties = "Properties";
            var keyColumn = "Name";
            var column = "Code";
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Address Downtown", column, "16954");
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Palace  Downtown", column, "17035");
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Address Fountain View", column, "108321");
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Address Sky View", column, "108317");
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Vida Emirates Hills", column, "108314");
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Vida Creek Harbour", column, "108319");
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Armani Hotel Dubai", column, "73769");
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Address Dubai Mall", column, "17147");
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Address Dubai Marina", column, "73168");
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Address Boulevard", column, "99931");
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Vida Downtown", column, "74253");
            migrationBuilder.UpdateData(tableProperties, keyColumn, "Manzil  Downtown", column, "74254");

            var tableRoomTypes = "RoomTypes";
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Armani Deluxe Room", column, "STU");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Armani Classic Room", column, "CLK");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Armani Premiere Suite", column, "PRV");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Armani Fountain Suite", column, "SUK");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Armani Executive Suite", column, "EXK");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Armani Signature Suite", column, "SIK");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Deluxe Room", column, "DLX");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Deluxe Boulevard Room", column, "DLB");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Superior Boulevard Room", column, "SBK");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Premier Room", column, "PRE");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Premier Club", column, "PRB");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Club Room", column, "CLK");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Junior Suite", column, "JSU");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Premier Suite", column, "PSU");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "Deluxe Room Marina View", column, "DMK");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
            migrationBuilder.UpdateData(tableRoomTypes, keyColumn, "", column, "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomTypes_Code",
                table: "RoomTypes");

            migrationBuilder.DropIndex(
                name: "IX_Properties_Code",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Properties");
        }
    }
}
