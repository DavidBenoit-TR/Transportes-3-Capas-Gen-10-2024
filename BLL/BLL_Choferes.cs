using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Choferes
    {
        public static List<Choferes_VO> get_Choferes(params object[] parametros)
        {
            return DAL_Choferes.get_Choferes(parametros);
        }
    }
}
