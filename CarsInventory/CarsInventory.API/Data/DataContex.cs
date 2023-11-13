using CarsInventory.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Servicio> servicios { get; set; }
        public DbSet<Cliente> clientes { get; set; } 
        public DbSet<Persona> personas { get; set; }
        public DbSet<Ciudad> ciudades { get; set; } 
        public DbSet<Tecnico> tecnicos { get; set; }    
        public DbSet<Vehiculo> vehiculos { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ciudad>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Persona>().HasIndex(x => x.cedulaId).IsUnique();

            modelBuilder.Entity<Vehiculo>().HasIndex(x => x.placaVh).IsUnique();



        }

    }
}
