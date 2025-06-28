using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using Entidad;

namespace BLL
{
    public class GerenteBLL
    {
        private readonly EmpleadoDAL empleadoDAL = new EmpleadoDAL();
        private readonly VentaDAL ventaDAL = new VentaDAL();

        public bool IniciarSesion(string usuario, string contrasenia)
        {
            DataTable dt = empleadoDAL.Iniciar_Sesion();

            foreach (DataRow fila in dt.Rows)
            {
                if (fila["USUARIO"].ToString() == usuario &&
                    fila["CONTRASEÑA"].ToString() == contrasenia &&
                    fila["DESCRIPCION"].ToString() == "Gerente")
                {
                    return true;
                }
            }

            return false;
        }

        public List<Venta> ListarVentas()
        {
            try
            {
                return ventaDAL.ObtenerTodasLasVentas();
            }
            catch (Exception)
            {
                throw; // se puede mejorar con logs o manejo específico
            }
        }

        public Venta BuscarVenta(int idVenta)
        {
            if (idVenta <= 0)
                throw new ArgumentException("El ID de la venta debe ser mayor a cero.");

            return ventaDAL.BuscarVentaPorId(idVenta);
        }

        public List<Venta> OrdenarVentasPor(string criterio)
        {
            return ventaDAL.ObtenerVentasOrdenadasPor(criterio);
        }
    }
}
