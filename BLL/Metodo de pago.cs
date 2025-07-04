using System;
using System.Collections.Generic;
using DAL;
using Entidad;

namespace BLL
{
    public class MetodoDePagoBLL
    {
        private readonly MetodoDePagoDAL metodoDAL = new MetodoDePagoDAL();

        public List<MetodoDePago> ObtenerMetodos()
        {
            return metodoDAL.ObtenerTodos();
        }

        public List<string> ObtenerNombresDeMetodos()
        {
            var metodos = metodoDAL.ObtenerTodos();
            List<string> nombres = new List<string>();

            foreach (var metodo in metodos)
            {
                nombres.Add(metodo.Nombre);
            }

            return nombres;
        }
    }
}
