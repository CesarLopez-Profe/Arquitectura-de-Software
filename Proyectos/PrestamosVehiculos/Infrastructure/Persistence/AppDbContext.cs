using Microsoft.EntityFrameworkCore;
using PrestamosVehiculos.Domain.Aggregates;
using PrestamosVehiculos.Domain.Entities;

namespace PrestamosVehiculos.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Prestamo>().ToTable("Prestamos");
            modelBuilder.Entity<Cuota>().ToTable("Cuotas");

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Cliente) // Relación 1:N (Un Cliente puede tener varios Préstamos)
                .WithMany()
                .HasForeignKey("ClienteId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cuota>()
                .HasOne<Prestamo>() // Relación 1:N (Un Préstamo genera varias Cuotas)
                .WithMany(p => p.Cuotas)
                .HasForeignKey("PrestamoId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
