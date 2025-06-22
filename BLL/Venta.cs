using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Venta
    {
		private int id_venta;

		public int Id_Venta
		{
			get { return id_venta; }
			set { id_venta = value; }
		}

		private Empleado empleado;

		public Empleado Empleado
		{
			get { return empleado; }
			set { empleado = value; }
		}

		private float total;

		public float Total
		{
			get { return total; }
			set { total = value; }
		}

		private DateTime fecha;
		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}

		private Cliente cliente;
		public Cliente Cliente
		{
			get { return cliente; }
			set { cliente = value; }
		}
		private Producto producto;

		public Producto Producto
		{
			get { return producto; }
			set { producto = value; }
		}
		private Metodo_de_pago metodo_De_Pago;

		public Metodo_de_pago Metodo_De_Pago
		{
			get { return metodo_De_Pago; }
			set { metodo_De_Pago = value; }
		}

		public Venta() { 
		
		}
		public Venta(int id_venta, Empleado empleado, float total, DateTime fecha, Cliente cliente, Producto producto, Metodo_de_pago metodo_De_Pago)
        {
            this.id_venta = id_venta;
            this.empleado = empleado;
            this.total = total;
            this.fecha = fecha;
            this.cliente = cliente;
            this.producto = producto;
            this.metodo_De_Pago = metodo_De_Pago;
        }




    }
}
