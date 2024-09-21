using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_Capas_Gen_10.Utilidades;

namespace Transportes_3_Capas_Gen_10.Catalogos.Usuarios
{
    public partial class listarusuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //recupero las variables de sesión
            string session_user = (string)Session["user"];
            string session_rol = (string)Session["rol"];

            //valido si no están vacías
            if (session_user != null)
            {
                if (!IsPostBack)
                {
                    //Valido acciones por usuario
                    if (session_rol == "2")
                    {
                        //Esto es un Operativo
                        //lo regreso al Login
                        //vaciar las variables de sesión por seguridad
                        Session.Clear();
                        sweetAlert.sweetAlert2("Alto ahí loca", "No has iniciado sesión", "info", this.Page, this.GetType(), "/Login");
                    }
                    else
                    {
                        if (session_rol != "3")
                        {
                            Insertar.Enabled = false;
                        }
                        cargargrid();
                    }
                }
            }
            else
            {
                sweetAlert.sweetAlert2("Alto ahí loca", "No has iniciado sesión", "info", this.Page, this.GetType(), "/Login");
            }


        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioUsuario.aspx");
        }

        public void cargargrid()
        {
            GVUsuarios.DataSource = BLL_Usuarios.get_Users();
            GVUsuarios.DataBind();
        }
    }
}