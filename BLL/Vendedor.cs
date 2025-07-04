using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class VendedorBLL
    {
        private readonly VendedorDAL vendedorDAL = new VendedorDAL();
        private readonly EmpleadoDAL empleadoDAL = new EmpleadoDAL();

        public List<string> ObtenerNombresDeProductos()
        {
            return vendedorDAL.ObtenerNombresDeProductos();
        }

        public string ObtenerNombreCompletoPorUsuario(string usuario)
        {
            var vendedor = vendedorDAL.ObtenerVendedorPorUsuario(usuario);
            if (vendedor != null)
                return $"{vendedor.Nombre} {vendedor.Apellido}";
            return "No encontrado";
        }


        public Entidad.Producto BuscarProducto(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del producto no puede estar vacío.");

            return vendedorDAL.ObtenerProductoCompleto(nombre);
        }

        public bool VerificarStock(string nombre, int cantidadDeseada)
        {
            if (cantidadDeseada <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");

            int stockDisponible = vendedorDAL.ObtenerStockPorProducto(nombre);
            return stockDisponible >= cantidadDeseada;
        }

        public float ObtenerPrecioUnitario(string nombre)
        {
            return vendedorDAL.ObtenerPrecioPorProducto(nombre);
        }

        public float CalcularSubtotal(string nombre, int cantidad)
        {
            float precio = ObtenerPrecioUnitario(nombre);
            return precio * cantidad;
        }

        public void RealizarVenta(Venta venta)
        {
            // Lógica futura
        }

        public bool IniciarSesion(string user, string pass)
        {
            try
            {
                DataTable dt = empleadoDAL.Iniciar_Sesion();

                foreach (DataRow fila in dt.Rows)
                {
                    if (fila["USUARIO"].ToString() == user &&
                        fila["CONTRASEÑA"].ToString() == pass &&
                        fila["descripcion"].ToString().Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
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
    }
}
