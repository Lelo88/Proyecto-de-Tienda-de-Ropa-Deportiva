using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VendedorDAL
    {
        public DataTable ObtenerProducto()
        {
            Conexion conexion = new Conexion();

            //DEVUELVE TODOS LOS PRODUCTOS
            DataTable dt = conexion.LeerPorComando("select NOMBRE from producto");
            return dt;
        }
        public DataTable ObtenerCantidad(string producto)
        {
            Conexion conexion = new Conexion();

            //DEVUELVE TODOS LOS PRODUCTOS
            return conexion.LeerPorComando($"SELECT cantidad FROM producto where nombre='{producto}'");
             
        }
        public DataTable ObtenerPrecioUnitario(string producto)
        {
            Conexion conexion = new Conexion();

            //DEVUELVE TODOS LOS PRODUCTOS
            DataTable dt = conexion.LeerPorComando($"SELECT precio FROM producto where nombre='{producto}'");
            return dt;
        }
        /*public DataTable ObtenerPrecioUnitario()
        {
            Conexion conexion = new Conexion();

            //DEVUELVE TODOS LOS PRODUCTOS
            DataTable dt = conexion.LeerPorComando("select NOMBRE from producto");
            return dt;
        }*/
        public DataTable ObtenerIdVendedor(string user, string pass)
        {
            Conexion conexion = new Conexion();
            DataTable dt = conexion.LeerPorComando($"SELECT id_empleado from empleado where usuario='{user}' AND contraseña='{pass}'");
            return dt;
        }
        public DataTable ObtenerCantidadDeTodosLosProductos()
        {
            Conexion conexion = new Conexion();

            //DEVUELVE TODOS LOS PRODUCTOS
            return conexion.LeerPorComando($"SELECT cantidad FROM producto ");
        }
        public DataTable ObtenerTodosLosPreciosUnitarios() {
            Conexion conexion = new Conexion();

            //DEVUELVE TODOS LOS PRODUCTOS
            return conexion.LeerPorComando($"SELECT precio FROM producto ");
        }
    }
}
