using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace DAL
{
    public class MetodoDePagoDAL
    {
        private readonly Conexion conexion = new Conexion();

        public List<MetodoDePago> ObtenerTodos()
        {
            List<MetodoDePago> metodos = new List<MetodoDePago>();

            try
            {
                string query = "SELECT id_metodo_de_pago, nombre FROM metodo_de_pago";
                DataTable dt = conexion.LeerPorComando(query);

                foreach (DataRow row in dt.Rows)
                {
                    metodos.Add(new MetodoDePago
                    {
                        IDMetodoDePago = Convert.ToInt32(row["id_metodo_de_pago"]),
                        Nombre = row["nombre"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener métodos de pago: " + ex.Message);
            }

            return metodos;
        }
    }
}
