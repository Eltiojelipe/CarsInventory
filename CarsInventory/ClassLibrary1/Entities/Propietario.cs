using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.Shared.Entities
{
    public class Propietario
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public int idVehiculo { get;set; }
        public string? cedula { get; set; } 

    }
}
