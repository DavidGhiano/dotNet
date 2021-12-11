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
    public class RepoJSONLineaDeFactura
    {
        private string archivo;
        public RepoJSONLineaDeFactura(string nombrearchivo)
        {
            archivo = nombrearchivo;
        }

        public void LeerYDeserializar(out List<LineaDeFactura> listaDestino)
        {
            try
            {
                StreamReader lectura_arch = new StreamReader(archivo);
                listaDestino = JsonSerializer.Deserialize<List<LineaDeFactura>>(lectura_arch.ReadToEnd());
                lectura_arch.Close();
            }
            /**** SI NO EXISTE EL ARCHIVO DE CLIETES CREAMOS LA LISTA VACÍA ****/
            catch
            {
                listaDestino = new List<LineaDeFactura>();
            }
        }

        public void SerializarYGuardar(List<LineaDeFactura> listaFuente)
        {
            StreamWriter escritura = new StreamWriter(archivo);
            escritura.Write(JsonSerializer.Serialize(listaFuente));
            escritura.Close();
        }
    }
}
