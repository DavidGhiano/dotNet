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
		private int idCliente;
		private List<LineaDeFactura> lineasDeFactura;

		public static int contadorFacturas = 0;

		static Factura()
		{
			contadorFacturas = 1;
		}

		public Factura()
		{
			this.fecha = DateTime.Today;
			this.idFactura = 0;
			this.importeTotal = 0.0f;
			this.idCliente = 0;
			this.lineasDeFactura = null;
			contadorFacturas++;
		}

		public Factura(DateTime fecha, int idFactura, int idCliente, List<LineaDeFactura> lineasDeFactura)
		{
			this.fecha = fecha;
			this.idFactura = idFactura;
			this.idCliente = idCliente;
			this.lineasDeFactura = lineasDeFactura;
			this.importeTotal = calcularImporte();
			contadorFacturas++;
		}

		public DateTime Fecha { get => fecha; set => fecha = value; }
		public int IdFactura { get => idFactura; set => idFactura = value; }
		public float ImporteTotal { get => importeTotal; set => importeTotal = value; }
		public int IdCliente { get => idCliente; set => idCliente = value; }
		public List<LineaDeFactura> LineasDeFactura { get => lineasDeFactura; set => lineasDeFactura = value; }

		public float calcularImporte()
		{
			float total = 0;
			lineasDeFactura.ForEach(linea => total += linea.Subtotal);
			return importeTotal = total;
		}

		public override string ToString()
		{
			return "Número de factura: " + idFactura +
				"\nFecha: " + fecha.ToString("dd/MM/yyyy") +
				"\n";
		}
	}
}
