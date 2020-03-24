using Microsoft.EntityFrameworkCore.Migrations;

namespace ShinyBooking.Data.Migrations
{
    public partial class AddRoomDisabledAmenities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rooms",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "ParkingSpaces",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoomArrangementsCapabilitiesDescription",
                table: "Rooms",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "RoomAddresses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "RoomAddresses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "RoomAddresses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Directions",
                table: "RoomAddresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "RoomAddresses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber1",
                table: "RoomAddresses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber2",
                table: "RoomAddresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebPage",
                table: "RoomAddresses",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Photos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmenitiesForDisabled",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenitiesForDisabled", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomActivities",
                columns: table => new
                {
                    ActivitiesId = table.Column<string>(nullable: false),
                    RoomId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomActivities", x => new { x.RoomId, x.ActivitiesId });
                    table.ForeignKey(
                        name: "FK_RoomActivities_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomActivities_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenitiesForDisabled",
                columns: table => new
                {
                    AmenitiesForDisabledId = table.Column<string>(nullable: false),
                    RoomId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenitiesForDisabled", x => new { x.RoomId, x.AmenitiesForDisabledId });
                    table.ForeignKey(
                        name: "FK_RoomAmenitiesForDisabled_AmenitiesForDisabled_AmenitiesForDisabledId",
                        column: x => x.AmenitiesForDisabledId,
                        principalTable: "AmenitiesForDisabled",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenitiesForDisabled_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomActivities_ActivitiesId",
                table: "RoomActivities",
                column: "ActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenitiesForDisabled_AmenitiesForDisabledId",
                table: "RoomAmenitiesForDisabled",
                column: "AmenitiesForDisabledId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomActivities");

            migrationBuilder.DropTable(
                name: "RoomAmenitiesForDisabled");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AmenitiesForDisabled");

            migrationBuilder.DropColumn(
                name: "ParkingSpaces",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomArrangementsCapabilitiesDescription",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Directions",
                table: "RoomAddresses");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "RoomAddresses");

            migrationBuilder.DropColumn(
                name: "PhoneNumber1",
                table: "RoomAddresses");

            migrationBuilder.DropColumn(
                name: "PhoneNumber2",
                table: "RoomAddresses");

            migrationBuilder.DropColumn(
                name: "WebPage",
                table: "RoomAddresses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "RoomAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "RoomAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "RoomAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
