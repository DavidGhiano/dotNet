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
		static void Main(string[] args)
		{
			ConsoleKeyInfo opcion;
			string dniCliente;
			string nombrePaquete;
			Cliente cliente;
			Paquete paquete;
            #region CLIENTE
			List<Cliente> lclientes;
			RepoJSONCliente repoJsonCliente = new RepoJSONCliente("clientes.json");
			repoJsonCliente.LeerYDeserializar(out lclientes);
            #endregion
            #region CLIENTE CORPORATIVO
			List<ClienteCorporativo> lCliCorporativos;
			RepoJSONClienteCorporativo repoJsonCliCorporativo = new RepoJSONClienteCorporativo("clientesCorporativos.json");
			repoJsonCliCorporativo.LeerYDeserializar(out lCliCorporativos);
            #endregion
            #region FACTURA
			List<Factura> lFacturas;
			
			RepoJSONFactura repoJsonFactura = new RepoJSONFactura("facturas.json");
			repoJsonFactura.LeerYDeserializar(out lFacturas);
			#endregion
			#region LINEA DE FACTURA
			List<LineaDeFactura> lLineaFacturas;
			RepoJSONLineaDeFactura repoJsonLineaFactura = new RepoJSONLineaDeFactura("lineaFacturas.json");
			repoJsonLineaFactura.LeerYDeserializar(out lLineaFacturas);
			#endregion
			#region LUGAR
			List<Lugar> lLugares;
			RepoJSONLugar repoJsonLugar = new RepoJSONLugar("lugares.json");
			repoJsonLugar.LeerYDeserializar(out lLugares);
            #endregion
            #region PAQUETE
            List<Paquete> lPaquetes;
			RepoJSONPaquete repoJsonPaquete = new RepoJSONPaquete("paquetes.json");
			repoJsonPaquete.LeerYDeserializar(out lPaquetes);
			#endregion
			#region PAQUETE INTERNACIONAL
			List<PaqueteInternacional> lPaqInter;
			RepoJSONPaqueteInternacional repoJsonInter = new RepoJSONPaqueteInternacional("paqInter.json");
			repoJsonInter.LeerYDeserializar(out lPaqInter);
			#endregion
			#region PAQUETE NACIONAL
			List<PaqueteNacional> lPaqNac;
			RepoJSONPaqueteNacional repoJsonNac = new RepoJSONPaqueteNacional("paqNac.json");
			repoJsonNac.LeerYDeserializar(out lPaqNac);
            #endregion

            //lLugares = new List<Lugar>() { new Lugar(Lugar.contadorLugares,"Brasil"), new Lugar(Lugar.contadorLugares,"Argentina")};
            //lPaqInter = new List<PaqueteInternacional>() { new PaqueteInternacional(100, 1000, true, 10, true, DateTime.Parse("20-01-2021"), Paquete.contadorPaquetes, "Paquete Brasil", 6500, 3, 0, new List<Lugar>() { lLugares[0] })};
            //lPaqNac = new List<PaqueteNacional>() { new PaqueteNacional("Contado", 0.21f, 15, true, DateTime.Parse("20-01-2021"), Paquete.contadorPaquetes, "Paquete Argentina", 3500, 1,0, new List<Lugar>() { lLugares[1] }) };

           /* LineaDeFactura lf1 = new LineaDeFactura(Factura.contadorFacturas, LineaDeFactura.contadorLineasFactura, 1, 0, lPaqInter[0]);
            Factura f1 = new Factura(DateTime.Now, Factura.contadorFacturas, 0, null, new List<LineaDeFactura>() { lf1 });
            LineaDeFactura lf2 = new LineaDeFactura(Factura.contadorFacturas, LineaDeFactura.contadorLineasFactura, 1, 0, lPaqNac[0]);
            Factura f2 = new Factura(DateTime.Now, Factura.contadorFacturas, 0, null, new List<LineaDeFactura>() { lf2 });*/

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
            do
            {
				Console.WriteLine("1 - Nuevo cliente");
				Console.WriteLine("2 - Listar facturas de un cliente");
				Console.WriteLine("3 - Inactivar paquete");
				Console.WriteLine("4 - Actualizar precio de un paquete");
				Console.WriteLine("5 - Listar clientes que tengan al menos dos ventas");
				Console.WriteLine("ESC - Salir");
				Console.Write("Ingrese una opción: ");
				do
				{
					opcion = Console.ReadKey();
				} while (((int)opcion.KeyChar != 27) && (opcion.KeyChar < '1' || opcion.KeyChar > '5'));
				switch (opcion.KeyChar)
				{
					case '1':
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
									Console.WriteLine("\n\nIngrese los datos para el nuevo cliente particular:");
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
									lclientes.Add(cliCC);
								}
								catch (Exception ex)
								{
									Console.WriteLine("UPS" + ex.Message);
								}
								Console.WriteLine("\n");
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
						break;
					case '2':
						Console.Write("\n\nIngrese el DNI del cliente: ");
						dniCliente = Console.ReadLine();
						cliente = lclientes.Find(x => x.Dni == dniCliente);
						if (cliente != null)
						{
							Console.WriteLine(cliente.ToString());
							List<Factura> facturasCli = lFacturas.FindAll(x => x.Cliente.Dni == cliente.Dni);
							for(int i = 0; i<facturasCli.Count; i++)
							{
								facturasCli[i].ToString();
							}
							Console.WriteLine("\n");
						}
						else
						{
							Console.WriteLine("\nCliente no encontrado. Crear primero el cliente");
							Console.WriteLine("\n");
						}
						break;
					case '3':

						/*
						Console.Write("\n\nIngrese el nombre del paquete: ");
						nombrePaquete = Console.ReadLine();
						paquete = lPaquetes.Find(x => x.Nombre == nombrePaquete);

						if (paquete != null)
						{
							Console.WriteLine(paquete.ToString());

							Console.Write("\n\n¿Desea inactivar el paquete?");
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
								paquete.Estado = false;
								Console.WriteLine("Paquete inactivado existosamente.");
							}
                            else
                            {
								Console.WriteLine("Error al inactivar paquete.");
                            }
						}
						else
						{
							Console.WriteLine("\nPaquete no encontrado.");
							Console.WriteLine("\n");
						}
						*/



						//############## CODIGO PABLO ##############

						/*Console.Write("\n\nIngrese el número de cliente: ");
						int.TryParse(Console.ReadLine(), out nroCliente);
						cliente = clientes.Find(x => x.nroCliente == nroCliente);
						if (cliente != null)
						{
							cliente.mostrarDatos();
						}
						else
						{
							Console.WriteLine("\nCliente no encontrado.");
							Console.WriteLine("\n");
						}*/
						break;
					case '4':

						/*Console.Write("\n\nIngrese el nombre del paquete: ");
						nombrePaquete = Console.ReadLine();
						paquete = lPaquetes.Find(x => x.Nombre == nombrePaquete);

						if (paquete != null)
						{
							Console.WriteLine($"Precio del paquete seleccionado:{paquete.Precio.ToString()}");

							Console.Write("\n\nIngrese el nuevo precio: ");
							float nuevoPrecioPaquete = float.Parse(Console.ReadLine());

							Console.Write("\n\n¿Desea actualizar el precio del paquete?");
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
								Console.WriteLine("Precio actualizado existosamente.");
							}
                            else
                            {
								Console.WriteLine("Error al actualizar precio.");
                            }
														
						}
						else
						{
							Console.WriteLine("\nPaquete no encontrado.");
							Console.WriteLine("\n");
						}*/



						//############## CODIGO PABLO ##############

						/*Console.Write("\n\nIngrese el número de cliente: ");
						int.TryParse(Console.ReadLine(), out nroCliente);
						List<Pedido> pedidosCliente = pedidos.FindAll(p => p.cliente.nroCliente == nroCliente);
						pedidosCliente.ForEach(p => p.mostrarDatos());*/
						break;
					case '5':


						//############## CODIGO PABLO ##############
						/*Console.Write("\n\nIngrese el número de cliente: ");
						int.TryParse(Console.ReadLine(), out nroCliente);
						cliente = clientes.Find(x => x.nroCliente == nroCliente);
						if (cliente != null)
						{
							cliente.mostrarDatos();
							Console.Write("\nAtención, se eliminará el cliente ingresado. ¿Confirma esta acción? S/s (Si) N/n (No): ");
							ConsoleKeyInfo confirma;
							do
							{
								confirma = Console.ReadKey();
							} while ((confirma.KeyChar != 'S') && (confirma.KeyChar != 's') && (confirma.KeyChar != 'N') && (confirma.KeyChar != 'n'));
							if (confirma.KeyChar == 'S' || confirma.KeyChar == 's')
							{
								clientes.Remove(cliente);
								Console.Write("\nCliente eliminado exitosamente");
								Console.Write("\n");
							}
						}
						else
						{
							Console.WriteLine("\nCliente no encontrado.");
						}*/
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
	}
}
