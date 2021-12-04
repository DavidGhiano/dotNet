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
