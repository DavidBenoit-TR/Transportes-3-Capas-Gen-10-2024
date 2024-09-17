using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Camiones_VO
    {
        //VO =  View Object
        //Representación de una talba SQL a nivel de código C#
        private int _ID_Camion;
        private string _matricula;
        private int _capacidad;
        private string _tipo_camion;
        private string _urlfoto;
        private string _marca;
        private string _modelo;
        private double _kilometraje;
        private bool _disponibilidad;


        //Encapsulamiento
        public int ID_Camion { get => _ID_Camion; set => _ID_Camion = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public int Capacidad { get => _capacidad; set => _capacidad = value; }
        public string Tipo_camion { get => _tipo_camion; set => _tipo_camion = value; }
        public string Urlfoto { get => _urlfoto; set => _urlfoto = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public double Kilometraje { get => _kilometraje; set => _kilometraje = value; }
        public bool Disponibilidad { get => _disponibilidad; set => _disponibilidad = value; }

        //Constructor
        //Por defecto
        public Camiones_VO()
        {
            _ID_Camion = 0;
            _matricula = "";
            _capacidad = 0;
            _tipo_camion = "";
            _urlfoto = string.Empty;
            _marca = "";
            _modelo = "";
            _kilometraje = 0;
            _disponibilidad = true;
        }

        //Contructor con parámetros (Datarow)
        //Datarow => Objeto de ADO
        public Camiones_VO(DataRow dr)
        {
            _ID_Camion = int.Parse(dr["ID_Camion"].ToString());
            _matricula = dr["matricula"].ToString();
            _capacidad = int.Parse(dr["capacidad"].ToString());
            _tipo_camion = dr["tipo_camion"].ToString();
            _urlfoto = dr["urlfoto"].ToString();
            _marca = dr["marca"].ToString();
            _modelo = dr["modelo"].ToString();
            _kilometraje = double.Parse(dr["kilometraje"].ToString());
            _disponibilidad = bool.Parse(dr["disponibilidad"].ToString());
        }
    }
}
