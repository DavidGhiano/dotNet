using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DatosJSON;
using System.Runtime.CompilerServices;

namespace AgenciaDeViajes
{
	class Program
	{
		public static ConsoleKeyInfo opcion;
		public static string dniCliente;
		public static string cuitCliente;
		public static int idPaquete;
		public static string nombreLugar;
		public static ClienteCorporativo clienteCorporativo;
		public static Cliente clienteParticular;
		public static Paquete paquete;
		public static Lugar lugar;

		public static List<Cliente> lclientes;
		public static RepoJSONCliente repoJsonCliente = new RepoJSONCliente("clientes.json");

		public static List<ClienteCorporativo> lCliCorporativos;
		public static RepoJSONClienteCorporativo repoJsonCliCorporativo = new RepoJSONClienteCorporativo("clientesCorporativos.json");

		public static List<Factura> lFacturas;
		public static RepoJSONFactura repoJsonFactura = new RepoJSONFactura("facturas.json");

		public static List<LineaDeFactura> lLineaFacturas;
		public static RepoJSONLineaDeFactura repoJsonLineaFactura = new RepoJSONLineaDeFactura("lineaFacturas.json");

		public static List<Lugar> lLugares;
		public static RepoJSONLugar repoJsonLugar = new RepoJSONLugar("lugares.json");

		public static List<Paquete> lPaquetes;
		public static RepoJSONPaquete repoJsonPaquete = new RepoJSONPaquete("paquetes.json");

		public static List<PaqueteInternacional> lPaqInter;
		public static RepoJSONPaqueteInternacional repoJsonInter = new RepoJSONPaqueteInternacional("paqInter.json");

		public static List<PaqueteNacional> lPaqNac;
		public static RepoJSONPaqueteNacional repoJsonNac = new RepoJSONPaqueteNacional("paqNac.json");

		static void Main(string[] args)
		{
			repoJsonCliente.LeerYDeserializar(out lclientes);
			repoJsonCliCorporativo.LeerYDeserializar(out lCliCorporativos);
			repoJsonFactura.LeerYDeserializar(out lFacturas);
			repoJsonLineaFactura.LeerYDeserializar(out lLineaFacturas);
			repoJsonLugar.LeerYDeserializar(out lLugares);
			repoJsonPaquete.LeerYDeserializar(out lPaquetes);
			repoJsonInter.LeerYDeserializar(out lPaqInter);
			repoJsonNac.LeerYDeserializar(out lPaqNac);


			#region Comentarios
			//lLugares = new List<Lugar>() { new Lugar(Lugar.contadorLugares, "Brasil"), new Lugar(Lugar.contadorLugares, "Argentina") };
			//lPaqInter = new List<PaqueteInternacional>() { new PaqueteInternacional(100, 1000, true, 10, true, DateTime.Parse("20-01-2021"), Paquete.contadorPaquetes, "Paquete Brasil", 6500, 3, new List<Lugar>() { lLugares[0] }) };
			//lPaqNac = new List<PaqueteNacional>() { new PaqueteNacional("Contado", 0.21f, 15, true, DateTime.Parse("20-01-2021"), Paquete.contadorPaquetes, "Paquete Argentina", 3500, 1, new List<Lugar>() { lLugares[1] }) };


			//LineaDeFactura lf1 = new LineaDeFactura(
			//Factura.contadorFacturas,
			//LineaDeFactura.contadorLineasFactura,
			//1,
			//lPaqInter[0].ImporteTotal,
			//lPaqInter[0].IdPaquete);
			//Factura f1 = new Factura(DateTime.Now, Factura.contadorFacturas, 1, new List<LineaDeFactura>() { lf1 });

			//LineaDeFactura lf2 = new LineaDeFactura(
			//Factura.contadorFacturas,
			//LineaDeFactura.contadorLineasFactura,
			//1,
			//lPaqNac[0].ImporteTotal,
			//lPaqNac[0].IdPaquete);
			//Factura f2 = new Factura(DateTime.Now, Factura.contadorFacturas, 1, new List<LineaDeFactura>() { lf2 });

			//lLineaFacturas.Add(lf1);
			//lLineaFacturas.Add(lf2);
			//lFacturas.Add(f1);
			//lFacturas.Add(f2);

			//lFacturas[0].Cliente = lclientes[0];
			//lFacturas[1].Cliente = lclientes[0];

			//lLineaFacturas[0].Paquete = lPaqInter[0];
			//lLineaFacturas[1].Paquete = lPaqNac[0];

			//Paquete paqueteNa = new PaqueteNacional(
			//	"contado",
			//	0.21f,
			//	3,
			//	true,
			//	DateTime.Now,
			//	Paquete.contadorPaquetes,
			//	"Argentina",
			//	6500.0f,
			//	1,
			//	6500.0f,
			//	new List<Lugar>() { lLugares[1] });
			//Paquete paqueteIn = new PaqueteInternacional(
			//	107.5f,
			//	0.21f,
			//	false,
			//	5,
			//	true,
			//	DateTime.Now,
			//	Paquete.contadorPaquetes,
			//	"Mexico",
			//	8000.5f,
			//	6,
			//	8000.5f,
			//	new List<Lugar>(){lLugares[0]});
			//lPaquetes.Add(paqueteIn);
			//lPaquetes.Add(paqueteNa);
			#endregion

			do
			{
				Console.WriteLine("1 - Gestionar clientes");
				Console.WriteLine("2 - Gestionar lugares");
				Console.WriteLine("3 - Gestionar paquetes");
				Console.WriteLine("4 - Gestionar ventas");
				Console.WriteLine("5 - Listar facturas de un cliente");
				Console.WriteLine("6 - Inactivar/activar paquete");
				Console.WriteLine("7 - Actualizar precio de un paquete");
				Console.WriteLine("8 - Listar clientes que tengan al menos dos ventas");
				Console.WriteLine("ESC - Salir");
				Console.Write("Ingrese una opción: ");
				do
				{
					opcion = Console.ReadKey();
				} while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '8'));
				switch (opcion.KeyChar)
				{
					case '1':
						gestionClientes();
						break;

					case '2':
						gestionLugares();
						break;

					case '3':
						//gestionPaquetes();
						break;

					case '4':
						//gestionVentas();
						break;

					case '5':
						listaFacturaCliente();
						break;

					case '6':
						inactivarActivarPaquete();
						break;

					case '7':
						actualizarPrecioPaquete();
						break;

					case '8':
						listarClientesAlMenosDosVentas();
						break;

					default:
						break;
				}
			} while ((int)opcion.KeyChar != 27); // 27 es el código ASCII del Escape
			repoJsonCliente.SerializarYGuardar(lclientes);
			repoJsonCliCorporativo.SerializarYGuardar(lCliCorporativos);
			repoJsonFactura.SerializarYGuardar(lFacturas);
			repoJsonLineaFactura.SerializarYGuardar(lLineaFacturas);
			repoJsonLugar.SerializarYGuardar(lLugares);
			repoJsonPaquete.SerializarYGuardar(lPaquetes);
			repoJsonInter.SerializarYGuardar(lPaqInter);
			repoJsonNac.SerializarYGuardar(lPaqNac);
		}

        #region Gestion del Cliente
        private static void gestionClientes()
		{
			Console.Write("\n\nGestión de clientes: ");
			Console.WriteLine("\n1 - Nuevo cliente");
			Console.WriteLine("2 - Editar cliente");
			Console.WriteLine("3 - Baja de cliente");
			Console.WriteLine("ESC - Salir");
			Console.Write("Ingrese una opción: ");
			do
			{
				opcion = Console.ReadKey();
			} while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '3'));
			switch (opcion.KeyChar)
			{
				case '1':
					nuevoCliente();
					break;
				case '2':
					editarCliente();
					break;
				case '3':
					bajaCliente();
					break;
				default:
					break;
			}
		}
		private static void nuevoCliente()
		{
			Console.Write("\n\nTipo de cliente: ");
			Console.WriteLine("\n1 - Cliente corporativo");
			Console.WriteLine("2 - Cliente particular");
			Console.WriteLine("ESC - Salir");
			Console.Write("Ingrese una opción: ");
			do
			{
				opcion = Console.ReadKey();
			} while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '2'));
			switch (opcion.KeyChar)
			{
				case '1':
					try
					{
						Console.WriteLine("\n\nIngrese los datos para el nuevo cliente corporativo:");
						Console.Write("CUIT: ");
						string cuit = Console.ReadLine();
						Console.Write("Razón social: ");
						string razonSocial = Console.ReadLine();
						Console.Write("DNI del viajante: ");
						string dniCC = Console.ReadLine();
						Console.Write("Nombre del viajante: ");
						string nombreCC = Console.ReadLine();
						Console.Write("Apellido del viajante: ");
						string apellidoCC = Console.ReadLine();
						Console.Write("Dirección: ");
						string direccionCC = Console.ReadLine();
						Console.Write("Teléfono: ");
						string telefonoCC = Console.ReadLine();
						Console.Write("Nacionalidad: ");
						string nacionalidadCC = Console.ReadLine();
						Console.Write("Provincia: ");
						string provinciaCC = Console.ReadLine();
						int idClienteCC = Cliente.contadorClientes;
						ClienteCorporativo cliCC = new ClienteCorporativo(cuit, razonSocial, direccionCC, idClienteCC, nacionalidadCC, provinciaCC, telefonoCC, apellidoCC, nombreCC, dniCC);
						lCliCorporativos.Add(cliCC);

						Console.WriteLine("\nCliente corporativo creado con exito");

					}
					catch (Exception ex)
					{
						Console.WriteLine("UPS" + ex.Message);
					}
					Console.Write("\n");
					break;
				case '2':
					try
					{
						Console.WriteLine("\n\nIngrese los datos para el nuevo cliente particular:");
						Console.Write("DNI: ");
						string dni = Console.ReadLine();
						Console.Write("Nombre: ");
						string nombre = Console.ReadLine();
						Console.Write("Apellido: ");
						string apellido = Console.ReadLine();
						Console.Write("Dirección: ");
						string direccion = Console.ReadLine();
						Console.Write("Teléfono: ");
						string telefono = Console.ReadLine();
						Console.Write("Nacionalidad: ");
						string nacionalidad = Console.ReadLine();
						Console.Write("Provincia: ");
						string provincia = Console.ReadLine();
						int idCliente = Cliente.contadorClientes;
						Cliente cli = new Cliente(direccion, idCliente, nacionalidad, provincia, telefono, apellido, nombre, dni);
						lclientes.Add(cli);

						Console.WriteLine("\nCliente particular creado con exito");

					}
					catch (Exception ex)
					{
						Console.WriteLine("UPS" + ex.Message);
					}
					Console.Write("\n");
					break;
				default:
					break;
			}
		}
		private static void editarCliente(){
			Console.Write("\n\nTipo de cliente: ");
			Console.WriteLine("\n1 - Cliente corporativo");
			Console.WriteLine("2 - Cliente particular");
			Console.WriteLine("ESC - Salir");
			Console.Write("Ingrese una opción: ");
			do
			{
				opcion = Console.ReadKey();
			} while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '2'));
			switch (opcion.KeyChar)
			{
				case '1':
					try
					{
						Console.Write("\n\nIngrese el CUIT del cliente: ");
						cuitCliente = Console.ReadLine();
						clienteCorporativo = lCliCorporativos.Find(x => x.Cuit == cuitCliente);
						if (clienteCorporativo != null)
						{
							Console.WriteLine(clienteCorporativo.ToString());

							Console.WriteLine("Ingrese los nuevos datos del cliente corporativo:");
							Console.Write("Razón social: ");
							string razonSocial = Console.ReadLine();
							Console.Write("DNI del viajante: ");
							string dniCC = Console.ReadLine();
							Console.Write("Nombre del viajante: ");
							string nombreCC = Console.ReadLine();
							Console.Write("Apellido del viajante: ");
							string apellidoCC = Console.ReadLine();
							Console.Write("Dirección: ");
							string direccionCC = Console.ReadLine();
							Console.Write("Teléfono: ");
							string telefonoCC = Console.ReadLine();
							Console.Write("Nacionalidad: ");
							string nacionalidadCC = Console.ReadLine();
							Console.Write("Provincia: ");
							string provinciaCC = Console.ReadLine();
							int idClienteCC = clienteCorporativo.IdCliente;
							ClienteCorporativo cliCC = new ClienteCorporativo(cuitCliente, razonSocial, direccionCC, idClienteCC, nacionalidadCC, provinciaCC, telefonoCC, apellidoCC, nombreCC, dniCC);
							lCliCorporativos.Remove(clienteCorporativo);
							lCliCorporativos.Add(cliCC);

							Console.WriteLine("\nCliente corporativo editado correctamente");

						}
						else
						{
							Console.WriteLine("\nCliente no encontrado. Debe crearlo primero");
							Console.Write("\n");
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine("UPS" + ex.Message);
					}
					Console.Write("\n");
					break;
				case '2':
					try
					{
						Console.Write("\n\nIngrese el DNI del cliente: ");
						dniCliente = Console.ReadLine();
						clienteParticular = lclientes.Find(x => x.Dni == dniCliente);
						if (clienteParticular != null)
						{
							Console.WriteLine(clienteParticular.ToString());

							Console.WriteLine("Ingrese los nuevos datos del cliente particular:");
							Console.Write("Nombre: ");
							string nombre = Console.ReadLine();
							Console.Write("Apellido: ");
							string apellido = Console.ReadLine();
							Console.Write("Dirección: ");
							string direccion = Console.ReadLine();
							Console.Write("Teléfono: ");
							string telefono = Console.ReadLine();
							Console.Write("Nacionalidad: ");
							string nacionalidad = Console.ReadLine();
							Console.Write("Provincia: ");
							string provincia = Console.ReadLine();
							int idCliente = clienteParticular.IdCliente;
							Cliente cli = new Cliente(direccion, idCliente, nacionalidad, provincia, telefono, apellido, nombre, dniCliente);
							lclientes.Remove(clienteParticular);
							lclientes.Add(cli);

							Console.WriteLine("\nCliente particular editado correctamente");

						}
						else
						{
							Console.WriteLine("\nCliente no encontrado. Debe crearlo primero");
							Console.Write("\n");
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine("UPS" + ex.Message);
					}
					Console.Write("\n");
					break;
				default:
					break;
			}
		}
		private static void bajaCliente()
        {
			Console.Write("\n\nIngrese el DNI del cliente: ");
			dniCliente = Console.ReadLine();
			clienteParticular = lclientes.Find(x => x.Dni == dniCliente);
			if (clienteParticular != null)
			{
				Console.Write("\n");
				Console.WriteLine(clienteParticular.ToString());

				if (clienteParticular.Habilitado)
				{
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.Write("¿Desea inactivar el cliente?");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("\ns/S: Sí");
					Console.WriteLine("n/N: No");
					ConsoleKeyInfo confirma;
					do
					{
						confirma = Console.ReadKey(true);
					} while ((confirma.KeyChar != 's') && (confirma.KeyChar != 'S')
					&& (confirma.KeyChar != 'n') && (confirma.KeyChar != 'N'));
					if (confirma.KeyChar == 's' || confirma.KeyChar == 'S')
					{
						clienteParticular.Habilitado = false;
						Console.WriteLine("\nCliente inactivado existosamente.\n");
					}
					else Console.Write("\n");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.WriteLine("\nEl cliente ya se encuentra inactivado.\n¿Desea activarlo?");
					Console.WriteLine("\ns/S: Sí");
					Console.WriteLine("n/N: No");
					ConsoleKeyInfo confirma;
					do
					{
						confirma = Console.ReadKey(true);
					} while ((confirma.KeyChar != 's') && (confirma.KeyChar != 'S')
					&& (confirma.KeyChar != 'n') && (confirma.KeyChar != 'N'));
					if (confirma.KeyChar == 's' || confirma.KeyChar == 'S')
					{
						clienteParticular.Habilitado = true;
						Console.WriteLine("\nCliente activado existosamente.\n");
					}
					else Console.Write("\n");
				}
			}
			else
			{
				clienteCorporativo = lCliCorporativos.Find(x => x.Dni == dniCliente);
				if (clienteCorporativo != null)
				{
					Console.Write("\n");
					Console.WriteLine(clienteCorporativo.ToString());

					if (clienteCorporativo.Habilitado)
					{
						Console.Write("\n\n¿Desea inactivar el cliente?");
						Console.WriteLine("\ns/S: Sí");
						Console.WriteLine("n/N: No");
						ConsoleKeyInfo confirma;
						do
						{
							confirma = Console.ReadKey(true);
						} while ((confirma.KeyChar != 's') && (confirma.KeyChar != 'S')
						&& (confirma.KeyChar != 'n') && (confirma.KeyChar != 'N'));
						if (confirma.KeyChar == 's' || confirma.KeyChar == 'S')
						{
							clienteCorporativo.Habilitado = false;
							Console.WriteLine("\nCliente inactivado existosamente.\n");
						}
						else Console.Write("\n");
					}
					else
					{
						Console.WriteLine("\nEl cliente ya se encuentra inactivado.\n¿Desea activarlo?");
						Console.WriteLine("\ns/S: Sí");
						Console.WriteLine("n/N: No");
						ConsoleKeyInfo confirma;
						do
						{
							confirma = Console.ReadKey(true);
						} while ((confirma.KeyChar != 's') && (confirma.KeyChar != 'S')
						&& (confirma.KeyChar != 'n') && (confirma.KeyChar != 'N'));
						if (confirma.KeyChar == 's' || confirma.KeyChar == 'S')
						{
							clienteCorporativo.Habilitado = true;
							Console.WriteLine("\nCliente activado existosamente.\n");
						}
						else Console.Write("\n");
					}
				}
				else
				{
					Console.WriteLine("\nCliente no encontrado. Debe crearlo primero");
					Console.Write("\n");
				}
			}
		}
        #endregion

		#region Gestion de Lugares
		private static void gestionLugares()
		{
			Console.Write("\n\nGestión de Lugares: ");
			Console.WriteLine("\n1 - Nuevo lugar");
			Console.WriteLine("2 - Editar lugar");
			Console.WriteLine("3 - Baja de lugar");
			Console.WriteLine("ESC - Salir");
			Console.Write("Ingrese una opción: ");
			do
			{
				opcion = Console.ReadKey();
			} while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '3'));
			switch (opcion.KeyChar)
			{
				case '1':
					nuevoLugar();
					break;
				case '2':
					editarLugar();
					break;
				case '3':
					bajaLugar();
					break;
				default:
					break;
			}
		}
		private static void nuevoLugar() 
		{ 
			try
			{
				Console.WriteLine("\n\nIngrese el nombre del nuevo lugar:");
				Console.Write("Nombre: ");
				string nombre = Console.ReadLine();
				int idLugar = Lugar.contadorLugares;
				lugar = new Lugar(idLugar, nombre, true);
				lLugares.Add(lugar);

			}
			catch (Exception ex)
			{
				Console.WriteLine("UPS" + ex.Message);
			}
			Console.Write("\n");
		}
		private static void editarLugar()
		{
			Console.WriteLine("\n\nLugares disponibles:");
			foreach (Lugar l in lLugares)
			{
				if (l.Habilitado)
				{
					Console.WriteLine(" - " + l.Nombre);
				}
			}
			Console.Write("\n");

			try
			{
				Console.Write("\n\nIngrese el nombre del lugar: ");
				nombreLugar = Console.ReadLine();
				lugar = lLugares.Find(x => x.Nombre == nombreLugar);
				if (lugar != null)
				{

					Console.WriteLine("Ingrese el nuevo nombre del lugar:");
					Console.Write("Nombre: ");
					string nombre = Console.ReadLine();
					int idLugar = lugar.IdLugar;
					Lugar lug = new Lugar(idLugar, nombre, true);
					lLugares.Remove(lugar);
					lLugares.Add(lug);

					Console.WriteLine("\nLugar editado correctamente");

				}
				else
				{
					Console.WriteLine("\nLugar no encontrado. Debe crearlo primero");
					Console.Write("\n");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("UPS" + ex.Message);
			}
			Console.Write("\n");
        }
		private static void bajaLugar()
        {
			Console.Write("\n\nIngrese el nombre del lugar: ");
			nombreLugar = Console.ReadLine();
			lugar = lLugares.Find(x => x.Nombre == nombreLugar);
			if (lugar != null)
				{
					Console.Write("\n");

					if (lugar.Habilitado)
					{
						Console.Write("\n\n¿Desea inactivar el cliente?");
						Console.WriteLine("s/S: Sí");
						Console.WriteLine("n/N: No");
						ConsoleKeyInfo confirma;
						do
						{
							confirma = Console.ReadKey(true);
						} while ((confirma.KeyChar != 's') && (confirma.KeyChar != 'S')
						&& (confirma.KeyChar != 'n') && (confirma.KeyChar != 'N'));
						if (confirma.KeyChar == 's' || confirma.KeyChar == 'S')
						{
							lugar.Habilitado = false;
							Console.WriteLine("\nLugar inactivado existosamente.\n");
						}
						else Console.Write("\n");
					}
					else
					{
						Console.WriteLine("\nEl Lugar ya se encuentra inactivado.\n¿Desea activarlo?");
						Console.WriteLine("s/S: Sí");
						Console.WriteLine("n/N: No");
						ConsoleKeyInfo confirma;
						do
						{
							confirma = Console.ReadKey(true);
						} while ((confirma.KeyChar != 's') && (confirma.KeyChar != 'S')
						&& (confirma.KeyChar != 'n') && (confirma.KeyChar != 'N'));
						if (confirma.KeyChar == 's' || confirma.KeyChar == 'S')
						{
							lugar.Habilitado = true;
							Console.WriteLine("\nLugar activado existosamente.\n");
						}
						else Console.Write("\n");
					}
				}
				else
				{
					Console.WriteLine("\nLugar no encontrado. Debe primero crearlo");
					Console.Write("\n");
				}
        }
		#endregion


		private static void listaFacturaCliente()
        {
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("\n\nIngrese el DNI del cliente: ");
			Console.ForegroundColor = ConsoleColor.Gray;
			dniCliente = Console.ReadLine();
			clienteParticular = lclientes.Find(x => x.Dni == dniCliente);
			if (clienteParticular != null)
			{
				clienteParticular.ImprimirDatos();
				Console.Write("\n");

				List<Factura> facturasCli = lFacturas.FindAll(x => x.IdCliente == clienteParticular.IdCliente);
				foreach (Factura f in facturasCli)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine($"============== FACTURA: {f.IdFactura}==============");

					f.ImprimirDatos();
					Paquete paquete1 = null;
					foreach (LineaDeFactura lf in f.LineasDeFactura)
					{
						Console.WriteLine("--------------------------------------------");

						paquete1 = lPaqInter.Find(x => x.IdPaquete == lf.IdPaquete);
						if (paquete1 == null)
						{
							paquete1 = lPaqNac.Find(x => x.IdPaquete == lf.IdPaquete);
						}
						paquete1.ImprimirDatos();
						lf.ImprimirDatos();
						//Console.WriteLine(paquete1.ToString());
					}
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine($"============== FIN FACTURA==============");
					Console.ResetColor();
					Console.WriteLine("\n");
				}
			}
			else
			{
				clienteCorporativo = lCliCorporativos.Find(x => x.Dni == dniCliente);
				if (clienteCorporativo != null)
				{
					Console.WriteLine(clienteCorporativo.ToString());
					List<Factura> facturasCli = lFacturas.FindAll(x => x.IdCliente == clienteCorporativo.IdCliente);
					foreach (Factura f in facturasCli)
					{
						Console.WriteLine(f.ToString());
						Paquete paquete1 = null;
						foreach (LineaDeFactura lf in f.LineasDeFactura)
						{
							paquete1 = lPaqInter.Find(x => x.IdPaquete == lf.IdPaquete);
							if (paquete1 == null)
							{
								paquete1 = lPaqNac.Find(x => x.IdPaquete == lf.IdPaquete);
							}

							Console.WriteLine(lf.ToString());
							Console.WriteLine(paquete1.ToString());
						}
					}
					Console.Write("\n");
				}
				else
				{
					Console.WriteLine("\nCliente no encontrado. Crear primero el cliente");
					Console.Write("\n");
				}
			}
		}

		private static void inactivarActivarPaquete()
		{
			Console.WriteLine("\n\nPaquetes Nacionales:");
			foreach (Paquete p in lPaqNac)
			{
				if (p.Estado)
				{
					Console.WriteLine(p.IdPaquete + " - " + p.Nombre);
				}
			}
			Console.Write("\n");
			Console.WriteLine("Paquetes Internacionales:");
			foreach (Paquete p in lPaqInter)
			{
				if (p.Estado)
				{
					Console.WriteLine(p.IdPaquete + " - " + p.Nombre);
				}
			}
			Console.Write("\n");

			Console.Write("\nIngrese el ID del paquete: ");
			idPaquete = int.Parse(Console.ReadLine());

			paquete = lPaqInter.Find((x => x.IdPaquete == idPaquete));
			if (paquete == null)
			{
				paquete = lPaqNac.Find((x => x.IdPaquete == idPaquete));
			}

			if (paquete != null)
			{
				Console.Write("\n");
				Console.WriteLine(paquete.ToString());

				if (paquete.Estado)
				{
					Console.ForegroundColor = ConsoleColor.DarkMagenta;
					Console.Write("¿Desea inactivar el paquete?");
					Console.WriteLine("\ns/S: Sí");
					Console.WriteLine("n/N: No");
					ConsoleKeyInfo confirma;
					do
					{
						confirma = Console.ReadKey(true);
					} while ((confirma.KeyChar != 's') && (confirma.KeyChar != 'S')
					&& (confirma.KeyChar != 'n') && (confirma.KeyChar != 'N'));
					if (confirma.KeyChar == 's' || confirma.KeyChar == 'S')
					{
						paquete.Estado = false;
						Console.WriteLine("\nPaquete inactivado existosamente.\n");
					}
					else Console.Write("\n");
				}
				else
				{
					Console.WriteLine("El paquete ya se encuentra inactivado.\n¿Desea activar el paquete?");
					Console.WriteLine("\ns/S: Sí");
					Console.WriteLine("n/N: No");
					ConsoleKeyInfo confirma;
					do
					{
						confirma = Console.ReadKey(true);
					} while ((confirma.KeyChar != 's') && (confirma.KeyChar != 'S')
					&& (confirma.KeyChar != 'n') && (confirma.KeyChar != 'N'));
					if (confirma.KeyChar == 's' || confirma.KeyChar == 'S')
					{
						paquete.Estado = true;
						Console.WriteLine("\nPaquete activado existosamente.\n");
					}
					else Console.Write("\n");
				}
			}
			else
			{
				Console.WriteLine("\nPaquete no encontrado.");
				Console.Write("\n");
			}
		}

		private static void actualizarPrecioPaquete()
		{
			Console.WriteLine("\n\nPaquetes Nacionales:");
			foreach (Paquete p in lPaqNac)
			{
				if (p.Estado)
				{
					Console.WriteLine(p.IdPaquete + " - " + p.Nombre);
				}
			}
			Console.Write("\n");

			Console.WriteLine("Paquetes Internacionales:");
			foreach (Paquete p in lPaqInter)
			{
				if (p.Estado)
				{
					Console.WriteLine(p.IdPaquete + " - " + p.Nombre);
				}
			}
			Console.Write("\n");

			Console.Write("Ingrese el ID del paquete: ");
			idPaquete = int.Parse(Console.ReadLine());

			paquete = lPaqInter.Find((x => x.IdPaquete == idPaquete && x.Estado == true));
			if (paquete == null)
			{
				paquete = lPaqNac.Find((x => x.IdPaquete == idPaquete && x.Estado == true));
			}

			if (paquete != null)
			{
				Console.Write("\n");
				Console.WriteLine($"Precio del paquete seleccionado: {paquete.Precio.ToString()}");

				Console.Write("\nIngrese el nuevo precio: ");
				float nuevoPrecioPaquete = float.Parse(Console.ReadLine());


				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.Write("\n¿Desea actualizar el precio del paquete?\n");
				Console.WriteLine("s/S: Sí");
				Console.WriteLine("n/N: No");
				ConsoleKeyInfo confirma;
				do
				{
					confirma = Console.ReadKey(true);
				} while ((confirma.KeyChar != 's') && (confirma.KeyChar != 'S')
				&& (confirma.KeyChar != 'n') && (confirma.KeyChar != 'N'));
				if (confirma.KeyChar == 's' || confirma.KeyChar == 'S')
				{
					paquete.Precio = nuevoPrecioPaquete;
					Console.WriteLine("\nPrecio actualizado existosamente.\n");
				}
				else Console.Write("\n");

			}
			else
			{
				Console.WriteLine("\nPaquete no encontrado.");
				Console.Write("\n");
			}
		}

		private static void listarClientesAlMenosDosVentas()
		{
			Console.WriteLine("\nClientes con más de dos compras:");
			Console.Write("\n");
			foreach (Cliente cli in lclientes)
			{
				if (lFacturas.FindAll(x => x.IdCliente == cli.IdCliente).Count >= 2)
				{
					Console.WriteLine(" - " + cli.Nombre + " " + cli.Apellido);
				}
			}
			Console.Write("\n");

			foreach (ClienteCorporativo cliCorp in lCliCorporativos)
			{
				if (lFacturas.FindAll(x => x.IdCliente == cliCorp.IdCliente).Count >= 2)
				{
					Console.WriteLine(" - " + cliCorp.RazonSocial);
				}
			}
			Console.Write("\n");
		}

		#region Gestion de Paquetes
		//codigo gestion paquetes
		#endregion

		#region Gestion de Ventas
		// codigo gestion ventas
		#endregion

    }
}
