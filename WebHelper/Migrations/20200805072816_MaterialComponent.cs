using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHelper.Migrations
{
    public partial class MaterialComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaterialComponent",
                table: "Spells",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialComponent",
                table: "Spells");
        }
    }
}
