﻿// <auto-generated />
using DungeonMaster.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DungeonMaster.Data.Migrations
{
    [DbContext(typeof(DungeonMasterDevContext))]
    [Migration("20180424233458_AddCharacterAbilityScoreFK")]
    partial class AddCharacterAbilityScoreFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DungeonMaster.Data.Models.AbilityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AbilityType");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Background", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BackgroundTypeId")
                        .HasColumnName("BackgroundType_Id");

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Background");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age");

                    b.Property<int>("BackgroundId")
                        .HasColumnName("Background_Id");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<decimal?>("Copper")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<decimal?>("Electrum")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<decimal?>("Gold")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<int?>("Height");

                    b.Property<int>("Level");

                    b.Property<decimal?>("Platinum")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int>("RaceId")
                        .HasColumnName("Race_Id");

                    b.Property<decimal?>("Silver")
                        .HasColumnType("numeric(18, 0)");

                    b.Property<int?>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("BackgroundId");

                    b.HasIndex("RaceId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.CharacterAbilityScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AbilityTypeId")
                        .HasColumnName("AbilityType_Id");

                    b.Property<int>("CharacterId")
                        .HasColumnName("Character_Id");

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Character_AbilityScore");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Dndclass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CharacterId");

                    b.Property<int>("ClassTypeId")
                        .HasColumnName("ClassType_Id");

                    b.Property<string>("Desription")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ParentClassId")
                        .HasColumnName("ParentClass_Id");

                    b.Property<int?>("SubClassTypeId")
                        .HasColumnName("SubClassType_Id");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("ParentClassId");

                    b.ToTable("DNDClass");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Dndskill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AbilityTypeId")
                        .HasColumnName("AbilityType_Id");

                    b.Property<int>("SkillTypeId")
                        .HasColumnName("SkillType_Id");

                    b.HasKey("Id");

                    b.HasIndex("AbilityTypeId");

                    b.ToTable("DNDSkill");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<int>("FeatureTypeId")
                        .HasColumnName("FeatureType_Id");

                    b.Property<string>("Summary")
                        .HasColumnType("ntext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("IX_Feature");

                    b.ToTable("Feature");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Proficiency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SavingThrowTypeId")
                        .HasColumnName("SavingThrowType_Id");

                    b.Property<int>("SkillTypeId")
                        .HasColumnName("SkillType_Id");

                    b.HasKey("Id");

                    b.HasIndex("SavingThrowTypeId");

                    b.ToTable("Proficiency");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("BaseSpeed");

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ParentRaceId")
                        .HasColumnName("ParentRace_Id");

                    b.Property<int>("RaceTypeId")
                        .HasColumnName("RaceType_Id");

                    b.Property<int?>("SubRaceTypeId")
                        .HasColumnName("SubRaceType_Id");

                    b.HasKey("Id");

                    b.HasIndex("ParentRaceId");

                    b.ToTable("Race");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Character", b =>
                {
                    b.HasOne("DungeonMaster.Data.Models.Background", "Background")
                        .WithMany("Character")
                        .HasForeignKey("BackgroundId")
                        .HasConstraintName("FK_Character_Background");

                    b.HasOne("DungeonMaster.Data.Models.Race", "Race")
                        .WithMany("Character")
                        .HasForeignKey("RaceId")
                        .HasConstraintName("FK_Character_Race");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.CharacterAbilityScore", b =>
                {
                    b.HasOne("DungeonMaster.Data.Models.Character")
                        .WithMany("AbilityScores")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DungeonMaster.Data.Models.AbilityType", "AbilityType")
                        .WithOne("CharacterAbilityScore")
                        .HasForeignKey("DungeonMaster.Data.Models.CharacterAbilityScore", "Id")
                        .HasConstraintName("FK_Character_AbilityScore_AbilityType");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Dndclass", b =>
                {
                    b.HasOne("DungeonMaster.Data.Models.Character")
                        .WithMany("Classes")
                        .HasForeignKey("CharacterId");

                    b.HasOne("DungeonMaster.Data.Models.Dndclass", "ParentClass")
                        .WithMany("ChildClass")
                        .HasForeignKey("ParentClassId")
                        .HasConstraintName("FK_Class_ParentClass");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Dndskill", b =>
                {
                    b.HasOne("DungeonMaster.Data.Models.AbilityType", "AbilityType")
                        .WithMany("Dndskill")
                        .HasForeignKey("AbilityTypeId")
                        .HasConstraintName("FK_DNDSkill_AbilityType");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Proficiency", b =>
                {
                    b.HasOne("DungeonMaster.Data.Models.AbilityType", "SavingThrowType")
                        .WithMany("Proficiency")
                        .HasForeignKey("SavingThrowTypeId")
                        .HasConstraintName("FK_Proficiency_SavingThrow");
                });

            modelBuilder.Entity("DungeonMaster.Data.Models.Race", b =>
                {
                    b.HasOne("DungeonMaster.Data.Models.Race", "ParentRace")
                        .WithMany("InverseParentRace")
                        .HasForeignKey("ParentRaceId")
                        .HasConstraintName("FK_Race_ParentRace");
                });
#pragma warning restore 612, 618
        }
    }
}
