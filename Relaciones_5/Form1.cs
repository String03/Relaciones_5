using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Relaciones_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aBRIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioAutor formularioAutor = new FormularioAutor();
            formularioAutor.MdiParent = this;
            if (!formularioAutor.IsDisposed)
            {
                formularioAutor.Show();
            }
        }

        private void aBRIRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormularioLibro formularioLibro = new FormularioLibro();
            formularioLibro.MdiParent = this;
            if (!formularioLibro.IsDisposed)
            {
                formularioLibro.Show();
            }
        }
    }
}
