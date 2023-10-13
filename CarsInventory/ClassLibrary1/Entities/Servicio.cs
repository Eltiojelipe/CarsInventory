using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.Shared.Entities
{
    public enum tipoServicio
    {
        Grualiviano,
        GruaPesado
    }
    public class Servicio
    {
        public int Id { get; set; }

        public double costo { get; set; }

        public DateTime fechaServicio { get; set; }

        public tipoServicio tipo { get; set; } // tipo grua liviana o 

        public Empresa? empresa { get; set; }
        public int EmpresaId { get; set; }

        public Cliente? Cliente { get; set; }   
        public int ClienteId { get; set; }

        public Tecnico? Tecnico { get; set;}
        public int TecnicoId { get; set; }
    }
}
