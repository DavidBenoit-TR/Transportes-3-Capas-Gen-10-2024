using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_Capas_Gen_10.Utilidades;
using VO;

namespace Transportes_3_Capas_Gen_10.Catalogos.Rutas
{
    public partial class FormularioRutas : System.Web.UI.Page
    {
        public DateTime fecha_salida_global;
        public DateTime fecha_llegada_global;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Cargo mis DDL's
                cargar_ddl();
                //Configuro mis Calendarios
                calactual.SelectedDate = DateTime.Now.Date;
                calactual.VisibleDate = DateTime.Now.Date;
                lblactual.Text = "Fecah Actual: " + DateTime.Now.ToShortDateString();
                //Valido si se desea Insertar o Actualizar
                if (Request.QueryString["Id"] != null)
                {
                    //Voy a Actualizar
                    //recupero el ID de la URL
                    int idruta = int.Parse(Request.QueryString["Id"].ToString());
                    //recupero el objeto original
                    Rutas_VO _ruta = BLL_Rutas.GetRutas("@ID_Ruta", idruta)[0];
                    //valido que realmente haya recuperado una ruta
                    if (_ruta.ID_Ruta != 0)
                    {
                        //Relleno el formulario
                        titulo.Text = "Actualizar Ruta";
                        subtitulo.Text = "Ruta #" + idruta;
                        ddlcamion.SelectedValue = _ruta.Camion_ID.ToString();
                        ddlchoferes.SelectedValue = _ruta.Chofer_ID.ToString();
                        ddlorigen.SelectedValue = _ruta.Direccion_Origen_ID.ToString();
                        ddldestino.SelectedValue = _ruta.Direccion_Destino_ID.ToString();
                        ddlcargamentos.SelectedValue = _ruta.Cargamento_ID.ToString();
                        txtdistancia.Text = _ruta.Distancia.ToString();

                        calestimada.SelectedDate = DateTime.Parse(_ruta.Fecha_llegada_estimada);
                        calestimada.VisibleDate = DateTime.Parse(_ruta.Fecha_llegada_estimada);
                        lblestimada.Text = "Fecha estimada de LLegada: " + _ruta.Fecha_llegada_estimada;

                        calsalida.SelectedDate = DateTime.Parse(_ruta.Fecha_salida);
                        calsalida.VisibleDate = DateTime.Parse(_ruta.Fecha_salida);
                        lblsalida.Text = "Fecha estimada de Salida: " + _ruta.Fecha_salida;

                    }
                    else
                    {
                        //sweet alert
                    }
                }
                else
                {
                    //voy a aInsertar
                    titulo.Text = "Agregar Nueva Ruta";
                    subtitulo.Text = "";

                    calsalida.SelectedDate = DateTime.Now.Date.AddDays(1);
                    calsalida.VisibleDate = DateTime.Now.Date.AddDays(1);
                    lblsalida.Text = "Fecha de Salida: " + DateTime.Now.Date.AddDays(1).ToShortDateString();
                    calestimada.SelectedDate = calsalida.SelectedDate.AddDays(4);
                    calestimada.VisibleDate = calsalida.SelectedDate.AddDays(4);
                    lblestimada.Text = "Fecha estimada de LLegada: " + calsalida.SelectedDate.AddDays(4).ToShortDateString();

                }
            }
        }

        protected void cargar_ddl()
        {
            //ddlcamiones
            //creo un objeto de tipo 'ListItem' para agregarlo a la lista de elementos del DDL
            //ListItem(valor_a_mostar, valor_a_guardar)
            ListItem ddlcamiones_I = new ListItem("Seleccione un camión", "0");
            ddlcamion.Items.Add(ddlcamiones_I);
            //recupero la lsita de camiones disponbiles que voy a pasar al DDL
            List<Camiones_VO> list_c = BLL_Camiones.get_Camiones("@Disponibilidad", true);
            //valido si mi lsita tiene objetos
            if (list_c.Count > 0)
            {
                //recorro mi lista creando nuevos objetos LitItem en función de los datos que requiero
                foreach (var c in list_c)
                {
                    ListItem Ci = new ListItem(
                        (c.Marca + " | " + c.Modelo + " | " + c.Matricula),
                        c.ID_Camion.ToString()
                        );
                    ddlcamion.Items.Add(Ci);
                }
            }
            ////Opción Alternativa apra llenar los DDL
            //ddlcamion.DataSource = BLL_Camiones.get_Camiones(); //llenar el DDL
            //ddlcamion.DataBind(); //mostrar los resultados

            //ddlchoferes
            ListItem ddlchoferes_I = new ListItem("Seleccione un chofer", "0");
            ddlchoferes.Items.Add(ddlchoferes_I);
            List<Choferes_VO> list_ch = BLL_Choferes.get_Choferes();
            if (list_ch.Count > 0)
            {
                foreach (var ch in list_ch)
                {
                    ListItem Chi = new ListItem(
                        (ch.Nombre + " " + ch.Apellido_paterno + " " + ch.Apellido_materno),
                        ch.ID_Chofer.ToString()
                        );
                    ddlchoferes.Items.Add(Chi);
                }
            }

            //ddlchoferes
            ListItem ddlcargamentos_I = new ListItem("Seleccione un cargamento", "0");
            ddlcargamentos.Items.Add(ddlcargamentos_I);
            List<Cargamentos_VO> list_car = BLL_Cargamentos.get_Cargamentos();
            if (list_car.Count > 0)
            {
                foreach (var car in list_car)
                {
                    ListItem cari = new ListItem(
                        car.Descripcion,
                        car.ID_Cargamento.ToString()
                        );
                    ddlcargamentos.Items.Add(cari);
                }
            }

            //ddorigne
            //ddldestino
            ListItem DDL_D = new ListItem("Seleccione una Dirección", "0");
            ddlorigen.Items.Add(DDL_D);
            ddldestino.Items.Add(DDL_D);
            List<Direcciones_VO> list_d = BLL_Direcciones.get_Direcciones();
            if (list_d.Count > 0)
            {
                foreach (var d in list_d)
                {
                    ListItem origen = new ListItem((d.Calle + " # " + d.Numero + " ") + d.Colonia + " " + d.Ciudad, d.ID_Direccion.ToString());
                    ListItem destino = new ListItem((d.Calle + " #" + d.Numero + " ") + d.Colonia + " " + d.Ciudad, d.ID_Direccion.ToString());
                    ddlorigen.Items.Add(origen);
                    ddldestino.Items.Add(destino);
                }
            }
        }

        protected void calsalida_SelectionChanged(object sender, EventArgs e)
        {
            //almacenos la fecha seleccionada en el calendario de salida de forma global
            fecha_salida_global = calsalida.SelectedDate;
            fecha_llegada_global = calsalida.SelectedDate.AddDays(4);

            //asiganos textos especiales a las cabeceras de los calendarios, convirtiendo la fecha estandar en una fecha más legible
            //(dd/MM/aaaa HH:mm:ss => dd/MM/aaaa)
            lblsalida.Text = "Salida Estimada \n" + fecha_salida_global.ToShortDateString();
            lblestimada.Text = "Llegada estimada \n" + fecha_llegada_global.ToShortDateString();
            calestimada.SelectedDate = fecha_llegada_global;
            calestimada.VisibleDate = fecha_llegada_global;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //preparo mi objeto a enviar
            Rutas_VO _ruta = new Rutas_VO();
            //variables apra mi Sweet Alert
            string titulo, msg, tipo, respuesta;

            try
            {
                // Asigno mis valores del formulario al objeto
                _ruta.Distancia = float.Parse(txtdistancia.Text);
                _ruta.Camion_ID = int.Parse(ddlcamion.SelectedValue);
                _ruta.Chofer_ID = int.Parse(ddlchoferes.SelectedValue);
                _ruta.Direccion_Origen_ID = int.Parse(ddlorigen.SelectedValue);
                _ruta.Direccion_Destino_ID = int.Parse(ddldestino.SelectedValue);
                _ruta.Cargamento_ID = int.Parse(ddlcargamentos.SelectedValue);
                //Formateamos la fecha en Inglés, para así enviarla a SQL
                _ruta.Fecha_salida = calsalida.SelectedDate.ToString("yyyy/MM/dd");
                _ruta.Fecha_llegada_estimada = calestimada.SelectedDate.ToString("yyyy/MM/dd");
                _ruta.Fecha_llegada_real = DateTime.MaxValue.ToString("yyyy/MM/dd"); //paso el valor máximo, para así guardarlo en la BD

                //valido si voy a insertar o a actualizar
                if (Request.QueryString["Id"] != null)
                {
                    //Voy a actualziar
                    _ruta.ID_Ruta = int.Parse(Request.QueryString["Id"]);
                    respuesta = BLL_Rutas.ActualizarRuta(_ruta);
                }
                else
                {
                    //Voy a Insertar
                    respuesta = BLL_Rutas.InsertarRuta(_ruta);
                }

                //Preaparo mi Sweet Alert
                if (respuesta.ToUpper().Contains("ERROR"))
                {
                    titulo = "Error";
                    msg = respuesta;
                    tipo = "error";
                    //sweet alert
                    sweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
                }
                else
                {
                    titulo = "Ok!";
                    msg = respuesta;
                    tipo = "success";
                    //sweet alert
                    sweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/catalogos/rutas/listarrutas.aspx");
                }
            }
            catch (Exception ex)
            {
                titulo = "Error";
                msg = ex.Message;
                tipo = "error";
                //sweet alert
                sweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
            }
        }
    }
}