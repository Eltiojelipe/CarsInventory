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
        [MaxLength(100, ErrorMessage = "Este campo {0} no permite más de {1} caracteres ")]  //{1}
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? nombre { get; set; }    
        public string? telefono { get; set; } 
        public string? nit { get; set;}
    }
}
