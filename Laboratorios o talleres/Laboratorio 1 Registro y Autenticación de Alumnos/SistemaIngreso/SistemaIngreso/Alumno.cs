using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIngreso
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Carrera { get; set; }
        public string Semestre { get; set; }
        public string Jornada { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public override string ToString()
        {
            // Formato para mostrar en la ListBox
            return $"{Cedula} - {Nombre} ({Carrera})";
        }
    }
}
