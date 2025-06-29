using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace DAL
{
    public class EncargadoDAL
    {
        private readonly Conexion conexion = new Conexion();
       
        public List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();
            string query = @"SELECT p.id_producto, p.nombre, p.cantidad, p.marca, p.modelo, p.precio,
                                    d.id_deporte, d.nombre AS nombre_deporte
                             FROM producto p
                             INNER JOIN deporte d ON d.id_deporte = p.id_deporte";

            try
            {
                DataTable dt = conexion.LeerPorComando(query);

                foreach (DataRow row in dt.Rows)
                {
                    productos.Add(new Producto
                    {
                        Id_Producto = Convert.ToInt32(row["id_producto"]),
                        Nombre = row["nombre"].ToString(),
                        Cantidad = Convert.ToInt32(row["cantidad"]),
                        Marca = row["marca"].ToString(),
                        Modelo = row["modelo"].ToString(),
                        Precio = Convert.ToSingle(row["precio"]),
                        Deporte = new Deporte
                        {
                            Id_Deporte = Convert.ToInt32(row["id_deporte"]),
                            Nombre = row["nombre_deporte"].ToString()
                        }
                    });
                }

                return productos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar productos: {ex.Message}");
                return new List<Producto>();
            }
        }

        public bool AgregarProducto(Producto producto)
        {
            string query = @"INSERT INTO producto (id_deporte, nombre, cantidad, marca, modelo, precio) 
                             VALUES (@id_deporte, @nombre, @cantidad, @marca, @modelo, @precio)";

            SqlParameter[] parametros = {
                conexion.CrearParametro("@id_deporte", producto.Deporte.Id_Deporte, SqlDbType.Int),
                conexion.CrearParametro("@nombre", producto.Nombre, SqlDbType.VarChar),
                conexion.CrearParametro("@cantidad", producto.Cantidad, SqlDbType.Int),
                conexion.CrearParametro("@marca", producto.Marca, SqlDbType.VarChar),
                conexion.CrearParametro("@modelo", producto.Modelo, SqlDbType.VarChar),
                conexion.CrearParametro("@precio", producto.Precio, SqlDbType.Float)
            };

            try
            {
                return conexion.EscribirPorComando(query, parametros) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar producto: {ex.Message}");
                return false;
            }
        }

        public bool ModificarProducto(Producto producto)
        {
            string query = @"UPDATE producto SET 
                                id_deporte = @id_deporte,
                                nombre = @nombre,
                                cantidad = @cantidad,
                                marca = @marca,
                                modelo = @modelo,
                                precio = @precio
                             WHERE id_producto = @id_producto";

            SqlParameter[] parametros = {
                conexion.CrearParametro("@id_producto", producto.Id_Producto, SqlDbType.Int),
                conexion.CrearParametro("@id_deporte", producto.Deporte.Id_Deporte, SqlDbType.Int),
                conexion.CrearParametro("@nombre", producto.Nombre, SqlDbType.VarChar),
                conexion.CrearParametro("@cantidad", producto.Cantidad, SqlDbType.Int),
                conexion.CrearParametro("@marca", producto.Marca, SqlDbType.VarChar),
                conexion.CrearParametro("@modelo", producto.Modelo, SqlDbType.VarChar),
                conexion.CrearParametro("@precio", producto.Precio, SqlDbType.Float)
            };

            try
            {
                return conexion.EscribirPorComando(query, parametros) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar producto: {ex.Message}");
                return false;
            }
        }

        public bool EliminarProducto(int idProducto)
        {
            string query = "DELETE FROM producto WHERE id_producto = @id_producto";
            SqlParameter[] parametros = {
                conexion.CrearParametro("@id_producto", idProducto, SqlDbType.Int)
            };

            try
            {
                return conexion.EscribirPorComando(query, parametros) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar producto: {ex.Message}");
                return false;
            }
        }
    }
}
