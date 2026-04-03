using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DDDTemplate.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RouterLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "modules",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "router_link",
                table: "modules",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "modules",
                keyColumn: "id",
                keyValue: 1,
                column: "router_link",
                value: null);

            migrationBuilder.UpdateData(
                table: "modules",
                keyColumn: "id",
                keyValue: 2,
                column: "router_link",
                value: "usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "router_link",
                table: "modules");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "modules",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
