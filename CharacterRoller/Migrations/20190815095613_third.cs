using Microsoft.EntityFrameworkCore.Migrations;

namespace CharacterRoller.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanAbilities",
                column: "Feature",
                value: "Your Ability Scores each increase by 1.");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanAge",
                column: "Feature",
                value: "Humans reach Adulthood in their late teens and live less than a century.");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanAlignment",
                column: "Feature",
                value: "Humans tend toward no particular Alignment. The best and the worst are found among them.");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanLanguages",
                column: "Feature",
                value: "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish Military phrases, and so on.");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanSize",
                column: "Feature",
                value: "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium.");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanSpeed",
                column: "Feature",
                value: "Your base walking speed is 30 feet.");

            migrationBuilder.InsertData(
                table: "RaceFeatures",
                columns: new[] { "raceFeatureId", "Feature", "race" },
                values: new object[,]
                {
                    { "Human(variant)Abilities", "Two different ability scores of your choice increase by 1.", "Human(variant)" },
                    { "Human(variant)Skills", "You gain proficiency in one skill of your choice.", "Human(variant)" },
                    { "Human(variant)Feat", "You gain one Feat of your choice.", "Human(variant)" },
                    { "Human(variant)Age", "Humans reach Adulthood in their late teens and live less than a century.", "Human(variant)" },
                    { "Human(variant)Alignment", "Humans tend toward no particular Alignment. The best and the worst are found among them.", "Human(variant)" },
                    { "Human(variant)Size", "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium.", "Human(variant)" },
                    { "Human(variant)Speed", "Your base walking speed is 30 feet.", "Human(variant)" },
                    { "Human(variant)Languages", "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish Military phrases, and so on.", "Human(variant)" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "CharismaImprovement", "ConstitutionImprovement", "DexterityImprovement", "IntelligenceImprovement", "StrenghtImprovement", "WisdomImprovement" },
                values: new object[] { "Human(variant)", 0, 0, 0, 0, 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "Human(variant)Abilities");

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "Human(variant)Age");

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "Human(variant)Alignment");

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "Human(variant)Feat");

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "Human(variant)Languages");

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "Human(variant)Size");

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "Human(variant)Skills");

            migrationBuilder.DeleteData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "Human(variant)Speed");

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "Id",
                keyValue: "Human(variant)");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanAbilities",
                column: "Feature",
                value: "Ability Score Increase: Your Ability Scores each increase by 1.");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanAge",
                column: "Feature",
                value: "Age: Humans reach Adulthood in their late teens and live less than a century.");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanAlignment",
                column: "Feature",
                value: "Alignment: Humans tend toward no particular Alignment. The best and the worst are found among them.");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanLanguages",
                column: "Feature",
                value: "Languages: You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish Military phrases, and so on.");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanSize",
                column: "Feature",
                value: "Size: Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium.");

            migrationBuilder.UpdateData(
                table: "RaceFeatures",
                keyColumn: "raceFeatureId",
                keyValue: "HumanSpeed",
                column: "Feature",
                value: "Speed: Your base walking speed is 30 feet.");
        }
    }
}
