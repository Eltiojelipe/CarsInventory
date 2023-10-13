using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.Shared.Entities
{
    public class Poseedor
    {
        public int Id { get; set; } 

        public Cliente? Cliente { get; set; }
        public int ClienteId { get; set; }  

        public Vehiculo? Vehiculo { get; set; }
        public int VehiculoId { get; set; }

    }
}
