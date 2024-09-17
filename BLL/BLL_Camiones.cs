using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Camiones
    {
        //CREATE
        //READ
        public static List<Camiones_VO> get_Camiones(params object[] parametros)
        {
            return DAL_Camiones.get_Camiones(parametros);
        }
        //UPDATE
        //DELETE
    }
}
