using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
	public class LineaDeFactura
	{
		private int idFactura;
		private int idLineaDeFactura;
		private int cantidad;
		private float subtotal;
		private Paquete paquete;

		public static int contadorLineasFactura = 0;

		static LineaDeFactura()
		{
			contadorLineasFactura = 1;
		}

		public LineaDeFactura()
		{
			this.idFactura = 0;
			this.idLineaDeFactura = 0;
			this.cantidad = 0;
			this.subtotal = 0.0f;
			this.paquete = null;
			contadorLineasFactura++;
		}

		public LineaDeFactura(int idFactura, int idLineaDeFactura, int cantidad, float subtotal, PaqueteNacional paquete)
		{
			this.idFactura = idFactura;
			this.idLineaDeFactura = idLineaDeFactura;
			this.cantidad = cantidad;
			this.subtotal = subtotal;
			this.paquete = paquete;
			contadorLineasFactura++;
		}

		public LineaDeFactura(int idFactura, int idLineaDeFactura, int cantidad, float subtotal, PaqueteInternacional paquete)
		{
			this.idFactura = idFactura;
			this.idLineaDeFactura = idLineaDeFactura;
			this.cantidad = cantidad;
			this.subtotal = subtotal;
			this.paquete = paquete;
			contadorLineasFactura++;
		}

		public int IdFactura { get => idFactura; set => idFactura = value; }
		public int IdLineaDeFactura { get => idLineaDeFactura; set => idLineaDeFactura = value; }
		public float Subtotal { get => subtotal; set => subtotal = value; }
		public int Cantidad { get => cantidad; set => cantidad = value; }
		public Paquete Paquete { get => paquete; set => paquete = value; }

		public void calcularSubtotal()
		{
			subtotal = cantidad * paquete.ImporteTotal;
		}

		public override string ToString()
		{
			return "Paquete: " + Paquete.Nombre +
				"\nCantidad: " + cantidad +
				"\nSubtotal: " + subtotal +
				"\n";
		}
	}
}
