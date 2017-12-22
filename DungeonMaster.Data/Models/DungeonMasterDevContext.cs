using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DungeonMaster.Data.Models
{
    public partial class DungeonMasterDevContext : DbContext
    {
        public virtual DbSet<AbilityType> AbilityType { get; set; }
        public virtual DbSet<Background> Background { get; set; }
        public virtual DbSet<BackgroundType> BackgroundType { get; set; }
        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<CharacterAbilityScore> CharacterAbilityScore { get; set; }
        public virtual DbSet<ClassType> ClassType { get; set; }
        public virtual DbSet<Dndclass> Dndclass { get; set; }
        public virtual DbSet<Dndskill> Dndskill { get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<FeatureType> FeatureType { get; set; }
        public virtual DbSet<Proficiency> Proficiency { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<RaceType> RaceType { get; set; }
        public virtual DbSet<SkillType> SkillType { get; set; }
        public virtual DbSet<SubClassType> SubClassType { get; set; }
        public virtual DbSet<SubRaceType> SubRaceType { get; set; }

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

                entity.HasOne(d => d.BackgroundType)
                    .WithMany(p => p.Background)
                    .HasForeignKey(d => d.BackgroundTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Background_BackgroundType");
            });

            modelBuilder.Entity<BackgroundType>(entity =>
            {
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

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CharacterAbilityScore)
                    .HasForeignKey<CharacterAbilityScore>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Character_AbilityScore_AbilityType");
            });

            modelBuilder.Entity<ClassType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Dndclass>(entity =>
            {
                entity.ToTable("DNDClass");

                entity.Property(e => e.ClassTypeId).HasColumnName("ClassType_Id");

                entity.Property(e => e.Desription)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentClassId).HasColumnName("ParentClass_Id");

                entity.Property(e => e.SubClassTypeId).HasColumnName("SubClassType_Id");

                entity.HasOne(d => d.ClassType)
                    .WithMany(p => p.Dndclass)
                    .HasForeignKey(d => d.ClassTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DNDClass_ClassType");

                entity.HasOne(d => d.ParentClass)
                    .WithMany(p => p.InverseParentClass)
                    .HasForeignKey(d => d.ParentClassId)
                    .HasConstraintName("FK_Class_ParentClass");

                entity.HasOne(d => d.SubClassType)
                    .WithMany(p => p.Dndclass)
                    .HasForeignKey(d => d.SubClassTypeId)
                    .HasConstraintName("FK_DNDClass_SubClassType");
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

                entity.HasOne(d => d.SkillType)
                    .WithMany(p => p.Dndskill)
                    .HasForeignKey(d => d.SkillTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DNDSkill_SkillType");
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

                entity.HasOne(d => d.FeatureType)
                    .WithMany(p => p.Feature)
                    .HasForeignKey(d => d.FeatureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feature_FeatureType");
            });

            modelBuilder.Entity<FeatureType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
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

                entity.HasOne(d => d.SkillType)
                    .WithMany(p => p.Proficiency)
                    .HasForeignKey(d => d.SkillTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proficiency_SkillType");
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
                    .WithMany(p => p.InverseParentRace)
                    .HasForeignKey(d => d.ParentRaceId)
                    .HasConstraintName("FK_Race_ParentRace");

                entity.HasOne(d => d.RaceType)
                    .WithMany(p => p.Race)
                    .HasForeignKey(d => d.RaceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Race_RaceType");

                entity.HasOne(d => d.SubRaceType)
                    .WithMany(p => p.Race)
                    .HasForeignKey(d => d.SubRaceTypeId)
                    .HasConstraintName("FK_Race_SubRaceType");
            });

            modelBuilder.Entity<RaceType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SkillType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SubClassType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SubRaceType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
