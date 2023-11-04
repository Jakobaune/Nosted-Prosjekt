using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NostedServicePro.Migrations
{
    /// <inheritdoc />
    public partial class Sjekkliste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Arbeidstimer",
                table: "service",
                type: "double",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kommentar",
                table: "service",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arbeidstimer",
                table: "service");

            migrationBuilder.DropColumn(
                name: "Kommentar",
                table: "service");
        }
    }
}
