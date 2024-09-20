using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Rutas
    {
        //Create (crear/insertar)
        public static string InsertarRuta(Rutas_VO ruta)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarRuta",
                        "@Camion_ID", ruta.Camion_ID,
                        "@Chofer_ID", ruta.Chofer_ID,
                        "@Distancia", ruta.Distancia,
                        "@Fecha_salida", ruta.Fecha_salida,
                        "@Fecha_llegadaestimada", ruta.Fecha_llegada_estimada,
                        "@Fecha_llegadareal", ruta.Fecha_llegada_real,
                        "@Direccionorigen_ID", ruta.Direccion_Origen_ID,
                        "@Direcciondestino_ID", ruta.Direccion_Destino_ID,
                        "@Cargamento_ID", ruta.Cargamento_ID
                    );
                if (respuesta != 0)
                {
                    salida = "Ruta registrada con éxito";
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

        //Read (consultar/obtener)
        public static List<Rutas_VO> GetRutas(params object[] parametros)
        {
            List<Rutas_VO> list_rutas = new List<Rutas_VO>();
            try
            {
                DataSet ds_camiones = metodos_datos.execute_DataSet("sp_ListarRutas", parametros);
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list_rutas.Add(new Rutas_VO(dr));
                }
                return list_rutas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update (actualizar/modificar)
        public static string ActualizarRuta(Rutas_VO ruta)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarRuta",
                        "@ID_Ruta", ruta.ID_Ruta,
                        "@Camion_ID", ruta.Camion_ID,
                        "@Chofer_ID", ruta.Chofer_ID,
                        "@Distancia", ruta.Distancia,
                        "@Fecha_salida", ruta.Fecha_salida,
                        "@Fecha_llegadaestimada", ruta.Fecha_llegada_estimada,
                        "@Fecha_llegadareal", ruta.Fecha_llegada_real,
                        "@Direccionorigen_ID", ruta.Direccion_Origen_ID,
                        "@Direcciondestino_ID", ruta.Direccion_Destino_ID,
                        "@Cargamento_ID", ruta.Cargamento_ID
                    ); ;
                if (respuesta != 0)
                {
                    salida = "Ruta Actualizada con éxito";
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

        //Delete (eliminar)
        public static string EliminarRuta(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarRuta",
                    "@ID_Ruta", id
                    );
                if (respuesta != 0)
                {
                    salida = "Ruta eliminada con éxito";
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
