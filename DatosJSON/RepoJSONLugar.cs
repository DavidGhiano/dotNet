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
    public class RepoJSONLugar
    {
        private string archivo;
        public RepoJSONLugar(string nombrearchivo)
        {
            archivo = nombrearchivo;
        }

        public void LeerYDeserializar(out List<Lugar> listaDestino)
        {
            try
            {
                StreamReader lectura_arch = new StreamReader(archivo);
                listaDestino = JsonSerializer.Deserialize<List<Lugar>>(lectura_arch.ReadToEnd());
                lectura_arch.Close();
            }
            /**** SI NO EXISTE EL ARCHIVO DE CLIETES CREAMOS LA LISTA VACÍA ****/
            catch
            {
                listaDestino = new List<Lugar>();
            }
        }

        public void SerializarYGuardar(List<Lugar> listaFuente)
        {
            StreamWriter escritura = new StreamWriter(archivo);
            escritura.Write(JsonSerializer.Serialize(listaFuente));
            escritura.Close();
        }
    }
}
