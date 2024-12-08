using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace File_splitters.FileHelper.Particion
{
    public class Archivo666PartStrategy : IParticionStrategy
    {
        public int parteInicio = 66600;
        public Regex patron = new Regex(@"\.666\d{2}$");
        public string[] ObtienePartesFaltantes(FileInfo archivoParticionado)
        {

            // Obtenemos el directorio del archivo de la primera parte
            DirectoryInfo directorio = archivoParticionado.Directory; 
            
            // Obtiene el nombre del archivo sin la extension
            string nombreSinExtension = Path.GetFileName( this.RemueveEnumeracion(archivoParticionado.FullName));


            // Obtenemos todos los archivos que coincidan con el patron
            FileInfo[] archivos = directorio.GetFiles($"{nombreSinExtension}.666*");

            // Ordenamos lo archivos por numero
            archivos = archivos.OrderBy(archivo => archivo.LastWriteTime).ToArray();

            return archivos.Select(archivo => archivo.FullName).ToArray();
        }

        public string[] BuscarArchivosEnCarpeta(DirectoryInfo carpeta, bool recursive = false)
        {
            string patron = $"*.{this.parteInicio}";


            // Obtenemos todos los archivos que coincidan con el patron
            FileInfo[] archivos = carpeta.GetFiles(patron, recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);



            return archivos.Select(archivo => archivo.FullName).ToArray();
        }

        public string[] ObtieneNombresConEnumeracion(FileInfo archivo, int numPartes)
        {
            // Obtenemos los nombres de los archivos a particionar
            int inicio = this.parteInicio;

            // Obtenemos solo el nombre del archivo
            string nombreArchivo = Path.GetFileName(archivo.FullName); 

            // Listo a donde pondremos los nombres de las particiones
            List<string> nombreExtensiones = new List<string>();


            // Creamos un indice de particiones
            for (int i = 0; i < numPartes; i++)
            {
                // Creamos el nuevo nombre de archivo junto con el numero de parte
                nombreExtensiones.Add($"{nombreArchivo}.{inicio + i}");
            }

            // Modificamos la lista agregandole la ruta completa
            // La ruta del directorio + el archivo y numero de parte
            return nombreExtensiones.Select( nombre=>
            {
                return Path.Combine(
                    Path.GetDirectoryName(archivo.FullName),
                    nombre
                );
            }).ToArray();

        }

        public Regex ObtienePatronBusqueda()
        {
            return patron;
        }

        public string RemueveEnumeracion(string nombreArchivo)
        {
            return patron.Replace(nombreArchivo, "");
        }
    }
}
