using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class PaqueteInternacional : Paquete
    {
        private float cotizacionDolar;
        private float importePorImpuestos;
        private bool requiereVisa;

        public PaqueteInternacional()
		{
            this.CotizacionDolar = 0.0f;
            this.ImportePorImpuestos = 0.0f;
            this.RequiereVisa = false;
        }

        public PaqueteInternacional(
            float cotizacionDolar,
            float importePorImpuestos,
            bool requiereVisa,
            int cantidadDia,
            bool estado,
            DateTime fechaViaje,
            int idPaquete,
            string nombre,
            float precio,
            int cantidadCuota,
            List<Lugar> lugares)
            : base(
                  cantidadDia,
                  estado, 
                  fechaViaje, 
                  idPaquete,
                  nombre, 
                  precio, 
                  cantidadCuota,
                  lugares)
        {
            this.CotizacionDolar = cotizacionDolar;
            this.ImportePorImpuestos = importePorImpuestos;
            this.RequiereVisa = requiereVisa;
            CalcularImporte();
        }

        public float CotizacionDolar { get => cotizacionDolar; set => cotizacionDolar = value; }
        public float ImportePorImpuestos { get => importePorImpuestos; set => importePorImpuestos = value; }
        public bool RequiereVisa { get => requiereVisa; set => requiereVisa = value; }

        public override void CalcularImporte()
        {
            this.importeTotal = precio * cotizacionDolar + importePorImpuestos;
        }
        public override void ImprimirDatos()
        {
            string cadenaLugares = "";
            foreach (Lugar l in lugares)
            {
                cadenaLugares = $"{cadenaLugares} - {l.Nombre} \n";
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Nombre: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{nombre}\t");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Fecha: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"{fechaViaje.ToString("dd/MM/yyyy")}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Lugares: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(cadenaLugares);
        }

        public override string ToString()
        {
            return base.ToString() + 
                "Cotización del dolar: " + cotizacionDolar.ToString() +
                "\nImporte por impuestos: " + importePorImpuestos.ToString() +
                "\nRequiere Visa: " + requiereVisa.ToString() +
                "\n";
        }
    }
}
