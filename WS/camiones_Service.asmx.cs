using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VO;

namespace Transportes_3_Capas_Gen_10.WS
{
    /// <summary>
    /// Descripción breve de camiones_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class camiones_Service : System.Web.Services.WebService
    {

        [WebMethod]
        //READ
        public List<Camiones_VO> get_Camiones(params object[] parametros)
        {
            return BLL_Camiones.get_Camiones(parametros);
        }
    }
}
