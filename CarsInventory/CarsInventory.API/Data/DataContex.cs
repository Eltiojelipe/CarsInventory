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
        public DbSet<clienteAsegurado> asegurados { get; set; } 
        public DbSet<clienteParticular> particulares { get; set; }
        public DbSet<Empresa> empresas { get; set; }
        public DbSet<Poseedor> poseedores { get; set; } 
        public DbSet<Propietario> propietarios { get; set;}
        public DbSet<tipoCliente> tipoClientes { get; set; }  
        public DbSet<Vehiculo> vehiculos { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
