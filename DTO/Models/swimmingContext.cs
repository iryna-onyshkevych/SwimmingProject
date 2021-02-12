using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DTO.Models
{
    public partial class swimmingContext : DbContext
    {
        public swimmingContext()
        {
        }

        public swimmingContext(DbContextOptions<swimmingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CoachDTO> Coaches { get; set; }
        public virtual DbSet<SwimStyleDTO> SwimStyles { get; set; }
        public virtual DbSet<SwimmerDTO> Swimmers { get; set; }
        public virtual DbSet<TrainingDTO> Trainings { get; set; }
        public virtual DbSet<TrainingsSwimmersSwimStyleDTO> TrainingsSwimmersSwimStyles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=swimming;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<CoachDTO>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<SwimStyleDTO>(entity =>
            {
                entity.Property(e => e.StyleName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<SwimmerDTO>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Swimmers)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Swimmers__Coach__4CA06362");
            });

            modelBuilder.Entity<TrainingDTO>(entity =>
            {
                entity.Property(e => e.TrainingDate).HasColumnType("datetime");

                entity.HasOne(d => d.SwimStyle)
                    .WithMany(p => p.training)
                    .HasForeignKey(d => d.SwimStyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trainings__SwimS__534D60F1");

                entity.HasOne(d => d.Swimmer)
                    .WithMany(p => p.training)
                    .HasForeignKey(d => d.SwimmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trainings__Swimm__52593CB8");
            });

            modelBuilder.Entity<TrainingsSwimmersSwimStyleDTO>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TrainingsSwimmersSwimStyles");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.TrainingDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
      
    }
}
