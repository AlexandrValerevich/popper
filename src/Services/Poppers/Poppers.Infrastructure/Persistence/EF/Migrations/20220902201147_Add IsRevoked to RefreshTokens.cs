using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poppers.Infrastructure.Migrations
{
    public partial class AddIsRevokedtoRefreshTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeviceID",
                schema: "popper",
                table: "RefreshTokens",
                newName: "DeviceId");

            migrationBuilder.AddColumn<bool>(
                name: "IsRevoked",
                schema: "popper",
                table: "RefreshTokens",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRevoked",
                schema: "popper",
                table: "RefreshTokens");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                schema: "popper",
                table: "RefreshTokens",
                newName: "DeviceID");
        }
    }
}
