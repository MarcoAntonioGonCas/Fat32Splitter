using File_splitters.FileHelper.Particion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace File_splitters.FileHelper.Split
{
    public class FileSplit
    {
        public event EventHandler<ProgressSplitArgs> ProgressSplit;
        public event EventHandler<FileSplitErrorArgs> FileSplitError;

        List<string> historialSplit = new List<string>();

        // Indica si se debe borrar el archivo original
        public bool BorrarOriginal { get; set; } = false;

        private readonly IParticionStrategy particionStrategy;

        public FileSplit(IParticionStrategy particionStrategy)
        {
            this.particionStrategy = particionStrategy;
        }

        private void EliminarOriginal(string ruta)
        {
            if (BorrarOriginal)
            {
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
            }
        }

        private void EliminarHistorial()
        {
            try
            {
                foreach (var item in this.historialSplit)
                {
                    if (File.Exists(item)){
                        File.Delete(item);
                    }
                }

            }
            catch(Exception ex)
            {
                throw new Exception("Error al eliminar el historial", ex);
            }
        }

        private void AgregarHistorial(string[] nombrePartes)
        {
            this.historialSplit.AddRange(nombrePartes);
        }

        public bool HaSidoParticionadoPreviamente(string archivo)
        {
            FileInfo info = new FileInfo(archivo);
            string[] archivosParticionados = this.particionStrategy.ObtienePartesFaltantes(info);
            return archivosParticionados.Length > 0;
        
        }


        public bool EsParticionadoPreviamenteCoorecto(string archivo)
        {
            FileInfo info = new FileInfo(archivo);
            string[] archivosParticionados = this.particionStrategy.ObtienePartesFaltantes(info);

            long sumaTamanios = archivosParticionados.Sum(parteActual =>
            {
                if (File.Exists(parteActual))
                {
                    return new FileInfo(parteActual).Length;
                }
                else {

                    return 0;
                }
            });


            return sumaTamanios == info.Length;
        }

        public bool EliminarParticionesPreviamente(string archivo)
        {
            FileInfo info = new FileInfo(archivo);
            string[] archivosParticionados = this.particionStrategy.ObtienePartesFaltantes(info);
            foreach (var item in archivosParticionados)
            {
                if (File.Exists(item))
                {
                    File.Delete(item);
                }
            }
            return true;
        }



        public async Task<bool> FilleSplit(string archivo, CancellationToken cancellationToken)
        {

            try
            {
                FileInfo info = new FileInfo(archivo);
                bool procesoCancelado = false;
                long lenArchivo = info.Length;
                // Obtenemos informacion del archivo
                this.historialSplit = new List<string>();

                // Si el archivo es menor o igual al tamanio maximo de fat32
                // no es necesario particionar
                if (lenArchivo <= FileConstants.tamanioMaxFat32)
                {
                    return false;
                }


                // Numero total de particiones 
                int numParticiones = (int)Math.Ceiling((double)lenArchivo / FileConstants.tamanioArchivoSplit);
                string[] nombrePartes = this.particionStrategy.ObtieneNombresConEnumeracion(info, numParticiones);
                byte[] buffer = new byte[FileConstants.bufferSize];
                long bytesContador = 0;



                AgregarHistorial(nombrePartes);

                // Abrimos el archivo original
                using (FileStream archivosFuente = new FileStream(archivo, FileMode.Open))
                {
                    // Recorremos los numeros de particiones
                    for (int i = 0; i < nombrePartes.Length; i++)
                    {
                        string parteActual = nombrePartes[i];
                        long offsetBytes = 0;
                        long bytesLeidos = 0;
                        
                        // Mientras leamos bytes
                        while (
                            //(bytesLeidos = await archivosFuente.ReadAsync(buffer,0,buffer.Length)) > 0  &&
                            (offsetBytes < FileConstants.tamanioArchivoSplit))
                        {
                            if(cancellationToken.IsCancellationRequested)
                            {
                                procesoCancelado = true;
                                break;
                            }

                            bytesLeidos = await archivosFuente.ReadAsync(buffer, 0, buffer.Length);

                            // Si no hay más bytes que leer, salimos
                            if (bytesLeidos == 0)
                            {
                                break;
                            }

                            // Actualizamos el contador de bytes
                            bytesContador += bytesLeidos;
                            

                            // En cada iteracion abrimos el archivo parte
                            using (FileStream fsDestinoParte = new FileStream(parteActual, FileMode.OpenOrCreate))
                            {
                                // Nos posicionamos en el archivo
                                // En la parte actual
                                fsDestinoParte.Position = offsetBytes;

                                // Actualizamos el offset de bytes de la parte actual
                                offsetBytes += bytesLeidos;


                                this.ProgressSplit?.Invoke(this, new ProgressSplitArgs()
                                {
                                    BytesActuales = bytesContador,
                                    TotalBytes = lenArchivo,
                                    TotalPartes = numParticiones,
                                    ParteActual = i + 1
                                });
                                if (bytesLeidos == 0)
                                {
                                    break;
                                }
                                await fsDestinoParte.WriteAsync(buffer, 0, (int)bytesLeidos);

                            }


                        }

                        if (procesoCancelado)
                        {
                            break;
                        }
                    }



                }

                if (this.BorrarOriginal)
                {
                    EliminarOriginal(archivo);
                }

                if(procesoCancelado)
                {
                    this.FileSplitError?.Invoke(this, new FileSplitErrorArgs()
                    {
                        MensajeError = "Proceso cancelado",
                    });
                    EliminarHistorial();
                    return false;
                }


                return true;

            }
            catch (Exception ex)
            {
                EliminarHistorial();
                this.FileSplitError?.Invoke(this, new FileSplitErrorArgs()
                {
                    MensajeError = ex.Message,
                });
                throw new Exception("Error al splitear el archivo", ex);
            }
        }
    }
}
