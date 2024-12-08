using File_splitters.FileHelper.Particion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_splitters.FileHelper.Marge
{
    public class FileMarge
    {
        public delegate void MargeSplit(object sender, ProgressMargeArgs e);
        public delegate void MargeSplitGeneric<T>(T sender, ProgressMargeArgs e);

        public event EventHandler<ProgressMargeArgs> Progreso;
        public event EventHandler<string> Error;

        private readonly IParticionStrategy _particion;

        public FileMarge(IParticionStrategy particion)
        {
            _particion = particion;
        }


        public void Marge(string nombreArchivoPrimeraParte, string directoryMarge)
        {
            // Creamos nuestro buffer para unir archivos
            byte[] buffer = new byte[FileConstants.bufferSize];

            // Obtenemos la informacion del archivo
            FileInfo informacionPrimeraParte = new FileInfo(nombreArchivoPrimeraParte);

            
            string[] partes = this._particion.ObtienePartesFaltantes(informacionPrimeraParte);

            long totalBytesPartes = partes.Sum(parte => new FileInfo(parte).Length);


            // Verificamos el archivoOriginal
            string soloNombreArchivoUnido = this._particion.RemueveEnumeracion(nombreArchivoPrimeraParte);
            string rutaCompletaArchivoUnido = Path.Combine(informacionPrimeraParte.Directory.FullName, soloNombreArchivoUnido);


            bool existeArchivoOriginal = File.Exists(rutaCompletaArchivoUnido) && new FileInfo(rutaCompletaArchivoUnido).Length == totalBytesPartes;
            if (existeArchivoOriginal)
            {
                // No seguimos ya que existe el archivo original
                Progreso?.Invoke(this, new ProgressMargeArgs()
                {
                    BytesActuales = totalBytesPartes,
                    TotalPartes = partes.Length,
                    ParteActual = partes.Length,
                    TotalBytes = totalBytesPartes,
                });
                return;
            }


            // Creamos el archivo unido
            using (FileStream fs = new FileStream(rutaCompletaArchivoUnido, FileMode.CreateNew, FileAccess.Write))
            {
                long bytesEscritos = 0;

                
                for (int i = 0; i < partes.Length; i++)
                {
                    string rutaParteActual = partes[i];

                    using (FileStream fsParte = new FileStream(rutaParteActual, FileMode.Open, FileAccess.Read))
                    {
                        int readBytes = 0;
                        while((readBytes = fs.Read(buffer, 0, buffer.Length)) > 0)
                        {

                            fs.Write(buffer, 0, readBytes);

                            bytesEscritos += readBytes;


                            this.Progreso?.Invoke(
                                this,
                                new ProgressMargeArgs()
                                {
                                    BytesActuales = bytesEscritos,
                                    TotalBytes = totalBytesPartes,
                                    ParteActual = i+1,
                                    TotalPartes = partes.Length
                                }
                            );

                        }
                    }

                }



            }



        }


    }
}
