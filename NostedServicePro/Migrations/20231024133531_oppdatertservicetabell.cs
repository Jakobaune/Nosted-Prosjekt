using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NostedServicePro.Migrations
{
    /// <inheritdoc />
    public partial class oppdatertservicetabell : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Brukere");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProduktmottattDato",
                table: "service",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AvtaltleveringsDato",
                table: "service",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Avtaltferdigstillingsdato",
                table: "service",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "ProduktmottattDato",
                table: "service",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "AvtaltleveringsDato",
                table: "service",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Avtaltferdigstillingsdato",
                table: "service",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Brukere",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
