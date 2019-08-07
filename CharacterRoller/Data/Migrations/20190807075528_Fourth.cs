using Microsoft.EntityFrameworkCore.Migrations;

namespace CharacterRoller.Data.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Proficient",
                table: "Abilities",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proficient",
                table: "Abilities");
        }
    }
}
