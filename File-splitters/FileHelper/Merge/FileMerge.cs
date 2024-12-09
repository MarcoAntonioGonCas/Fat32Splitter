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
    public class FileMerge
    {
        public delegate void MargeSplit(object sender, ProgressMergeArgs e);
        public delegate void MargeSplitGeneric<T>(T sender, ProgressMergeArgs e);

        public event EventHandler<ProgressMergeArgs> Progreso;
        public event EventHandler<string> Error;

        public bool EliminarPartesAlFinalizar { get; set; } = false;

        private readonly IParticionStrategy _particion;

        public FileMerge(IParticionStrategy particion)
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
            long totalBytesPartes = CalcularBytesDePartes(nombreArchivoPrimeraParte);



            // Verificamos el archivoOriginal
            string soloNombreArchivoUnido = this._particion.RemueveEnumeracion(nombreArchivoPrimeraParte);
            string rutaCompletaArchivoUnido = Path.Combine(informacionPrimeraParte.Directory.FullName, soloNombreArchivoUnido);

            bool existeArchivoOriginal = ExisteArchivoOriginalYCompleto(nombreArchivoPrimeraParte);

            if (existeArchivoOriginal)
            {
                // No seguimos ya que existe el archivo original
                Progreso?.Invoke(this, new ProgressMergeArgs()
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

                try
                {
                    for (int i = 0; i < partes.Length; i++)
                    {
                        string rutaParteActual = partes[i];

                        using (FileStream fsParte = new FileStream(rutaParteActual, FileMode.Open, FileAccess.Read))
                        {
                            int readBytes = 0;
                            int countBytesParte = 0;

                            while (countBytesParte < fsParte.Length)
                            {
                                readBytes = await fsParte.ReadAsync(buffer, 0, buffer.Length, cancellationToken);


                                if (readBytes == 0)
                                {
                                    break;
                                }

                                await fsDestinoMezcla.WriteAsync(buffer, 0, readBytes, cancellationToken);
                                bytesEscritos += readBytes;
                                countBytesParte += readBytes;


                                this.Progreso?.Invoke(
                                    this,
                                    new ProgressMergeArgs()
                                    {
                                        BytesActuales = bytesEscritos,
                                        TotalBytes = totalBytesPartes,
                                        ParteActual = i + 1,
                                        TotalPartes = partes.Length
                                    }
                                );

                                if (cancellationToken.IsCancellationRequested)
                                {
                                   throw new TaskCanceledException("Proceso cancelado por el usuario.");
                                }

                            }
                        }

                        if (this.EliminarPartesAlFinalizar)
                        {
                            this.EliminarPartesDeArchivoMezclado(nombreArchivoPrimeraParte);
                        }

                    }
                }
                catch (TaskCanceledException)
                {
                    if (File.Exists(rutaCompletaArchivoUnido))
                    {
                        fsDestinoMezcla.Close();
                        File.Delete(rutaCompletaArchivoUnido);
                    }

                    this.Error?.Invoke(this, "Proceso cancelado, el archivo que estaba en proceso de union fue eliminado");
                }
                catch (Exception ex)
                {
                    this.Error?.Invoke(this, ex.Message);

                }


            }
        }


        public long CalcularBytesDePartes(string nombreArchivoPrimeraParte)
        {
            FileInfo informacionPrimeraParte = new FileInfo(nombreArchivoPrimeraParte);
            string[] partes = this._particion.ObtienePartesFaltantes(informacionPrimeraParte);
            return partes.Sum(parte => new FileInfo(parte).Length);
        }


        public bool EliminarArchivoOriginal(string nombreArchivoPrimeraParte)
        {
            string archivoOriginal = this._particion.RemueveEnumeracion(nombreArchivoPrimeraParte);
            if (File.Exists(archivoOriginal))
            {
                File.Delete(archivoOriginal);
                return true;
            }
            return false;
        }

        public bool EliminarPartesDeArchivoMezclado(string nombreArchivoPrimeraParte)
        {
            FileInfo informacionPrimeraParte = new FileInfo(nombreArchivoPrimeraParte);
            string[] partes = this._particion.ObtienePartesFaltantes(informacionPrimeraParte);
            int count = 0;
            foreach (string parte in partes)
            {
                if(File.Exists(parte))
                {
                    File.Delete(parte);
                    count++;
                }
            }
            return count == partes.Length;
        }

        public bool ExisteArchivoOriginal(string nombreArchivoPrimeraParte)
        {
            string archivoOriginal = this._particion.RemueveEnumeracion(nombreArchivoPrimeraParte);
            return File.Exists(archivoOriginal);
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
