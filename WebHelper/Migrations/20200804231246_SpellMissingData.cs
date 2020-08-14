using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHelper.Migrations
{
    public partial class SpellMissingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CastTime",
                table: "Spells",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SavingThrow",
                table: "Spells",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpellResistance",
                table: "Spells",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CastTime",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "SavingThrow",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "SpellResistance",
                table: "Spells");
        }
    }
}
