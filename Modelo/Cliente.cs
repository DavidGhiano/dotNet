using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente
    {
        protected string direccion;
        protected int idCliente;
        protected string nacionalidad;
        protected string provincia;
        protected string telefono;
        protected string apellido;
        protected string nombre;
        protected string dni;

        public static int contadorClientes = 0;

        static Cliente()
        {
            contadorClientes = 1;
        }

        public Cliente()
		{
            this.direccion = "";
            this.idCliente = 0;
            this.nacionalidad = "";
            this.provincia = "";
            this.telefono = "";
            this.apellido = "";
            this.nombre = "";
            this.dni = "";
            contadorClientes++;
        }

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
            contadorClientes++;
        }

        public string Direccion { get => direccion; set => direccion = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Dni { get => dni; set => dni = value; }

        public virtual void mostrarDatos()
        {
            Console.WriteLine("DNI: " + dni);
            Console.WriteLine("Apellidos y nombres: " + apellido + ", " + nombre);
            Console.WriteLine("Dirección: " + direccion);
            Console.WriteLine("Teléfono: " + telefono);
            Console.WriteLine("Nacionalidad: " + nacionalidad);
            Console.WriteLine("Provincia: " + provincia);
            Console.WriteLine("\n");
        }

        public override string ToString()
        {
            return "DNI: " + dni +
                "\nApellidos y nombres: " + apellido + ", " + nombre +
                "\nDirección: " + direccion +
                "\nTeléfono: " + telefono +
                "\nNacionalidad: " + nacionalidad +
                "\nProvincia: " + provincia +
                "\n";
        }
    }
}
