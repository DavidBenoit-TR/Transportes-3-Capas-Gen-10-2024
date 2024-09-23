using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_Capas_Gen_10.CalculadoraService;

namespace Transportes_3_Capas_Gen_10.Catalogos.Calculadora
{
    public partial class Calculadora : System.Web.UI.Page
    {
        //crear una cliente que resuelva las peticiones del servicio SOAP
        calculadora_ServiceSoapClient cliente_WS;
        protected void Page_Load(object sender, EventArgs e)
        {
            //inicializo mi cliente SOAP
            cliente_WS = new calculadora_ServiceSoapClient();
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            //Recuperar ñps datos de mi formularii
            double a = double.Parse(txta.Text);
            double b = double.Parse(txtb.Text);
            //invocco mi servisio pasando los datos que requiere
            double resultado = cliente_WS.Suma(a, b);
            //muestro el resultado del servicio en mi cliente
            lblresultado.Text = resultado.ToString();
        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            //Recuperar ñps datos de mi formularii
            double a = double.Parse(txta.Text);
            double b = double.Parse(txtb.Text);
            //invocco mi servisio pasando los datos que requiere
            double resultado = cliente_WS.Resta(a, b);
            //muestro el resultado del servicio en mi cliente
            lblresultado.Text = resultado.ToString();
        }

        protected void btnMultiplicar_Click(object sender, EventArgs e)
        {
            //Recuperar ñps datos de mi formularii
            double a = double.Parse(txta.Text);
            double b = double.Parse(txtb.Text);
            //invocco mi servisio pasando los datos que requiere
            double resultado = cliente_WS.Multiplicacion(a, b);
            //muestro el resultado del servicio en mi cliente
            lblresultado.Text = resultado.ToString();
        }

        protected void btnDividir_Click(object sender, EventArgs e)
        {
            //Recuperar ñps datos de mi formularii
            double a = double.Parse(txta.Text);
            double b = double.Parse(txtb.Text);
            //invocco mi servisio pasando los datos que requiere
            double resultado = cliente_WS.Division(a, b);
            //muestro el resultado del servicio en mi cliente
            lblresultado.Text = resultado.ToString();
        }
    }
}