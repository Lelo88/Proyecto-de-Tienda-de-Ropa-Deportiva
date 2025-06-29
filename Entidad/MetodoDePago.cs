using System;

namespace Entidad
{
    public class MetodoDePago
    {
        public int IDMetodoDePago { get; set; }

        private string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del método de pago no puede estar vacío.");
                nombre = value;
            }
        }

        public MetodoDePago() { }

        public MetodoDePago(int idMetodoDePago, string nombre)
        {
            IDMetodoDePago = idMetodoDePago;
            Nombre = nombre;
        }
    }
}

