using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_splitters.FileHelper.Split
{
    public class ProgressSplitArgs: EventArgs
    {
        public long BytesActuales { get; set; }
        public long TotalBytes { get; set; }
        public double Porcentaje
        {
            get
            {
                return (double)BytesActuales / TotalBytes;
            }
        }
        public int TotalPartes { get; set; }
        public int ParteActual { get; set; }

    }
}
