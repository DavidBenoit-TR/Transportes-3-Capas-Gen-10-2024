using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Roles_vo
    {
        private int _ID_Rol;
        private string _Nombre;

        public int ID_Rol { get => _ID_Rol; set => _ID_Rol = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }


        public Roles_vo()
        {
            _ID_Rol = 0;
            _Nombre = "";
        }

        public Roles_vo(DataRow dr)
        {
            _ID_Rol = int.Parse(dr["ID_Rol"].ToString());
            _Nombre = dr["Nombre"].ToString();
        }
    }
}
