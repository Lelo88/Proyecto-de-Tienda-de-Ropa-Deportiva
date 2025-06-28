using System;
using System.Collections.Generic;
using DAL;
using Entidad;

namespace BLL
{
    public class TipoEmpleadoBLL
    {
        private readonly TipoEmpleadoDAL tipoEmpleadoDAL = new TipoEmpleadoDAL();

        public List<TipoEmpleado> ObtenerTiposDeEmpleado()
        {
            return tipoEmpleadoDAL.ObtenerTodos();
        }

        public List<string> ObtenerDescripciones()
        {
            List<TipoEmpleado> tipos = tipoEmpleadoDAL.ObtenerTodos();
            List<string> descripciones = new List<string>();
            foreach (var tipo in tipos)
                descripciones.Add(tipo.Descripcion);

            return descripciones;
        }
    }
}
