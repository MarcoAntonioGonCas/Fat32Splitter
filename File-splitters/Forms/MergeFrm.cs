using File_splitters.Common;
using File_splitters.FileHelper.Marge;
using File_splitters.FileHelper.Particion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_splitters.Forms
{
    public partial class MergeFrm : Form
    {
        private FileMerge _fileMarge;
        private CancellationTokenSource _cancelationTokenSource;
        private IParticionStrategy _particionStrategy;
        private string _rutaArchivoParticion;


        public MergeFrm()
        {
            InitializeComponent();
            cmbTipoParticion.DataSource = Enum.GetValues(typeof(TipoParticionCombobox));
        }
        


        private void btnBuscarArchivosParticionados_Click(object sender, EventArgs e)
        {
            if(_fileMarge == null)
            {
                MessageBox.Show("Seleccione un tipo de particion");
                return;
            }

            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.RootFolder = Environment.SpecialFolder.MyComputer;

            if (folder.ShowDialog() == DialogResult.OK)
            {
                BuscarArchivosParticionados(folder.SelectedPath);
            }

        }

        private void cmbTipoParticion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoParticion.SelectedItem == null || cmbTipoParticion.SelectedIndex < 0)
            {
                return;
            }


            TipoParticionCombobox tipoParticionSeleccionada = (TipoParticionCombobox)cmbTipoParticion.SelectedItem;

            IniciarFileMarge(tipoParticionSeleccionada);
        }

        #region Metodos asociados a MessageBox


        private bool PreguntarBuscarRecursivo()
        {
            DialogResult dialogResult = MessageBox.Show(
                "¿Desea buscar de forma recursiva?",
                "Buscar recursivo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            return dialogResult == DialogResult.Yes;
        }

        private bool ConfirmarEliminarPartes()
        {

            DialogResult dialogResult = MessageBox.Show(
                "El archivo original ya esta mezclado correctamente, ¿Desea eliminar las partes?",
                "Eliminar archivos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            return dialogResult == DialogResult.Yes;
        }

        private bool PreguntarEliminarOriginal()
        {
            DialogResult dialogResult = MessageBox.Show(
                "¿Desea eliminar el archivo original, debido a que no esta mezclado correctamente?",
                "Eliminar archivo original",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            return dialogResult == DialogResult.Yes;
        }


        public bool ExisteArchivoOriginal(string nombreArchivoPrimeraParte)
        {
            return _fileMarge.ExisteArchivoOriginalYCompleto(nombreArchivoPrimeraParte);
        }
        public bool ExisteArchivoOriginalYCompleto(string nombreArchivoPrimeraParte)
        {
            return _fileMarge.ExisteArchivoOriginalYCompleto(nombreArchivoPrimeraParte);
        }

        #endregion

        #region Metodos para mezclar los archivos

        private void IniciarFileMarge(TipoParticionCombobox tipoParticionSeleccionada)
        {
            IParticionStrategy particionStrategy;
            if (
                tipoParticionSeleccionada == TipoParticionCombobox.Archivo666
                )
            {
                particionStrategy = new Archivo666PartStrategy();
            }
            else
            {
                return;
            }

            if (_fileMarge != null)
            {
                _fileMarge.Progreso -= _fileMarge_Progreso;
                _fileMarge.Error -= _fileMarge_Error;
            }

            _fileMarge = new FileMerge(
                particionStrategy
                );
            _fileMarge.Progreso += _fileMarge_Progreso;
            _fileMarge.Error += _fileMarge_Error;

            this._particionStrategy = particionStrategy;
        }
        private void BuscarArchivosParticionados(string selectedPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(selectedPath);
            string[] archivosParticionados = _particionStrategy.BuscarArchivosEnCarpeta(
                directoryInfo,
                    PreguntarBuscarRecursivo()
                );


            if (archivosParticionados.Length == 0)
            {
                MessageBox.Show("No se encontraron archivos particionados");
                return;
            }

            lsvArchivosParticionados.Items.Clear();

            foreach(string archivo in archivosParticionados)
            {
                lsvArchivosParticionados.Items.Add(archivo);    
            }


        }

        private bool ExisteArchivoParaMezclar(string rutaArchivo)
        {
            if (rutaArchivo == null)
            {
                return false
            }

            if (!File.Exists(rutaArchivo))
            {
                return false;
            }

            return true;
        }
        private void SeleccionarArchivoParticionado(string rutaArchivo)
        {

            

            FileInfo fileInfo = new FileInfo(rutaArchivo);
            string nombreSinParte =  _particionStrategy.RemueveEnumeracion(rutaArchivo);
            long sumabytes = _fileMarge.CalcularBytesDePartes(rutaArchivo);
        
            _rutaArchivoParticion = rutaArchivo;
            lblArchivo.Text = $"{fileInfo.Name} - {FileSizeFormatter.FormatSize(sumabytes)}";
            

            

            IniciarMezcla();
        }

        private bool ContinuarMezclaDeArchivo(string rutaArchivoParticion)
        {
            // Verificamos si existe el archivo original
            if (this.ExisteArchivoOriginal(_rutaArchivoParticion))
            {

                // Si existe el archivo original, preguntamos si desea eliminar las partes
                if (ExisteArchivoOriginalYCompleto(_rutaArchivoParticion))
                {
                    if (ConfirmarEliminarPartes())
                    {
                        _fileMarge.EliminarPartesDeArchivoMezclado(_rutaArchivoParticion);
                    }
                    return false;
                }
                // Si no esta completo, preguntamos si desea eliminar el archivo original para volver a mezclar
                else
                {
                    if (PreguntarEliminarOriginal())
                    {
                       this._fileMarge.EliminarArchivoOriginal(_rutaArchivoParticion);
                    }
                }


            }


            return true;
        }

        private void IniciarMezcla()
        {
            if (_rutaArchivoParticion == null)
            {
                MessageBox.Show("Seleccione un archivo particionado");
                return;
            }

            if(ExisteArchivoParaMezclar(_rutaArchivoParticion) == false)
            {
                MessageBox.Show("El archivo no existe");
                return;
            }


            if(ContinuarMezclaDeArchivo(_rutaArchivoParticion) == false)
            {
                return;
            }

            _fileMarge.EliminarPartesAlFinalizar = this.chkEliminarPartesFinalizar.Checked;
            btnCancelar.Visible = true;
            _cancelationTokenSource = new CancellationTokenSource();

            Task.Run(() =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                   _fileMarge.Marge(_rutaArchivoParticion, _cancelationTokenSource.Token);
                });
                
            });
        }


        #endregion


        #region Eventos asociados a la mezcla de archivos

        private void ProcesoCanceladoOCompletado()
        {
            btnCancelar.Visible = false;
            pgrMezcla.Value = 0;
            lblInfoProgreso.Text = "";
        }

        private void _fileMarge_Error(object sender, string e)
        {
            MessageBox.Show(e);
            ProcesoCanceladoOCompletado();
        }

        private void _fileMarge_Progreso(object sender, ProgressMergeArgs e)
        {
            double progreso = (double)e.BytesActuales / (double)e.TotalBytes;

            lblInfoProgreso.Text = $"{progreso}%  {e.BytesActuales} / {e.TotalBytes}";

            pgrMezcla.Value = (int)(progreso * 100);


            if(e.Porcentaje == 1)
            {
                ProcesoCanceladoOCompletado();
            }

        }

        #endregion

        private void lsvArchivosParticionados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ListViewHitTestInfo hit = lsvArchivosParticionados.HitTest(e.Location);
                if (hit.Item != null)
                {
                    SeleccionarArchivoParticionado(hit.Item.Text);
                    
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._cancelationTokenSource.Cancel();
            ProcesoCanceladoOCompletado();
        }
    }
}
