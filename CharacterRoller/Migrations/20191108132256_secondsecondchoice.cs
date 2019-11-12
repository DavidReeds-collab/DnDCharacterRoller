using Microsoft.EntityFrameworkCore.Migrations;

namespace CharacterRoller.Migrations
{
    public partial class secondsecondchoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Choices",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "AllowedNumberOfOptions", "Discriminator", "Options", "Type" },
                values: new object[] { "FighterFightingStyleChoice", 1, "Choice", "Archery: You gain a + 2 bonus to Attack rolls you make with Ranged Weapons.,Defense: While you are wearing armor you gain a + 1 bonus to AC.,Dueling: When you are wielding a melee weapon in one hand and no other Weapons you gain a + 2 bonus to Damage Rolls with that weapon.Great Weapon Fighting: When you roll a 1 or 2 on a damage die for an Attack you make with a melee weapon that you are wielding with two hands you can reroll the die and must use the new roll even if the new roll is a 1 or a 2. The weapon must have the Two - Handed or Versatile property for you to gain this benefit.,Protection: When a creature you can see attacks a target other than you that is within 5 feet of you you can use your Reaction to impose disadvantage on the Attack roll. You must be wielding a Shield.,Two-Weapon Fighting: When you engage in two-weapon fighting you can add your ability modifier to the damage of the second Attack.", null });

            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "classFeatureId", "Class", "Feature", "Level", "choiceId" },
                values: new object[] { "FighterFightingStyle", "fighter", "Archery: You gain a + 2 bonus to Attack rolls you make with Ranged Weapons.,Defense: While you are wearing armor you gain a + 1 bonus to AC.,Dueling: When you are wielding a melee weapon in one hand and no other Weapons you gain a + 2 bonus to Damage Rolls with that weapon.Great Weapon Fighting: When you roll a 1 or 2 on a damage die for an Attack you make with a melee weapon that you are wielding with two hands you can reroll the die and must use the new roll even if the new roll is a 1 or a 2. The weapon must have the Two - Handed or Versatile property for you to gain this benefit.,Protection: When a creature you can see attacks a target other than you that is within 5 feet of you you can use your Reaction to impose disadvantage on the Attack roll. You must be wielding a Shield.,Two-Weapon Fighting: When you engage in two-weapon fighting you can add your ability modifier to the damage of the second Attack.", 0, "FighterFightingStyleChoice" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassFeatures",
                keyColumn: "classFeatureId",
                keyValue: "FighterFightingStyle");

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: "FighterFightingStyleChoice");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Choices");
        }
    }
}
