using File_splitters.Common;
using File_splitters.FileHelper;
using File_splitters.FileHelper.Particion;
using File_splitters.FileHelper.Split;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace File_splitters.Forms
{
    public partial class SplitFrm : Form
    {
        private FileSplit _fileSplit;
        private IParticionStrategy _particionStrategy;
        private string _rutaArchivo;
        private CancellationTokenSource _cancellationTokenSource;

        public SplitFrm()
        {
            InitializeComponent();

            cmbTipoParticion.DataSource = Enum.GetValues(typeof(TipoParticionCombobox));
        }

        private void InicarFileSplit(TipoParticionCombobox tipoParticionSeleccionada)
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

            if (_fileSplit != null) { 
                
                _fileSplit.ProgressSplit -= _fileSplit_ProgressSplit;
                _fileSplit.FileSplitError += _fileSplit_FileSplitError;
            }


            _fileSplit = new FileSplit(
                particionStrategy
                );
            _fileSplit.ProgressSplit += _fileSplit_ProgressSplit;
            _fileSplit.FileSplitError += _fileSplit_FileSplitError;

        }

        private void _fileSplit_FileSplitError(object sender, FileSplitErrorArgs e)
        {
            lblInfoProgreso.Text = e.MensajeError;

            OperacionesProgresoCompletadoOError();
        }

        private void _fileSplit_ProgressSplit(object sender, ProgressSplitArgs e)
        {
            lblInfoProgreso.Text = $"{e.Porcentaje}%  {e.BytesActuales} / {e.TotalBytes}";
            pgrParticion.Value = (int)(e.Porcentaje * 100);
        
            if(e.Porcentaje == 1)
            {
                OperacionesProgresoCompletadoOError();
            }

        }

        private void BtnSeleccionarArchivo_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                long tamanio = new FileInfo(openFileDialog.FileName).Length;
                
                if(PesoMayorAFAT32(openFileDialog.FileName))
                {
                    EliminarSeleccionarDeArchivo();
                    Seleccionar(openFileDialog.FileName);
                }
                else
                {
                    MessageBox.Show("El archivo es muy pequeño para ser particionado");

                }
            
            }
        }

        private void SplitFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnArchivosPesados_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            bool buscarRecursivo = PreguntarBuscarRecursivo();




            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folderBrowserDialog.SelectedPath);

                FileInfo[] archivosPesados = directoryInfo.GetFiles("*.*", buscarRecursivo ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                .Where(
                    archivo => archivo.Length > FileConstants.tamanioMaxFat32
                ).ToArray();


                if (archivosPesados.Length == 0)
                {
                    MessageBox.Show("No se encontraron archivos pesados");
                    return;
                }

                lsvArchivosPesados.Items.Clear();
                foreach (var archivo in archivosPesados)
                {
                    lsvArchivosPesados.Items.Add(archivo.FullName);
                }
            }


        }

        private void lsvArchivosPesados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ListViewHitTestInfo hit = lsvArchivosPesados.HitTest(e.Location);
                if (hit.Item != null)
                {
                    Seleccionar(hit.Item.Text);
                }
            }
        }

        private bool PreguntarBuscarRecursivo()
        {
            DialogResult dialogResult = MessageBox.Show(
                "¿Desea buscar de forma recursiva?",
                "Buscar recursivo",
                MessageBoxButtons.YesNo
                );
            return dialogResult == DialogResult.Yes;
        }
        private bool PregunstarBorrarOriginal()
        {
            DialogResult dialogResult = MessageBox.Show(
                "¿Desea borrar el archivo original?",
                "Borrar original",
                MessageBoxButtons.YesNo
                );
            return dialogResult == DialogResult.Yes;
        }


        #region Metodos de seleccion de archivo

        private void OperacionesProgresoCompletadoOError()
        {
            btnCancelar.Visible = false;
            pgrParticion.Value = 0;
            this.btnCancelar.Visible = false;
        }

        private bool PesoMayorAFAT32(string rutaArchivo)
        {
            long tamanio = new FileInfo(rutaArchivo).Length;
            return tamanio > FileConstants.tamanioMaxFat32;
        }

        private void Seleccionar(string rutaArchivo)
        {
            FileInfo informacionArchivo = new FileInfo(rutaArchivo);

            string label = $"{informacionArchivo.Name} - Tamaño: {FileSizeFormatter.FormatSize(informacionArchivo.Length)}";

            lblArchivo.Text = label;
            this._rutaArchivo = rutaArchivo;
        }

        private void EliminarSeleccionarDeArchivo()
        {

            lblArchivo.Text = "";
            this._rutaArchivo = "";
        }

        private bool ArchivoSeleccionado()
        {
            return !string.IsNullOrEmpty(this._rutaArchivo);
        }
        #endregion

        private void cmbTipoParticion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTipoParticion.SelectedItem != null && cmbTipoParticion.SelectedIndex != -1)
            {
                TipoParticionCombobox tipoParticionSeleccionada = (TipoParticionCombobox)cmbTipoParticion.SelectedItem;

                InicarFileSplit(tipoParticionSeleccionada);
            }
        }

        private void btnParticionar_Click(object sender, EventArgs e)
        {


            _cancellationTokenSource = new CancellationTokenSource();
            btnCancelar.Visible = true;


            if(_fileSplit.HaSidoParticionadoPreviamente(this._rutaArchivo))
            {

                DialogResult dialogResult = MessageBox.Show(
                    "El archivo ya ha sido particionado previamente, ¿Desea eliminar las particiones previas?",
                    "Eliminar particiones previas",
                    MessageBoxButtons.YesNo
                    );


                if (dialogResult == DialogResult.Yes)
                {
                    _fileSplit.EliminarParticionesPreviamente(this._rutaArchivo);
                }
                else
                {
                    return;
                }
            }

            if (!ArchivoSeleccionado())
            {
                MessageBox.Show("No se ha seleccionado ningun archivo");
                return;
            }


            if (_fileSplit == null)
            {
                MessageBox.Show("No se ha seleccionado ningun tipo de particion");
                return;
            }

            bool borrarOriginal = PregunstarBorrarOriginal();


            _fileSplit.BorrarOriginal = borrarOriginal;


            Task.Run(() =>
            {
                // El hilo secundario no puede acceder directamente a controles en la UI
                // Usamos Invoke para ejecutar el código en el hilo principal
                this.Invoke((MethodInvoker)delegate
                {
                    // Ahora podemos usar tipoParticionSeleccionado en el hilo secundario
                    _fileSplit.FilleSplit(this._rutaArchivo,_cancellationTokenSource.Token);
                });
            });

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this._cancellationTokenSource.Cancel();
        }
    }
}
