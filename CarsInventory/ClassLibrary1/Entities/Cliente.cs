using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarsInventory.Shared.Entities
{
    public class Cliente
    {
        public int clienteId { get; set; }
        public Persona persona { get; set; }

        public string Med_Pago { get; set; }

        public ICollection<Servicio> Servicio { get; set; }
        public ICollection<Vehiculo> Vehiculo { get; set;}
    }


}
