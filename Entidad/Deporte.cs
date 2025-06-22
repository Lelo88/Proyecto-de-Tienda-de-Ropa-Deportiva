using System;

namespace Entidad
{
    public class Deporte
    {
        public int Id_Deporte { get; set; }

        private string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del deporte no puede estar vacío.");
                nombre = value;
            }
        }

        public Deporte() { }

        public Deporte(int id_deporte, string nombre)
        {
            Id_Deporte = id_deporte;
            Nombre = nombre;
        }
    }
}

