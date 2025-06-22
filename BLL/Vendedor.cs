using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Vendedor : Empleado
    {
        public Vendedor()
        {

        }
        public Vendedor(int id_empleado, string nombre, string apellido, string dni, Tipo_empleado tipoEmpleado, string usuario, string contrasena)
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
                if (fila["USUARIO"].Equals(user) && fila["CONTRASEÑA"].Equals(pass) && fila["DESCRIPCION"].Equals("Vendedor"))
                {
                    return true;
                }

            }
            return false;
        }
        public void RealizarVenta()
        {

        }
        public void EliminarDeLaLista()
        {

        }
        public List<string> ObtenerProducto()
        {
            DAL.VendedorDAL vendedorDAL = new DAL.VendedorDAL();
            DataTable dt = vendedorDAL.ObtenerProducto();
            List<string> productos = new List<string>();
            foreach (DataRow fila in dt.Rows)
            {
                productos.Add(fila["Nombre"].ToString());
            }
            return productos;
        }
        public List<int> ObtenerCantidadDeTodosLosProductos() {
            DAL.VendedorDAL vendedorDAL = new DAL.VendedorDAL();
            DataTable dt = vendedorDAL.ObtenerCantidadDeTodosLosProductos();
            List<int> cantidad = new List<int>();
            foreach (DataRow fila in dt.Rows)
            {
                cantidad.Add(Convert.ToInt32(fila["Cantidad"]));
            }
            return cantidad;
        }

        public int ObtenerPrecioUnitario(string producto)
        {
            DAL.VendedorDAL vendedorDAL = new DAL.VendedorDAL();
            DataTable dt = vendedorDAL.ObtenerPrecioUnitario(producto);
            return Convert.ToInt32(dt.Rows[0]["precio"]);
        }

        public int ObtenerCantidad(string producto)
        {
            DAL.VendedorDAL vendedorDAL = new DAL.VendedorDAL();
            DataTable dt = vendedorDAL.ObtenerCantidad(producto);
            return Convert.ToInt32(dt.Rows[0]["cantidad"]);

        }
        public int ObtenerIdVendedor(string user, string pass) { 
            VendedorDAL vendedorDAL = new VendedorDAL();
            DataTable dt = vendedorDAL.ObtenerIdVendedor(user,pass);
            return Convert.ToInt32(dt.Rows[0]["id_empleado"]);
        }

        public List<float> ObtenerTodosLosPreciosUnitarios()
        {
            DAL.VendedorDAL vendedorDAL = new DAL.VendedorDAL();
            DataTable dt = vendedorDAL.ObtenerTodosLosPreciosUnitarios();
            List<float> preciosUnitarios = new List<float>();
            foreach (DataRow fila in dt.Rows)
            {
                preciosUnitarios.Add(Convert.ToInt32(fila["Precio"]));
            }
            return preciosUnitarios;
        }
    }
}
