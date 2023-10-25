using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loginnosted.Migrations
{
    /// <inheritdoc />
    public partial class LeggTilSjekklisteFullført : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "XXBar",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Wire",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TrekkraftKn",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TestVinsjAlleFunksjoner",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TestHydraulikkblokk",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SlangerSkaderLekkasje",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SkiftOljeTank",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SkiftOljeGirboks",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkTestRadio",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkTestKnappekasse",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "RingsyllingerSkiftTelnlnger",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PlnlonLager",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PTOOpplagring",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LedningsnettVinsj",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LagerTrommel",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Kjedestrammer",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "KilleKjedehjul",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "HydraulikkSylinderLekkasje",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ClutchLameller",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BremsesylingerSkiftTelninger",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Bremser",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BremsekraftKn",
                table: "service",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "ErSjekklisteFullført",
                table: "service",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErSjekklisteFullført",
                table: "service");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "XXBar",
                keyValue: null,
                column: "XXBar",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "XXBar",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "Wire",
                keyValue: null,
                column: "Wire",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Wire",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "TrekkraftKn",
                keyValue: null,
                column: "TrekkraftKn",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TrekkraftKn",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "TestVinsjAlleFunksjoner",
                keyValue: null,
                column: "TestVinsjAlleFunksjoner",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TestVinsjAlleFunksjoner",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "TestHydraulikkblokk",
                keyValue: null,
                column: "TestHydraulikkblokk",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TestHydraulikkblokk",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "SlangerSkaderLekkasje",
                keyValue: null,
                column: "SlangerSkaderLekkasje",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SlangerSkaderLekkasje",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "SkiftOljeTank",
                keyValue: null,
                column: "SkiftOljeTank",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SkiftOljeTank",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "SkiftOljeGirboks",
                keyValue: null,
                column: "SkiftOljeGirboks",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SkiftOljeGirboks",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "SjekkTestRadio",
                keyValue: null,
                column: "SjekkTestRadio",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkTestRadio",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "SjekkTestKnappekasse",
                keyValue: null,
                column: "SjekkTestKnappekasse",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SjekkTestKnappekasse",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "RingsyllingerSkiftTelnlnger",
                keyValue: null,
                column: "RingsyllingerSkiftTelnlnger",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "RingsyllingerSkiftTelnlnger",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "PlnlonLager",
                keyValue: null,
                column: "PlnlonLager",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PlnlonLager",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "PTOOpplagring",
                keyValue: null,
                column: "PTOOpplagring",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PTOOpplagring",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "LedningsnettVinsj",
                keyValue: null,
                column: "LedningsnettVinsj",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "LedningsnettVinsj",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "LagerTrommel",
                keyValue: null,
                column: "LagerTrommel",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "LagerTrommel",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "Kjedestrammer",
                keyValue: null,
                column: "Kjedestrammer",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Kjedestrammer",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "KilleKjedehjul",
                keyValue: null,
                column: "KilleKjedehjul",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "KilleKjedehjul",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "HydraulikkSylinderLekkasje",
                keyValue: null,
                column: "HydraulikkSylinderLekkasje",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "HydraulikkSylinderLekkasje",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "ClutchLameller",
                keyValue: null,
                column: "ClutchLameller",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ClutchLameller",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "BremsesylingerSkiftTelninger",
                keyValue: null,
                column: "BremsesylingerSkiftTelninger",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "BremsesylingerSkiftTelninger",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "Bremser",
                keyValue: null,
                column: "Bremser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Bremser",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "service",
                keyColumn: "BremsekraftKn",
                keyValue: null,
                column: "BremsekraftKn",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "BremsekraftKn",
                table: "service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
