using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MetodoDePagoDAL
    {
        public DataTable ObtenerMetodoDePago()
        {
            Conexion conexion = new Conexion();

            //DEVUELVE TODOS LOS PRODUCTOS
            DataTable dt = conexion.LeerPorComando("select NOMBRE from METODO_DE_PAGO");
            return dt;
        }
    }
}
