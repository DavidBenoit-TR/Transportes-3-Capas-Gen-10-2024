using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Camiones
    {
        //CREATE
        //READ
        public static List<Camiones_VO> get_Camiones(params object[] parametros)
        {
            //creo una lsita de objetos a llenar
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {
                //crear un Dataset el cual recibirá lo que devuelva la ejecución del método "execute_Dataset" proviniente de la clase "metodos_Datos"
                DataSet ds_camiones = metodos_datos.execute_DataSet("", parametros);
                //recorremos cada renglón existente de nuestro ds crando objetos VO y añadiéndolo la lista
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list.Add(new Camiones_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //UPDATE
        //DELETE
    }
}
