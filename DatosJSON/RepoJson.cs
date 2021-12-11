using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Modelo;

namespace DatosJSON
{
    public class RepoJson
    {
        public static List<object> LeerYDeserializar(List<object> listaDestino, string archivo)
        {
            /**** INTENTAMOS LEER EL JSON DE CLIENTES DESDE UN ARCHIVO ****/
            StreamReader lectura_arch = null;
            try
            {
                lectura_arch = new StreamReader(archivo);
                listaDestino = JsonSerializer.Deserialize<List<object>>(lectura_arch.ReadToEnd());
                lectura_arch.Close();
            }
            /**** SI NO EXISTE EL ARCHIVO DE CLIETES CREAMOS LA LISTA VACÍA ****/
            catch
            {
                listaDestino = new List<object>();
            }
            return listaDestino;
        }

        public void SerializarYGuardar(List<object> listaFuente, string archivo)
        {
            /**** GUARDAMOS TODA LA LISTA DE CLIENTES EN UN JSON EN EL ARCHIVO CLIENTES.JSON ****/
            StreamWriter escritura = new StreamWriter(archivo);
            escritura.Write(JsonSerializer.Serialize(listaFuente));
            escritura.Close();
            /**** FIN GUARDADO DE CLIENTES ****/
        }
    }
}
