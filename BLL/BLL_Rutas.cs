using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Rutas
    {
        //Create (crear/insertar)
        public static string InsertarRuta(Rutas_VO ruta)
        {
            return DAL_Rutas.InsertarRuta(ruta);
        }

        //Read (consultar/obtener)
        public static List<Rutas_VO> GetRutas(params object[] parametros)
        {
            return DAL_Rutas.GetRutas(parametros);
        }

        //Update (actualizar/modificar)
        public static string ActualizarRuta(Rutas_VO ruta)
        {
            return DAL_Rutas.ActualizarRuta(ruta);
        }

        //Delete (eliminar)
        public static string EliminarRuta(int id)
        {
            return DAL_Rutas.EliminarRuta(id);
        }
    }
}
