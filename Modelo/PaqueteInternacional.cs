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
            float importeTotal,
            List<Lugar> lugares)
            : base(
                  cantidadDia,
                  estado, 
                  fechaViaje, 
                  idPaquete,
                  nombre, 
                  precio, 
                  cantidadCuota, 
                  importeTotal, 
                  lugares)
        {
            this.CotizacionDolar = cotizacionDolar;
            this.ImportePorImpuestos = importePorImpuestos;
            this.RequiereVisa = requiereVisa;
        }

        public float CotizacionDolar { get => cotizacionDolar; set => cotizacionDolar = value; }
        public float ImportePorImpuestos { get => importePorImpuestos; set => importePorImpuestos = value; }
        public bool RequiereVisa { get => requiereVisa; set => requiereVisa = value; }

        public override void CalcularImporte()
        {
            importeTotal = precio + importePorImpuestos;
        }
    }
}
