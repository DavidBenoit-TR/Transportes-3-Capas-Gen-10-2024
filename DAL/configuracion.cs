using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class configuracion
    {
        //Cadena de Conexión
        //Data Source = nombre del servidor de BD
        // localhost
        // .
        // Nombre de mi instancia
        //Inital Catalog = nombre de la BD
        //Integrated Security = true (Credenciales de la máquina)
        //= false (Credenciales de acceso)
        //Se habilitan los campos de
        // User =;
        // Password =;
        static string _cadenaConexion = @"Data Source = DESKTOP-C6HPFG2\SQLEXPRESS01;
                                          Initial Catalog = Transportes;
                                          Integrated Security = true;";

        public static string CadenaConexion //Encapsulamiento
        {
            get { return _cadenaConexion; }
        }
    }
}
