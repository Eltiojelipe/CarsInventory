
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.Shared.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; } 
        public string? marca { get; set; }
        public int modelo { get; set; } 
        public string? placa { get; set; }  


        public Cliente? Cliente { get; set; }    
        public int ClienteId { get; set; }  
    }
}
