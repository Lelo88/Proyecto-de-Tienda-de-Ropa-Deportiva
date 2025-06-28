using System;
using System.Data;
using DAL;
using Entidad;

namespace BLL
{
    public class EmpleadoBLL
    {
        private readonly EmpleadoDAL empleadoDAL = new EmpleadoDAL();

        public Empleado IniciarSesion(string usuario, string contrasenia)
        {
            try
            {
                DataTable dt = empleadoDAL.Iniciar_Sesion();

                foreach (DataRow fila in dt.Rows)
                {
                    string user = fila["USUARIO"].ToString();
                    string pass = fila["CONTRASEÑA"].ToString();
                    string tipo = fila["DESCRIPCION"].ToString();

                    if (user == usuario && pass == contrasenia)
                    {
                        // Armamos el tipo de empleado correspondiente
                        TipoEmpleado tipoEmpleado = new TipoEmpleado { Descripcion = tipo };

                        if (tipo == "Administrador")
                            return new Administrador { Usuario = user, Contrasenia = pass, TipoEmpleado = tipoEmpleado };
                        else if (tipo == "Gerente")
                            return new Gerente { Usuario = user, Contrasenia = pass, TipoEmpleado = tipoEmpleado };
                        else if (tipo == "Vendedor")
                            return new Vendedor { Usuario = user, Contrasenia = pass, TipoEmpleado = tipoEmpleado };
                        else if (tipo == "Encargado")
                            return new EncargadoDeDeposito { Usuario = user, Contrasenia = pass, TipoEmpleado = tipoEmpleado };
                        else
                            return null;

                    }
                }

                return null; // Usuario o contraseña incorrectos
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al iniciar sesión: " + ex.Message);
                return null;
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
