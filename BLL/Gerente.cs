using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Gerente : Empleado
    {
        public Gerente() { 
        
        }
        public Gerente(int id_empleado, string nombre, string apellido, string dni, Tipo_empleado tipoEmpleado, string usuario, string contrasena)
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
                if (fila["USUARIO"].Equals(user) && fila["CONTRASEÑA"].Equals(pass) && fila["DESCRIPCION"].Equals("Gerente"))
                {
                    return true;
                }

            }
            return false;
        }

        public void Listar_Ventas() { 
        
        }
        public void Buscar_Venta()
        {

        }
        public void Ordenar_Por()
        {

        }
    }
}
