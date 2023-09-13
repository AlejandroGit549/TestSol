using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestSolDatos;
using TestSolModelos.Entidades;
using TestSolModelos.ModeloRespuesta.Ayudantes;
using TestSolModelos.UtileriaRespuesta;
using TestSolModelos.Utilidades;

namespace TestSolReglas.ReglasEntidades
{
    public class ReglasArea : IOperacionesBasicas<Area,catArea >
    {
        private static ReglasArea _Instancia;
        public static ReglasArea Instancia
        {
            get
            {
                if (_Instancia == null)
                    _Instancia = new ReglasArea();
                return _Instancia;
            }
        }
        private ReglasArea() { }
        public ModeloRespuesta Acutalizar(Area Item)
        {
            throw new NotImplementedException();
        }
        public ModeloRespuesta Eliminar(int Id)
        {
            throw new NotImplementedException();
        }

        public ModeloRespuesta Insertar(Area Item)
        {
            ModeloRespuesta resultado = new ModeloRespuesta();
            try
            {
                using (TestSolEntities contexto = new TestSolEntities())
                {
                    catArea area = new catArea();
                    area.Descripcion = Item.Descripcion;
                    if (contexto.SaveChanges() > 0)
                    {
                        resultado.ActualizarRespuesta(CodigosRespuesta.Exito , MensajesRespuesta.Exito , area.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                int FolioError =  ReglasUtilerias.ReglasLog.Instancia.Insertar(new Log(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ReglasUtilerias.ReglasLog.Instancia.ObtenerLineaError(ex), ex.Message)).ObtenerValorComo <int>();
                resultado.ActualizarRespuesta(CodigosRespuesta.Error, MensajesRespuesta.Error, FolioError);
            }
            return resultado;
        }

        public ModeloRespuesta Consultar(Expression<Func<catArea, bool>> expresionLambda, TestSolEntities entidad)
        {
            ModeloRespuesta resultado = new ModeloRespuesta();
            List<Area> lstArea = new List<Area>();
            try
            {
                var areas = entidad.catAreas.Where(expresionLambda).ToList();
                foreach (var  area in areas)
                {
                    lstArea.Add(
                        new Area()
                        {
                            Id = area.Id,
                            Descripcion = area.Descripcion,
                            Activo = area.Activo,
                            Fecha_Registro = area.Fecha_Registro,
                            Fecha_Modificacion = area.Fecha_Modificacion
                        });
                }
                resultado.ActualizarRespuesta(CodigosRespuesta.Exito , MensajesRespuesta.Exito , lstArea);
            }
            catch (Exception ex)
            {
                int FolioError = ReglasUtilerias.ReglasLog.Instancia.Insertar(new Log(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ReglasUtilerias.ReglasLog.Instancia.ObtenerLineaError(ex), ex.Message)).ObtenerValorComo<int>();
                resultado.ActualizarRespuesta(CodigosRespuesta.Error, MensajesRespuesta.Error, FolioError);
            }
            return resultado;
        }
    }
}
