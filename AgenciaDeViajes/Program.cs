using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace AgenciaDeViajes
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleKeyInfo opcion;
			int nroCliente;
			List<Cliente> clientes = new List<Cliente>();
			List<Paquete> paquetes = new List<Paquete>();
			Cliente cliente;
			Paquete paquete;
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
						Console.Write("Ingrese una opción: ");
						do
						{
							opcion = Console.ReadKey();
						} while ((opcion.KeyChar < '1' || opcion.KeyChar > '2'));
						switch (opcion.KeyChar)
						{
							case '1':
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
								clientes.Add(cliCC);
								try
								{
									//RepositorioCliente.agregar(cli);
								}
								catch (Exception ex)
								{
									Console.WriteLine("UPS" + ex.Message);
								}
								Console.WriteLine("\n");
								break;
							case '2':
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
								clientes.Add(cli);
								try
								{
									//RepositorioCliente.agregar(cli);
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
						/*Console.Write("\n\nIngrese el número de cliente: ");
						int.TryParse(Console.ReadLine(), out nroCliente);
						cliente = clientes.Find(x => x.nroCliente == nroCliente);
						if (cliente != null)
						{
							cliente.mostrarDatos();
							Console.Write("Ingrese el número de pedido: ");
							int nroPedido;
							int.TryParse(Console.ReadLine(), out nroPedido);
							Console.Write("Ingrese la descripción del pedido: ");
							string desc = Console.ReadLine();
							Pedido pedido = new Pedido(nroPedido, cliente, desc, DateTime.Now);
							pedidos.Add(pedido);
							Console.WriteLine("\n");
						}
						else
						{
							Console.WriteLine("\nCliente no encontrado. Crear primero el cliente");
							Console.WriteLine("\n");
						}*/
						break;
					case '3':
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
						/*Console.Write("\n\nIngrese el número de cliente: ");
						int.TryParse(Console.ReadLine(), out nroCliente);
						List<Pedido> pedidosCliente = pedidos.FindAll(p => p.cliente.nroCliente == nroCliente);
						pedidosCliente.ForEach(p => p.mostrarDatos());*/
						break;
					case '5':
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
		}
	}
}
