using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Cargamentos_VO
    {
        private int _ID_Cargamento;
        private string _descripcion;
        private double _peso;
        private int _estatus;

        public int ID_Cargamento { get => _ID_Cargamento; set => _ID_Cargamento = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public double Peso { get => _peso; set => _peso = value; }
        public int Estatus { get => _estatus; set => _estatus = value; }

        public Cargamentos_VO()
        {
            _ID_Cargamento = 0;
            _descripcion = "";
            _peso = 0;
            _estatus = 0;
        }

        public Cargamentos_VO(DataRow dr)
        {
            _ID_Cargamento = int.Parse(dr["ID_Cargamento"].ToString());
            _descripcion = dr["descripcion"].ToString();
            _peso = double.Parse(dr["peso"].ToString());
            _estatus = int.Parse(dr["estatus"].ToString());
        }
    }
}
