using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.Shared.Entities
{
    public class Empresa
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Empresa")]  //{0}
        [MaxLength(50, ErrorMessage = "Este campo {0} no permite más de {1} caracteres ")]  //{1}
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? nombre { get; set; }
        public string? telefono { get; set; }

        [Display(Name = "NIT")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? nit { get; set; }

        [DataType(DataType.MultilineText)]
        public string? descripcion { get; set; }

        public DateTime fechFundacion { get; set; }

        public string? correo { get; set; }

        public string? direccion { get; set; } 
        
        public ICollection<Servicio>? Servicio { get; set; } 
    }
}
