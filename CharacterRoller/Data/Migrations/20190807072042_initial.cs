using Microsoft.EntityFrameworkCore.Migrations;

namespace CharacterRoller.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
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
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
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
                    raceId = table.Column<string>(nullable: true),
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
                        name: "FK_Characters_Races_raceId",
                        column: x => x.raceId,
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
                name: "IX_Characters_raceId",
                table: "Characters",
                column: "raceId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_sleightOfHandId",
                table: "Characters",
                column: "sleightOfHandId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_parentAbilityId",
                table: "Skills",
                column: "parentAbilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Abilities");
        }
    }
}
