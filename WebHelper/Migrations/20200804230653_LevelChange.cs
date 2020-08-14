using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHelper.Migrations
{
    public partial class LevelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpellAvailability");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Spells",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Spells");

            migrationBuilder.CreateTable(
                name: "SpellAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    SpellId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpellAvailability_Spells_SpellId",
                        column: x => x.SpellId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpellAvailability_SpellId",
                table: "SpellAvailability",
                column: "SpellId");
        }
    }
}
