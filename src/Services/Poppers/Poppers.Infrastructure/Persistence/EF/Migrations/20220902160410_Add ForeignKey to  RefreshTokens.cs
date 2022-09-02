using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poppers.Infrastructure.Migrations
{
    public partial class AddForeignKeytoRefreshTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "popper",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                schema: "popper",
                table: "RefreshTokens",
                column: "UserId",
                principalSchema: "popper",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                schema: "popper",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "popper",
                table: "RefreshTokens");
        }
    }
}
