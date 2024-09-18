using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Camiones
    {
        //CREATE
        public static string insertar_Camion(Camiones_VO camion)
        {
            return DAL_Camiones.insertar_Camion(camion);
        }
        //READ
        public static List<Camiones_VO> get_Camiones(params object[] parametros)
        {
            return DAL_Camiones.get_Camiones(parametros);
        }
        //UPDATE
        public static string update_Camion(Camiones_VO camion)
        {
            return DAL_Camiones.update_Camion(camion);
        }
        //DELETE
        public static string delete_Camion(int id)
        {
            return DAL_Camiones.delete_Camion(id);
        }


    }
}
