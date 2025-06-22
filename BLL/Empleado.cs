using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class Empleado
    {
        

        private int id_empleado;

		public int Id_Empleado
		{
			get { return id_empleado; }
			set { id_empleado = value; }
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

		private Tipo_empleado tipo_Empleado;

		public Tipo_empleado Tipo_Empleado
		{
			get { return tipo_Empleado; }
			set { tipo_Empleado = value; }
		}


		private string usuario;

		public string Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}
		private string contrasenia;

		public string Contrasenia
		{
			get { return contrasenia; }
			set { contrasenia = value; }
		}
		public Empleado() {
            
        }

		public Empleado(int id_empleado, 
			string nombre, 
			string apellido, 
			string dni, 
			Tipo_empleado tipo_empleado, 
			string usuario, 
			string contrasenia) {
			
			this.id_empleado=id_empleado;
			this.nombre=nombre;
			this.apellido=apellido;
			this.dni=dni;
			this.Tipo_Empleado=tipo_empleado ;
			this.usuario=usuario;
			this.contrasenia=contrasenia;
		}

		public virtual bool Iniciar_Sesion(string usuario, string contrasenia)
		{
            return true;
		}

	}
}
