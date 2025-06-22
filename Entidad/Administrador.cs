using System;

namespace Entidad
{
    public class Administrador : Empleado
    {
        public Administrador() { }

        public Administrador(int id_empleado, string nombre, string apellido, string dni, Tipo_Empleado tipoEmpleado, string usuario, string contrasena)
            : base(id_empleado, nombre, apellido, dni, tipoEmpleado, usuario, contrasena)
        {
        }
    }
}
