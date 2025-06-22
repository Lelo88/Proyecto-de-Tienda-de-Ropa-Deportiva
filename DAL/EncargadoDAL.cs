using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class EncargadoDAL
    {
        public DataTable ListarProductos()
        {
            Conexion conexion = new Conexion();

            //DEVUELVE TODOS LOS PRODUCTOS
            DataTable dt = conexion.LeerPorComando("select p.id_producto, d.nombre AS deporte, p.nombre, p.cantidad, p.marca, p.modelo, p.precio from producto p inner join deporte d on d.id_deporte=p.id_deporte");
            return dt;
        }
        public object AgregarProducto(string nombre, string marca, string modelo, int cantidad, float precio, string deporte)
        {
            int tipoDeporte = 0;
            Conexion conexion = new Conexion();
            //AGREGA UN PRODUCTO A LA BASE DE DATOS
            if (deporte.Equals("Futbol"))
            {
                tipoDeporte = 1;
            }
            if (deporte.Equals("Handball"))
            {
                tipoDeporte = 2;
            }
            if (deporte.Equals("Volleyball"))
            {
                tipoDeporte = 3;
            }
            if (deporte.Equals("Hockey"))
            {
                tipoDeporte = 4;
            }
            if (deporte.Equals("Rugby"))
            {
                tipoDeporte = 5;
            }
            if (deporte.Equals("Natacion"))
            {
                tipoDeporte = 6;
            }
            if (deporte.Equals("Basquetball"))
            {
                tipoDeporte = 7;
            }
            if (deporte.Equals("Tenis"))
            {
                tipoDeporte = 8;
            }
            if (deporte.Equals("Golf"))
            {
                tipoDeporte = 9;
            }
            string add =
            $"INSERT INTO producto (id_deporte, nombre, cantidad, marca, modelo, precio) " +
            $"VALUES ('{tipoDeporte}','{nombre}', {cantidad}, '{marca}', '{modelo}', {precio} )";
            return conexion.EscribirPorComando(add);
        }

        public object ModificarProducto(int id_producto, string deporte, string nombre, int cantidad, string marca, string modelo, double precio)
        {
            int tipoDeporte = 0;
            Conexion conexion = new Conexion();
            //MODIFICA UN PRODUCTO DE BASE DE DATOS
            if (deporte.Equals("Futbol"))
            {
                tipoDeporte = 1;
            }
            if (deporte.Equals("Handball"))
            {
                tipoDeporte = 2;
            }
            if (deporte.Equals("Volleyball"))
            {
                tipoDeporte = 3;
            }
            if (deporte.Equals("Hockey"))
            {
                tipoDeporte = 4;
            }
            if (deporte.Equals("Rugby"))
            {
                tipoDeporte = 5;
            }
            if (deporte.Equals("Natacion"))
            {
                tipoDeporte = 6;
            }
            if (deporte.Equals("Basquetball"))
            {
                tipoDeporte = 7;
            }
            if (deporte.Equals("Tenis"))
            {
                tipoDeporte = 8;
            }
            if (deporte.Equals("Golf"))
            {
                tipoDeporte = 9;
            }
            string update = $"UPDATE producto SET id_deporte={tipoDeporte}, nombre='{nombre}', cantidad={cantidad}, marca='{marca}', modelo='{modelo}', precio={((float)precio)} WHERE id_producto={id_producto}";
            return conexion.EscribirPorComando(update);
        }
        public object EliminarProducto(int idProducto)
        {
            Conexion conexion = new Conexion();
            //ELIMINA UN PRODUCTO DE LA BASE DE DATOS
            string delete = $"DELETE FROM producto WHERE id_producto={idProducto}";
            return conexion.EscribirPorComando(delete);
        }
    }
}
