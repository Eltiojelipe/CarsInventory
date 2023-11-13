
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarsInventory.Shared.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [Display(Name = "Placa")]
        [MaxLength(8, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string placaVh { get; set; }
        public string marca { get; set; }
        public int modelo { get; set; }

        public int ClienteId { get; set; } 

        [JsonIgnore]
        public Cliente Cliente { get; set; }

        public ICollection<Servicio> Servicio { get; set; }

    }
}
