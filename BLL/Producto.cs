using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Producto
    {
		private int id_producto;

		public int Id_producto
		{
			get { return id_producto; }
			set { id_producto = value; }
		}
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private int cantidad;

		public int Cantidad
		{
			get { return cantidad; }
			set { cantidad = value; }
		}

		private float precio;

		public float Precio
		{
			get { return precio; }
			set { precio = value; }
		}

		private Deporte deporte;

		public Deporte Deporte
        {
			get { return deporte; }
			set { deporte = value; }
		}

		private string marca;

		public string Marca
		{
			get { return marca; }
			set { marca = value; }
		}

		private string modelo;

		public string Modelo
		{
			get { return modelo; }
			set { modelo = value; }
		}



	}
}
