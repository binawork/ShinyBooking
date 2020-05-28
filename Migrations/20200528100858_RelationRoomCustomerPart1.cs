using Microsoft.EntityFrameworkCore.Migrations;

namespace ShinyBooking.Migrations
{
    public partial class RelationRoomCustomerPart1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Rooms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CustomerId",
                table: "Rooms",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Customers_CustomerId",
                table: "Rooms",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Customers_CustomerId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CustomerId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Rooms");
        }
    }
}
