using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Conexion : InterfaceConexion
    {
        private SqlConnection _conexion;
        private string _cadenaConexion;

        public Conexion()
        {
            _cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        }

        private void Conectar()
        {
            _conexion = new SqlConnection(_cadenaConexion);
            _conexion.Open();
        }

        private void Desconectar()
        {
            if (_conexion != null && _conexion.State == ConnectionState.Open)
            {
                _conexion.Close();
                _conexion.Dispose();
            }
        }

        public DataTable LeerPorComando(string query, SqlParameter[] parametros = null)
        {
            DataTable tabla = new DataTable();
            SqlCommand comando = new SqlCommand(query);

            try
            {
                Conectar();
                comando.Connection = _conexion;
                comando.CommandType = CommandType.Text;
                if (parametros != null)
                    comando.Parameters.AddRange(parametros);

                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            finally
            {
                Desconectar();
            }

            return tabla;
        }

        public int EscribirPorComando(string query, SqlParameter[] parametros = null)
        {
            SqlCommand comando = new SqlCommand(query);
            int filasAfectadas = 0;

            try
            {
                Conectar();
                comando.Connection = _conexion;
                comando.CommandType = CommandType.Text;
                if (parametros != null)
                    comando.Parameters.AddRange(parametros);

                filasAfectadas = comando.ExecuteNonQuery();
            }
            finally
            {
                Desconectar();
            }

            return filasAfectadas;
        }

        public SqlParameter CrearParametro(string nombre, object valor, SqlDbType tipo)
        {
            return new SqlParameter(nombre, tipo)
            {
                Value = valor ?? DBNull.Value
            };
        }
    }
}
