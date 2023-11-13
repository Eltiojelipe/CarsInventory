using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarsInventory.Shared.Entities
{
    public class Tecnico
    {
        public int tecnicoId { get; set; }

        [JsonIgnore]
        public Persona persona { get; set; }
        public string Num_Permiso_Conducir { get; set; }   


        public ICollection<Servicio> Servicio { get; set; }

    }
}
