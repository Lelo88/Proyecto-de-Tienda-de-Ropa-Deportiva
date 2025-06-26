using System;
using System.Collections.Generic;
using Entidad;
using DAL;

namespace BLL
{
    public class VendedorBLL
    {
        private readonly VendedorDAL vendedorDAL = new VendedorDAL();

        public List<string> ObtenerNombresDeProductos()
        {
            return vendedorDAL.ObtenerNombresDeProductos();
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
    }
}
