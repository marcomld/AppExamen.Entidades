using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExamen.Entidades
{
    public class Software
    {
        [Key]
        public int Id { get; set; }   // PK 

        public string Nombre { get; set; }
        public string Version { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInstalacion { get; set; }

        public int ComputadoraId { get; set; }  // FK
        public Computadora? Computadora { get; set; } // La computadora en la que está instalado este software
    }
}
