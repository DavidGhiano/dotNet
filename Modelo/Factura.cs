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
		public List<LineaDeFactura> lineasDeFactura;

		public Factura()
		{
			this.fecha = DateTime.Today;
			this.idFactura = 0;
			this.importeTotal = 0.0f;
			this.Cliente = null;
		}

		public Factura(DateTime fecha, int idFactura, float importeTotal, Cliente cliente)
		{
			this.fecha = fecha;
			this.idFactura = idFactura;
			this.importeTotal = importeTotal;
			this.Cliente = cliente;
		}

		public DateTime Fecha { get => fecha; set => fecha = value; }
		public int IdFactura { get => idFactura; set => idFactura = value; }
		public float ImporteTotal { get => importeTotal; set => importeTotal = value; }
		public Cliente Cliente { get => cliente; set => cliente = value; }

		public void crearLineaDeFactura()
		{
			LineaDeFactura lf = new LineaDeFactura()
		}
	}
}
