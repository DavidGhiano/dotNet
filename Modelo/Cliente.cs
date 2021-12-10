using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente
    {
        private string direccion;
        private int idCliente;
        private string nacionalidad;
        private string provincia;
        private string telefono;
        private string apellido;
        private string nombre;
        private string dni;

        public Cliente(
            string direccion, 
            int idCliente, 
            string nacionalidad, 
            string provincia, 
            string telefono, 
            string apellido, 
            string nombre, 
            string dni)
        {
            this.direccion = direccion;
            this.idCliente = idCliente;
            this.nacionalidad = nacionalidad;
            this.provincia = provincia;
            this.telefono = telefono;
            this.apellido = apellido;
            this.nombre = nombre;
            this.dni = dni;
        }

        public string Direccion { get => direccion; set => direccion = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Dni { get => dni; set => dni = value; }
    }
}
