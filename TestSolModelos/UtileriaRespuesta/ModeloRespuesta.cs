using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolModelos.ModeloRespuesta.Ayudantes;

namespace TestSolModelos.UtileriaRespuesta
{
    public class ModeloRespuesta
    {
        public CodigosRespuesta Codigo { get; private set; }

        public string Mensaje { get; private set; }

        public object Valor { get; private set; }

        public bool Exito
        {
            get
            {
                return Codigo == CodigosRespuesta.Exito ||
                       Codigo == CodigosRespuesta.Advertencia;
            }
        }

        public ModeloRespuesta()
        {
            Codigo = CodigosRespuesta.Error;
            Mensaje = MensajesRespuesta.Error;
        }

        public void ActualizarRespuesta(object valor)
        {
            Valor = valor;
        }

        public void ActualizarRespuesta(CodigosRespuesta codigo, string mensaje)
        {
            Codigo = codigo;
            Mensaje = mensaje;
            Valor = null;
        }

        public void ActualizarRespuesta(CodigosRespuesta codigo, string mensaje, object valor)
        {
            Codigo = codigo;
            Mensaje = mensaje;
            Valor = valor;
        }

        public void CopiarRespuesta(ModeloRespuesta origen)
        {
            ActualizarRespuesta(origen.Codigo, origen.Mensaje, origen.Valor);
        }

        public T ObtenerValorComo<T>()
        {
            if (this.Exito)
                return (T)((object)this.Valor);
            else
                return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }
    }
}
