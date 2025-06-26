using System;
using System.Data;
using DAL;
using Entidad;

namespace BLL
{
    public class EmpleadoBLL
    {
        private readonly EmpleadoDAL empleadoDAL = new EmpleadoDAL();

        public bool IniciarSesion(string usuario, string contrasena, out string tipoEmpleado)
        {
            tipoEmpleado = string.Empty;

            try
            {
                DataTable dt = empleadoDAL.Iniciar_Sesion();

                foreach (DataRow row in dt.Rows)
                {
                    string usuarioDb = row["USUARIO"].ToString();
                    string contrasenaDb = row["CONTRASEÑA"].ToString();
                    string descripcion = row["descripcion"].ToString();

                    if (usuarioDb.Equals(usuario, StringComparison.OrdinalIgnoreCase) &&
                        contrasenaDb.Equals(contrasena))
                    {
                        tipoEmpleado = descripcion;
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al iniciar sesión: " + ex.Message);
                return false;
            }
        }

        public DataTable ObtenerTiposDeEmpleado()
        {
            return empleadoDAL.ObtenerTiposDeEmpleado();
        }

        public DataTable ListarEmpleados()
        {
            return empleadoDAL.ListarEmpleados();
        }

        public bool AgregarEmpleado(TipoEmpleado tipo, string nombre, string apellido, string dni, string usuario, string contrasena)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(usuario))
                    throw new ArgumentException("Nombre y usuario no pueden estar vacíos.");

                int idTipoEmpleado = tipo.Id_TipoEmpleado;
                int resultado = empleadoDAL.AgregarEmpleado(idTipoEmpleado, nombre, apellido, dni, usuario, contrasena);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar empleado: " + ex.Message);
                return false;
            }
        }

        public bool ModificarEmpleado(int idEmpleado, TipoEmpleado tipo, string nombre, string apellido, string dni, string usuario, string contrasena)
        {
            try
            {
                int idTipoEmpleado = tipo.Id_TipoEmpleado;
                int resultado = empleadoDAL.ModificarEmpleado(idEmpleado, idTipoEmpleado, nombre, apellido, dni, usuario, contrasena);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar empleado: " + ex.Message);
                return false;
            }
        }

        public bool EliminarEmpleado(int idEmpleado)
        {
            try
            {
                int resultado = empleadoDAL.EliminarEmpleado(idEmpleado);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar empleado: " + ex.Message);
                return false;
            }
        }
    }
}
