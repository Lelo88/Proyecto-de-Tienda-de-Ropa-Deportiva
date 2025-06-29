using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace DAL
{
    public class TipoEmpleadoDAL
    {
        private readonly Conexion conexion = new Conexion();

        public List<TipoEmpleado> ObtenerTodos()
        {
            List<TipoEmpleado> tipos = new List<TipoEmpleado>();

            string query = "SELECT id_tipo_empleado, descripcion FROM tipo_empleado";
            DataTable dt = conexion.LeerPorComando(query);

            foreach (DataRow row in dt.Rows)
            {
                tipos.Add(new TipoEmpleado
                {
                    Id_TipoEmpleado = Convert.ToInt32(row["id_tipo_empleado"]),
                    Descripcion = row["descripcion"].ToString()
                });
            }

            return tipos;
        }
    }
}
