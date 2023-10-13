using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarsInventory.Shared.Entities
{
    public enum TipoCliente
    {
        Asegurado,
        Particular
    }
    public class Cliente
    {
        public int Id {  get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? cedula { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? nombre { get; set; } 

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? apellido { get; set; } 

        public string direccion { get; set; } = null!;

        public string? telefono { get; set; }  
        
        public string? correo { get; set; }

        public TipoCliente Tipo { get; set; }


        public ICollection<Servicio>? Servicio { get; set; }

        public ICollection<Poseedor>? Poseedor { get; set; }  
    }


}
