using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Transportes_3_Capas_Gen_10.Utilidades
{
    public class sweetAlert
    {
        public static void Sweet_Alert(string title, string msg, string type, Page pg, Object obj)
        {
            string sa = "<script languaje='javascript'>" +
                "Swal.fire({" +
                "title: '" + title + "'," +
                "text: '" + msg + "'," +
                "icon: '" + type + "'" +
                "});" +
                "</script>";

            //Type hace referencia al tipo de objeto que voy a trabajar
            Type cstype = obj.GetType();
            //ClientScriptManager me ayuda a  incrustar bloques de Código de JS en tiempo real
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, sa, sa);
        }

        public static void Sweet_Alert(string title, string msg, string type, Page pg, Object obj, string dir)
        {
            string sa = "<script languaje='javascript'>" +
                "Swal.fire({" +
                "title: '" + title + "'," +
                "text: '" + msg + "'," +
                "icon: '" + type + "'" +
                "}).then((result)=>{" +
                "if(result.isConfirmed){" +
                "window.location.href = '" + dir + "'" +
                "}" +
                "});" +
                "</script>";

            //Type hace referencia al tipo de objeto que voy a trabajar
            Type cstype = obj.GetType();
            //ClientScriptManager me ayuda a  incrustar bloques de Código de JS en tiempo real
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, sa, sa);
        }

        public static void sweetAlert2(string title, string msg, string type, Page pg, Object obj, string dir)
        {
            //guardo el script de JS que voy a inyectar
            string sa = "<script language='javascript'>" +
                "Swal.fire({  " +
                "text: '" + msg.Replace("\r\n", "\\n").Replace("'", "") + "'," +
                "imageUrl: 'https://i.ytimg.com/vi/y4EZcunxvw8/maxresdefault.jpg'," +
                "imageWidth: 400," +
                "imageHeight: 200," +
                "imageAlt: 'Custom image'" +
                "}).then((result) => {" +
                "if(result.isConfirmed){" +
                "window.location.href='" + dir + "'" +
                "}" +
                "});" +
                "</script>";

            //obtengo el tipo de estilo y propiedades provienientes el doblejo
            Type csType = obj.GetType();
            //crea un "ClientScriptManager" que me permitirá modificar las ejecuciones y llamadas del JS en tiempo Real
            ClientScriptManager cs = pg.ClientScript;
            //usando "ClientScripManager" incrusto en la página el contenido JS
            cs.RegisterClientScriptBlock(csType, sa, sa);
        }
    }
}