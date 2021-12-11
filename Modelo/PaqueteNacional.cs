using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class PaqueteNacional : Paquete
    {
        private string modoDePago;
        private float porcentajePorImpuestos;

        public string ModoDePago { get => modoDePago; set => modoDePago = value; }
        public float PorcentajePorImpuestos { get => porcentajePorImpuestos; set => porcentajePorImpuestos = value; }

        public PaqueteNacional()
        {
            this.ModoDePago = "";
            this.PorcentajePorImpuestos = 0.0f;
        }
        public PaqueteNacional(
            string modoDePago, 
            float porcentajePorImpuestos, 
            int cantidadDia, 
            bool estado, 
            DateTime fechaViaje,
            int idPaquete,
            string nombre,
            float precio,
            int cantidadCuota,
            float importeTotal,
            List<Lugar> lugares) : base(
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
            this.ModoDePago = modoDePago;
            this.PorcentajePorImpuestos = porcentajePorImpuestos;
        }

        public override void CalcularImporte()
        {
            importeTotal = precio * porcentajePorImpuestos;
        }
    }
}
