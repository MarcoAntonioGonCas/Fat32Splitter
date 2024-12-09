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
        private void SeleccionarArchivoParticionado(string rutaArchivo)
        {
            FileInfo fileInfo = new FileInfo(rutaArchivo);
            string nombreSinParte =  _particionStrategy.RemueveEnumeracion(rutaArchivo);
            long sumabytes = _fileMarge.ObtieneTotalBytes(rutaArchivo);
        
            _rutaArchivoParticion = rutaArchivo;
            lblArchivo.Text = $"{fileInfo.Name} - {FileSizeFormatter.FormatSize(sumabytes)}";


            IniciarFileMarge((TipoParticionCombobox)cmbTipoParticion.SelectedItem);
            IniciarMezcla();
        }

        private void IniciarMezcla()
        {
            if (_rutaArchivoParticion == null)
            {
                MessageBox.Show("Seleccione un archivo particionado");
                return;
            }


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
