using System;
using System.Collections.Generic;

namespace Entidad
{
    public class Venta
    {
        public int Id_Venta { get; set; }

        public Empleado Empleado { get; set; }

        public Cliente Cliente { get; set; }

        public MetodoDePago Metodo_De_Pago { get; set; }

        public DateTime Fecha { get; set; }

        public float Total { get; set; }

        // Relación 1 a muchos: una venta tiene varios detalles (productos vendidos)
        public List<DetalleVenta> Detalles { get; set; }

        public Venta()
        {
            Detalles = new List<DetalleVenta>();
        }

        public Venta(int id_venta, Empleado empleado, Cliente cliente, MetodoDePago metodo_De_Pago, DateTime fecha, float total, List<DetalleVenta> detalles)
        {
            Id_Venta = id_venta;
            Empleado = empleado;
            Cliente = cliente;
            Metodo_De_Pago = metodo_De_Pago;
            Fecha = fecha;
            Total = total;
            Detalles = detalles ?? new List<DetalleVenta>();
        }
    }
}
