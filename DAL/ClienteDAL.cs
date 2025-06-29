using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace DAL
{
    public class ClienteDAL
    {
        private readonly Conexion conexion = new Conexion();

        public Cliente ObtenerPorDni(string dni)
        {
            try
            {
                string query = "SELECT * FROM cliente WHERE dni = @dni";
                SqlParameter[] parametros = {
                    new SqlParameter("@dni", dni)
                };

                DataTable dt = conexion.LeerPorComando(query, parametros);

                if (dt.Rows.Count == 0) return null;

                DataRow row = dt.Rows[0];
                return new Cliente
                {
                    Id_Cliente = Convert.ToInt32(row["id_cliente"]),
                    Nombre = row["nombre"].ToString(),
                    Apellido = row["apellido"].ToString(),
                    Dni = row["dni"].ToString()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar cliente por DNI: " + ex.Message);
                return null;
            }
        }

        public bool Crear(Cliente cliente)
        {
            try
            {
                string query = "INSERT INTO cliente (nombre, apellido, dni) VALUES (@nombre, @apellido, @dni)";
                SqlParameter[] parametros = {
                    new SqlParameter("@nombre", cliente.Nombre),
                    new SqlParameter("@apellido", cliente.Apellido),
                    new SqlParameter("@dni", cliente.Dni)
                };

                return conexion.EscribirPorComando(query, parametros) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear cliente: " + ex.Message);
                return false;
            }
        }

        public List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                string query = "SELECT * FROM cliente";
                DataTable dt = conexion.LeerPorComando(query);

                foreach (DataRow row in dt.Rows)
                {
                    clientes.Add(new Cliente
                    {
                        Id_Cliente = Convert.ToInt32(row["id_cliente"]),
                        Nombre = row["nombre"].ToString(),
                        Apellido = row["apellido"].ToString(),
                        Dni = row["dni"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar clientes: " + ex.Message);
            }

            return clientes;
        }
    }
}
