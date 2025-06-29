using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DetalleVentaDAL
    {
        private readonly Conexion conexion = new Conexion();

        public bool CrearDetalle(DetalleVenta detalle)
        {
            try
            {
                string query = @"INSERT INTO detalle_venta (id_venta, id_producto, cantidad, precio_unitario)
                                 VALUES (@idVenta, @idProducto, @cantidad, @precioUnitario)";

                SqlParameter[] parametros = {
                    new SqlParameter("@idVenta", detalle.Venta.Id_Venta),
                    new SqlParameter("@idProducto", detalle.Producto.Id_Producto),
                    new SqlParameter("@cantidad", detalle.Cantidad),
                    new SqlParameter("@precioUnitario", detalle.Precio_Unitario)
                };

                return conexion.EscribirPorComando(query, parametros) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar detalle de venta: " + ex.Message);
                return false;
            }
        }

        public bool CrearDetallesLote(List<DetalleVenta> detalles)
        {
            bool todoOk = true;

            foreach (var detalle in detalles)
            {
                if (!CrearDetalle(detalle))
                    todoOk = false; // Se puede adaptar a rollback si luego usás transacciones
            }

            return todoOk;
        }

        public List<DetalleVenta> ObtenerDetallesPorVenta(int idVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();

            SqlParameter[] parametros = {
                conexion.CrearParametro("@idVenta", idVenta, SqlDbType.Int)
            };

            string query = @"
                SELECT DV.ID_DETALLE, DV.ID_VENTA, DV.CANTIDAD, DV.PRECIO_UNITARIO,
                       P.ID_PRODUCTO, P.NOMBRE AS NOMBRE_PRODUCTO, P.MARCA, P.MODELO
                FROM DETALLE_VENTA DV
                JOIN PRODUCTO P ON DV.ID_PRODUCTO = P.ID_PRODUCTO
                WHERE DV.ID_VENTA = @idVenta";

            DataTable dt = conexion.LeerPorComando(query, parametros);

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(MapearDetalleVenta(row));
            }

            return lista;
        }

        private DetalleVenta MapearDetalleVenta(DataRow row)
        {
            return new DetalleVenta
            {
                Id_Detalle = Convert.ToInt32(row["ID_DETALLE"]),
                Cantidad = Convert.ToInt32(row["CANTIDAD"]),
                Precio_Unitario = Convert.ToSingle(row["PRECIO_UNITARIO"]),
                Producto = new Producto
                {
                    Id_Producto = Convert.ToInt32(row["ID_PRODUCTO"]),
                    Nombre = row["NOMBRE_PRODUCTO"].ToString(),
                    Marca = row["MARCA"].ToString(),
                    Modelo = row["MODELO"].ToString()
                }
            };
        }
    }
}
