using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PumpItUp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRoleColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_users_UserId",
                table: "role");

            migrationBuilder.DropIndex(
                name: "IX_role_UserId",
                table: "role");

            migrationBuilder.AddColumn<long>(
                name: "RoleId",
                table: "users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "IX_role_UserId",
                table: "role",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_role_users_UserId",
                table: "role",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
