using System;
using System.Collections.Generic;
using DAL;
using Entidad;

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
    }
}
