using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Usuarios
    {
        //Create
        public static string insertar_User(User_VO user)
        {
            return DAL_Usuarios.insertar_User(user);
        }
        //Read
        public static List<User_VO> get_Users(params object[] parametros)
        {
            return DAL_Usuarios.get_Users(parametros);
        }
        //Login
        public static List<string> Login(string nick, string pass)
        {
            //Recupero el Usuario que corresponda
            User_VO usuario = DAL_Usuarios.Login(nick, pass);
            //preparar las variables que necesito
            string nombre = "", rol = "", error = "";
            List<string> respuesta = new List<string>();
            //valido si realmente existe el usuario
            if (usuario.ID_Usuario != 0)
            {
                //Si exite y se recuperó
                nombre = usuario.Nombre_Usuario;
                rol = usuario.Rol_ID.ToString();
            }
            else
            {
                //no hay nada
                error = "Error: No se ha encontrado el usuario en la Base de datos";
            }
            //añadimos las variables de respuesta a la lsita
            respuesta.Add(nombre);
            respuesta.Add(rol);
            respuesta.Add(error);
            //devolvemos la lista
            return respuesta;
        }

        #region Roles
        public static List<Roles_vo> get_Roles()
        {
            return DAL_Usuarios.get_Roles();
        }
        #endregion
    }
}
