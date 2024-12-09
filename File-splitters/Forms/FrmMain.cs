using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_splitters.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void OpenForm(Form form)
        {
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
        }

        private void btnParticionar_Click(object sender, EventArgs e)
        {
            OpenForm(new SplitFrm());
        }

        private void btnMezclar_Click(object sender, EventArgs e)
        {
            OpenForm(new MergeFrm());
        }
    }
}
