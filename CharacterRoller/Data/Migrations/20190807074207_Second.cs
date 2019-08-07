using Microsoft.EntityFrameworkCore.Migrations;

namespace CharacterRoller.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "parentCharacterId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BaseValue",
                table: "Abilities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "parentCharacterId",
                table: "Abilities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "parentCharacterId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "BaseValue",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "parentCharacterId",
                table: "Abilities");
        }
    }
}
