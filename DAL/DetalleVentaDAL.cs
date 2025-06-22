using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetalleVentaDAL
    {
        public object AgregarProductoALista(int idVenta,string nombreP,int cantidadP,float precioP)
        {
            Conexion conexion = new Conexion();

            return true;
            //ARREGLAR CONSULTA SQL
            /*string insert = $"INSERT INTO empleado (id_tipo_empleado, nombre, apelido, dni, usuario, contraseña) " +
                $"VALUES ({idTipoEmpleado}, '{nombre}', '{apellido}', '{dni}', '{usuario}', '{contraseña}');";
            return conexion.EscribirPorComando(insert);*/

        }
    }
}
