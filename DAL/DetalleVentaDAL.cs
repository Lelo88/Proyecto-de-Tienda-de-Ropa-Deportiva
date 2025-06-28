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
    }
}
