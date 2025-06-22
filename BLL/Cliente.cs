using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cliente
    {
		private int id_Cliente;

		public int Id_Cliente
		{
			get { return id_Cliente; }
			set { id_Cliente = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private string apellido;

		public string Apellido
		{
			get { return apellido; }
			set { apellido = value; }
		}

		private string dni;

		public string Dni
		{
			get { return dni; }
			set { dni = value; }
		}

		public Cliente() { 
		
		}
        public Cliente(int id_cliente, string nombre, string apellido, string dni)
        {
            this.Id_Cliente = id_cliente;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
        }
    }
}
