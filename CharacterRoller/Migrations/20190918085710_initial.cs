using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CharacterRoller.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Proficient = table.Column<bool>(nullable: false),
                    BaseValue = table.Column<int>(nullable: false),
                    parentCharacterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

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
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
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
                    StrenghtImprovement = table.Column<int>(nullable: false),
                    DexterityImprovement = table.Column<int>(nullable: false),
                    ConstitutionImprovement = table.Column<int>(nullable: false),
                    IntelligenceImprovement = table.Column<int>(nullable: false),
                    WisdomImprovement = table.Column<int>(nullable: false),
                    CharismaImprovement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    parentCharacterId = table.Column<int>(nullable: false),
                    Proficient = table.Column<bool>(nullable: false),
                    Expertise = table.Column<bool>(nullable: false),
                    parentAbilityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Abilities_parentAbilityId",
                        column: x => x.parentAbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    choice = table.Column<bool>(nullable: false),
                    ClassId = table.Column<string>(nullable: true),
                    Feature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassFeatures", x => x.classFeatureId);
                    table.ForeignKey(
                        name: "FK_ClassFeatures_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
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
                    StrengthId = table.Column<string>(nullable: true),
                    DexterityId = table.Column<string>(nullable: true),
                    ConstitutionId = table.Column<string>(nullable: true),
                    IntelligenceId = table.Column<string>(nullable: true),
                    WisdomId = table.Column<string>(nullable: true),
                    CharismaId = table.Column<string>(nullable: true),
                    AcrobaticsId = table.Column<string>(nullable: true),
                    animalHandlingId = table.Column<string>(nullable: true),
                    ArcanaId = table.Column<string>(nullable: true),
                    AthleticsId = table.Column<string>(nullable: true),
                    DeceptionId = table.Column<string>(nullable: true),
                    HistoryId = table.Column<string>(nullable: true),
                    InsightId = table.Column<string>(nullable: true),
                    IntimidationId = table.Column<string>(nullable: true),
                    InvestigationId = table.Column<string>(nullable: true),
                    MedicineId = table.Column<string>(nullable: true),
                    NatureId = table.Column<string>(nullable: true),
                    PerceptionId = table.Column<string>(nullable: true),
                    PerformanceId = table.Column<string>(nullable: true),
                    PersuasionId = table.Column<string>(nullable: true),
                    ReligionId = table.Column<string>(nullable: true),
                    sleightOfHandId = table.Column<string>(nullable: true),
                    StealthId = table.Column<string>(nullable: true),
                    SuvivalId = table.Column<string>(nullable: true),
                    characterRaceId = table.Column<string>(nullable: true),
                    characterClassId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_AcrobaticsId",
                        column: x => x.AcrobaticsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_ArcanaId",
                        column: x => x.ArcanaId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_AthleticsId",
                        column: x => x.AthleticsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Abilities_CharismaId",
                        column: x => x.CharismaId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Abilities_ConstitutionId",
                        column: x => x.ConstitutionId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_DeceptionId",
                        column: x => x.DeceptionId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Abilities_DexterityId",
                        column: x => x.DexterityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_InsightId",
                        column: x => x.InsightId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Abilities_IntelligenceId",
                        column: x => x.IntelligenceId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_IntimidationId",
                        column: x => x.IntimidationId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_InvestigationId",
                        column: x => x.InvestigationId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_NatureId",
                        column: x => x.NatureId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_PerceptionId",
                        column: x => x.PerceptionId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_PersuasionId",
                        column: x => x.PersuasionId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_StealthId",
                        column: x => x.StealthId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Abilities_StrengthId",
                        column: x => x.StrengthId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_SuvivalId",
                        column: x => x.SuvivalId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Abilities_WisdomId",
                        column: x => x.WisdomId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characters_Skills_animalHandlingId",
                        column: x => x.animalHandlingId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_Characters_Skills_sleightOfHandId",
                        column: x => x.sleightOfHandId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "barbarian", "Barbarian" },
                    { "wizard", "Wizard" },
                    { "warlock", "Warlock" },
                    { "rogue", "Rogue" },
                    { "ranger", "Ranger" },
                    { "paladin", "Paladin" },
                    { "sorcerer", "Sorcerer" },
                    { "fighter", "Fighter" },
                    { "druid", "Druid" },
                    { "cleric", "Cleric" },
                    { "bard", "Bard" },
                    { "monk", "Monk" }
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
                    { "14", "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the Languages of other peoples they deal with, including obscure dialects. They are fond of sprinkling their Speech with words borrowed from other tongues: Orc curses, Elvish musical expressions, Dwarvish Military phrases, and so on.", "humanVariant", "Languages" },
                    { "4", "Humans vary widely in height and build, from barely 5 feet to well over 6 feet tall. Regardless of your position in that range, your size is Medium.", "human", "Size" },
                    { "3", "Humans tend toward no particular Alignment. The best and the worst are found among them.", "human", "Alignment" },
                    { "2", "Humans reach Adulthood in their late teens and live less than a century.", "human", "Age" },
                    { "1", "Your Ability Scores each increase by 1.", "human", "Abilities" },
                    { "13", "Your base walking speed is 30 feet.", "humanVariant", "Speed" },
                    { "5", "Your base walking speed is 30 feet.", "human", "Speed" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "CharismaImprovement", "ConstitutionImprovement", "DexterityImprovement", "IntelligenceImprovement", "Name", "StrenghtImprovement", "WisdomImprovement" },
                values: new object[,]
                {
                    { "human", 1, 1, 1, 1, "Human", 1, 1 },
                    { "humanVariant", 0, 0, 0, 0, "Human (Variant)", 0, 0 }
                });

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
                name: "IX_Characters_AcrobaticsId",
                table: "Characters",
                column: "AcrobaticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ArcanaId",
                table: "Characters",
                column: "ArcanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AthleticsId",
                table: "Characters",
                column: "AthleticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharismaId",
                table: "Characters",
                column: "CharismaId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ConstitutionId",
                table: "Characters",
                column: "ConstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_DeceptionId",
                table: "Characters",
                column: "DeceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_DexterityId",
                table: "Characters",
                column: "DexterityId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_HistoryId",
                table: "Characters",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InsightId",
                table: "Characters",
                column: "InsightId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_IntelligenceId",
                table: "Characters",
                column: "IntelligenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_IntimidationId",
                table: "Characters",
                column: "IntimidationId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_InvestigationId",
                table: "Characters",
                column: "InvestigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MedicineId",
                table: "Characters",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_NatureId",
                table: "Characters",
                column: "NatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PerceptionId",
                table: "Characters",
                column: "PerceptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PerformanceId",
                table: "Characters",
                column: "PerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PersuasionId",
                table: "Characters",
                column: "PersuasionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ReligionId",
                table: "Characters",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StealthId",
                table: "Characters",
                column: "StealthId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StrengthId",
                table: "Characters",
                column: "StrengthId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SuvivalId",
                table: "Characters",
                column: "SuvivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WisdomId",
                table: "Characters",
                column: "WisdomId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_animalHandlingId",
                table: "Characters",
                column: "animalHandlingId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_characterClassId",
                table: "Characters",
                column: "characterClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_characterRaceId",
                table: "Characters",
                column: "characterRaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_sleightOfHandId",
                table: "Characters",
                column: "sleightOfHandId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassFeatures_ClassId",
                table: "ClassFeatures",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_parentAbilityId",
                table: "Skills",
                column: "parentAbilityId");
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
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Abilities");
        }
    }
}
