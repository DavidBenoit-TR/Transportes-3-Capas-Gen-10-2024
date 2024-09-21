using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_Capas_Gen_10.Utilidades;

namespace Transportes_3_Capas_Gen_10
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //recuperar la variable de Sesión
            var session = (string)Session["user"];
            string var_rol = (string)Session["rol"];
            //si no existe la variable
            if (session == null)
            {
                //escondo el navbar
                nav.Visible = false;
            }
            else
            {
                if (var_rol != "Admin")
                {
                    Users.Visible = false;
                }

                usuario.Text = session;
                //muestro el navbar
                nav.Visible = true; 
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            sweetAlert.Sweet_Alert("Hasta pronto", "Adiós", "info", this.Page, this.GetType(), "/Login");
        }
    }
}