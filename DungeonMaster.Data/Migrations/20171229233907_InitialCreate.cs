using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbilityType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BackgroundType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeatureType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubClassType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubClassType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubRaceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRaceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Character_AbilityScore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbilityType_Id = table.Column<int>(nullable: false),
                    Character_Id = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character_AbilityScore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_AbilityScore_AbilityType",
                        column: x => x.Id,
                        principalTable: "AbilityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Background",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BackgroundType_Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Background", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Background_BackgroundType",
                        column: x => x.BackgroundType_Id,
                        principalTable: "BackgroundType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "ntext", nullable: false),
                    FeatureType_Id = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(type: "ntext", nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature_FeatureType",
                        column: x => x.FeatureType_Id,
                        principalTable: "FeatureType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DNDSkill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbilityType_Id = table.Column<int>(nullable: false),
                    SkillType_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNDSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DNDSkill_AbilityType",
                        column: x => x.AbilityType_Id,
                        principalTable: "AbilityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DNDSkill_SkillType",
                        column: x => x.SkillType_Id,
                        principalTable: "SkillType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proficiency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SavingThrowType_Id = table.Column<int>(nullable: false),
                    SkillType_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proficiency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proficiency_SavingThrow",
                        column: x => x.SavingThrowType_Id,
                        principalTable: "AbilityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proficiency_SkillType",
                        column: x => x.SkillType_Id,
                        principalTable: "SkillType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DNDClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassType_Id = table.Column<int>(nullable: false),
                    Desription = table.Column<string>(type: "ntext", nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ParentClass_Id = table.Column<int>(nullable: true),
                    SubClassType_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNDClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DNDClass_ClassType",
                        column: x => x.ClassType_Id,
                        principalTable: "ClassType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Class_ParentClass",
                        column: x => x.ParentClass_Id,
                        principalTable: "DNDClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DNDClass_SubClassType",
                        column: x => x.SubClassType_Id,
                        principalTable: "SubClassType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseSpeed = table.Column<short>(nullable: false),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ParentRace_Id = table.Column<int>(nullable: true),
                    RaceType_Id = table.Column<int>(nullable: false),
                    SubRaceType_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Race_ParentRace",
                        column: x => x.ParentRace_Id,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Race_RaceType",
                        column: x => x.RaceType_Id,
                        principalTable: "RaceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Race_SubRaceType",
                        column: x => x.SubRaceType_Id,
                        principalTable: "SubRaceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: true),
                    Background_Id = table.Column<int>(nullable: false),
                    CharacterName = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Copper = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Electrum = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Gold = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Height = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Platinum = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    PlayerName = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Race_Id = table.Column<int>(nullable: false),
                    Silver = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    Weight = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Background",
                        column: x => x.Background_Id,
                        principalTable: "Background",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Character_Race",
                        column: x => x.Race_Id,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Background_BackgroundType_Id",
                table: "Background",
                column: "BackgroundType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Character_Background_Id",
                table: "Character",
                column: "Background_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Character_Race_Id",
                table: "Character",
                column: "Race_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DNDClass_ClassType_Id",
                table: "DNDClass",
                column: "ClassType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DNDClass_ParentClass_Id",
                table: "DNDClass",
                column: "ParentClass_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DNDClass_SubClassType_Id",
                table: "DNDClass",
                column: "SubClassType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DNDSkill_AbilityType_Id",
                table: "DNDSkill",
                column: "AbilityType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DNDSkill_SkillType_Id",
                table: "DNDSkill",
                column: "SkillType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feature_FeatureType_Id",
                table: "Feature",
                column: "FeatureType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Feature",
                table: "Feature",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Proficiency_SavingThrowType_Id",
                table: "Proficiency",
                column: "SavingThrowType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Proficiency_SkillType_Id",
                table: "Proficiency",
                column: "SkillType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Race_ParentRace_Id",
                table: "Race",
                column: "ParentRace_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Race_RaceType_Id",
                table: "Race",
                column: "RaceType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Race_SubRaceType_Id",
                table: "Race",
                column: "SubRaceType_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Character_AbilityScore");

            migrationBuilder.DropTable(
                name: "DNDClass");

            migrationBuilder.DropTable(
                name: "DNDSkill");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "Proficiency");

            migrationBuilder.DropTable(
                name: "Background");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "ClassType");

            migrationBuilder.DropTable(
                name: "SubClassType");

            migrationBuilder.DropTable(
                name: "FeatureType");

            migrationBuilder.DropTable(
                name: "AbilityType");

            migrationBuilder.DropTable(
                name: "SkillType");

            migrationBuilder.DropTable(
                name: "BackgroundType");

            migrationBuilder.DropTable(
                name: "RaceType");

            migrationBuilder.DropTable(
                name: "SubRaceType");
        }
    }
}
