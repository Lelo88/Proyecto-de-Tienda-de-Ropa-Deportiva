using System;
using System.Linq;

namespace Entidad
{
    public abstract class Empleado
    {
        public int Id_Empleado { get; set; }

        private string nombre;
        public string Nombre
        {
            get => nombre;
            set => nombre = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Nombre requerido");
        }

        private string apellido;
        public string Apellido
        {
            get => apellido;
            set => apellido = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Apellido requerido");
        }

        private string dni;
        public string Dni
        {
            get => dni;
            set => dni = value.Length == 8 && value.All(char.IsDigit)
                ? value
                : throw new ArgumentException("DNI debe ser numérico de 8 dígitos");
        }

        public TipoEmpleado TipoEmpleado { get; set; }

        public string Usuario { get; set; }

        public string Contrasenia { get; set; }

        public Empleado() { }

        public Empleado(int id_empleado, string nombre, string apellido, string dni, Tipo_Empleado tipo_empleado, string usuario, string contrasenia)
        {
            Id_Empleado = id_empleado;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            TipoEmpleado = tipo_empleado;
            Usuario = usuario;
            Contrasenia = contrasenia;
        }
    }
}
