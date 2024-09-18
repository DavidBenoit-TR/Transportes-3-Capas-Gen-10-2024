using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Camiones
    {
        //CREATE
        public static string insertar_Camion(Camiones_VO camion)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarCamion",
                    "@Matricula", camion.Matricula,
                    "@Tipo_Camion", camion.Tipo_camion,
                    "@Marca", camion.Marca,
                    "@Modelo", camion.Modelo,
                    "@Capacidad", camion.Capacidad,
                    "@Kilometraje", camion.Kilometraje,
                    "@UrlFoto", camion.Urlfoto,
                    "@Disponibilidad", camion.Disponibilidad
                    );

                if (respuesta != 0)
                {
                    salida = "Camión registrado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = "Error: " + e.Message;
            }
            return salida;
        }
        //READ
        public static List<Camiones_VO> get_Camiones(params object[] parametros)
        {
            //creo una lsita de objetos a llenar
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {
                //crear un Dataset el cual recibirá lo que devuelva la ejecución del método "execute_Dataset" proviniente de la clase "metodos_Datos"
                DataSet ds_camiones = metodos_datos.execute_DataSet("sp_ListarCamiones", parametros);
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
        public static string update_Camion(Camiones_VO camion)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarCamion",
                    "@ID_Camion", camion.ID_Camion,
                    "@Matricula", camion.Matricula,
                    "@Tipo_Camion", camion.Tipo_camion,
                    "@Marca", camion.Marca,
                    "@Modelo", camion.Modelo,
                    "@Capacidad", camion.Capacidad,
                    "@Kilometraje", camion.Kilometraje,
                    "@UrlFoto", camion.Urlfoto,
                    "@Disponibilidad", camion.Disponibilidad
                    );

                if (respuesta != 0)
                {
                    salida = "Camión actualizado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = "Error: " + e.Message;
            }
            return salida;
        }
        //DELETE
        public static string delete_Camion(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarCamion",
                    "@ID_Camion", id
                    );

                if (respuesta != 0)
                {
                    salida = "Camión eliminado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = "Error: " + e.Message;
            }
            return salida;
        }
    }
}
