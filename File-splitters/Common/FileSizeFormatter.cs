using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_splitters.Common
{
    public static class FileSizeFormatter
    {
        public static string FormatSize(long bytes)
        {
            int unit = 1024;


            double bytesD = bytes;
            string[] sufix = { "B", "KB", "MB", "GB", "TB", "PB" };
            int i = 0;


            // Comprobamos si los bytes son mayores que el tamaño de la unidad
            // y si no hemos llegado al final del array de sufijos

            while (bytesD >= unit && i < sufix.Length-1)
            {
                bytesD /= unit;
                i++;
            }

            return string.Format("{0:0.##} {1}", bytesD, sufix[i]);

        }
    }
}
