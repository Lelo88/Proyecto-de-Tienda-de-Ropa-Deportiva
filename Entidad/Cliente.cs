using System;
using System.Linq;

namespace Entidad
{
    public class Cliente
    {
        public int Id_Cliente { get; set; }

        private string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value;
            }
        }

        private string apellido;
        public string Apellido
        {
            get => apellido;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El apellido no puede estar vacío.");
                apellido = value;
            }
        }

        private string dni;
        public string Dni
        {
            get => dni;
            set
            {
                if (value.Length != 8 || !value.All(char.IsDigit))
                    throw new ArgumentException("El DNI debe contener 8 dígitos numéricos.");
                dni = value;
            }
        }

        public Cliente() { }

        public Cliente(int id_cliente, string nombre, string apellido, string dni)
        {
            Id_Cliente = id_cliente;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
        }
    }
}

