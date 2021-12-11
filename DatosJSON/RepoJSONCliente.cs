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
    public class RepoJSONCliente
    {
        private string archivo;
        public RepoJSONCliente(string nombrearchivo)
        {
            archivo = nombrearchivo;
        }

        public void LeerYDeserializar(out List<Cliente> listaDestino)
        {
            StreamReader lectura_arch = null;
            try
            {
                lectura_arch = new StreamReader(archivo);
                listaDestino = JsonSerializer.Deserialize<List<Cliente>>(lectura_arch.ReadToEnd());
                lectura_arch.Close();
            }
            /**** SI NO EXISTE EL ARCHIVO DE CLIETES CREAMOS LA LISTA VACÍA ****/
            catch
            {
                if(lectura_arch != null) lectura_arch.Close();
                listaDestino = new List<Cliente>();
            }
        }

        public void SerializarYGuardar(List<Cliente> listaFuente)
        {
            StreamWriter escritura = null;
            try
            {
                escritura = new StreamWriter(archivo);
                escritura.Write(JsonSerializer.Serialize(listaFuente));
                escritura.Close();
            }
            catch
            {
                if (escritura != null) escritura.Close();
            }

        }
    }
}
