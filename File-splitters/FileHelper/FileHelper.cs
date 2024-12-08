using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_splitters.FileHelper
{
    public class FileHelper
    {


        // Suma los longitudes de archivos
        public static long SumaLongitudes(FileInfo[] archivos)
        {
            if(archivos == null)
            {
                throw new NullReferenceException(nameof(archivos));
            }


            return archivos.Sum(archivo => archivo.Length);
        }

        // Duvuelve solo el nombre del archivo
        public static string DevuelveSoloNombre(string path)
        {
            return Path.GetFileName(path);
        }


        
    }
}
