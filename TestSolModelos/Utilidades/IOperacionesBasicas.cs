using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestSolDatos;
using TestSolModelos.UtileriaRespuesta;

namespace TestSolModelos.Utilidades
{
    public interface IOperacionesBasicas<T,M>
    {
        UtileriaRespuesta.ModeloRespuesta Insertar(T Item);
        UtileriaRespuesta.ModeloRespuesta Eliminar(int Id);
        UtileriaRespuesta.ModeloRespuesta Acutalizar(T Item);
        UtileriaRespuesta.ModeloRespuesta Consultar(Expression<Func<M,bool >> expresionLambda, TestSolEntities entidad);
    }
}
