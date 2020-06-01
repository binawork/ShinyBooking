using Microsoft.EntityFrameworkCore.Migrations;

namespace ShinyBooking.Migrations
{
    public partial class TryFoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "IdentityId1",
            //    table: "Customers");

            //migrationBuilder.DropColumn(
            //    name: "CustomerIdentityId",
            //    table: "Rooms");

            //migrationBuilder.DropIndex(
            //    name: "IX_Rooms_CustomerIdentityId",
            //    table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            //migrationBuilder.DropIndex(
            //    name: "IX_Customers_IdentityId1",
            //    table: "Customers");

            //migrationBuilder.DropColumn(
            //    name: "CustomerIdentityId",
            //    table: "Rooms");

            //migrationBuilder.DropColumn(
            //    name: "IdentityId1",
            //    table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Customers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityId",
                table: "Customers",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_IdentityId",
                table: "Customers",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_IdentityId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_IdentityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "CustomerIdentityId",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "IdentityId1",
            //    table: "Customers",
            //    type: "nvarchar(450)",
            //    nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CustomerIdentityId",
                table: "Rooms",
                column: "CustomerIdentityId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Customers_IdentityId1",
            //    table: "Customers",
            //    column: "IdentityId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Customers_AspNetUsers_IdentityId1",
            //    table: "Customers",
            //    column: "IdentityId1",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Customers_CustomerIdentityId",
                table: "Rooms",
                column: "CustomerIdentityId",
                principalTable: "Customers",
                principalColumn: "IdentityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
