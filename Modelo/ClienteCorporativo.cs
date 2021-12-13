using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ClienteCorporativo : Cliente
    {
        private string cuit;
        private string razonSocial;

        public ClienteCorporativo()
		{
            this.cuit = "";
            this.razonSocial = "";
        }

        public ClienteCorporativo(
            string cuit,
            string razonSocial,
            string direccion,
                int idCliente,
                string nacionalidad,
                string provincia,
                string telefono,
                string apellido,
                string nombre,
                string dni):
            base(
                direccion,
                idCliente,
                nacionalidad,
                provincia,
                telefono,
                apellido,
                nombre,
                dni)
        {
            this.cuit = cuit;
            this.razonSocial = razonSocial;
        }

        public string Cuit { get => cuit; set => cuit = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }

		public override void mostrarDatos()
		{
            Console.WriteLine("CUIT: " + cuit);
            Console.WriteLine("Razón social: " + razonSocial);
            base.mostrarDatos();
		}

        public override string ToString()
        {
            return "CUIT: " + cuit +
                "\nRazón social: " + razonSocial +
                base.ToString();
        }
    }
}
