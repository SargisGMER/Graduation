using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Graduation.DAL.Models
{
    public partial class GraduationDBContext : DbContext
    {
        private readonly IConfigurationRoot configuration;
        public GraduationDBContext()
        {
      

        }

        public GraduationDBContext(DbContextOptions<GraduationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<Weapons> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-58U31SB\\SQLEXPRESS;Initial Catalog=GraduationDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CharacterModel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultSkinColor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeaponId).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Character_Account");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.WeaponId)
                    .HasConstraintName("FK_Character_Weapons");
            });

            modelBuilder.Entity<Weapons>(entity =>
            {
                entity.Property(e => e.WeaponDefaultSkinColor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeaponName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
