using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Factura
    {
        private DateTime fecha;
        private int idFactura;
        private float importeTotal;
        private string nroFactura;
        

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int IdFactura { get => idFactura; set => idFactura = value; }
        public float ImporteTotal { get => importeTotal; set => importeTotal = value; }
    }
}
