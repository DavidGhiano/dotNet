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
    public class RepoJSONFactura
    {
        private string archivo;
        public RepoJSONFactura(string nombrearchivo)
        {
            archivo = nombrearchivo;
        }

        public void LeerYDeserializar(out List<Factura> listaDestino)
        {
            try
            {
                StreamReader lectura_arch = new StreamReader(archivo);
                listaDestino = JsonSerializer.Deserialize<List<Factura>>(lectura_arch.ReadToEnd());
                lectura_arch.Close();
            }
            /**** SI NO EXISTE EL ARCHIVO DE CLIETES CREAMOS LA LISTA VACÍA ****/
            catch
            {
                listaDestino = new List<Factura>();
            }
        }

        public void SerializarYGuardar(List<Factura> listaFuente)
        {
            StreamWriter escritura = new StreamWriter(archivo);
            escritura.Write(JsonSerializer.Serialize(listaFuente));
            escritura.Close();

        }
    }
}
