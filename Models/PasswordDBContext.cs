using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Auth_project.Models
{
    public partial class PasswordDBContext : DbContext
    {
        public PasswordDBContext()
        {
        }

        public PasswordDBContext(DbContextOptions<PasswordDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PasswordTable> PasswordTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-QHS346J;Database=PasswordDB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<PasswordTable>(entity =>
            {
                entity.ToTable("PasswordTable");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.KullaniciAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Kullanici_adi");

                entity.Property(e => e.Sifre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Site_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
