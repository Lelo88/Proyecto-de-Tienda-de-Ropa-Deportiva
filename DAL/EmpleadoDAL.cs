using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmpleadoDAL
    {
        private Conexion conexion = new Conexion();

        public DataTable Iniciar_Sesion()
        {
            try
            {
                string query = "SELECT E.USUARIO, E.CONTRASEÑA, TE.descripcion " +
                               "FROM EMPLEADO E " +
                               "INNER JOIN TIPO_EMPLEADO TE ON E.ID_TIPO_EMPLEADO = TE.ID_TIPO_EMPLEADO";
                return conexion.LeerPorComando(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al iniciar sesión: " + ex.Message);
                return null;
            }
        }

        public int AgregarEmpleado(int idTipoEmpleado, string nombre, string apellido, string dni, string usuario, string contraseña)
        {
            try
            {
                string query = "INSERT INTO EMPLEADO (id_tipo_empleado, nombre, apelido, dni, usuario, contraseña) " +
                               "VALUES (@idTipoEmpleado, @nombre, @apellido, @dni, @usuario, @contrasena)";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@idTipoEmpleado", idTipoEmpleado),
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@apellido", apellido),
                    new SqlParameter("@dni", dni),
                    new SqlParameter("@usuario", usuario),
                    new SqlParameter("@contrasena", contraseña)
                };

                return conexion.EscribirPorComando(query, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar empleado: " + ex.Message);
                return -1;
            }
        }

        public int ModificarEmpleado(int idEmpleado, int idTipoEmpleado, string nombre, string apellido, string dni, string usuario, string contraseña)
        {
            try
            {
                string query = "UPDATE EMPLEADO SET id_tipo_empleado = @idTipoEmpleado, nombre = @nombre, apelido = @apellido, dni = @dni, usuario = @usuario, contraseña = @contrasena " +
                               "WHERE id_empleado = @idEmpleado";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@idEmpleado", idEmpleado),
                    new SqlParameter("@idTipoEmpleado", idTipoEmpleado),
                    new SqlParameter("@nombre", nombre),
                    new SqlParameter("@apellido", apellido),
                    new SqlParameter("@dni", dni),
                    new SqlParameter("@usuario", usuario),
                    new SqlParameter("@contrasena", contraseña)
                };

                return conexion.EscribirPorComando(query, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar empleado: " + ex.Message);
                return -1;
            }
        }

        public int EliminarEmpleado(int idEmpleado)
        {
            try
            {
                string query = "DELETE FROM EMPLEADO WHERE id_empleado = @idEmpleado";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@idEmpleado", idEmpleado)
                };

                return conexion.EscribirPorComando(query, parametros);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar empleado: " + ex.Message);
                return -1;
            }
        }

        public DataTable ObtenerTiposDeEmpleado()
        {
            try
            {
                string query = "SELECT ID_TIPO_EMPLEADO, DESCRIPCION FROM TIPO_EMPLEADO";
                return conexion.LeerPorComando(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener tipos de empleado: " + ex.Message);
                return null;
            }
        }

        public DataTable ListarEmpleados()
        {
            try
            {
                string query = "SELECT E.ID_EMPLEADO, TE.ID_TIPO_EMPLEADO, TE.DESCRIPCION AS DESCRIPCION, " +
                               "E.NOMBRE, E.APELIDO, E.DNI, E.USUARIO, E.CONTRASEÑA " +
                               "FROM EMPLEADO E " +
                               "INNER JOIN TIPO_EMPLEADO TE ON E.ID_TIPO_EMPLEADO = TE.ID_TIPO_EMPLEADO";
                return conexion.LeerPorComando(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar empleados: " + ex.Message);
                return null;
            }
        }
    }
}
