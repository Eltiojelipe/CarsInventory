using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.Shared.Entities
{
    public class tipoCliente
    {
        public int Id { get; set; } 
        public string? nombre { get; set; } 
        public string? cedula { get; set; } 
        public string? telefono { get; set; }
        public string? tipo { get; set;} //si es asegurado o particular
    }
}
