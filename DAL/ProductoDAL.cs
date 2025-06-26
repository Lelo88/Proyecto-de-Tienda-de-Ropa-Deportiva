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

        public List<Producto> ObtenerTodos()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                string query = "SELECT * FROM producto";
                DataTable dt = conexion.LeerPorComando(query);

                foreach (DataRow row in dt.Rows)
                {
                    productos.Add(new Producto
                    {
                        Id_Producto = Convert.ToInt32(row["id_producto"]),
                        Nombre = row["nombre"].ToString(),
                        Cantidad = Convert.ToInt32(row["cantidad"]),
                        Precio = Convert.ToSingle(row["precio"]),
                        Marca = row["marca"].ToString(),
                        Modelo = row["modelo"].ToString(),
                        Deporte = new Deporte { Id_Deporte = Convert.ToInt32(row["id_deporte"]) }
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener productos: " + ex.Message);
            }

            return productos;
        }

        public Producto ObtenerPorNombre(string nombre)
        {
            try
            {
                string query = "SELECT * FROM producto WHERE nombre = @nombre";
                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", nombre)
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
                    Modelo = row["modelo"].ToString(),
                    Deporte = new Deporte { Id_Deporte = Convert.ToInt32(row["id_deporte"]) }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener producto por nombre: " + ex.Message);
                return null;
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
    }
}
