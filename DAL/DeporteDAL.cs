using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace DAL
{
    public class DeporteDAL
    {
        private readonly Conexion conexion = new Conexion();

        public List<Deporte> ObtenerTodos()
        {
            List<Deporte> deportes = new List<Deporte>();

            try
            {
                string query = "SELECT id_deporte, nombre FROM deporte";
                DataTable dt = conexion.LeerPorComando(query);

                foreach (DataRow row in dt.Rows)
                {
                    deportes.Add(new Deporte
                    {
                        Id_Deporte = Convert.ToInt32(row["id_deporte"]),
                        Nombre = row["nombre"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener deportes: " + ex.Message);
            }

            return deportes;
        }
    }
}
