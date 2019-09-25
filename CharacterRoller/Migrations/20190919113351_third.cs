using Microsoft.EntityFrameworkCore.Migrations;

namespace CharacterRoller.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassFeatures_Classes_ClassId",
                table: "ClassFeatures");

            migrationBuilder.DropIndex(
                name: "IX_ClassFeatures_ClassId",
                table: "ClassFeatures");

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "14");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "ClassFeatures",
                newName: "Class");

            migrationBuilder.AlterColumn<string>(
                name: "Class",
                table: "ClassFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "RaceFeatures",
                columns: new[] { "raceFeatureId", "Feature", "race", "raceFeatureName" },
                values: new object[] { "", "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish Military phrases, and so on.", "humanVariant", "Languages" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "ClassFeatures",
                newName: "ClassId");

            migrationBuilder.AlterColumn<string>(
                name: "ClassId",
                table: "ClassFeatures",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "RaceFeatures",
                columns: new[] { "raceFeatureId", "Feature", "race", "raceFeatureName" },
                values: new object[] { "14", "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish Military phrases, and so on.", "humanVariant", "Languages" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeatures_ClassId",
                table: "ClassFeatures",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassFeatures_Classes_ClassId",
                table: "ClassFeatures",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
