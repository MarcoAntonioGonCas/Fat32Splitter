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
    public partial class MargeFrm : Form
    {
        private FileMarge _fileMarge;
        private CancellationTokenSource _cancelationTokenSource;
        private IParticionStrategy _particionStrategy;
        private string _rutaArchivoParticion;


        public MargeFrm()
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

            _fileMarge = new FileMarge(
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


        #endregion


        #region Eventos asociados a la mezcla de archivos

        private void _fileMarge_Error(object sender, string e)
        {
            MessageBox.Show(e);
        }

        private void _fileMarge_Progreso(object sender, ProgressMargeArgs e)
        {
            double progreso = e.BytesActuales / e.TotalBytes;

            lblInfoProgreso.Text = $"{progreso}%  {e.BytesActuales} / {e.TotalBytes}";

            pgrMezcla.Value = (int)(progreso * 100);

        }

        #endregion
    }
}
