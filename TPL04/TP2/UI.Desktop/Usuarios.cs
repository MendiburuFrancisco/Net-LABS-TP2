using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic; 

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();

        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource =  ul.GetAll();
            id.DataPropertyName = "ID";
            nombre.DataPropertyName = "Nombre";
            apellido.DataPropertyName = "Apellido";
            usuario.DataPropertyName = "Usuario";
            email.DataPropertyName = "EMail";
            habilitado.DataPropertyName = "Habilitado";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
