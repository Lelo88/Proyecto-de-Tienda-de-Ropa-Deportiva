using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Administrador : Empleado
    {
        public Administrador()
        {
             
            
        }
        public Administrador(int id_empleado, string nombre, string apellido, string dni, Tipo_empleado tipoEmpleado, string usuario, string contrasena)
        {
            this.Id_Empleado = id_empleado;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Tipo_Empleado = tipoEmpleado;
            this.Usuario = usuario;
            this.Contrasenia = contrasena;
        }

        public override bool Iniciar_Sesion(string user, string pass)
        {
            DAL.EmpleadoDAL empleadoDAL = new DAL.EmpleadoDAL();
            DataTable dt = empleadoDAL.Iniciar_Sesion();

            foreach (DataRow fila in dt.Rows)
            {
                
                    if (fila["USUARIO"].Equals(user) && fila["CONTRASEÑA"].Equals(pass) && fila["descripcion"].Equals("Administrador"))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Usuario o contraseña incorrectos."+user+pass);
                    }
            }
            return false;

        }
          
        public object Listar_empleados()
        {
            DAL.EmpleadoDAL empleadoDAL = new DAL.EmpleadoDAL();
            return empleadoDAL.ListarEmpleados();
            
        }
        public object Alta_de_empleado(string descripcion, string nombre, string apellido,string dni, string usuario, string contraseña) {
            DAL.EmpleadoDAL empleadoDAL = new DAL.EmpleadoDAL();
            return empleadoDAL.AgregarEmpleados(descripcion,nombre,apellido,dni,usuario,contraseña);
            
        }
        public object Baja_de_empleado(int idEmpleado)
        {
            DAL.EmpleadoDAL empleadoDAL = new DAL.EmpleadoDAL();
            return empleadoDAL.eliminarEmpleado(idEmpleado);
        }
        public object Modificar_empleado(string idEmpleado, string descripcion, string nombre, string apellido, string dni, string usuario, string contraseña)
        {
            DAL.EmpleadoDAL empleadoDAL = new DAL.EmpleadoDAL();
            return empleadoDAL.modificarEmpleado(idEmpleado,descripcion,nombre,apellido,dni,usuario,contraseña);
        }


    }
}
