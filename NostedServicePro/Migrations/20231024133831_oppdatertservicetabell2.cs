using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NostedServicePro.Migrations
{
    /// <inheritdoc />
    public partial class oppdatertservicetabell2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BremsekraftKn",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Bremser",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BremsesylingerSkiftTelninger",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ClutchLameller",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HydraulikkSylinderLekkasje",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "KilleKjedehjul",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Kjedestrammer",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LagerTrommel",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LedningsnettVinsj",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PTOOpplagring",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PlnlonLager",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RingsyllingerSkiftTelnlnger",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SjekkTestKnappekasse",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SjekkTestRadio",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SkiftOljeGirboks",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SkiftOljeTank",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SlangerSkaderLekkasje",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TestHydraulikkblokk",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TestVinsjAlleFunksjoner",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TrekkraftKn",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Wire",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "XXBar",
                table: "service",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BremsekraftKn",
                table: "service");

            migrationBuilder.DropColumn(
                name: "Bremser",
                table: "service");

            migrationBuilder.DropColumn(
                name: "BremsesylingerSkiftTelninger",
                table: "service");

            migrationBuilder.DropColumn(
                name: "ClutchLameller",
                table: "service");

            migrationBuilder.DropColumn(
                name: "HydraulikkSylinderLekkasje",
                table: "service");

            migrationBuilder.DropColumn(
                name: "KilleKjedehjul",
                table: "service");

            migrationBuilder.DropColumn(
                name: "Kjedestrammer",
                table: "service");

            migrationBuilder.DropColumn(
                name: "LagerTrommel",
                table: "service");

            migrationBuilder.DropColumn(
                name: "LedningsnettVinsj",
                table: "service");

            migrationBuilder.DropColumn(
                name: "PTOOpplagring",
                table: "service");

            migrationBuilder.DropColumn(
                name: "PlnlonLager",
                table: "service");

            migrationBuilder.DropColumn(
                name: "RingsyllingerSkiftTelnlnger",
                table: "service");

            migrationBuilder.DropColumn(
                name: "SjekkTestKnappekasse",
                table: "service");

            migrationBuilder.DropColumn(
                name: "SjekkTestRadio",
                table: "service");

            migrationBuilder.DropColumn(
                name: "SkiftOljeGirboks",
                table: "service");

            migrationBuilder.DropColumn(
                name: "SkiftOljeTank",
                table: "service");

            migrationBuilder.DropColumn(
                name: "SlangerSkaderLekkasje",
                table: "service");

            migrationBuilder.DropColumn(
                name: "TestHydraulikkblokk",
                table: "service");

            migrationBuilder.DropColumn(
                name: "TestVinsjAlleFunksjoner",
                table: "service");

            migrationBuilder.DropColumn(
                name: "TrekkraftKn",
                table: "service");

            migrationBuilder.DropColumn(
                name: "Wire",
                table: "service");

            migrationBuilder.DropColumn(
                name: "XXBar",
                table: "service");
        }
    }
}
