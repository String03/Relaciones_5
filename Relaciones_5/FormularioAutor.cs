using Relaciones_5.BLL;
using Relaciones_5.EE;
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
    public partial class FormularioAutor : Form
    {
        private AutorBLL autorBLL = new AutorBLL();
        public FormularioAutor()
        {
            InitializeComponent();
            RefrescarGrilla();
        }

        private void RefrescarGrilla()
        {
            grillaAutor.DataSource = null;
            grillaAutor.DataSource = autorBLL.Listar();
        }

        private void FormularioAutor_Load(object sender, EventArgs e)
        {

        }

        private Autor ListarAutor()
        {
            return new Autor
            {
                Fecha_reg = DateTime.Now,
                Apellido = txt_apellido_autor.Text.Trim(),
                Nombres = txt_nombres_autor.Text.Trim()
            };
        }

        private void btn_alta_autor_Click(object sender, EventArgs e)
        {
            var autor = ListarAutor();
            autorBLL.Alta(autor);
            RefrescarGrilla();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txt_nombres_autor.Text = string.Empty;
            txt_apellido_autor.Text = string.Empty;
        }
    }
}
