using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace DAL
{
    public class VendedorDAL
    {
        private Conexion conexion = new Conexion();

        public List<string> ObtenerNombresDeProductos()
        {
            try
            {
                var productos = new List<string>();
                string query = "SELECT nombre FROM producto";
                DataTable dt = conexion.LeerPorComando(query);

                foreach (DataRow row in dt.Rows)
                {
                    productos.Add(row["nombre"].ToString());
                }

                return productos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener nombres de productos: " + ex.Message);
                return new List<string>();
            }
        }

        public int ObtenerStockPorProducto(string nombreProducto)
        {
            try
            {
                string query = "SELECT cantidad FROM producto WHERE nombre = @nombre";
                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", nombreProducto)
                };

                DataTable dt = conexion.LeerPorComando(query, parametros);
                return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["cantidad"]) : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener stock: " + ex.Message);
                return -1;
            }
        }

        public float ObtenerPrecioPorProducto(string nombreProducto)
        {
            try
            {
                string query = "SELECT precio FROM producto WHERE nombre = @nombre";
                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", nombreProducto)
                };

                DataTable dt = conexion.LeerPorComando(query, parametros);
                return dt.Rows.Count > 0 ? Convert.ToSingle(dt.Rows[0]["precio"]) : -1f;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener precio: " + ex.Message);
                return -1f;
            }
        }

        public Producto ObtenerProductoCompleto(string nombreProducto)
        {
            try
            {
                string query = "SELECT * FROM producto WHERE nombre = @nombre";
                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", nombreProducto)
                };

                DataTable dt = conexion.LeerPorComando(query, parametros);
                if (dt.Rows.Count == 0) return null;

                DataRow row = dt.Rows[0];
                return new Producto
                {
                    Id_Producto = Convert.ToInt32(row["id_producto"]),
                    Nombre = row["nombre"].ToString(),
                    Cantidad = Convert.ToInt32(row["cantidad"]),
                    Precio = Convert.ToSingle(row["precio"]),
                    Marca = row["marca"].ToString(),
                    Modelo = row["modelo"].ToString()
                    // Nota: deberías cargar también el deporte si hacés join
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener producto completo: " + ex.Message);
                return null;
            }
        }
    }
}
