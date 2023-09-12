using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolModelos.Entidades
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Area Area { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public decimal Sueldo { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public DateTime? Fecha_Modificacion { get; set; }
        public bool Activo { get; set; }
    }
}
