using File_splitters.FileHelper.Particion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace File_splitters.FileHelper
{
    public enum TipoParticionEnum
    {
        // marco.
        Archivo666Part,
        ArchivoPuntoPart,
        Ninguna
    }
    public class FileSplitHelper
    {      
        private readonly IParticionStrategy _particionStrategy;

        public FileSplitHelper(IParticionStrategy particionStrategy)
        {
            _particionStrategy = particionStrategy;
        }

        // Crea los archivos agregandoles el tipo de particion y el numero de parte segun el tipo de particion
        public static string[] ObtieneNombresParticionado(FileInfo archivo, TipoParticionEnum tipoParticion, int numPartes)
        {
            if (tipoParticion == TipoParticionEnum.Ninguna)
            {
                throw new Exception("Ningun tipo de particion seleccionado");
            }

            string nombreArchivo = Path.GetFileName(archivo.FullName);

            List<string> nombreExtensiones = new List<string>();
            int inicio666 = 66600;
            

            // Agrega el nombre del archivo con el numero de parte
            for (int i = 0; i < numPartes; i++)
            {

                if (tipoParticion == TipoParticionEnum.Archivo666Part)
                {
                    nombreExtensiones.Add($"{nombreArchivo}.${inicio666 + i}");

                }else if (tipoParticion == TipoParticionEnum.ArchivoPuntoPart)
                {
                    nombreExtensiones.Add($"{nombreArchivo}.{(i).ToString().PadLeft(2,'0')}");

                }
            }


            return nombreExtensiones.ToArray();
        }
    }
}
