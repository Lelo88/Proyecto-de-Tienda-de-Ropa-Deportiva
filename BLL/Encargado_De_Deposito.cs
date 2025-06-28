using System;
using System.Collections.Generic;
using Entidad;
using DAL;

namespace BLL
{
    public class EncargadoBLL
    {
        private readonly EncargadoDAL encargadoDAL = new EncargadoDAL();

        public List<Producto> ListarProductos()
        {
            return encargadoDAL.ListarProductos();
        }

        public bool AgregarProducto(Producto producto)
        {
            ValidarProducto(producto, requiereId: false);
            return encargadoDAL.AgregarProducto(producto);
        }

        public bool ModificarProducto(Producto producto)
        {
            ValidarProducto(producto, requiereId: true);
            return encargadoDAL.ModificarProducto(producto);
        }

        public bool EliminarProducto(int idProducto)
        {
            if (idProducto <= 0)
                throw new ArgumentException("El ID del producto debe ser válido.");

            return encargadoDAL.EliminarProducto(idProducto);
        }

        private void ValidarProducto(Producto producto, bool requiereId)
        {
            if (producto == null)
                throw new ArgumentNullException("El producto no puede ser nulo.");

            if (requiereId && producto.Id_Producto <= 0)
                throw new ArgumentException("El ID del producto debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(producto.Marca))
                throw new ArgumentException("La marca no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(producto.Modelo))
                throw new ArgumentException("El modelo no puede estar vacío.");

            if (producto.Cantidad < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.");

            if (producto.Precio < 0)
                throw new ArgumentException("El precio no puede ser negativo.");

            if (producto.Deporte == null || producto.Deporte.Id_Deporte <= 0)
                throw new ArgumentException("Debe asignarse un deporte válido al producto.");
        }
    }
}
