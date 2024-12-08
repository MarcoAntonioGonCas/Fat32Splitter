using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_splitters.FileHelper
{
    public class FileSearchHelper
    {
        public const long maxBytesFile = 4294967296;
        public static FileInfo[] BuscarArchivosPesados(string directorio, bool recursivo = false)
        {
            return Directory.EnumerateFiles(directorio, "*.*", recursivo ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                .Where(nombreArchivo => new FileInfo(nombreArchivo).Length >= maxBytesFile)
                .Select(archivosGrandes => new FileInfo(archivosGrandes)).ToArray(); 

        }



    }
}
