using CarsInventory.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarsInventory.API.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Aseguradora> Aseguradoras { get; set; }
        public DbSet<Cliente> asegurados { get; set; } 
        public DbSet<clienteParticular> particulares { get; set; }
        public DbSet<Empresa> empresas { get; set; }
        public DbSet<Poseedor> poseedores { get; set; } 
        public DbSet<Tecnico> tecnicos { get; set; }    
        public DbSet<Vehiculo> vehiculos { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().HasIndex(c => c.cedula).IsUnique();
            modelBuilder.Entity<Empresa>().HasIndex("nit", "nombre").IsUnique();
            modelBuilder.Entity<Poseedor>().HasIndex("Id").IsUnique();
        }

    }
}
