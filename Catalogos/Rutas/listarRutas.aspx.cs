using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transportes_3_Capas_Gen_10.Catalogos.Rutas
{
    public partial class listarRutas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargargrid();
            }
        }

        private void cargargrid()
        {
            GVRutas.DataSource = BLL_Rutas.GetRutas();
            GVRutas.DataBind();
        }

        protected void GVRutas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int varIndex = int.Parse(e.CommandArgument.ToString());
                string id = GVRutas.DataKeys[varIndex].Values["ID_Ruta"].ToString();
                Response.Redirect("FormularioRutas.aspx?Id=" + id);
            }
        }

        protected void GVRutas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idruta = int.Parse(GVRutas.DataKeys[e.RowIndex].Values["ID_Ruta"].ToString());
            string respuesta = BLL_Rutas.EliminarRuta(idruta);
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo = "Ops...";
                msg = respuesta;
                tipo = "error";
            }
            else
            {

                titulo = "Correcto!";
                msg = respuesta;
                tipo = "success";
            }
            cargargrid();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioRutas.aspx");
        }
    }
}