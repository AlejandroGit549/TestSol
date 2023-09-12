using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolModelos.Entidades
{
    public class Area: ClaseBase
    {
        public DateTime Fecha_Registro { get; set; }
        public DateTime? Fecha_Modificacion { get; set; }
        public bool Activo { get; set; }
    }
}
