using DAL;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ClienteBLL
    {
        private readonly ClienteDAL clienteDAL = new ClienteDAL();

        public Cliente BuscarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new ArgumentException("El DNI no puede estar vacío.");

            if (!EsDniValido(dni))
                throw new ArgumentException("El DNI debe contener solo números y tener entre 7 y 8 dígitos.");

            return clienteDAL.ObtenerPorDni(dni);
        }

        public bool CrearCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException("cliente", "El cliente no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(cliente.Nombre) ||
                string.IsNullOrWhiteSpace(cliente.Apellido) ||
                string.IsNullOrWhiteSpace(cliente.Dni))
                throw new ArgumentException("Todos los campos del cliente son obligatorios.");

            if (!EsDniValido(cliente.Dni))
                throw new ArgumentException("El DNI debe contener solo números y tener entre 7 y 8 dígitos.");

            // Evitar duplicación de clientes por DNI
            var existente = clienteDAL.ObtenerPorDni(cliente.Dni);
            if (existente != null)
                throw new InvalidOperationException("Ya existe un cliente con ese DNI.");

            return clienteDAL.Crear(cliente);
        }

        public List<Cliente> ObtenerTodos()
        {
            return clienteDAL.Listar();
        }

        private bool EsDniValido(string dni)
        {
            return dni.All(char.IsDigit) && (dni.Length >= 7 && dni.Length <= 8);
        }
    }
}
