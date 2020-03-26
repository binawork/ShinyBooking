using Microsoft.EntityFrameworkCore.Migrations;

namespace ShinyBooking.Data.Migrations
{
    public partial class RoomAddressId_column_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAddresses_Rooms_RoomId",
                table: "RoomAddresses");

            migrationBuilder.DropIndex(
                name: "IX_RoomAddresses_RoomId",
                table: "RoomAddresses");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RoomAddresses");

            migrationBuilder.AddColumn<string>(
                name: "RoomAddressId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomAddressId",
                table: "Rooms",
                column: "RoomAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomAddresses_RoomAddressId",
                table: "Rooms",
                column: "RoomAddressId",
                principalTable: "RoomAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomAddresses_RoomAddressId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomAddressId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomAddressId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoomId",
                table: "RoomAddresses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomAddresses_RoomId",
                table: "RoomAddresses",
                column: "RoomId",
                unique: true,
                filter: "[RoomId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAddresses_Rooms_RoomId",
                table: "RoomAddresses",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
