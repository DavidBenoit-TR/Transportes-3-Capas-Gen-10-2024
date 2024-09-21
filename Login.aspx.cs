using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_Capas_Gen_10.Utilidades;

namespace Transportes_3_Capas_Gen_10
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //recuperar los datos del formulario
            var user = txtnickname.Text;
            var pass = txtPassword.Text;

            var hashedpass = ComputeSha512Hash(pass);
            //mandarlo a la capa BLL para validación, y esperar una respuesta
            var session = BLL_Usuarios.Login(user.ToLower(), hashedpass);

            //validar
            if (session[2].ToUpper().Contains("ERROR"))
            {
                //significa que existe un error
                sweetAlert.Sweet_Alert("Error", session[2], "warning", this.Page, this.GetType());
            }
            else
            {
                //to' bien
                //creamos variables de sesión
                Session["user"] = session[0];
                Session["rol"] = session[1];
                //muestro un msj y redirecciono
                sweetAlert.Sweet_Alert("Bienvenido", $"Bienvenido de vuelta {session[0]}", "success", this.Page, this.GetType(), "/catalogos/Camiones/listarCamiones.aspx");
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