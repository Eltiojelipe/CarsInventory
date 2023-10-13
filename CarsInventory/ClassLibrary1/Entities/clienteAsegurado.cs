using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.Shared.Entities
{
    public class clienteAsegurado
    {
        public int Id {  get; set; }    

        public string? IdtipoCliente { get; set; }   
        public string? tipoPoliza { get; set; } 
    }
}
