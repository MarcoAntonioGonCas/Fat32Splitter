using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace File_splitters.FileHelper
{
    public class FileMargeHelper
    {
        public static Regex regexArchivo666part = new Regex(@"\.666\d{2}$");
        public static Regex regexPuntoPart = new Regex(@"\.\d+$");

        // Obtiene las demas partes del archivo dividivo 
        public FileInfo[] ObtienePartesDivididas(FileInfo primeraParte, TipoParticionEnum tipoParticion)
        {
            if (tipoParticion == TipoParticionEnum.Ninguna)
            {
                throw new Exception("Ningun tipo de particion seleccionado");
            }

            DirectoryInfo directorioArchivo = primeraParte.Directory;
            string nombreSinExtension = Path.GetFileNameWithoutExtension(primeraParte.FullName);


            if (tipoParticion == TipoParticionEnum.Archivo666Part)
            {
                return directorioArchivo.GetFiles($"{nombreSinExtension}.666*");
            }


            if (tipoParticion == TipoParticionEnum.ArchivoPuntoPart)
            {
                return directorioArchivo.GetFiles($"{nombreSinExtension}.*");
            }


            return new FileInfo[0];

        }
        // Indica si un archivo tiene algun tipo de particion
        public TipoParticionEnum ObtieneTipoParticion(FileInfo archivo)
        {
            string nombreExtension = Path.GetFileName(archivo.FullName);


            if (regexArchivo666part.IsMatch(nombreExtension))
            {

                return TipoParticionEnum.Archivo666Part;
            }


            if (regexPuntoPart.IsMatch(nombreExtension))
            {
                return TipoParticionEnum.ArchivoPuntoPart;
            }


            return TipoParticionEnum.Ninguna;

        }
        // Obtiene el nombre quitanto el numero de parte del archivo
        public string ObtieneNombreSinExtensionParticionado(FileInfo primeraParte, TipoParticionEnum tipoParticion)
        {
            if (tipoParticion == TipoParticionEnum.Ninguna)
            {
                throw new Exception("Ningun tipo de particion seleccionado");
            }

            string nombreArchivo = primeraParte.FullName;


            if (tipoParticion == TipoParticionEnum.Archivo666Part)
            {
                nombreArchivo = regexArchivo666part.Replace(nombreArchivo, "");
            }


            if (tipoParticion == TipoParticionEnum.ArchivoPuntoPart)
            {
                nombreArchivo = regexPuntoPart.Replace(nombreArchivo, "");
            }


            return nombreArchivo;

        }

    }
}
