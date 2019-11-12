using Microsoft.EntityFrameworkCore.Migrations;

namespace CharacterRoller.Migrations
{
    public partial class secondsecondchoiceupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: "FighterFightingStyleChoice",
                column: "Type",
                value: "Feature");

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: "FighterProficiencyChoice",
                column: "Type",
                value: "Proficiency");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: "FighterFightingStyleChoice",
                column: "Type",
                value: null);

            migrationBuilder.UpdateData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: "FighterProficiencyChoice",
                column: "Type",
                value: null);
        }
    }
}
