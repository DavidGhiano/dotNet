using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Modelo;


namespace DatosJSON
{
    public class RepoJSON
    {
        private string archivo; //ruta y nombre
        public RepoJSON(string nombrearchivo)
        {
            archivo = nombrearchivo;
        }

        public void LeerYDeserializar(out List<object> listaDestino)
        {
            /**** INTENTAMOS LEER EL JSON DE CLIENTES DESDE UN ARCHIVO ****/
            StreamReader lectura_arch = null;
            try
            {
                lectura_arch = new StreamReader(archivo);
                listaDestino = JsonSerializer.Deserialize<List<object>>(lectura_arch.ReadToEnd());
                //listaDestino = JsonSerializer.Deserialize<List<Cliente>>(lectura_arch_clientes.ReadToEnd());
                lectura_arch.Close();
            }
            /**** SI NO EXISTE EL ARCHIVO DE CLIETES CREAMOS LA LISTA VACÍA ****/
            catch
            {
                listaDestino = new List<object>();
            }
        }

        public void SerializarYGuardar(List<object> listaFuente)
        {
            /**** GUARDAMOS TODA LA LISTA DE CLIENTES EN UN JSON EN EL ARCHIVO CLIENTES.JSON ****/
            StreamWriter escritura = new StreamWriter(archivo);
            escritura.Write(JsonSerializer.Serialize(listaFuente));
            escritura.Close();
            /**** FIN GUARDADO DE CLIENTES ****/
        }
    }
}
