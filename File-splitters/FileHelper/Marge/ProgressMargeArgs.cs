using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_splitters.FileHelper.Marge
{
    public class ProgressMargeArgs:EventArgs
    {

        public int TotalPartes { get; set; }
        public int ParteActual { get; set; }

        public long TotalBytes { get; set; }
        public long BytesActuales { get; set; }
        /// <summary>
        /// Muestra el porcentaje 0.00 - 1.00
        /// </summary>
        public double Porcentaje
        {
            get
            {
                return (double)BytesActuales / TotalBytes;
            }
        }
        public double Porcentaje100
        {
            get
            {
                return (double)(BytesActuales * 100) / TotalBytes;
            }
        }
    }
}
