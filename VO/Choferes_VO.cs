using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Choferes_VO
    {
        private int _ID_Chofer;
        private string _nombre;
        private string _apellido_paterno;
        private string _apellido_materno;
        private string _fecha_nacimiento;
        private string _licencia;
        private string _telefono;
        private bool _disponibilidad;
        private string _urlfoto;

        public int ID_Chofer { get => _ID_Chofer; set => _ID_Chofer = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido_paterno { get => _apellido_paterno; set => _apellido_paterno = value; }
        public string Apellido_materno { get => _apellido_materno; set => _apellido_materno = value; }
        public string Fecha_nacimiento { get => _fecha_nacimiento; set => _fecha_nacimiento = value; }
        public string Licencia { get => _licencia; set => _licencia = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public bool Disponibilidad { get => _disponibilidad; set => _disponibilidad = value; }
        public string Urlfoto { get => _urlfoto; set => _urlfoto = value; }

        public Choferes_VO()
        {
            _ID_Chofer = 0;
            _nombre = "";
            _apellido_paterno = "";
            _apellido_materno = "";
            _fecha_nacimiento = "";
            _licencia = "";
            _telefono = "";
            _disponibilidad = true;
            _urlfoto = "";
        }

        public Choferes_VO(DataRow dr)
        {
            _ID_Chofer = int.Parse(dr["ID_Chofer"].ToString());
            _nombre = dr["nombre"].ToString();
            _apellido_paterno = dr["apellido_paterno"].ToString();
            _apellido_materno = dr["apellido_materno"].ToString();
            _fecha_nacimiento = dr["fecha_nacimiento"].ToString();
            _licencia = dr["licencia"].ToString();
            _telefono = dr["telefono"].ToString();
            _disponibilidad = bool.Parse(dr["disponibilidad"].ToString());
            _urlfoto = dr["urlfoto"].ToString();
        }
    }
}
