using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace File_splitters.FileHelper.Particion
{
    public interface IParticionStrategy
    {
        string[] ObtieneNombresConEnumeracion(FileInfo archivo, int numPartes);
        Regex ObtienePatronBusqueda();
        string[] BuscarArchivosEnCarpeta(DirectoryInfo carpeta, bool recursive = false);
        string[] ObtienePartesFaltantes(FileInfo archivoPrimeraParte);
        string RemueveEnumeracion(string nombreArchivo);
    }
}
