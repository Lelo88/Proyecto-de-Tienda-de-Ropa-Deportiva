using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DeporteDAL
    {
        public DataTable ObtenerDeportes() {
            Conexion conexion = new Conexion();

            //DEVUELVE TODOS LOS DEPORTES
            DataTable dt = conexion.LeerPorComando("select nombre from deporte");
            return dt;
        }
    }
}
