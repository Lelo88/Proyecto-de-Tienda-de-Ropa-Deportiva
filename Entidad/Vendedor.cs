using System;

namespace Entidad
{
    public class Vendedor : Empleado
    {
        public Vendedor() { }

        public Vendedor(int id_empleado, string nombre, string apellido, string dni, TipoEmpleado tipoEmpleado, string usuario, string contrasena)
            : base(id_empleado, nombre, apellido, dni, tipoEmpleado, usuario, contrasena)
        {
        }

        public override bool IniciarSesion(string usuario, string contrasenia)
        {
            // Implementación específica para este tipo de empleado
            return usuario == Usuario && contrasenia == Contrasenia; // Ejemplo simple
        }

    }
}