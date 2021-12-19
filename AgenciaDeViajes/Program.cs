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
		public static int idLugar;
		public static string nombreLugar;
		public static ClienteCorporativo clienteCorporativo;
		public static Cliente clienteParticular;
		public static Paquete paquete;
		public static PaqueteInternacional paqueteInter;
		public static PaqueteNacional paqueteNac;
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
				Console.WriteLine("4 - Registrar una nueva venta");
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
						gestionPaquetes();
						break;

					case '4':
						nuevaVenta();
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
						Console.WriteLine("UPS, " + ex.Message);
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
						Console.WriteLine("UPS, " + ex.Message);
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
							Console.Write("\n");
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
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine("UPS, " + ex.Message);
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
							Console.Write("\n");
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
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine("UPS, " + ex.Message);
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
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write("¿Desea inactivar el cliente?");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("\ns/S: Sí");
					Console.WriteLine("n/N: No");
					Console.ForegroundColor = ConsoleColor.Gray;
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
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("\nEl cliente ya se encuentra inactivado.\n¿Desea activarlo?");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("\ns/S: Sí");
					Console.WriteLine("n/N: No");
					Console.ForegroundColor = ConsoleColor.Gray;
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
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("\n\n¿Desea inactivar el cliente?");
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\ns/S: Sí");
						Console.WriteLine("n/N: No");
						Console.ForegroundColor = ConsoleColor.Gray;
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
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("\nEl cliente ya se encuentra inactivado.\n¿Desea activarlo?");
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\ns/S: Sí");
						Console.WriteLine("n/N: No");
						Console.ForegroundColor = ConsoleColor.Gray;
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

				Console.WriteLine("\nLugar creado con exito");
			}
			catch (Exception ex)
			{
				Console.WriteLine("UPS, " + ex.Message);
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
					Console.WriteLine(l.IdLugar + " - " + l.Nombre);
				}
			}

			try
			{
				Console.Write("\nIngrese el ID del lugar: ");
				idLugar = int.Parse(Console.ReadLine());
				lugar = lLugares.Find(x => x.IdLugar == idLugar);
				if (lugar != null)
				{
					Console.Write("\n");
					Console.WriteLine("Ingrese los nuevos datos del lugar:");
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
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("UPS, " + ex.Message);
			}
			Console.Write("\n");
        }
		private static void bajaLugar()
        {
			Console.WriteLine("\n\nLugares disponibles:");
			foreach (Lugar l in lLugares)
			{
				if (l.Habilitado)
				{
					Console.WriteLine(l.IdLugar + " - " + l.Nombre);
				}
			}

			Console.Write("\nIngrese el ID del lugar: ");
			idLugar = int.Parse(Console.ReadLine());
			lugar = lLugares.Find(x => x.IdLugar == idLugar);
			if (lugar != null)
				{
					Console.Write("\n");

					if (lugar.Habilitado)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("¿Desea inactivar el lugar?");
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\ns/S: Sí");
						Console.WriteLine("n/N: No");
						Console.ForegroundColor = ConsoleColor.Gray;
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
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("\nEl lugar ya se encuentra inactivado.\n¿Desea activarlo?");
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\ns/S: Sí");
						Console.WriteLine("n/N: No");
						Console.ForegroundColor = ConsoleColor.Gray;
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

		#region Gestion de Paquetes
		private static void gestionPaquetes()
		{
			Console.Write("\n\nGestión de paquetes: ");
			Console.WriteLine("\n1 - Nuevo paquete");
			Console.WriteLine("2 - Editar paquete");
			Console.WriteLine("ESC - Salir");
			Console.Write("Ingrese una opción: ");
			do
			{
				opcion = Console.ReadKey();
			} while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '2'));
			switch (opcion.KeyChar)
			{
				case '1':
					nuevoPaquete();
					break;
				case '2':
					editarPaquete();
					break;
				default:
					break;
			}
		}
		private static void nuevoPaquete()
		{
			Console.Write("\n\nTipo de paquete: ");
			Console.WriteLine("\n1 - Paquete internacional");
			Console.WriteLine("2 - Paquete nacional");
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
						Console.WriteLine("\n\nIngrese los datos para el nuevo paquete internacional:");
						Console.Write("Nombre: ");
						string nombrePI = Console.ReadLine();
						Console.Write("Cantidad de días: ");
						int cantidadDiasPI = int.Parse(Console.ReadLine());
						DateTime fechaViajePI;
						string fecha = "";
						do
						{
							Console.Write("Fecha de viaje (dd/MM/yyyy): ");
							fecha = Console.ReadLine();
							if (DateTime.TryParse(fecha, out fechaViajePI))
							{
								fechaViajePI = DateTime.Parse(fecha);
							}
							else
							{
								Console.WriteLine("Formato inválido. Ingrese una fecha en el formato especificado.\n");
							}
						} while (!DateTime.TryParse(fecha, out fechaViajePI));
						Console.Write("Precio: ");
						float precioPI = float.Parse(Console.ReadLine());
						Console.Write("Cantidad de cuotas: ");
						int cantidadCuotasPI = int.Parse(Console.ReadLine());
						Console.Write("Cotización del dolar: ");
						float cotizacionDolar = float.Parse(Console.ReadLine());
						Console.Write("Importe por impuestos: ");
						float importePorImpuestos = float.Parse(Console.ReadLine());
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("¿Requiere visa?");
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\ns/S: Sí");
						Console.WriteLine("n/N: No");
						Console.ForegroundColor = ConsoleColor.Gray;
						bool requiereVisa;
						ConsoleKeyInfo confirma;
						do
						{
							confirma = Console.ReadKey(true);
						} while ((confirma.KeyChar != 's') && (confirma.KeyChar != 'S')
						&& (confirma.KeyChar != 'n') && (confirma.KeyChar != 'N'));
						if (confirma.KeyChar == 's' || confirma.KeyChar == 'S')
						{
							requiereVisa = true;
						}
						else
						{
							requiereVisa = false;
						}
						bool estadoPI = true;
						Console.Write("\n");
						Console.Write("Cantidad de lugares incluídos en le paquete: ");
						int cantidadLugaresPI = int.Parse(Console.ReadLine());
						Console.Write("\n");
						List<Lugar> lugaresPI = new List<Lugar>();

						Console.WriteLine("Lugares disponibles:");
						foreach (Lugar l in lLugares)
						{
							if (l.Habilitado)
							{
								Console.WriteLine(l.IdLugar + " - " + l.Nombre);
							}
						}
						Console.Write("\n");

						for (int i = 1; i <= cantidadLugaresPI; i++)
						{
							Console.Write($"Ingrese el ID del lugar {i} a agregar: ");
							idLugar = int.Parse(Console.ReadLine());

							lugar = lLugares.Find(x => x.IdLugar == idLugar && x.Habilitado == true);
							if (lugar != null)
							{
								if (lugaresPI.Find(x => x.IdLugar == lugar.IdLugar) == null)
								{
									lugaresPI.Add(lugar);
								}
								else
								{
									Console.WriteLine("\nEste lugar ya se encuentra agregado al paquete. Ingrese otro por favor.\n");
									i--;
								}
							}
							else
							{
								Console.WriteLine("\nLugar no encontrado. Ingrese alguno de los disponibles en lista.\n");
								i--;
							}
						}

						int idPaquetePI = Paquete.contadorPaquetes;
						PaqueteInternacional paqueteInternacional = new PaqueteInternacional(cotizacionDolar, importePorImpuestos, requiereVisa, cantidadDiasPI, estadoPI, fechaViajePI, idPaquetePI, nombrePI, precioPI, cantidadCuotasPI, lugaresPI);
						lPaqInter.Add(paqueteInternacional);

						Console.WriteLine("\nPaquete internacional creado con exito");

					}
					catch (Exception ex)
					{
						Console.WriteLine("UPS, " + ex.Message);
					}
					Console.Write("\n");
					break;
				case '2':
					try
					{
						Console.WriteLine("\n\nIngrese los datos para el nuevo paquete nacional:");
						Console.Write("Nombre: ");
						string nombrePN = Console.ReadLine();
						Console.Write("Cantidad de días: ");
						int cantidadDiasPN = int.Parse(Console.ReadLine());
						DateTime fechaViajePN;
						string fecha = "";
						do
						{
							Console.Write("Fecha de viaje (dd/MM/yyyy): ");
							fecha = Console.ReadLine();
							if (DateTime.TryParse(fecha, out fechaViajePN))
							{
								fechaViajePN = DateTime.Parse(fecha);
							}
							else
							{
								Console.WriteLine("Formato inválido. Ingrese una fecha en el formato especificado.\n");
							}
						} while (!DateTime.TryParse(fecha, out fechaViajePN));
						Console.Write("Precio: ");
						float precioPN = float.Parse(Console.ReadLine());
						Console.Write("Cantidad de cuotas: ");
						int cantidadCuotasPN = int.Parse(Console.ReadLine());
						Console.Write("Modo de pago: ");
						string modoDePago = Console.ReadLine();
						Console.Write("Porcentaje por impuestos: ");
						float porcentajePorImpuestos = float.Parse(Console.ReadLine()) / 100;
						bool estadoPN = true;
						Console.Write("\n");
						Console.Write("Cantidad de lugares incluídos en le paquete: ");
						int cantidadLugaresPN = int.Parse(Console.ReadLine());
						Console.Write("\n");
						List<Lugar> lugaresPN = new List<Lugar>();

						Console.WriteLine("Lugares disponibles:");
						foreach (Lugar l in lLugares)
						{
							if (l.Habilitado)
							{
								Console.WriteLine(l.IdLugar + " - " + l.Nombre);
							}
						}
						Console.Write("\n");

						for (int i = 1; i <= cantidadLugaresPN; i++)
						{
							Console.Write($"Ingrese el ID del lugar {i} a agregar: ");
							idLugar = int.Parse(Console.ReadLine());

							lugar = lLugares.Find((x => x.IdLugar == idLugar && x.Habilitado == true));
							if (lugar != null)
							{
								if (lugaresPN.Find(x => x.IdLugar == lugar.IdLugar) == null)
								{
									lugaresPN.Add(lugar);
								}
								else
								{
									Console.WriteLine("\nEste lugar ya se encuentra agregado al paquete. Ingrese otro por favor.\n");
									i--;
								}
							}
							else
							{
								Console.WriteLine("\nLugar no encontrado. Ingrese alguno de los disponibles en lista.\n");
								i--;
							}
						}
						int idPaquetePN = Paquete.contadorPaquetes;
						PaqueteNacional paqueteNacional = new PaqueteNacional(modoDePago, porcentajePorImpuestos, cantidadDiasPN, estadoPN, fechaViajePN, idPaquetePN, nombrePN, precioPN, cantidadCuotasPN, lugaresPN);
						lPaqNac.Add(paqueteNacional);

						Console.WriteLine("\nPaquete nacional creado con exito");

					}
					catch (Exception ex)
					{
						Console.WriteLine("UPS, " + ex.Message);
					}
					Console.Write("\n");
					break;
				default:
					break;
			}
		}
		private static void editarPaquete()
		{
			Console.Write("\n\nTipo de paquete: ");
			Console.WriteLine("\n1 - Paquete internacional");
			Console.WriteLine("2 - Paquete nacional");
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
						Console.WriteLine("\n\nPaquetes internacionales disponibles:");
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

						paqueteInter = lPaqInter.Find((x => x.IdPaquete == idPaquete));
						if (paqueteInter != null)
						{
							Console.Write("\n");
							Console.WriteLine(paqueteInter.ToString());

							Console.WriteLine("Ingrese los nuevos datos del paquete internacional:");
							Console.Write("Nombre: ");
							string nombrePI = Console.ReadLine();
							Console.Write("Cantidad de días: ");
							int cantidadDiasPI = int.Parse(Console.ReadLine());
							DateTime fechaViajePI;
							string fecha = "";
							do
							{
								Console.Write("Fecha de viaje (dd/MM/yyyy): ");
								fecha = Console.ReadLine();
								if (DateTime.TryParse(fecha, out fechaViajePI))
								{
									fechaViajePI = DateTime.Parse(fecha);
								}
								else
								{
									Console.WriteLine("Formato inválido. Ingrese una fecha en el formato especificado.\n");
								}
							} while (!DateTime.TryParse(fecha, out fechaViajePI));
							Console.Write("Precio: ");
							float precioPI = float.Parse(Console.ReadLine());
							Console.Write("Cantidad de cuotas: ");
							int cantidadCuotasPI = int.Parse(Console.ReadLine());
							Console.Write("Cotización del dolar: ");
							float cotizacionDolar = float.Parse(Console.ReadLine());
							Console.Write("Importe por impuestos: ");
							float importePorImpuestos = float.Parse(Console.ReadLine());
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write("¿Requiere visa?");
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine("\ns/S: Sí");
							Console.WriteLine("n/N: No");
							Console.ForegroundColor = ConsoleColor.Gray;
							bool requiereVisa;
							ConsoleKeyInfo confirma;
							do
							{
								confirma = Console.ReadKey(true);
							} while ((confirma.KeyChar != 's') && (confirma.KeyChar != 'S')
							&& (confirma.KeyChar != 'n') && (confirma.KeyChar != 'N'));
							if (confirma.KeyChar == 's' || confirma.KeyChar == 'S')
							{
								requiereVisa = true;
							}
							else
							{
								requiereVisa = false;
							}
							bool estadoPI = true;
							Console.Write("\n");
							Console.Write("Cantidad de lugares incluídos en le paquete: ");
							int cantidadLugaresPI = int.Parse(Console.ReadLine());
							Console.Write("\n");
							List<Lugar> lugaresPI = new List<Lugar>();

							Console.WriteLine("Lugares disponibles:");
							foreach (Lugar l in lLugares)
							{
								if (l.Habilitado)
								{
									Console.WriteLine(l.IdLugar + " - " + l.Nombre);
								}
							}
							Console.Write("\n");

							for (int i = 1; i <= cantidadLugaresPI; i++)
							{
								Console.Write($"Ingrese el ID del lugar {i} a agregar: ");
								idLugar = int.Parse(Console.ReadLine());

								lugar = lLugares.Find(x => x.IdLugar == idLugar && x.Habilitado == true);
								if (lugar != null)
								{
									if (lugaresPI.Find(x => x.IdLugar == lugar.IdLugar) == null)
									{
										lugaresPI.Add(lugar);
									}
									else
									{
										Console.WriteLine("\nEste lugar ya se encuentra agregado al paquete. Ingrese otro por favor.\n");
										i--;
									}
								}
								else
								{
									Console.WriteLine("\nLugar no encontrado. Debe crearlo primero");
								}
							}

							int idPaquetePI = paqueteInter.IdPaquete;
							PaqueteInternacional paqueteInternacional = new PaqueteInternacional(cotizacionDolar, importePorImpuestos, requiereVisa, cantidadDiasPI, estadoPI, fechaViajePI, idPaquetePI, nombrePI, precioPI, cantidadCuotasPI, lugaresPI);
							lPaqInter.Remove(paqueteInter);
							lPaqInter.Add(paqueteInternacional);

							Console.WriteLine("\nPaquete internacional editado correctamente");
						}
						else
						{
							Console.WriteLine("\nPaquete no encontrado. Debe crearlo primero");
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine("UPS, " + ex.Message);
					}
					Console.Write("\n");
					break;
				case '2':
					try
					{
						Console.WriteLine("\n\nPaquetes nacionales disponibles:");
						foreach (Paquete p in lPaqNac)
						{
							if (p.Estado)
							{
								Console.WriteLine(p.IdPaquete + " - " + p.Nombre);
							}
						}
						Console.Write("\n");

						Console.Write("Ingrese el ID del paquete: ");
						idPaquete = int.Parse(Console.ReadLine());

						paqueteNac = lPaqNac.Find((x => x.IdPaquete == idPaquete));
						if (paqueteNac != null)
						{
							Console.Write("\n");
							Console.WriteLine(paqueteNac.ToString());

							Console.WriteLine("Ingrese los nuevos datos del paquete nacional:");
							Console.Write("Nombre: ");
							string nombrePN = Console.ReadLine();
							Console.Write("Cantidad de días: ");
							int cantidadDiasPN = int.Parse(Console.ReadLine());
							DateTime fechaViajePN;
							string fecha = "";
							do
							{
								Console.Write("Fecha de viaje (dd/MM/yyyy): ");
								fecha = Console.ReadLine();
								if (DateTime.TryParse(fecha, out fechaViajePN))
								{
									fechaViajePN = DateTime.Parse(fecha);
								}
								else
								{
									Console.WriteLine("Formato inválido. Ingrese una fecha en el formato especificado.\n");
								}
							} while (!DateTime.TryParse(fecha, out fechaViajePN));
							Console.Write("Precio: ");
							float precioPN = float.Parse(Console.ReadLine());
							Console.Write("Cantidad de cuotas: ");
							int cantidadCuotasPN = int.Parse(Console.ReadLine());
							Console.Write("Modo de pago: ");
							string modoDePago = Console.ReadLine();
							Console.Write("Porcentaje por impuestos: ");
							float porcentajePorImpuestos = float.Parse(Console.ReadLine()) / 100;
							bool estadoPN = true;
							Console.Write("\n");
							Console.Write("Cantidad de lugares incluídos en le paquete: ");
							int cantidadLugaresPN = int.Parse(Console.ReadLine());
							Console.Write("\n");
							List<Lugar> lugaresPN = new List<Lugar>();

							Console.WriteLine("Lugares disponibles:");
							foreach (Lugar l in lLugares)
							{
								if (l.Habilitado)
								{
									Console.WriteLine(l.IdLugar + " - " + l.Nombre);
								}
							}
							Console.Write("\n");

							for (int i = 1; i <= cantidadLugaresPN; i++)
							{
								Console.Write($"Ingrese el ID del lugar {i} a agregar: ");
								idLugar = int.Parse(Console.ReadLine());

								lugar = lLugares.Find((x => x.IdLugar == idLugar && x.Habilitado == true));
								if (lugar != null)
								{
									if (lugaresPN.Find(x => x.IdLugar == lugar.IdLugar) == null)
									{
										lugaresPN.Add(lugar);
									}
									else
									{
										Console.WriteLine("\nEste lugar ya se encuentra agregado al paquete. Ingrese otro por favor.\n");
										i--;
									}
								}
								else
								{
									Console.WriteLine("\nLugar no encontrado. Debe crearlo primero");
								}
							}
							int idPaquetePN = paqueteNac.IdPaquete;
							PaqueteNacional paqueteNacional = new PaqueteNacional(modoDePago, porcentajePorImpuestos, cantidadDiasPN, estadoPN, fechaViajePN, idPaquetePN, nombrePN, precioPN, cantidadCuotasPN, lugaresPN);
							lPaqNac.Remove(paqueteNac);
							lPaqNac.Add(paqueteNacional);

							Console.WriteLine("\nPaquete nacional editado correctamente");
						}
						else
						{
							Console.WriteLine("\nPaquete no encontrado. Debe crearlo primero");
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine("UPS, " + ex.Message);
					}
					Console.Write("\n");
					break;
				default:
					break;
			}
		}
		#endregion

		#region Gestion de Ventas
		private static void nuevaVenta()
		{
			try
			{
				Console.WriteLine("\n\nIngrese los datos de la nueva venta:");
				DateTime fechaFactura = DateTime.Now;
				int idFactura = Factura.contadorFacturas;
				Console.Write("Ingrese el DNI del viajante: ");
				dniCliente = Console.ReadLine();
				clienteParticular = lclientes.Find(x => x.Dni == dniCliente);
				clienteCorporativo = lCliCorporativos.Find(x => x.Dni == dniCliente);
				if (clienteParticular != null || clienteCorporativo != null)
				{
					int idCliente = 0;
					if (clienteParticular != null) idCliente = clienteParticular.IdCliente;
					else idCliente = clienteCorporativo.IdCliente;

					Console.Write("Cantidad de paquetes a vender: ");
					int cantidadPaquetes = int.Parse(Console.ReadLine());
					Console.Write("\n");
					List<LineaDeFactura> lineas = new List<LineaDeFactura>();
					Console.WriteLine("Paquetes nacionales disponibles:");
					foreach (Paquete p in lPaqNac)
					{
						if (p.Estado)
						{
							Console.WriteLine(p.IdPaquete + " - " + p.Nombre);
						}
					}
					Console.Write("\n");

					Console.WriteLine("Paquetes internacionales disponibles:");
					foreach (Paquete p in lPaqInter)
					{
						if (p.Estado)
						{
							Console.WriteLine(p.IdPaquete + " - " + p.Nombre);
						}
					}
					Console.Write("\n");

					for (int i = 1; i <= cantidadPaquetes; i++)
					{
						Console.Write($"Ingrese el ID del paquete {i} a agregar: ");
						int idPaquete = int.Parse(Console.ReadLine());

						paquete = lPaqInter.Find((x => x.IdPaquete == idPaquete));
						if (paquete == null)
						{
							paquete = lPaqNac.Find((x => x.IdPaquete == idPaquete));
						}

						if (paquete != null)
						{
							if (lineas.Find(x => x.IdPaquete == idPaquete) == null)
							{
								Console.Write("Ingrese la cantidad a vender de este paquete: ");
								int cantidad = int.Parse(Console.ReadLine());
								float unitario = paquete.ImporteTotal;
								int idLineaDeFactura = LineaDeFactura.contadorLineasFactura;
								LineaDeFactura lineaFactura = new LineaDeFactura(idFactura, idLineaDeFactura, cantidad, unitario, idPaquete);
								lineas.Add(lineaFactura);
								lLineaFacturas.Add(lineaFactura);
								Console.Write("\n");
							}
							else
							{
								Console.WriteLine("\nEste paquete ya se encuentra agregado a la venta. Ingrese otro por favor.\n");
								i--;
							}
						}
						else
						{
							Console.WriteLine("\nPaquete no encontrado. Ingrese un paquete disponible de la lista.\n");
							i--;
						}
					}
					Factura factura = new Factura(fechaFactura, idFactura, idCliente, lineas);
					lFacturas.Add(factura);

					Console.WriteLine("Venta creada con exito");
				}
				else
				{
					Console.WriteLine("\nCliente no encontrado. Debe crearlo primero");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("UPS, " + ex.Message);
			}
			Console.Write("\n");
		}
		#endregion

		private static void listaFacturaCliente()
        {
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
					}
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine($"============== FIN FACTURA==============");
					Console.ResetColor();
					Console.Write("\n");
				}
			}
			else
			{
				clienteCorporativo = lCliCorporativos.Find(x => x.Dni == dniCliente);
				if (clienteCorporativo != null)
				{
					Console.WriteLine(clienteCorporativo.ToString());
					Console.Write("\n");

					List<Factura> facturasCli = lFacturas.FindAll(x => x.IdCliente == clienteCorporativo.IdCliente);
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
						}
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine($"============== FIN FACTURA==============");
						Console.ResetColor();
						Console.Write("\n");
					}
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

			Console.Write("Ingrese el ID del paquete: ");
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
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write("¿Desea inactivar el paquete?");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("\ns/S: Sí");
					Console.WriteLine("n/N: No");
					Console.ForegroundColor = ConsoleColor.Gray;
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
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("El paquete ya se encuentra inactivado.\n¿Desea activar el paquete?");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine("\ns/S: Sí");
					Console.WriteLine("n/N: No");
					Console.ForegroundColor = ConsoleColor.Gray;
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

				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("\n¿Desea actualizar el precio del paquete?");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("\ns/S: Sí");
				Console.WriteLine("n/N: No");
				Console.ForegroundColor = ConsoleColor.Gray;
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
			Console.WriteLine("Clientes particulares:");
			foreach (Cliente cli in lclientes)
			{
				if (lFacturas.FindAll(x => x.IdCliente == cli.IdCliente).Count >= 2)
				{
					Console.WriteLine(" - " + cli.Nombre + " " + cli.Apellido);
				}
			}
			Console.Write("\n");

			Console.WriteLine("Clientes corporativos:");
			foreach (ClienteCorporativo cliCorp in lCliCorporativos)
			{
				if (lFacturas.FindAll(x => x.IdCliente == cliCorp.IdCliente).Count >= 2)
				{
					Console.WriteLine(" - " + cliCorp.RazonSocial);
				}
			}
			Console.Write("\n");
		}
	}
}
