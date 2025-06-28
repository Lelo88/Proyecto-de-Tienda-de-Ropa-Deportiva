using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class Administrador : Empleado
    {
        private readonly EmpleadoDAL empleadoDAL = new EmpleadoDAL();

        public Administrador() { }

        public Administrador(int id_empleado, string nombre, string apellido, string dni, TipoEmpleado tipoEmpleado, string usuario, string contrasena)
        {
            this.Id_Empleado = id_empleado;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.TipoEmpleado = tipoEmpleado;
            this.Usuario = usuario;
            this.Contrasenia = contrasena;
        }

        public override bool IniciarSesion(string user, string pass)
        {
            try
            {
                DataTable dt = empleadoDAL.Iniciar_Sesion();

                foreach (DataRow fila in dt.Rows)
                {
                    if (fila["USUARIO"].ToString() == user &&
                        fila["CONTRASEÑA"].ToString() == pass &&
                        fila["descripcion"].ToString() == "Administrador")
                    {
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

        public DataTable Listar_empleados()
        {
            try
            {
                return empleadoDAL.ListarEmpleados();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar empleados: " + ex.Message);
                return null;
            }
        }

        public bool Alta_de_empleado(string descripcion, string nombre, string apellido, string dni, string usuario, string contraseña)
        {
            try
            {
                int idTipo = ObtenerIdTipoEmpleadoPorDescripcion(descripcion);
                if (idTipo == 0)
                    throw new Exception("Tipo de empleado no válido.");

                return empleadoDAL.AgregarEmpleado(idTipo, nombre, apellido, dni, usuario, contraseña) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al dar de alta al empleado: " + ex.Message);
                return false;
            }
        }

        public bool Baja_de_empleado(int idEmpleado)
        {
            try
            {
                return empleadoDAL.EliminarEmpleado(idEmpleado) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al dar de baja al empleado: " + ex.Message);
                return false;
            }
        }

        public bool Modificar_empleado(int idEmpleado, string descripcion, string nombre, string apellido, string dni, string usuario, string contraseña)
        {
            try
            {
                int idTipo = ObtenerIdTipoEmpleadoPorDescripcion(descripcion);
                if (idTipo == 0)
                    throw new Exception("Tipo de empleado no válido.");

                return empleadoDAL.ModificarEmpleado(idEmpleado, idTipo, nombre, apellido, dni, usuario, contraseña) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar empleado: " + ex.Message);
                return false;
            }
        }

        private int ObtenerIdTipoEmpleadoPorDescripcion(string descripcion)
        {
            try
            {
                DataTable tipos = empleadoDAL.ObtenerTiposDeEmpleado();
                foreach (DataRow row in tipos.Rows)
                {
                    if (row["DESCRIPCION"].ToString().Equals(descripcion, StringComparison.OrdinalIgnoreCase))
                        return Convert.ToInt32(row["ID_TIPO_EMPLEADO"]);
                }

                return 0; // No encontrado
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener ID del tipo de empleado: " + ex.Message);
                return 0;
            }
        }
    }
}
