using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmpleadoDAL
    {
        public DataTable Iniciar_Sesion() { 
            Conexion conexion = new Conexion();

            //DEVUELVE LA DESCRIPCION DEL EMPLEADO,
            //EL USUARIO Y SU CONTRASEÑA PARA COMPARAR A LA HORA DE INICIAR SESION
            DataTable dt = conexion.LeerPorComando("select E.USUARIO, E.CONTRASEÑA, TE.descripcion from EMPLEADO E INNER JOIN TIPO_EMPLEADO TE on E.ID_TIPO_EMPLEADO=TE.ID_TIPO_EMPLEADO");

            return dt;
        }
        public DataTable ListarEmpleados()
        {
            Conexion conexion = new Conexion();

            //DEVUELVE TODOS LOS EMPLEADOS
            DataTable dt = conexion.LeerPorComando("select E.ID_EMPLEADO, TE.ID_TIPO_EMPLEADO, TE.DESCRIPCION AS DESCRIPCION, E.NOMBRE, E.APELIDO, E.DNI, E.USUARIO, E.CONTRASEÑA from EMPLEADO E \r\nINNER JOIN TIPO_EMPLEADO TE on E.ID_TIPO_EMPLEADO=TE.ID_TIPO_EMPLEADO");
            return dt;
        }

        public object AgregarEmpleados(string descripcion, string nombre, string apellido, string dni, string usuario, string contraseña)
        {
            Conexion conexion = new Conexion();
            
            int idTipoEmpleado = 0;
            //AGREGA UN NUEVO EMPLEADO
            if (descripcion.Equals("Administrador"))
            {
                idTipoEmpleado = 1;
            }
            if (descripcion.Equals("Encargado"))
            {
                idTipoEmpleado = 2;
            }
            if (descripcion.Equals("Gerente"))
            {
                idTipoEmpleado = 3;
            }
            if (descripcion.Equals("Vendedor"))
            {
                idTipoEmpleado = 4;
            }
            //ARREGLAR CONSULTA SQL
            string insert = $"INSERT INTO empleado (id_tipo_empleado, nombre, apelido, dni, usuario, contraseña) " +
                $"VALUES ({idTipoEmpleado}, '{nombre}', '{apellido}', '{dni}', '{usuario}', '{contraseña}');";
            return conexion.EscribirPorComando(insert);
            
        }
        public object eliminarEmpleado(int id_empleado)
        {
            Conexion conexion = new Conexion();
            //ELIMINA UN EMPLEADO
            string delete = $"DELETE FROM empleado WHERE id_empleado={id_empleado}";
            return conexion.EscribirPorComando(delete);
            
        }

        public object modificarEmpleado(string idEmpleado, string descripcion, string nombre, string apellido, string dni, string usuario, string contraseña)
        {
            int idTipoEmpleado = 0;
            Conexion conexion = new Conexion();
            //MODIFICA UN EMPLEADO
            if (descripcion.Equals("Administrador"))
            {
                idTipoEmpleado = 1;
            }
            if (descripcion.Equals("Encargado"))
            {
                idTipoEmpleado = 2;
            }
            if (descripcion.Equals("Gerente"))
            {
                idTipoEmpleado = 3;
            }
            if (descripcion.Equals("Vendedor"))
            {
                idTipoEmpleado = 4;
            }
            string update = $"UPDATE empleado SET id_tipo_empleado={idTipoEmpleado}, nombre='{nombre}', apelido='{apellido}', dni='{dni}', usuario='{usuario}', contraseña='{contraseña}' WHERE id_empleado={idEmpleado}";
            return conexion.EscribirPorComando(update);
            
        }
        public DataTable ObtenerTiposDeEmpleado()
        {
            Conexion conexion = new Conexion();
            DataTable dt = conexion.LeerPorComando("select descripcion from TIPO_EMPLEADO");
            return dt;
        }

    }
}
