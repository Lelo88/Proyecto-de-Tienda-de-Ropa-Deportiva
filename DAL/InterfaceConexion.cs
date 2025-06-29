using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface InterfaceConexion
    {
        DataTable LeerPorComando(string query, SqlParameter[] parametros = null);
        int EscribirPorComando(string query, SqlParameter[] parametros = null);
        SqlParameter CrearParametro(string nombre, object valor, SqlDbType tipo);
    }
}
