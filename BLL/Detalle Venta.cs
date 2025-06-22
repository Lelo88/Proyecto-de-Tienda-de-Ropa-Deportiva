using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Detalle_Venta
    {
		private int id_DetalleVenta;

		public int Id_DetalleVenta
		{
			get { return id_DetalleVenta; }
			set { id_DetalleVenta = value; }
		}
		private int cantidad;
		public int Cantidad
		{
			get { return cantidad; }
			set { cantidad = value; }
		}
		private float precioUnitario;

		public float PrecioUnitario
		{
			get { return precioUnitario; }
			set { precioUnitario = value; }
		}
        public Detalle_Venta()
        {

        }
        public Detalle_Venta(int id_DetalleVenta, int cantidad, float precioUnitario)
        {
            this.id_DetalleVenta = id_DetalleVenta;
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
        }

		public object agregarProductoALista(int idVenta,string nombreP,int cantidadP,float precioP) {
			DAL.DetalleVentaDAL detalleVentaDAL = new DAL.DetalleVentaDAL();
			detalleVentaDAL.AgregarProductoALista(idVenta,nombreP, cantidadP, precioP);
            return true;
		}

    }
}
