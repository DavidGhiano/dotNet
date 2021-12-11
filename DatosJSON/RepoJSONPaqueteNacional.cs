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
    public class RepoJSONPaqueteNacional
    {
        private string archivo;
        public RepoJSONPaqueteNacional(string nombrearchivo)
        {
            archivo = nombrearchivo;
        }

        public void LeerYDeserializar(out List<PaqueteNacional> listaDestino)
        {
            try
            {
                StreamReader lectura_arch = new StreamReader(archivo);
                listaDestino = JsonSerializer.Deserialize<List<PaqueteNacional>>(lectura_arch.ReadToEnd());
                lectura_arch.Close();
            }
            /**** SI NO EXISTE EL ARCHIVO DE CLIETES CREAMOS LA LISTA VACÍA ****/
            catch
            {
                listaDestino = new List<PaqueteNacional>();
            }
        }

        public void SerializarYGuardar(List<PaqueteNacional> listaFuente)
        {
            StreamWriter escritura = new StreamWriter(archivo);
            escritura.Write(JsonSerializer.Serialize(listaFuente));
            escritura.Close();
        }
    }
}
