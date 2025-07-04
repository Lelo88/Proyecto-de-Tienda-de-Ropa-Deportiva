using System;

namespace Entidad
{
    public class DetalleVenta
    {
        public int Id_Detalle { get; set; }

        public Producto Producto { get; set; }

        public int Cantidad { get; set; }

        public float Precio_Unitario { get; set; }

        public Venta Venta { get; set; }

        public DetalleVenta() { }

        public DetalleVenta(int id_detalle, Producto producto, int cantidad, float precioUnitario, Venta venta)
        {
            Id_Detalle = id_detalle;

            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0.");

            if (precioUnitario <= 0)
                throw new ArgumentException("El precio unitario debe ser mayor a 0.");
            if (venta == null)
                throw new ArgumentNullException(nameof(venta), "La venta no puede ser nula.");

            Producto = producto;
            Cantidad = cantidad;
            Precio_Unitario = precioUnitario;
            Venta = venta;
        }

        public float CalcularSubtotal()
        {
            return Cantidad * Precio_Unitario;
        }
    }
}
