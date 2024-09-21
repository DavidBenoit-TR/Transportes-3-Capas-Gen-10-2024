using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Usuarios
    {
        //Create
        public static string insertar_User(User_VO user)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarUsuario",
                    "@Nombre_Usuario", user.Nombre_Usuario,
                    "@Contraseña", user.Contraseña,
                    "@Rol_ID", user.Rol_ID
                    );

                if (respuesta != 0)
                {
                    salida = "Usuario registrado con éxito";
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
        //Read
        public static List<User_VO> get_Users(params object[] parametros)
        {
            List<User_VO> list_Users = new List<User_VO>();
            try
            {
                DataSet ds_Users = metodos_datos.execute_DataSet("sp_listar_usuarios", parametros);
                foreach (DataRow dr in ds_Users.Tables[0].Rows)
                {
                    list_Users.Add(new User_VO(dr));
                }
                return list_Users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //Login
        public static User_VO Login(string nick, string pass)
        {
            User_VO User = new User_VO();
            try
            {
                DataSet ds_Users = metodos_datos.execute_DataSet("SP_Login",
                    "@Nombre_Usuario", nick,
                    "@Contraseña", pass);
                foreach (DataRow dr in ds_Users.Tables[0].Rows)
                {
                    User = new User_VO(dr);
                }
                return User;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region Roles
        public static List<Roles_vo> get_Roles()
        {
            List<Roles_vo> list_Users = new List<Roles_vo>();
            try
            {
                DataSet ds_Users = metodos_datos.execute_DataSet("sp_listarRoles");
                foreach (DataRow dr in ds_Users.Tables[0].Rows)
                {
                    list_Users.Add(new Roles_vo(dr));
                }
                return list_Users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
