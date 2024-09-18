using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class metodos_datos
    {
        //método para ejecutar un dataset
        //Utilizado para ejecutar una consulta SQL que devuelve un conjunto de datos
        //que puede contener una o varias tablas con filas y columnas de datos.
        public static DataSet execute_DataSet(string sp, params object[] parametros)
        {
            //instanciamos un DS (DataSet) => Objeto de ADO
            DataSet ds = new DataSet();
            //obtenemos la cadena de conexión desde la clase configuración
            string cadenaConexion = configuracion.CadenaConexion;
            //crear una conexión => SqlConnection Objeto de ADO 
            SqlConnection con = new SqlConnection(cadenaConexion);
            try
            {
                //verificamos si la conexión está abierta
                if (con.State == ConnectionState.Open)
                {
                    //cerramos la conexión
                    con.Close();
                }
                else
                {
                    //Comando para SQL(sp, conexión) => SqlCommand Objeto de ADO
                    SqlCommand cmd = new SqlCommand(sp, con);
                    //definimo que el comando será ejecutado como un SP (Stored Proedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    //pasamos el SP
                    cmd.CommandText = sp;

                    //validamos si existen y están completos los parámmetros.
                    //sis es diferente de null y su residuo es diferente de 0
                    //parametros = {clave:valor}

                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parámetros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        //asignamos los parámetros al comando
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {
                            //SqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }

                        //Abrimos la conexión
                        con.Open();
                        //ejecutamos el comando
                        //SqlDataAdapter => Objeto de ADO
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        //llenamos el ds
                        adapter.Fill(ds);
                        //cerramos la conexión
                        con.Close();
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                //verificamos si la conexión está abierta
                if (con.State == ConnectionState.Open)
                {
                    //Cerramos la conexión
                    con.Close();
                }
            }
        }
        //Métodod que ejecuta un escalar
        //ejecuta una consulta SQL que devuelve un solo valor o una sola columna de dats.
        //retorna el valor de la primera columna y la primera fila del conjutno de resutltado
        public static int execute_Scalar(string sp, params object[] parametros)
        {
            //variable para el control del resultado
            int id = 0;
            DataSet ds = new DataSet();
            //obtenemos la cadena de conexión desde la clase configuración
            string cadenaConexion = configuracion.CadenaConexion;
            //crear una conexión => SqlConnection Objeto de ADO 
            SqlConnection con = new SqlConnection(cadenaConexion);
            try
            {
                //verificamos si la conexión está abierta
                if (con.State == ConnectionState.Open)
                {
                    //cerramos la conexión
                    con.Close();
                }
                else
                {
                    //Comando para SQL(sp, conexión) => SqlCommand Objeto de ADO
                    SqlCommand cmd = new SqlCommand(sp, con);
                    //definimo que el comando será ejecutado como un SP (Stored Proedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    //pasamos el SP
                    cmd.CommandText = sp;

                    //validamos si existen y están completos los parámmetros.
                    //sis es diferente de null y su residuo es diferente de 0
                    //parametros = {clave:valor}

                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parámetros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        //asignamos los parámetros al comando
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {
                            //SqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }

                        //Abrimos la conexión
                        con.Open();
                        //ejecutamos el comando
                        id = int.Parse(cmd.ExecuteScalar().ToString());
                        //cerramos la conexión
                        con.Close();
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                //verificamos si la conexión está abierta
                if (con.State == ConnectionState.Open)
                {
                    //Cerramos la conexión
                    con.Close();
                }
            }
        }
        //Método que ejecuta un NonQuery
        //Utilizado para ejecutar consultas SQL que no devuelven un conjunto de resultados.
        //como sentencias INSERT, UPDATE o DELETE.
        //Retorna un valor entero  que representa el número de filas afectadas por la operación.
        //(por ejemplo, el número de filas insertadas, actualizdas o eliminadas).
        public static int execute_nonQuery(string sp, params object[] parametros)
        {
            //variable para el control del resultado
            int id = 0;
            DataSet ds = new DataSet();
            //obtenemos la cadena de conexión desde la clase configuración
            string cadenaConexion = configuracion.CadenaConexion;
            //crear una conexión => SqlConnection Objeto de ADO 
            SqlConnection con = new SqlConnection(cadenaConexion);
            try
            {
                //verificamos si la conexión está abierta
                if (con.State == ConnectionState.Open)
                {
                    //cerramos la conexión
                    con.Close();
                }
                else
                {
                    //Comando para SQL(sp, conexión) => SqlCommand Objeto de ADO
                    SqlCommand cmd = new SqlCommand(sp, con);
                    //definimo que el comando será ejecutado como un SP (Stored Proedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                    //pasamos el SP
                    cmd.CommandText = sp;

                    //validamos si existen y están completos los parámmetros.
                    //sis es diferente de null y su residuo es diferente de 0
                    //parametros = {clave:valor}

                    if (parametros != null && parametros.Length % 2 != 0)
                    {
                        throw new Exception("Los parámetros deben estar en pares (clave:valor)");
                    }
                    else
                    {
                        //asignamos los parámetros al comando
                        for (int i = 0; i < parametros.Length; i = i + 2)
                        {
                            //SqlParameter => Objeto de ADO
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1].ToString());
                        }

                        //Abrimos la conexión
                        con.Open();
                        //ejecutamos el comando
                        cmd.ExecuteNonQuery();
                        id = 1;
                        //cerramos la conexión
                        con.Close();
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                //verificamos si la conexión está abierta
                if (con.State == ConnectionState.Open)
                {
                    //Cerramos la conexión
                    con.Close();
                }
            }
        }
    }
}
