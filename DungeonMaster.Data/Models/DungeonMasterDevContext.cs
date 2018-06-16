﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DungeonMaster.Data.Models
{
    public partial class DungeonMasterDevContext : DbContext
    {
        public virtual DbSet<AbilityType> AbilityType { get; set; }
        public virtual DbSet<Background> Background { get; set; }
        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<CharacterAbilityScore> CharacterAbilityScore { get; set; }
        public virtual DbSet<Dndclass> Dndclass { get; set; }
        public virtual DbSet<Dndskill> Dndskill { get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<Proficiency> Proficiency { get; set; }
        public virtual DbSet<Race> Race { get; set; }

        // Unable to generate entity type for table 'dbo.Character_Class'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Race_Feature'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Class_Feature'. Please see the warning messages.

        public DungeonMasterDevContext(DbContextOptions<DungeonMasterDevContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbilityType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Background>(entity =>
            {
                entity.Property(e => e.BackgroundTypeId).HasColumnName("BackgroundType_Id");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.BackgroundId).HasColumnName("Background_Id");

                entity.Property(e => e.CharacterName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Copper).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Electrum).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Gold).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Platinum).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PlayerName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RaceId).HasColumnName("Race_Id");

                entity.Property(e => e.Silver).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Background)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.BackgroundId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Character_Background");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Character_Race");
            });

            modelBuilder.Entity<CharacterAbilityScore>(entity =>
            {
                entity.ToTable("Character_AbilityScore");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.AbilityTypeId).HasColumnName("AbilityType_Id");

                entity.Property(e => e.CharacterId).HasColumnName("Character_Id");

                entity.HasOne(d => d.AbilityType)
                    .WithOne(p => p.CharacterAbilityScore)
                    .HasForeignKey<CharacterAbilityScore>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Character_AbilityScore_AbilityType");
            });

            modelBuilder.Entity<Dndclass>(entity =>
            {
                entity.ToTable("DNDClass");

                entity.Property(e => e.ClassTypeId).HasColumnName("ClassType_Id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentClassId).HasColumnName("ParentClass_Id");

                entity.Property(e => e.SubClassTypeId).HasColumnName("SubClassType_Id");

                entity.HasOne(d => d.ParentClass)
                    .WithMany(p => p.ChildClass)
                    .HasForeignKey(d => d.ParentClassId)
                    .HasConstraintName("FK_Class_ParentClass");

            });

            modelBuilder.Entity<Dndskill>(entity =>
            {
                entity.ToTable("DNDSkill");

                entity.Property(e => e.AbilityTypeId).HasColumnName("AbilityType_Id");

                entity.Property(e => e.SkillTypeId).HasColumnName("SkillType_Id");

                entity.HasOne(d => d.AbilityType)
                    .WithMany(p => p.Dndskill)
                    .HasForeignKey(d => d.AbilityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DNDSkill_AbilityType");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_Feature");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.FeatureTypeId).HasColumnName("FeatureType_Id");

                entity.Property(e => e.Summary).HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
                
            });

            modelBuilder.Entity<Proficiency>(entity =>
            {
                entity.Property(e => e.SavingThrowTypeId).HasColumnName("SavingThrowType_Id");

                entity.Property(e => e.SkillTypeId).HasColumnName("SkillType_Id");

                entity.HasOne(d => d.SavingThrowType)
                    .WithMany(p => p.Proficiency)
                    .HasForeignKey(d => d.SavingThrowTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proficiency_SavingThrow");
                
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentRaceId).HasColumnName("ParentRace_Id");

                entity.Property(e => e.RaceTypeId).HasColumnName("RaceType_Id");

                entity.Property(e => e.SubRaceTypeId).HasColumnName("SubRaceType_Id");

                entity.HasOne(d => d.ParentRace)
                    .WithMany(p => p.ChildRaces)
                    .HasForeignKey(d => d.ParentRaceId)
                    .HasConstraintName("FK_Race_ParentRace");
                
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 25,
                Description = "little thicc bois",
                Id = 1,
                Name = "Dwarf",
                Size = "small"
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 25,
                Description = "little thicc bois",
                Id = 2,
                Name = "Hill Dwarf",
                Size = "small",
                ParentRaceId = 1
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 25,
                Description = "little thicc bois",
                Id = 3,
                Name = "Mountain Dwarf",
                Size = "small",
                ParentRaceId = 1
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "tall pointy bois",
                Id = 4,
                Name = "Elf",
                Size = "medium"
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "tall bougie bois",
                Id = 5,
                Name = "High Elf",
                Size = "medium",
                ParentRaceId = 4
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 35,
                Description = "tall nature bois",
                Id = 6,
                Name = "Wood Elf",
                Size = "medium",
                ParentRaceId = 4
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "tall emo bois",
                Id = 7,
                Name = "Dark Elf (Drow)",
                Size = "medium",
                ParentRaceId = 4
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 25,
                Description = "little happy bois",
                Id = 8,
                Name = "Halfling",
                Size = "small"
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 25,
                Description = "little sneaky bois",
                Id = 9,
                Name = "Lightfoot Halfling",
                Size = "small",
                ParentRaceId = 8
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 25,
                Description = "little hardy bois",
                Id = 10,
                Name = "Stout Halfling",
                Size = "small",
                ParentRaceId = 8
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "boring bois",
                Id = 11,
                Name = "Human",
                Size = "medium"
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "special boring bois",
                Id = 12,
                Name = "Variant Human",
                Size = "medium",
                ParentRaceId = 11
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "dragon bois",
                Id = 13,
                Name = "Dragonborn",
                Size = "medium"
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "black dragon bois",
                Id = 14,
                Name = "Black Dragonborn",
                Size = "medium",
                ParentRaceId = 13
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "blue dragon bois",
                Id = 15,
                Name = "Blue Dragonborn",
                Size = "medium",
                ParentRaceId = 13
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "brass dragon bois",
                Id = 16,
                Name = "Brass Dragonborn",
                Size = "medium",
                ParentRaceId = 13
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "bronze dragon bois",
                Id = 17,
                Name = "Bronze Dragonborn",
                Size = "medium",
                ParentRaceId = 13
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "copper dragon bois",
                Id = 18,
                Name = "Copper Dragonborn",
                Size = "medium",
                ParentRaceId = 13
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "gold dragon bois",
                Id = 19,
                Name = "Gold Dragonborn",
                Size = "medium",
                ParentRaceId = 13
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "green dragon bois",
                Id = 20,
                Name = "Green Dragonborn",
                Size = "medium",
                ParentRaceId = 13
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "red dragon bois",
                Id = 21,
                Name = "Red Dragonborn",
                Size = "medium",
                ParentRaceId = 13
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "silver dragon bois",
                Id = 22,
                Name = "Silver Dragonborn",
                Size = "medium",
                ParentRaceId = 13
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "white dragon bois",
                Id = 23,
                Name = "White Dragonborn",
                Size = "medium",
                ParentRaceId = 13
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "stupid lil bois",
                Id = 24,
                Name = "Gnome",
                Size = "small"
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "stupid lil nature bois",
                Id = 25,
                Name = "Forest Gnome",
                Size = "small",
                ParentRaceId = 24
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "stupid lil hard bois",
                Id = 26,
                Name = "Rock Gnome",
                Size = "small",
                ParentRaceId = 24
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "half and half bois",
                Id = 27,
                Name = "Half-Elf",
                Size = "medium"
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "little tusky bois",
                Id = 28,
                Name = "Half-Orc",
                Size = "medium"
            });

            modelBuilder.Entity<Race>().HasData(new Models.Race()
            {
                BaseSpeed = 30,
                Description = "devil bois",
                Id = 29,
                Name = "Tiefling",
                Size = "medium"
            });







        }
    }
}
