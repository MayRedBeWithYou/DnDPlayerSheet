using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHelper.Migrations
{
    public partial class FeatChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecialRules",
                table: "Feats",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialRules",
                table: "Feats");
        }
    }
}
