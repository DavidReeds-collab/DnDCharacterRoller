using Microsoft.EntityFrameworkCore.Migrations;

namespace CharacterRoller.Migrations
{
    public partial class initialsecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClassFeatures",
                keyColumn: "classFeatureId",
                keyValue: "fighterProficiencyChoice",
                column: "choiceId",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClassFeatures",
                keyColumn: "classFeatureId",
                keyValue: "fighterProficiencyChoice",
                column: "choiceId",
                value: "FighterProficiencyChoice");
        }
    }
}
