using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poppers.Infrastructure.Migrations
{
    public partial class AddDeviceIdtoRefreshTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceID",
                schema: "popper",
                table: "RefreshTokens",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceID",
                schema: "popper",
                table: "RefreshTokens");
        }
    }
}
