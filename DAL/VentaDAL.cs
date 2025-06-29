using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class VentaDAL
    {
        private readonly Conexion conexion = new Conexion();

        public int CrearVenta(Venta venta)
        {
            try
            {
                string query = @"INSERT INTO venta (id_empleado, id_cliente, id_metodo_de_pago, fecha, total)
                                 VALUES (@idEmpleado, @idCliente, @idMetodoPago, @fecha, @total);
                                 SELECT SCOPE_IDENTITY();";

                SqlParameter[] parametros = {
                    new SqlParameter("@idEmpleado", venta.Empleado.Id_Empleado),
                    new SqlParameter("@idCliente", venta.Cliente.Id_Cliente),
                    new SqlParameter("@idMetodoPago", venta.Metodo_De_Pago.IDMetodoDePago),
                    new SqlParameter("@fecha", venta.Fecha),
                    new SqlParameter("@total", venta.Total)
                };

                object result = conexion.EjecutarScalar(query, parametros);
                return Convert.ToInt32(result); // Retorna el ID generado
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar la venta: " + ex.Message);
                return -1;
            }
        }


            public List<Venta> ObtenerTodasLasVentas()
            {
                var lista = new List<Venta>();
                string query = @"
                SELECT V.ID_VENTA, V.FECHA, V.TOTAL,
                       C.ID_CLIENTE, C.NOMBRE AS NOMBRE_CLIENTE, C.APELLIDO AS APELLIDO_CLIENTE, C.DNI AS DNI_CLIENTE,
                       E.ID_EMPLEADO, E.NOMBRE AS NOMBRE_EMPLEADO, E.APELIDO AS APELLIDO_EMPLEADO,
                       M.ID_METODO_DE_PAGO, M.NOMBRE AS METODO
                FROM VENTA V
                JOIN CLIENTE C ON V.ID_CLIENTE = C.ID_CLIENTE
                JOIN EMPLEADO E ON V.ID_EMPLEADO = E.ID_EMPLEADO
                JOIN METODO_DE_PAGO M ON V.ID_METODO_DE_PAGO = M.ID_METODO_DE_PAGO";

                DataTable dt = conexion.LeerPorComando(query);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(MapearVenta(row));
                }

                return lista;
            }

            public Venta BuscarVentaPorId(int idVenta)
            {
                SqlParameter[] parametros = {
                conexion.CrearParametro("@idVenta", idVenta, SqlDbType.Int)
            };

                string query = @"
                SELECT V.ID_VENTA, V.FECHA, V.TOTAL,
                       C.ID_CLIENTE, C.NOMBRE AS NOMBRE_CLIENTE, C.APELLIDO AS APELLIDO_CLIENTE, C.DNI AS DNI_CLIENTE,
                       E.ID_EMPLEADO, E.NOMBRE AS NOMBRE_EMPLEADO, E.APELIDO AS APELLIDO_EMPLEADO,
                       M.ID_METODO_DE_PAGO, M.NOMBRE AS METODO
                FROM VENTA V
                JOIN CLIENTE C ON V.ID_CLIENTE = C.ID_CLIENTE
                JOIN EMPLEADO E ON V.ID_EMPLEADO = E.ID_EMPLEADO
                JOIN METODO_DE_PAGO M ON V.ID_METODO_DE_PAGO = M.ID_METODO_DE_PAGO
                WHERE V.ID_VENTA = @idVenta";

                DataTable dt = conexion.LeerPorComando(query, parametros);
                return dt.Rows.Count == 0 ? null : MapearVenta(dt.Rows[0]);
            }

            public List<Venta> ObtenerVentasOrdenadasPor(string campo)
            {
                // Validar campo permitido
                var camposPermitidos = new HashSet<string> { "FECHA", "TOTAL", "NOMBRE_CLIENTE", "NOMBRE_EMPLEADO" };
                if (!camposPermitidos.Contains(campo.ToUpper()))
                    throw new ArgumentException("Campo de ordenamiento inválido.");

                string query = $@"
                SELECT V.ID_VENTA, V.FECHA, V.TOTAL,
                       C.ID_CLIENTE, C.NOMBRE AS NOMBRE_CLIENTE, C.APELLIDO AS APELLIDO_CLIENTE, C.DNI AS DNI_CLIENTE,
                       E.ID_EMPLEADO, E.NOMBRE AS NOMBRE_EMPLEADO, E.APELIDO AS APELLIDO_EMPLEADO,
                       M.ID_METODO_DE_PAGO, M.NOMBRE AS METODO
                FROM VENTA V
                JOIN CLIENTE C ON V.ID_CLIENTE = C.ID_CLIENTE
                JOIN EMPLEADO E ON V.ID_EMPLEADO = E.ID_EMPLEADO
                JOIN METODO_DE_PAGO M ON V.ID_METODO_DE_PAGO = M.ID_METODO_DE_PAGO
                ORDER BY " + campo;

                DataTable dt = conexion.LeerPorComando(query);
                var lista = new List<Venta>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(MapearVenta(row));
                }

                return lista;
            }

            private Venta MapearVenta(DataRow row)
            {
                return new Venta
                {
                    Id_Venta = Convert.ToInt32(row["ID_VENTA"]),
                    Fecha = Convert.ToDateTime(row["FECHA"]),
                    Total = Convert.ToSingle(row["TOTAL"]),
                    Cliente = new Cliente
                    {
                        Id_Cliente = Convert.ToInt32(row["ID_CLIENTE"]),
                        Nombre = row["NOMBRE_CLIENTE"].ToString(),
                        Apellido = row["APELLIDO_CLIENTE"].ToString(),
                        Dni = row["DNI_CLIENTE"].ToString()
                    },
                    Empleado = new Entidad.Vendedor // Puede ser subclase más específica si deseás
                    {
                        Id_Empleado = Convert.ToInt32(row["ID_EMPLEADO"]),
                        Nombre = row["NOMBRE_EMPLEADO"].ToString(),
                        Apellido = row["APELLIDO_EMPLEADO"].ToString()
                    },
                    Metodo_De_Pago = new MetodoDePago
                    {
                        IDMetodoDePago = Convert.ToInt32(row["ID_METODO_DE_PAGO"]),
                        Nombre = row["METODO"].ToString()
                    }
                };
            }
        }
    }

