using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Deporte
    {
        private int id_deporte;

        public int Id_Deporte
        {
            get { return id_deporte; }
            set { id_deporte = value; }
        }
        
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Deporte() { 
        
        }
        public Deporte(int id_deporte, string nombre)
        {
            this.id_deporte = id_deporte;
            this.nombre = nombre;
        }
        public List<string> obtenerDeportes()
        {
            DAL.DeporteDAL deporte = new DAL.DeporteDAL();
            DataTable dt = deporte.ObtenerDeportes();
            List<string> deportes = new List<string>();
            foreach (DataRow fila in dt.Rows)
            {
                deportes.Add(fila["Nombre"].ToString()); 
            }
            return deportes;
        }
    }
}
