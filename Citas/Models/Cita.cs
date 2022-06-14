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
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public int cliente { get; set; }
        public int medico { get; set; }
    }
}
