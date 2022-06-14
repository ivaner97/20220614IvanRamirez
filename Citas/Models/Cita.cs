using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Citas.Models
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.Time)]

        public DateTime Hora { get; set; }
        public string cliente { get; set; }
        public string medico { get; set; }

        [Display(Name = "Cliente")]
        public int Idcliente { get; set; }

        [Display(Name = "Medico")]
        public int Idmedico { get; set; }

        public string diagnostico { get; set; }

        //0=pendiente 1=finalizado
        public int estado { get; set; }

        public List<Medico> ListaMedicos { get; set; }
        public List<Cliente> ListaClientes { get; set; }
    }
}
