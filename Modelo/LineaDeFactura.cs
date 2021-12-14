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
		private int idPaquete;

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
			this.idPaquete = 0;
			contadorLineasFactura++;
		}

		public LineaDeFactura(int idFactura, int idLineaDeFactura, int cantidad, float subtotal, int idPaquete)
		{
			this.idFactura = idFactura;
			this.idLineaDeFactura = idLineaDeFactura;
			this.cantidad = cantidad;
			this.subtotal = subtotal;
			this.idPaquete = idPaquete;
			contadorLineasFactura++;
		}

		public int IdFactura { get => idFactura; set => idFactura = value; }
		public int IdLineaDeFactura { get => idLineaDeFactura; set => idLineaDeFactura = value; }
		public float Subtotal { get => subtotal; set => subtotal = value; }
		public int Cantidad { get => cantidad; set => cantidad = value; }
		public int IdPaquete { get => idPaquete; set => idPaquete = value; }

		public void calcularSubtotal(Paquete paquete)
		{
			subtotal = cantidad * paquete.ImporteTotal;
		}

		public override string ToString()
		{
			return "Cantidad: " + cantidad +
				"\nSubtotal: " + subtotal +
				"\n";
		}
	}
}
