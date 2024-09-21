using BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_Capas_Gen_10.Utilidades;
using VO;

namespace Transportes_3_Capas_Gen_10.Catalogos.Usuarios
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarddl();
            }
        }

        public void cargarddl()
        {
            //ddlchoferes
            ListItem ddl_item = new ListItem("Seleccione un Rol", "0");
            ddlrol.Items.Add(ddl_item);
            List<Roles_vo> list_rol = BLL_Usuarios.get_Roles();
            if (list_rol.Count > 0)
            {
                foreach (var rol in list_rol)
                {
                    ListItem rol_item = new ListItem(
                        rol.Nombre,
                        rol.ID_Rol.ToString()
                        );
                    ddlrol.Items.Add(rol_item);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            var a = txtPassword_C.Text;
            var b = txtPassword.Text;

            if (a != b)
            {
                lblPasswordMatch.Text = "Las Contraseñas no Coinciden";
                lblPasswordMatch.ForeColor = Color.White;
                lblPasswordMatch.ForeColor = Color.Red;
            }
            else
            {
                User_VO newuser = new User_VO();
                newuser.Nombre_Usuario = txtnickname.Text.ToLower();
                newuser.Rol_ID = int.Parse(ddlrol.SelectedValue);

                //Manejo de contraseña
                var hashedPassword = ComputeSha512Hash(txtPassword_C.Text);
                newuser.Contraseña = hashedPassword;

                string respuesta = "", titulo = "", tipo = "";
                respuesta = BLL_Usuarios.insertar_User(newuser);

                if (respuesta.ToUpper().Contains("ERROR"))
                {
                    titulo = "Error";
                    tipo = "error";
                }
                else
                {
                    titulo = "Ok";
                    tipo = "success";
                }

                sweetAlert.Sweet_Alert(titulo, respuesta, tipo, this.Page, this.GetType(), "/Catalogos/Usuarios/ListarUsuarios.aspx");
            }
        }

        private static string ComputeSha512Hash(string rawData)
        {
            //Raw Data (Pronunciado: roh –dei-ta) es todo tipo de data que no ha sido procesada aún.
            using (SHA512 sha512Hash = SHA512.Create())
            {
                //ComputeHash => deolver el array de bytes de la palabra ya cifrada
                byte[] bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                //convertimos el array a un nuevo string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    //La cadena de formato "x2" en el método ToString se utiliza para convertir un byte a su representación hexadecimal, asegurando que cada byte se represente con dos caracteres:

                    //"x": Especifica que el formato de la cadena debe ser hexadecimal en minúsculas.
                    //"2": Indica que la cadena resultante debe tener al menos dos caracteres.Si el valor hexadecimal del byte es un solo carácter(por ejemplo, 0x5), se agregará un cero a la izquierda para hacer dos caracteres(05).
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}