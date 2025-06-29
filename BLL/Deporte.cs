using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class DeporteBLL
    {
        private readonly DeporteDAL deporteDAL = new DeporteDAL();

        public List<Deporte> ObtenerDeportes()
        {
            return deporteDAL.ObtenerTodos();
        }

        public List<string> ObtenerNombresDeDeportes()
        {
            List<Deporte> deportes = ObtenerDeportes();
            List<string> nombres = new List<string>();

            foreach (var d in deportes)
            {
                nombres.Add(d.Nombre);
            }

            return nombres;
        }

        public int ObtenerIdDeporteDesdeNombre(string nombre)
        {
            var deportes = ObtenerDeportes(); // List<Deporte> con propiedades Id_Deporte y Nombre
            var deporte = deportes.FirstOrDefault(d => d.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            return deporte != null ? deporte.Id_Deporte : 0; // Retorna el ID o 0 si no se encuentra
        }
    }
}
