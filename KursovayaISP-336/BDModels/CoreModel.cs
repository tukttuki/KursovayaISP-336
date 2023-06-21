using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KursovayaISP_336.BDModels
{
    public partial class CoreModel : DbContext
    {
        private static CoreModel Core;
        public static CoreModel init()
        {
            if(Core==null)
                Core=new CoreModel();
            return Core;
        }
        public CoreModel()
        {
        }

        public CoreModel(DbContextOptions<CoreModel> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<FitCategory> FitCategories { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Recruit> Recruits { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=cfif31.ru;port=3306;user id=ISPr23-36_MurzinKA;database=ISPr23-36_MurzinKA_Kurs;password=ISPr23-36_MurzinKA;character set=utf8", ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName).HasMaxLength(45);

                entity.Property(e => e.Patronymic).HasMaxLength(45);

                entity.Property(e => e.SecondName).HasMaxLength(45);
            });

            modelBuilder.Entity<FitCategory>(entity =>
            {
                entity.ToTable("Fit_categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.HasIndex(e => e.Idrecruit, "idrecruit_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idrecruit).HasColumnName("idrecruit");

                entity.Property(e => e.IsNotification).HasColumnName("isNotification");

                entity.HasOne(d => d.IdrecruitNavigation)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.Idrecruit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idrecruit");
            });

            modelBuilder.Entity<Recruit>(entity =>
            {
                entity.ToTable("recruit");

                entity.HasIndex(e => e.Fit, "Fit_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName).HasMaxLength(45);

                entity.Property(e => e.Patronymic).HasMaxLength(45);

                entity.Property(e => e.SecondName).HasMaxLength(45);

                entity.HasOne(d => d.FitNavigation)
                    .WithMany(p => p.Recruits)
                    .HasForeignKey(d => d.Fit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fit");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login).HasMaxLength(45);

                entity.Property(e => e.Password).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
