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
		private Cliente cliente;
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
			this.Cliente = null;
			this.lineasDeFactura = null;
			contadorFacturas++;
		}

		public Factura(DateTime fecha, int idFactura, float importeTotal, Cliente cliente, List<LineaDeFactura> lineasDeFactura)
		{
			this.fecha = fecha;
			this.idFactura = idFactura;
			this.importeTotal = importeTotal;
			this.Cliente = cliente;
			this.lineasDeFactura = lineasDeFactura;
			contadorFacturas++;
		}

		public DateTime Fecha { get => fecha; set => fecha = value; }
		public int IdFactura { get => idFactura; set => idFactura = value; }
		public float ImporteTotal { get => importeTotal; set => importeTotal = value; }
		public Cliente Cliente { get => cliente; set => cliente = value; }
		public List<LineaDeFactura> LineasDeFactura { get => lineasDeFactura; set => lineasDeFactura = value; }

		public void calcularImporte()
		{
			float total = 0;
			lineasDeFactura.ForEach(linea => total += linea.Subtotal);
			importeTotal = total;
		}

		public override string ToString()
		{
			return "Número de factura: " + idFactura +
				"\nFecha: " + fecha.ToString("dd/MM/yyyy") +
				"\nLineas De Facutura: \n" + convertirListaEnCadena(lineasDeFactura) +
				"\n";
		}

		private string convertirListaEnCadena(List<LineaDeFactura> lineas)
		{
			string cadena = "";
			for(int i = 0; i<lineas.Count; i++)
			{
				cadena = cadena + lineas[i].ToString();
			}
			return cadena;
		}
	}
}
