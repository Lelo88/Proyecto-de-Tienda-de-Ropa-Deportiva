using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class EncargadoBLL
    {
        private readonly EncargadoDAL encargadoDAL = new EncargadoDAL();
        private readonly EmpleadoDAL empleadoDAL = new EmpleadoDAL();

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

        public bool IniciarSesion(string user, string pass)
        {
            try
            {
                DataTable dt = empleadoDAL.Iniciar_Sesion();

                foreach (DataRow fila in dt.Rows)
                {
                    if (fila["USUARIO"].ToString() == user &&
                        fila["CONTRASEÑA"].ToString() == pass &&
                        fila["descripcion"].ToString().Equals("Encargado", StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al iniciar sesión: " + ex.Message);
                return false;
            }
        }
    }
}
