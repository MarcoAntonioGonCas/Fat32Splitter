using File_splitters.FileHelper.Particion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace File_splitters.FileHelper.Marge
{
    public class FileMarge
    {
        public delegate void MargeSplit(object sender, ProgressMargeArgs e);
        public delegate void MargeSplitGeneric<T>(T sender, ProgressMargeArgs e);

        public event EventHandler<ProgressMargeArgs> Progreso;
        public event EventHandler<string> Error;

        public bool EliminarPartes { get; set; } = false;

        private readonly IParticionStrategy _particion;

        public FileMarge(IParticionStrategy particion)
        {
            _particion = particion;
        }


        public async Task Marge(string nombreArchivoPrimeraParte,CancellationToken cancellationToken )
        {
            // Creamos nuestro buffer para unir archivos
            byte[] buffer = new byte[FileConstants.bufferSize];

            // Obtenemos la informacion del archivo
            FileInfo informacionPrimeraParte = new FileInfo(nombreArchivoPrimeraParte);


            string[] partes = this._particion.ObtienePartesFaltantes(informacionPrimeraParte);
            long totalBytesPartes = ObtieneTotalBytes(nombreArchivoPrimeraParte);



            // Verificamos el archivoOriginal
            string soloNombreArchivoUnido = this._particion.RemueveEnumeracion(nombreArchivoPrimeraParte);
            string rutaCompletaArchivoUnido = Path.Combine(informacionPrimeraParte.Directory.FullName, soloNombreArchivoUnido);
            bool cancelado = false;

            bool existeArchivoOriginal = ExisteArchivoOriginalYCompleto(nombreArchivoPrimeraParte);

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
                
            }


            // Creamos el archivo unido
            using (FileStream fsDestinoMezcla = new FileStream(rutaCompletaArchivoUnido, FileMode.CreateNew, FileAccess.Write))
            {
                long bytesEscritos = 0;


                for (int i = 0; i < partes.Length; i++)
                {
                    string rutaParteActual = partes[i];

                    using (FileStream fsParte = new FileStream(rutaParteActual, FileMode.Open, FileAccess.Read))
                    {
                        int readBytes = 0;
                        int countBytesParte = 0;

                        while (countBytesParte < fsParte.Length)
                        {
                            readBytes = await fsParte.ReadAsync(buffer, 0, buffer.Length);


                            if(readBytes == 0)
                            {
                                break;
                            }

                            await fsDestinoMezcla.WriteAsync(buffer, 0, readBytes);





                            bytesEscritos += readBytes;
                            countBytesParte += readBytes;


                            this.Progreso?.Invoke(
                                this,
                                new ProgressMargeArgs()
                                {
                                    BytesActuales = bytesEscritos,
                                    TotalBytes = totalBytesPartes,
                                    ParteActual = i + 1,
                                    TotalPartes = partes.Length
                                }
                            );


                            if (cancellationToken.IsCancellationRequested)
                            {
                                cancelado = true;
                                break;
                            }

                        }

                        if (cancelado)
                        {
                            break;
                        }
                    }

                }



            }

            if (cancelado)
            {
                this.Error?.Invoke(this, "Proceso cancelado");
            }


        }


        public long ObtieneTotalBytes(string nombreArchivoPrimeraParte)
        {
            FileInfo informacionPrimeraParte = new FileInfo(nombreArchivoPrimeraParte);
            string[] partes = this._particion.ObtienePartesFaltantes(informacionPrimeraParte);
            return partes.Sum(parte => new FileInfo(parte).Length);
        }


        public bool ExisteArchivoOriginalYCompleto(string nombreArchivoPrimeraParte)
        {
            string archivoOriginal = this._particion.RemueveEnumeracion(nombreArchivoPrimeraParte);

            if(!File.Exists(archivoOriginal))
            {
                return false;
            }


            FileInfo informacionPrimeraParte = new FileInfo(nombreArchivoPrimeraParte);
            string[] partes = this._particion.ObtienePartesFaltantes(informacionPrimeraParte);

            return partes.Sum(parte => new FileInfo(parte).Length) == new FileInfo(archivoOriginal).Length;

        }
    }
}
