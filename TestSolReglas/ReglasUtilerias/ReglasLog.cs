using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestSolDatos;
using TestSolModelos.Entidades;
using TestSolModelos.ModeloRespuesta.Ayudantes;
using TestSolModelos.UtileriaRespuesta;
using TestSolModelos.Utilidades;

namespace TestSolReglas.ReglasUtilerias
{
    public class ReglasLog:IOperacionesBasicas<Log,opeLog >
    {
        private static ReglasLog _Instancia;
        public static ReglasLog Instancia
        {
            get
            {
                if (_Instancia == null)
                    _Instancia = new ReglasLog();
                return _Instancia;
            }
        }
        private ReglasLog() { }

        public ModeloRespuesta Insertar(Log Item)
        {
            ModeloRespuesta resultado = new ModeloRespuesta();
            try
            {
                using (TestSolEntities entidad = new TestSolEntities())
                {
                    opeLog objectoLog = new opeLog();
                    objectoLog.NombreClase = Item.NombreClase;
                    objectoLog.NombreMetodo = Item.NombreMetodo;
                    objectoLog.LineaCodigo = Item.LineaCodigo;
                    objectoLog.MesajeError = Item.MensajeError ;
                    objectoLog.Fecha_Registro = DateTime.Now;
                    entidad.opeLogs.Add(objectoLog);
                    if (entidad.SaveChanges () > 0)
                    {
                        resultado.ActualizarRespuesta(CodigosRespuesta.Exito, MensajesRespuesta.Exito, objectoLog.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.ActualizarRespuesta(CodigosRespuesta.Error, MensajesRespuesta.Error + "\n" + "Error: " + ex.Message,0);
            }
            return resultado;
        }

        public ModeloRespuesta Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public ModeloRespuesta Acutalizar(Log Item)
        {
            throw new NotImplementedException();
        }
        public int ObtenerLineaError(Exception ex)
        {
            var st = new StackTrace(ex, true);
            var frame = st.GetFrame(0);
            var line = frame.GetFileLineNumber();
            return line;
        }

        public ModeloRespuesta Consultar(Expression<Func<opeLog, bool>> expresionLambda, TestSolEntities entidad)
        {
            throw new NotImplementedException();
        }
    }
}
