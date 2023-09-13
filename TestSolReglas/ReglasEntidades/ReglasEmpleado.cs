using System;
using System.Collections.Generic;
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
    public class ReglasEmpleado : IOperacionesBasicas<Empleado, opeEmpleado>
    {
        private static ReglasEmpleado _Instancia = null;
        private static ReglasEmpleado Instancia
        {
            get
            {
                if (_Instancia == null)
                    _Instancia = new ReglasEmpleado();
                return _Instancia;
            }
        }

        private ReglasEmpleado() { }
        public ModeloRespuesta Consultar(Expression<Func<opeEmpleado, bool>> expresionLambda, TestSolEntities entidad)
        {
            ModeloRespuesta resultado = new ModeloRespuesta();
            List<Empleado> lstEmpleados = new List<Empleado>();
            try
            {
                var empleados = entidad.opeEmpleadoes.Where(expresionLambda).ToList();
                foreach (var item in empleados)
                {
                    lstEmpleados.Add(new Empleado
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        ApellidoPaterno = item.ApPaterno,
                        ApellidoMaterno = item.ApMaterno,
                        Fecha_Nacimiento = item.Fecha_Nacimiento,
                        Area = new Area() { Id = item.catArea.Id, Descripcion = item.catArea.Descripcion },
                        Sueldo = item.Sueldo,
                        Activo = item.Activo
                    }); 
                }
                resultado.ActualizarRespuesta(CodigosRespuesta.Exito, MensajesRespuesta.Exito, lstEmpleados);
            }
            catch (Exception ex)
            {
                int FolioError = ReglasUtilerias.ReglasLog.Instancia.Insertar(new Log(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ReglasUtilerias.ReglasLog.Instancia.ObtenerLineaError(ex), ex.Message)).ObtenerValorComo<int>();
                resultado.ActualizarRespuesta(CodigosRespuesta.Error, MensajesRespuesta.Error, FolioError);
            }
            return resultado;
        }
        public ModeloRespuesta Insertar(Empleado Item)
        {
            ModeloRespuesta resultado = new ModeloRespuesta();
            try
            {
                using (TestSolEntities contexto = new TestSolEntities())
                {
                    opeEmpleado opeEmpleado = new opeEmpleado(); //contexto.opeEmpleadoes.Where(expresionLambda).FirstOrDefault();
                    opeEmpleado.Nombre = Item.Nombre;
                    opeEmpleado.ApPaterno = Item.ApellidoPaterno;
                    opeEmpleado.ApMaterno = Item.ApellidoMaterno;
                    opeEmpleado.Fecha_Nacimiento = Item.Fecha_Nacimiento ;
                    opeEmpleado.Activo = true;
                    opeEmpleado.Fecha_Registro = DateTime.Now;
                    opeEmpleado.Sueldo = Item.Sueldo;
                    opeEmpleado.FkIdArea = Item.Area.Id;
                    contexto.opeEmpleadoes.Add(opeEmpleado);
                    if (contexto.SaveChanges() > 0)
                    {
                        resultado.ActualizarRespuesta(CodigosRespuesta.Exito, MensajesRespuesta.Exito);
                    }
                }
            }
            catch (Exception ex)
            {
                int FolioError = ReglasUtilerias.ReglasLog.Instancia.Insertar(new Log(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ReglasUtilerias.ReglasLog.Instancia.ObtenerLineaError(ex), ex.Message)).ObtenerValorComo<int>();
                resultado.ActualizarRespuesta(CodigosRespuesta.Error, MensajesRespuesta.Error, FolioError);
            }
            return resultado;
        }
        public ModeloRespuesta Eliminar(Expression<Func<opeEmpleado, bool>> expresionLambda, int Id)
        {
            ModeloRespuesta resultado = new ModeloRespuesta();
            try
            {
                using (TestSolEntities contexto = new TestSolEntities())
                {
                    opeEmpleado opeEmpleado = contexto.opeEmpleadoes.Where(expresionLambda).FirstOrDefault();
                    opeEmpleado.Activo = false;
                    opeEmpleado.Fecha_Modificacion = DateTime.Now;
                    if (contexto.SaveChanges() > 0)
                    {
                        resultado.ActualizarRespuesta(CodigosRespuesta.Exito, MensajesRespuesta.Exito);
                    }
                }
            }
            catch (Exception ex)
            {
                int FolioError = ReglasUtilerias.ReglasLog.Instancia.Insertar(new Log(this.GetType().Name, MethodBase.GetCurrentMethod().Name, ReglasUtilerias.ReglasLog.Instancia.ObtenerLineaError(ex), ex.Message)).ObtenerValorComo<int>();
                resultado.ActualizarRespuesta(CodigosRespuesta.Error, MensajesRespuesta.Error, FolioError);
            }
            return resultado;
        }
        public ModeloRespuesta Acutalizar(Expression<Func<opeEmpleado, bool>> expresionLambda, Empleado Item)
        {
            ModeloRespuesta resultado = new ModeloRespuesta();
            try
            {
                using (TestSolEntities contexto = new TestSolEntities())
                {
                    opeEmpleado opeEmpleado = contexto.opeEmpleadoes.Where(expresionLambda).FirstOrDefault();
                    opeEmpleado.Nombre = Item.Nombre;
                    opeEmpleado.ApPaterno = Item.ApellidoPaterno;
                    opeEmpleado.ApMaterno = Item.ApellidoMaterno;
                    opeEmpleado.Fecha_Nacimiento = Item.Fecha_Nacimiento;
                    opeEmpleado.Fecha_Modificacion = DateTime.Now;
                    opeEmpleado.Sueldo = Item.Sueldo;
                    opeEmpleado.FkIdArea = Item.Area.Id;
                    if (contexto.SaveChanges() > 0)
                    {
                        resultado.ActualizarRespuesta(CodigosRespuesta.Exito, MensajesRespuesta.Exito);
                    }
                }
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
