using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolDatos;
using TestSolModelos.Entidades;
using TestSolModelos.UtileriaRespuesta;

namespace TestSolPruebasUnitarias
{
    [TestClass]
    public class Areas
    {
        [TestMethod]
        public void ObtenerAreas()
        {
            ModeloRespuesta respuesta =  TestSolReglas.ReglasEntidades.ReglasArea.Instancia.Consultar(p => p.Activo == true, new TestSolEntities());
            if (!respuesta.Exito )
            {
                int folioError = respuesta.ObtenerValorComo<int>();
                Console.WriteLine(respuesta.Mensaje + "Folio Error: " + folioError.ToString ());
                return;
            }
            List<Area> lstAreas = respuesta.ObtenerValorComo<List<Area>>();
            foreach (var item in lstAreas)
            {
                Console.WriteLine(item.Descripcion);
            }
        }
    }
}
