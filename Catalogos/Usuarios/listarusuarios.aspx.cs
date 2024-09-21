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
            if (!IsPostBack)
            {
                cargargrid();
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