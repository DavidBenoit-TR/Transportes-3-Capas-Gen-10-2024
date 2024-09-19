using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Cargamentos
    {
        public static List<Cargamentos_VO> get_Cargamentos(params object[] parametros)
        {
            List<Cargamentos_VO> list_Cargamentos = new List<Cargamentos_VO>();
            try
            {
                DataSet ds_camiones = metodos_datos.execute_DataSet("sp_ListarCargamentos", parametros);

                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list_Cargamentos.Add(new Cargamentos_VO(dr));
                }
                return list_Cargamentos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
