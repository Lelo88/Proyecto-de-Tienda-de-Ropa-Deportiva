using System;

namespace Entidad
{
    public class Producto
    {
        public int Id_Producto { get; set; }

        private string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del producto no puede estar vacío.");
                nombre = value;
            }
        }

        private int cantidad;
        public int Cantidad
        {
            get => cantidad;
            set
            {
                if (value < 0)
                    throw new ArgumentException("La cantidad no puede ser negativa.");
                cantidad = value;
            }
        }

        private float precio;
        public float Precio
        {
            get => precio;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El precio debe ser mayor a cero.");
                precio = value;
            }
        }

        public Deporte Deporte { get; set; }

        private string marca;
        public string Marca
        {
            get => marca;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La marca no puede estar vacía.");
                marca = value;
            }
        }

        private string modelo;
        public string Modelo
        {
            get => modelo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El modelo no puede estar vacío.");
                modelo = value;
            }
        }

        public Producto() { }

        public Producto(int id, string nombre, int cantidad, float precio, Deporte deporte, string marca, string modelo)
        {
