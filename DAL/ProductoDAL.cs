using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace DAL
{
    public class ProductoDAL
    {
        private readonly Conexion conexion = new Conexion();

        public List<Producto> ObtenerTodosLosProductos()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                string query = "SELECT * FROM producto";
                DataTable dt = conexion.LeerPorComando(query);

                foreach (DataRow row in dt.Rows)
                {
                    productos.Add(MapearProducto(row));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener productos: " + ex.Message);
            }

            return productos;
        }

        public Producto ObtenerProductoPorNombre(string nombre)
        {
            try
            {
                string query = "SELECT * FROM producto WHERE nombre = @nombre";
                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", nombre)
                };

                DataTable dt = conexion.LeerPorComando(query, parametros);
                if (dt.Rows.Count == 0) return null;

                return MapearProducto(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener producto por nombre: " + ex.Message);
                return null;
            }
        }

        public int ObtenerStock(string nombre)
        {
            try
            {
                string query = "SELECT cantidad FROM producto WHERE nombre = @nombre";
                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", nombre)
                };

                DataTable dt = conexion.LeerPorComando(query, parametros);
                if (dt.Rows.Count == 0) return 0;

                return Convert.ToInt32(dt.Rows[0]["cantidad"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener stock: " + ex.Message);
                return 0;
            }
        }

        public float ObtenerPrecio(string nombre)
        {
            try
            {
                string query = "SELECT precio FROM producto WHERE nombre = @nombre";
                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", nombre)
                };

                DataTable dt = conexion.LeerPorComando(query, parametros);
                if (dt.Rows.Count == 0) return 0;

                return Convert.ToSingle(dt.Rows[0]["precio"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener precio: " + ex.Message);
                return 0;
            }
        }

        public bool ActualizarStock(string nombre, int nuevaCantidad)
        {
            try
            {
                string query = "UPDATE producto SET cantidad = @cantidad WHERE nombre = @nombre";
                SqlParameter[] parametros = {
                    new SqlParameter("@cantidad", nuevaCantidad),
                    new SqlParameter("@nombre", nombre)
                };

                return conexion.EscribirPorComando(query, parametros) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar stock: " + ex.Message);
                return false;
            }
        }

        public bool Agregar(Producto producto)
        {
            try
            {
                string query = "INSERT INTO producto (nombre, cantidad, precio, marca, modelo, id_deporte) " +
                               "VALUES (@nombre, @cantidad, @precio, @marca, @modelo, @id_deporte)";

                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", producto.Nombre),
                    new SqlParameter("@cantidad", producto.Cantidad),
                    new SqlParameter("@precio", producto.Precio),
                    new SqlParameter("@marca", producto.Marca),
                    new SqlParameter("@modelo", producto.Modelo),
                    new SqlParameter("@id_deporte", producto.Deporte.Id_Deporte)
                };

                return conexion.EscribirPorComando(query, parametros) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar producto: " + ex.Message);
                return false;
            }
        }

        public bool Actualizar(Producto producto)
        {
            try
            {
                string query = "UPDATE producto SET nombre = @nombre, cantidad = @cantidad, precio = @precio, " +
                               "marca = @marca, modelo = @modelo, id_deporte = @id_deporte WHERE id_producto = @id_producto";

                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", producto.Nombre),
                    new SqlParameter("@cantidad", producto.Cantidad),
                    new SqlParameter("@precio", producto.Precio),
                    new SqlParameter("@marca", producto.Marca),
                    new SqlParameter("@modelo", producto.Modelo),
                    new SqlParameter("@id_deporte", producto.Deporte.Id_Deporte),
                    new SqlParameter("@id_producto", producto.Id_Producto)
                };

                return conexion.EscribirPorComando(query, parametros) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar producto: " + ex.Message);
                return false;
            }
        }

        public bool Eliminar(int idProducto)
        {
            try
            {
                string query = "DELETE FROM producto WHERE id_producto = @id";
                SqlParameter[] parametros = {
                    new SqlParameter("@id", idProducto)
                };

                return conexion.EscribirPorComando(query, parametros) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar producto: " + ex.Message);
                return false;
            }
        }

        private Producto MapearProducto(DataRow row)
        {
            return new Producto
            {
                Id_Producto = Convert.ToInt32(row["id_producto"]),
                Nombre = row["nombre"].ToString(),
                Cantidad = Convert.ToInt32(row["cantidad"]),
                Precio = Convert.ToSingle(row["precio"]),
                Marca = row["marca"].ToString(),
                Modelo = row["modelo"].ToString(),
                Deporte = new Deporte { Id_Deporte = Convert.ToInt32(row["id_deporte"]) }
            };
        }
    }
}
