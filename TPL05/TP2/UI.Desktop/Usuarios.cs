using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }


        public void Listar()
        {
            
            UsuarioLogic ul = new UsuarioLogic();
            try
            {
                dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message, "Error Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tlUsuarios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows != null)
            {
                int id = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop ud = new UsuarioDesktop(id, ApplicationForm.ModoForm.Modificacion);
                ud.ShowDialog();
                Listar();
            }
            else if(dgvUsuarios.SelectedRows == null)
            {
                MessageBox.Show("Error", "Seleccione un Usuario\n para edirar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop ud = new UsuarioDesktop(id, ApplicationForm.ModoForm.Baja);
            ud.ShowDialog();
            Listar();
        }
    }
}
