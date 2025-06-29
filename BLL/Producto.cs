using System;
using System.Collections.Generic;
using DAL;
using Entidad;

namespace BLL
{
    public class ProductoBLL
    {
        private readonly ProductoDAL productoDAL = new ProductoDAL();

        public List<Producto> ListarProductos()
        {
            return productoDAL.ObtenerTodosLosProductos();
        }

        public Producto BuscarProductoPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del producto no puede estar vacío.");

            return productoDAL.ObtenerProductoPorNombre(nombre);
        }

        public bool VerificarStock(string nombre, int cantidadDeseada)
        {
            if (cantidadDeseada <= 0)
                throw new ArgumentException("La cantidad deseada debe ser mayor a cero.");

            int stock = productoDAL.ObtenerStock(nombre);
            return stock >= cantidadDeseada;
        }

        public float ObtenerPrecioUnitario(string nombre)
        {
            return productoDAL.ObtenerPrecio(nombre);
        }

        public float CalcularSubtotal(string nombre, int cantidad)
        {
            float precio = ObtenerPrecioUnitario(nombre);
            return precio * cantidad;
        }

        public void DescontarStock(string nombre, int cantidad)
        {
            productoDAL.ActualizarStock(nombre, cantidad);
        }
    }
}
