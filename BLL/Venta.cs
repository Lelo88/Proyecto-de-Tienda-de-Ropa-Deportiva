using System;
using Entidad;
using DAL;

namespace BLL
{
    public class VentaBLL
    {
        private readonly VentaDAL ventaDAL = new VentaDAL();

        public int RegistrarVenta(Venta venta)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta), "La venta no puede ser nula.");

            if (venta.Cliente?.Id_Cliente <= 0)
                throw new ArgumentException("El cliente es inválido.");

            if (venta.Empleado?.Id_Empleado <= 0)
                throw new ArgumentException("El empleado es inválido.");

            if (venta.Metodo_De_Pago?.IDMetodoDePago <= 0)
                throw new ArgumentException("El método de pago es inválido.");

            if (venta.Total <= 0)
                throw new ArgumentException("El total de la venta debe ser mayor a cero.");

            return ventaDAL.CrearVenta(venta);
        }

    }
}
