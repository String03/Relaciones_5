using Relaciones_5.BLL;
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
    public partial class FormularioLibro : Form
    {
        private LibroBLL libroBLL = new LibroBLL();
        public FormularioLibro()
        {
            InitializeComponent();
            RefrescarGrilla();
        }

        private void RefrescarGrilla()
        {
            grillaLibro.DataSource = null;
            grillaLibro.DataSource = libroBLL.Listar();
        }

        private void FormularioLibro_Load(object sender, EventArgs e)
        {

        }
    }
}
