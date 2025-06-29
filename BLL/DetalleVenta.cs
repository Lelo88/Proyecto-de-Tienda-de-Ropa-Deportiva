using System;
using System.Collections.Generic;
using Entidad;
using DAL;

namespace BLL
{
    public class DetalleVentaBLL
    {
        private readonly DetalleVentaDAL detalleDAL = new DetalleVentaDAL();

        public bool RegistrarDetalle(DetalleVenta detalle)
        {
            ValidarDetalle(detalle);
            return detalleDAL.CrearDetalle(detalle);
        }

        public bool RegistrarDetalles(List<DetalleVenta> detalles)
        {
            if (detalles == null || detalles.Count == 0)
                throw new ArgumentException("La lista de detalles no puede estar vacía.");

            foreach (var detalle in detalles)
            {
                ValidarDetalle(detalle);
            }

            return detalleDAL.CrearDetallesLote(detalles);
        }

        private void ValidarDetalle(DetalleVenta detalle)
        {
            if (detalle == null)
                throw new ArgumentNullException("El detalle no puede ser nulo.");

            if (detalle.Venta == null || detalle.Venta.Id_Venta <= 0)
                throw new ArgumentException("La venta asociada no es válida.");

            if (detalle.Producto == null || detalle.Producto.Id_Producto <= 0)
                throw new ArgumentException("El producto del detalle no es válido.");

            if (detalle.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero.");

            if (detalle.Precio_Unitario <= 0)
                throw new ArgumentException("El precio unitario debe ser mayor que cero.");
        }
    }
}
