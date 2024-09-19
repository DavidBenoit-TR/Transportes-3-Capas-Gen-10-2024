using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Cargamentos
    {
        public static List<Cargamentos_VO> get_Cargamentos(params object[] parametros)
        {
            return DAL_Cargamentos.get_Cargamentos(parametros);
        }
    }
}
