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
        public DbSet<clienteParticular> clienteParticulars { get; set; }
        public DbSet<Empresa> empresas { get; set; }
        public DbSet<Poseedor> poseedores { get; set; } 
        public DbSet<Propietario> propietarios { get; set;}
        public DbSet<tipoCliente> tiposClientees { get; set; }  
        public DbSet<Vehiculo> vehiculoes { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
