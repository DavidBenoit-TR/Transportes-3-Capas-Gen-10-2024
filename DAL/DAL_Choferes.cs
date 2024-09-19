using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Choferes
    {
        public static List<Choferes_VO> get_Choferes(params object[] parametros)
        {
            List<Choferes_VO> list_choferes = new List<Choferes_VO>();
            try
            {
                DataSet ds_camiones = metodos_datos.execute_DataSet("sp_ListarChoferes", parametros);
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list_choferes.Add(new Choferes_VO(dr));
                }
                return list_choferes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
