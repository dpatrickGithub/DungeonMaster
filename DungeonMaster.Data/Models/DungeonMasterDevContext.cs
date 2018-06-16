using System;
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
                
                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                
            });

            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "Charlatan",
                Description = "extrovert boi",
                Id = 1
            });

            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "Criminal",
                Description = "outlaw boi",
                Id = 2
            });
            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "Entertainer",
                Description = "performer boi",
                Id = 3
            });

            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "folk Hero",
                Description = "legendary boi",
                Id = 4
            });

            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "Guild Artisan",
                Description = "professional boi",
                Id = 5
            });
            
            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "Hermit",
                Description = "introvert boi",
                Id = 6
            });

            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "Noble",
                Description = "bougie boi",
                Id = 7
            });

            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "Outlander",
                Description = "amish boi",
                Id = 8
            });

            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "Sage",
                Description = "book boi",
                Id = 9
            });

            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "Sailor",
                Description = "water boi",
                Id = 10
            });

            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "Soldier",
                Description = "army boi",
                Id = 11
            });

            modelBuilder.Entity<Background>().HasData(new Models.Background()
            {
                Name = "Urchin",
                Description = "orphan boi",
                Id = 12
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

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HitDieSize)
                    .IsRequired()
                    .HasColumnType("int");

                entity.Property(e => e.ParentClassId).HasColumnName("ParentClass_Id");

                entity.HasOne(d => d.ParentClass)
                    .WithMany(p => p.ChildClasses)
                    .HasForeignKey(d => d.ParentClassId)
                    .HasConstraintName("FK_Class_ParentClass");

            });

            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 1,
                Name = "Barbarian",
                Description = "Dumb bois",
                HitDieSize = 12
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 2,
                Name = "Path of the Totem Warrior Barbarian",
                Description = "Dumb Nature bois",
                HitDieSize = 12,
                ParentClassId = 1
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 3,
                Name = "Path of the Berserker Barbarian",
                Description = "Dumb Grumpy bois",
                HitDieSize = 12,
                ParentClassId = 1
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 4,
                Name = "Bard",
                Description = "Fancy bois",
                HitDieSize = 8
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 5,
                Name = "College of Lore Bard",
                Description = "Fancy Smart bois",
                HitDieSize = 8,
                ParentClassId = 4
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 6,
                Name = "College of Valor Bard",
                Description = "Fancy Theatric bois",
                HitDieSize = 8,
                ParentClassId = 4
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 7,
                Name = "Cleric",
                HitDieSize = 8,
                Description = "Holy bois",
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 8,
                Name = "Life Domain Cleric",
                Description = "Holy bois",
                HitDieSize = 8,
                ParentClassId = 7
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 9,
                Name = "Light Domain Cleric",
                Description = "Holy bois",
                HitDieSize = 8,
                ParentClassId = 7
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 10,
                Name = "Nature Domain Cleric",
                Description = "Holy bois",
                HitDieSize = 8,
                ParentClassId = 7
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 11,
                Name = "Tempest Domain Cleric",
                Description = "Holy bois",
                HitDieSize = 8,
                ParentClassId = 7
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 12,
                Name = "Trickery Domain Cleric",
                Description = "Holy bois",
                HitDieSize = 8,
                ParentClassId = 7
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 13,
                Name = "War Domain Cleric",
                Description = "Holy bois",
                HitDieSize = 8,
                ParentClassId = 7
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 14,
                Name = "Druid",
                Description = "Hippy bois",
                HitDieSize = 8
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 15,
                Name = "Circle of the Land Druid",
                Description = "Hippy bois",
                HitDieSize = 8,
                ParentClassId = 14
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 16,
                Name = "Circle of the Moon Druid",
                Description = "Hippy bois",
                HitDieSize = 8,
                ParentClassId = 14
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 17,
                Name = "Fighter",
                Description = "Pokie bois",
                HitDieSize = 10
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 18,
                Name = "Champion Fighter",
                Description = "Strong Pokie bois",
                HitDieSize = 10,
                ParentClassId = 17
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 19,
                Name = "Battle Master Fighter",
                Description = "Versatile Pokie bois",
                HitDieSize = 10,
                ParentClassId = 17
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 20,
                Name = "Eldritch Fighter",
                Description = "Magical Pokie bois",
                HitDieSize = 10,
                ParentClassId = 17
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 21,
                Name = "Monk",
                Description = "Calm bois",
                HitDieSize = 8
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 22,
                Name = "Way of the Open Hand Monk",
                Description = "Calm bois",
                HitDieSize = 8,
                ParentClassId = 21
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 23,
                Name = "Way of the Shadow Monk",
                Description = "Calm bois",
                HitDieSize = 8,
                ParentClassId = 21
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 24,
                Name = "Way of the Four Elements Monk",
                Description = "Calm bois",
                HitDieSize = 8,
                ParentClassId = 21
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 25,
                Name = "Paladin",
                Description = "Crusader bois",
                HitDieSize = 10
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 26,
                Name = "Oath of Devotion Paladin",
                Description = "Crusader bois",
                HitDieSize = 10,
                ParentClassId = 25
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 27,
                Name = "Oath of The Ancients Paladin",
                Description = "Crusader bois",
                HitDieSize = 10,
                ParentClassId = 25
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 28,
                Name = "Oath of Vengeance Paladin",
                Description = "Crusader bois",
                HitDieSize = 10,
                ParentClassId = 25
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 29,
                Name = "Ranger",
                Description = "Arrow bois",
                HitDieSize = 10
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 30,
                Name = "Hunger Ranger",
                Description = "Arrow bois",
                HitDieSize = 10,
                ParentClassId = 29
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 31,
                Name = "Beast Master Ranger",
                Description = "Arrow bois",
                HitDieSize = 10,
                ParentClassId = 29
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 32,
                Name = "Rogue",
                Description = "Sneaky bois",
                HitDieSize = 8
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 33,
                Name = "Thief Rogue",
                Description = "Sneaky bois",
                HitDieSize = 8,
                ParentClassId = 32
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 34,
                Name = "Assassin Rogue",
                Description = "Sneaky bois",
                HitDieSize = 8,
                ParentClassId = 32
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 35,
                Name = "Arcane Trickster Rogue",
                Description = "Magical Sneaky bois",
                HitDieSize = 8,
                ParentClassId = 32
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 36,
                Name = "Sorcerer",
                Description = "Magical bois",
                HitDieSize = 6
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 37,
                Name = "Draconic Bloodline Sorcerer",
                Description = "Magical bois",
                HitDieSize = 6,
                ParentClassId = 36
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 38,
                Name = "Wild Magic Sorcerer",
                Description = "Magical bois",
                HitDieSize = 6,
                ParentClassId = 36
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 39,
                Name = "Warlock",
                Description = "Grumpy Magic bois",
                HitDieSize = 8
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 40,
                Name = "Pact of the Chain Warlock",
                Description = "Grumpy Magic bois",
                HitDieSize = 8,
                ParentClassId = 39
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 41,
                Name = "Pact of the Blade Warlock",
                Description = "Grumpy Magic bois",
                HitDieSize = 8,
                ParentClassId = 39
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 42,
                Name = "Pact of the Tome Warlock",
                Description = "Grumpy Magic bois",
                HitDieSize = 8,
                ParentClassId = 39
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 43,
                Name = "Wizard",
                Description = "Xtra Magic bois",
                HitDieSize = 6
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 44,
                Name = "Abjuration Wizard",
                Description = "Xtra Magic bois",
                HitDieSize = 6,
                ParentClassId = 43
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 45,
                Name = "Conjuration Wizard",
                Description = "Xtra Magic bois",
                HitDieSize = 6,
                ParentClassId = 43
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 46,
                Name = "Divination Wizard",
                Description = "Xtra Magic bois",
                HitDieSize = 6,
                ParentClassId = 43
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 47,
                Name = "Enchantment Wizard",
                Description = "Xtra Magic bois",
                HitDieSize = 6,
                ParentClassId = 43
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 48,
                Name = "Evocation Wizard",
                Description = "Xtra Magic bois",
                HitDieSize = 6,
                ParentClassId = 43
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 49,
                Name = "Illusion Wizard",
                Description = "Xtra Magic bois",
                HitDieSize = 6,
                ParentClassId = 43
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 50,
                Name = "Necromancy Wizard",
                Description = "Xtra Magic bois",
                HitDieSize = 6,
                ParentClassId = 43
            });
            modelBuilder.Entity<Dndclass>().HasData(new Models.Dndclass()
            {
                Id = 51,
                Name = "Transmutation Wizard",
                Description = "Xtra Magic bois",
                HitDieSize = 6,
                ParentClassId = 43
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
