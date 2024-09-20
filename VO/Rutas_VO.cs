using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Rutas_VO
    {
        private int _ID_Ruta;
        private double _distancia;
        private string _fecha_salida;
        private string _fecha_llegada_estimada;
        private string _fecha_llegada_real;
        private int _Camion_ID;
        private int _Chofer_ID;
        private int _Direccion_Origen_ID;
        private int _Direccion_Destino_ID;
        private int _Cargamento_ID;

        public int ID_Ruta { get => _ID_Ruta; set => _ID_Ruta = value; }
        public double Distancia { get => _distancia; set => _distancia = value; }
        public string Fecha_salida { get => _fecha_salida; set => _fecha_salida = value; }
        public string Fecha_llegada_estimada { get => _fecha_llegada_estimada; set => _fecha_llegada_estimada = value; }
        public string Fecha_llegada_real { get => _fecha_llegada_real; set => _fecha_llegada_real = value; }
        public int Camion_ID { get => _Camion_ID; set => _Camion_ID = value; }
        public int Chofer_ID { get => _Chofer_ID; set => _Chofer_ID = value; }
        public int Direccion_Origen_ID { get => _Direccion_Origen_ID; set => _Direccion_Origen_ID = value; }
        public int Direccion_Destino_ID { get => _Direccion_Destino_ID; set => _Direccion_Destino_ID = value; }
        public int Cargamento_ID { get => _Cargamento_ID; set => _Cargamento_ID = value; }

        public Rutas_VO()
        {
            _ID_Ruta = 0;
            _distancia = 0;
            _fecha_salida = "";
            _fecha_llegada_estimada = "";
            _fecha_llegada_real = "";
            _Camion_ID = 0;
            _Chofer_ID = 0;
            _Direccion_Origen_ID = 0;
            _Direccion_Destino_ID = 0;
            _Cargamento_ID = 0;
        }

        public Rutas_VO(DataRow dr)
        {
            _ID_Ruta = int.Parse(dr["ID_Ruta"].ToString());
            _distancia = int.Parse(dr["distancia"].ToString());
            //1. Recupero la Fecha del DR => dr["Fecha_Salida"].ToString()
            //2. Convierto la fecha a ujn DateTime => DateTime.Parse()
            //3. Convierto nuevamente la fecha a un string con formato aaaa/MM/dd => .ToShortDateString()
            _fecha_salida = DateTime.Parse(dr["fecha_salida"].ToString()).ToShortDateString();
            _fecha_llegada_estimada = DateTime.Parse(dr["fecha_llegada_estimada"].ToString()).ToShortDateString();
            _fecha_llegada_real = DateTime.Parse(dr["fecha_llegada_real"].ToString()).ToShortDateString();
            _Camion_ID = int.Parse(dr["Camion_ID"].ToString());
            _Chofer_ID = int.Parse(dr["Chofer_ID"].ToString());
            _Direccion_Origen_ID = int.Parse(dr["Direccion_Origen_ID"].ToString());
            _Direccion_Destino_ID = int.Parse(dr["Direccion_Destino_ID"].ToString());
            _Cargamento_ID = int.Parse(dr["Cargamento_ID"].ToString());
        }
    }
}
