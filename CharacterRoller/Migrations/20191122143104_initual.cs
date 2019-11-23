using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CharacterRoller.Migrations
{
    public partial class initual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Options = table.Column<string>(nullable: true),
                    AllowedNumberOfOptions = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CharacterId = table.Column<int>(nullable: true),
                    ChosenFeatures = table.Column<string>(nullable: true),
                    ProficiencyChoice_CharacterId = table.Column<int>(nullable: true),
                    ChosenProficiencies = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AbilityScoreImprovements = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceFeatures",
                columns: table => new
                {
                    raceFeatureName = table.Column<string>(nullable: true),
                    raceFeatureId = table.Column<string>(nullable: false),
                    race = table.Column<string>(nullable: true),
                    Feature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceFeatures", x => x.raceFeatureId);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AbilityScoreImprovements = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassFeatures",
                columns: table => new
                {
                    classFeatureId = table.Column<string>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    choiceId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Feature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassFeatures", x => x.classFeatureId);
                    table.ForeignKey(
                        name: "FK_ClassFeatures_Choices_choiceId",
                        column: x => x.choiceId,
                        principalTable: "Choices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Proficiencies = table.Column<string>(nullable: true),
                    Expertises = table.Column<string>(nullable: true),
                    StrenghtBase = table.Column<int>(nullable: false),
                    DexterityBase = table.Column<int>(nullable: false),
                    ConstitutionBase = table.Column<int>(nullable: false),
                    IntelligenceBase = table.Column<int>(nullable: false),
                    WisdomBase = table.Column<int>(nullable: false),
                    CharismaBase = table.Column<int>(nullable: false),
                    characterRaceId = table.Column<string>(nullable: true),
                    characterClassId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Classes_characterClassId",
                        column: x => x.characterClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Races_characterRaceId",
                        column: x => x.characterRaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "AllowedNumberOfOptions", "Discriminator", "Options", "Type" },
                values: new object[,]
                {
                    { "FighterProficiencyChoice", 2, "Choice", "Acrobatics,Animal Handling,Athletics,History,Insight,Intimidation,Perception,Survival", "Proficiency" },
                    { "FighterFightingStyleChoice", 1, "Choice", "Archery: You gain a + 2 bonus to Attack rolls you make with Ranged Weapons.,Defense: While you are wearing armor you gain a + 1 bonus to AC.,Dueling: When you are wielding a melee weapon in one hand and no other Weapons you gain a + 2 bonus to Damage Rolls with that weapon.Great Weapon Fighting: When you roll a 1 or 2 on a damage die for an Attack you make with a melee weapon that you are wielding with two hands you can reroll the die and must use the new roll even if the new roll is a 1 or a 2. The weapon must have the Two - Handed or Versatile property for you to gain this benefit.,Protection: When a creature you can see attacks a target other than you that is within 5 feet of you you can use your Reaction to impose disadvantage on the Attack roll. You must be wielding a Shield.,Two-Weapon Fighting: When you engage in two-weapon fighting you can add your ability modifier to the damage of the second Attack.", "Feature" }
                });

            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "classFeatureId", "Class", "Feature", "Level", "Name", "choiceId" },
                values: new object[,]
                {
                    { "FighterSecondWind", "fighter", "You have a limited well of stamina that you can draw on to protect yourself from harm. On your turn you can use a bonus action to regain hit points equal to 1d10 + your fighter level.Once you use this feature you must finish a short or long rest before you can use it again.", 0, "Second Wind", null },
                    { "FighterActionSurge", "fighter", "Starting at 2nd level, you can push yourself beyond your normal limits for a moment. On your turn, you can take one additional action on top of your regular action and a possible bonus action. Once you use this feature, you must finish a short or long rest before you can use it again. Starting at 17th level, you can use it twice before a rest, but only once on the same turn.", 2, "Action Surge", null }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "AbilityScoreImprovements", "Name" },
                values: new object[,]
                {
                    { "cleric", null, "Cleric" },
                    { "bard", null, "Bard" },
                    { "barbarian", null, "Barbarian" },
                    { "warlock", null, "Warlock" },
                    { "sorcerer", null, "Sorcerer" },
                    { "rogue", null, "Rogue" },
                    { "wizard", null, "Wizard" },
                    { "paladin", null, "Paladin" },
                    { "monk", null, "Monk" },
                    { "fighter", null, "Fighter" },
                    { "druid", null, "Druid" },
                    { "ranger", null, "Ranger" }
                });

            migrationBuilder.InsertData(
                table: "RaceFeatures",
                columns: new[] { "raceFeatureId", "Feature", "race", "raceFeatureName" },
                values: new object[,]
                {
                    { "7", "Two different ability scores of your choice increase by 1.", "humanVariant", "Abilities" },
                    { "12", "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium.", "humanVariant", "Size" },
                    { "11", "Humans tend toward no particular Alignment. The best and the worst are found among them.", "humanVariant", "Alignment" },
                    { "10", "Humans reach Adulthood in their late teens and live less than a century.", "humanVariant", "Age" },
                    { "9", "You gain one Feat of your choice.", "humanVariant", "Feat" },
                    { "8", "You gain proficiency in one skill of your choice.", "humanVariant", "Skills" },
                    { "6", "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish Military phrases, and so on.", "human", "Languages" },
                    { "", "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish Military phrases, and so on.", "humanVariant", "Languages" },
                    { "4", "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium.", "human", "Size" },
                    { "3", "Humans tend toward no particular Alignment. The best and the worst are found among them.", "human", "Alignment" },
                    { "2", "Humans reach Adulthood in their late teens and live less than a century.", "human", "Age" },
                    { "1", "Your Ability Scores each increase by 1.", "human", "Abilities" },
                    { "13", "Your base walking speed is 30 feet.", "humanVariant", "Speed" },
                    { "5", "Your base walking speed is 30 feet.", "human", "Speed" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "AbilityScoreImprovements", "Name" },
                values: new object[,]
                {
                    { "human", "Strenght_1_Racial|Dexterity_1_Racial|Constitution_1_Racial|Intelligence_1_Racial|Wisdom_1_Racial|Charisma_1_Racial", "Human" },
                    { "humanVariant", null, "Human (Variant)" }
                });

            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "classFeatureId", "Class", "Feature", "Level", "Name", "choiceId" },
                values: new object[] { "fighterProficiencyChoice", "fighter", "Skills: Choose two Skills from Acrobatics, Animal Handling, Athletics, History, Insight, Intimidation, Perception, and Survival", 0, "Proficiencies", "FighterProficiencyChoice" });

            migrationBuilder.InsertData(
                table: "ClassFeatures",
                columns: new[] { "classFeatureId", "Class", "Feature", "Level", "Name", "choiceId" },
                values: new object[] { "FighterFightingStyle", "fighter", "Archery: You gain a + 2 bonus to Attack rolls you make with Ranged Weapons.,Defense: While you are wearing armor you gain a + 1 bonus to AC.,Dueling: When you are wielding a melee weapon in one hand and no other Weapons you gain a + 2 bonus to Damage Rolls with that weapon.Great Weapon Fighting: When you roll a 1 or 2 on a damage die for an Attack you make with a melee weapon that you are wielding with two hands you can reroll the die and must use the new roll even if the new roll is a 1 or a 2. The weapon must have the Two - Handed or Versatile property for you to gain this benefit.,Protection: When a creature you can see attacks a target other than you that is within 5 feet of you you can use your Reaction to impose disadvantage on the Attack roll. You must be wielding a Shield.,Two-Weapon Fighting: When you engage in two-weapon fighting you can add your ability modifier to the damage of the second Attack.", 0, "Fighting style", "FighterFightingStyleChoice" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_characterClassId",
                table: "Characters",
                column: "characterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_characterRaceId",
                table: "Characters",
                column: "characterRaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeatures_choiceId",
                table: "ClassFeatures",
                column: "choiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "ClassFeatures");

            migrationBuilder.DropTable(
                name: "RaceFeatures");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Choices");
        }
    }
}
