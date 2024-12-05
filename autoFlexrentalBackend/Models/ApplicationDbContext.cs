using Microsoft.EntityFrameworkCore;
using autoFlexrentalBackend.Models; // Aseg�rate de que las clases de modelos est�n en este espacio de nombres.

namespace autoFlexrentalBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor que recibe opciones de configuraci�n
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // DbSets para las tablas de la base de datos
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }

        // Aqu� puedes agregar otras tablas que necesites como DbSets.

        // Sobrescribir el m�todo OnModelCreating si necesitas configuraciones adicionales (relaciones, claves for�neas, etc.)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aqu� puedes configurar las relaciones y restricciones adicionales entre las tablas si es necesario
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Category)  // Relaci�n entre Vehicle y Category
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.CategoryId);
        }
    }
}
