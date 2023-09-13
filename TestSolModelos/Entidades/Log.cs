using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolModelos.Entidades
{
    public class Log : ClaseBase
    {
        public string NombreClase { get; set; }
        public string NombreMetodo { get; set; }
        public int LineaCodigo { get; set; }
        public string MensajeError { get; set; }
        public Log()
        {
            this.Id = 0;
            this.Descripcion = string.Empty;
            this.NombreClase = string.Empty;
            this.NombreMetodo = string.Empty;
            this.LineaCodigo = 0;
            this.MensajeError = string.Empty;
        }

        public Log(string _NombreClase,string _NombreMetodo,int _LineaCodigo,string _MensajeError)
        {
            this.NombreClase = _NombreClase;
            this.NombreMetodo = _NombreMetodo;
            this.LineaCodigo = _LineaCodigo;
            this.MensajeError = _MensajeError;
        }

    }
}
