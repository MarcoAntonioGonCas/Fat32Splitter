using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_splitters.FileHelper
{
    public class FileConstants
    {
        // Tamaño maximo de un archivo en una particio FAT32 
        public const long tamanioMaxFat32 = 4294967296; // 4GB
        
        public const long tamanioArchivoSplit = 4278190080; // 4GB - 16MB = 4278190080
        //4,290,270,168
        // Tamaño del buffer
        // Importante bufferSize debe ser multiplo de tamanioArchivoSplit
        public const long bufferSize = 16777216; // 16MB

    }
}
