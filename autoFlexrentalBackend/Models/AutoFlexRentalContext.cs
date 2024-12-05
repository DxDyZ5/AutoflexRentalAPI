using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace autoFlexrentalBackend.Models
{
    public partial class AutoFlexRentalContext : DbContext
    {
        public AutoFlexRentalContext(DbContextOptions<AutoFlexRentalContext> options) : base(options)
        {
        }

        // Definición de DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<WhyChooseUs> WhyChooseUsItems { get; set; }
        public DbSet<Economy> Economy { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }  // Asegúrate de incluir esto

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            });

            // Configuración de Vehicle
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleId);
                entity.Property(e => e.Brand).IsRequired();
                entity.Property(e => e.Model).IsRequired();

                // Relación con Category (Muchos a Uno)
                entity.HasOne(v => v.Category)
                    .WithMany(c => c.Vehicles)
                    .HasForeignKey(v => v.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación con Reservations (Uno a Muchos)
                entity.HasMany(v => v.Reservations)
                    .WithOne(r => r.Vehicle)
                    .HasForeignKey(r => r.VehicleId);
            });

            // Configuración de ContactMessage
            modelBuilder.Entity<ContactMessage>(entity =>
            {
                entity.HasKey(e => e.MessageId);  // Definir MessageId como clave primaria
                entity.Property(e => e.FullName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.Message).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");  // Configuración del valor predeterminado para CreatedAt
            });

            // Configuración de Notification
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.NotificationId);
                entity.Property(e => e.Content).HasMaxLength(255);
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.IsRead).HasDefaultValue(false);
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__UserI__36B12243");
            });

            // Configuración de ActivityLog
            modelBuilder.Entity<ActivityLog>(entity =>
            {
                // Definir la clave primaria para ActivityLog
                entity.HasKey(e => e.LogId);

                // Configuración de las propiedades
                entity.Property(e => e.Action).HasMaxLength(255);
                entity.Property(e => e.Timestamp)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                // Relación con User
                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActivityLogs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ActivityLog_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
