using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class Encargado_De_Deposito : Empleado
    {
        public Encargado_De_Deposito() { 
        
        }
        public Encargado_De_Deposito(int id_empleado, string nombre, string apellido, string dni, Tipo_empleado tipoEmpleado, string usuario, string contrasena)
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
                if (fila["USUARIO"].Equals(user) && fila["CONTRASEÑA"].Equals(pass) && fila["DESCRIPCION"].Equals("Encargado"))
                {
                    return true;
                }

            }
            return false;
        }
        public object Visualizar_Producto() {
            DAL.EncargadoDAL encargadoDAL = new DAL.EncargadoDAL();
            return encargadoDAL.ListarProductos();
        }
        public object Agregar_Producto(string nombre,string marca,string modelo,int cantidad,float precio,string deporte)
        {
            DAL.EncargadoDAL encargadoDAL = new DAL.EncargadoDAL();
            return encargadoDAL.AgregarProducto(nombre, marca, modelo, cantidad, precio, deporte);
        }
        public object Modificar_Producto(int id_producto, string deporte,string nombre, int cantidad, string marca, string modelo, float precio)
        {
            DAL.EncargadoDAL encargadoDAL = new DAL.EncargadoDAL();
            return encargadoDAL.ModificarProducto(id_producto, deporte, nombre, cantidad, marca, modelo, precio);
        }
        public object Eliminar_Producto(int idProducto)
        {
            DAL.EncargadoDAL encargadoDAL = new DAL.EncargadoDAL();
            return encargadoDAL.EliminarProducto(idProducto);
        }
    }
}
