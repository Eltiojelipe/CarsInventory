using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.Shared.Entities
{
    public class Servicio
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "costo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal costo { get; set; }

        public string Direccion_origen { get; set; }   

        public string Direccion_fin { get; set; }   

        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }

        public DateTime fechaServicio { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int TecnicoId { get; set; }
        public Tecnico Tecnico { get; set;}


        public string placaVh { get; set; }    
        public Vehiculo Vehiculo { get; set;}
        
    }
}
