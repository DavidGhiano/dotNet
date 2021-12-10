using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
	class LineaDeFactura
	{
		private int idFactura;
		private int idLineaDeFactura;
		private float subtotal;

		public LineaDeFactura()
		{
			this.idFactura = 0;
			this.idLineaDeFactura = 0;
			this.subtotal = 0.0f;
		}

		public LineaDeFactura(int idFactura, int idLineaDeFactura, float subtotal)
		{
			this.idFactura = idFactura;
			this.idLineaDeFactura = idLineaDeFactura;
			this.subtotal = subtotal;
		}

		public int IdFactura { get => idFactura; set => idFactura = value; }
		public int IdLineaDeFactura { get => idLineaDeFactura; set => idLineaDeFactura = value; }
		public float Subtotal { get => subtotal; set => subtotal = value; }
	}
}
