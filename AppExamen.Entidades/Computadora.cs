using System.ComponentModel.DataAnnotations;

namespace AppExamen.Entidades
{
    public class Computadora
    {
        [Key]
        public int Id { get; set; }   // PK 

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Procesador { get; set; }
        public int MemoriaRAMGB { get; set; }
        public int AlmacenamientoGB { get; set; }

        public List<Software>? SoftwareInstalado { get; set; } = new List<Software>(); // Lista de software instalado en la computadora
    }
}
