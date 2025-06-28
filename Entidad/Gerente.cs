using System;

namespace Entidad
{
    public class Gerente : Empleado
    {
        public Gerente() { }

        public Gerente(int id_empleado, string nombre, string apellido, string dni, TipoEmpleado tipoEmpleado, string usuario, string contrasena)
            : base(id_empleado, nombre, apellido, dni, tipoEmpleado, usuario, contrasena)
        {
        }
    }
}

