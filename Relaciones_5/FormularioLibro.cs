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
    public partial class FormularioLibro : Form
    {
        private LibroBLL libroBLL = new LibroBLL();
        private AutorLibroBLL autorLibroBLL = new AutorLibroBLL();
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

        private Libro ListarLibros()
        {
            return new Libro
            {
                Fecha_reg = DateTime.Now,
                Isbn = txt_isbn_libro.Text.Trim(),
                Titulo = txt_titulo_libro.Text.Trim()
            };
        }


        private void btn_alta_libro_Click(object sender, EventArgs e)
        {
            var libro = ListarLibros();
            libroBLL.Alta(libro);
            RefrescarGrilla();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txt_isbn_libro.Text = string.Empty;
            txt_titulo_libro.Text = string.Empty;
        }

        private Libro SeleccionarLibro()
        {
            return (Libro)grillaLibro.SelectedRows[0].DataBoundItem;
        }

        private void btn_baja_libro_Click(object sender, EventArgs e)
        {
            var libro = SeleccionarLibro();
            libroBLL.Baja(libro);
            RefrescarGrilla();
            LimpiarCampos();
        }

        private void btn_modificacion_libro_Click(object sender, EventArgs e)
        {
            var libro = SeleccionarLibro();
            libro.Isbn = txt_isbn_libro.Text.Trim();
            libro.Titulo = txt_titulo_libro.Text.Trim();
            libroBLL.Modificacion(libro);
            RefrescarGrilla();
            LimpiarCampos();
        }

        private void grillaLibro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var libro = grillaLibro.SelectedRows[0].DataBoundItem as Libro;
            RefrescarGrillaAutor(libro);
        }

        private void RefrescarGrillaAutor(Libro libro)
        {
            grillaAutorLibro.DataSource = null;
            grillaAutorLibro.DataSource = autorLibroBLL.BuscarAutorEnLibro(libro);
        }

        private void btn_agregar_autor_Click(object sender, EventArgs e)
        {
            try
            {
                var libro = grillaLibro.SelectedRows[0].DataBoundItem as Libro;
                var autor = grillaAutorLibro.SelectedRows[0].DataBoundItem as Autor;

                autorLibroBLL.Alta(new AutorLibro {Autor_fk = autor.Id, Libro_fk = libro.Id });

                RefrescarGrilla();
                RefrescarGrillaAutor(libro);
                LimpiarCampos();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btn_eliminar_autor_Click(object sender, EventArgs e)
        {
            try
            {
                var libro = grillaLibro.SelectedRows[0].DataBoundItem as Libro;
                var autor = grillaAutorLibro.SelectedRows[0].DataBoundItem as Autor;

                autorLibroBLL.Baja(new AutorLibro { Autor_fk = autor.Id, Libro_fk = libro.Id });

                RefrescarGrilla();
                RefrescarGrillaAutor(libro);
                LimpiarCampos();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
