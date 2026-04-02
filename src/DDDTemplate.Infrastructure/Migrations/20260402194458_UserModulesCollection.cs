using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDTemplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserModulesCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "user_id1",
                table: "user_modules",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_modules_user_id1",
                table: "user_modules",
                column: "user_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_user_modules_users_user_id1",
                table: "user_modules",
                column: "user_id1",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_modules_users_user_id1",
                table: "user_modules");

            migrationBuilder.DropIndex(
                name: "ix_user_modules_user_id1",
                table: "user_modules");

            migrationBuilder.DropColumn(
                name: "user_id1",
                table: "user_modules");
        }
    }
}
