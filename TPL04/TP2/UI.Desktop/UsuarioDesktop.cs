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
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class UsuarioDesktop:ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }
 
        public UsuarioDesktop(ModoForm modo) : this()
          {
            Modo = modo;
            UsuarioActual = new Usuario();
          }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            MapearDeDatos();
        }

        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

      
        public override void MapearDeDatos()
        {
            txtID.Text = UsuarioActual.ID.ToString();
            txtNombre.Text = UsuarioActual.Nombre;
            txtEMail.Text = UsuarioActual.Email;
            txtClave.Text = UsuarioActual.Clave;
            txtApellido.Text = UsuarioActual.Apellido;
            txtUsuario.Text = UsuarioActual.NombreUsuario;
            txtConfirmarClave.Text = UsuarioActual.Clave;
            chkHabilitado.Checked = UsuarioActual.Habilitado;
            
            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
            }
        }
 
        public override void MapearADatos()
        {
       
            if(Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                UsuarioActual.State = BusinessEntity.States.Modified;
                
                
                if (Modo == ModoForm.Alta)
                {
                    UsuarioActual = new Usuario();
                    UsuarioActual.State = BusinessEntity.States.New;
                }
                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Email = txtEMail.Text;
                UsuarioActual.Clave = txtClave.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                UsuarioActual.NombreUsuario = txtUsuario.Text;
                UsuarioActual.Clave = txtClave.Text;
                UsuarioActual.Habilitado = chkHabilitado.Checked;
            }
            if (Modo == ModoForm.Baja)
            {
                UsuarioActual.State = BusinessEntity.States.Deleted;
            }
        }
        public override bool Validar()
        {
            String[] controles = { txtNombre.Text, txtEMail.Text, txtClave.Text, txtApellido.Text, txtUsuario.Text, txtConfirmarClave.Text };
           
            
            foreach (string valor in controles)
            {
                if (String.IsNullOrWhiteSpace(valor))
                {
                    Notificar("Debe llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (txtClave.Text.Length <8 || txtClave.Text != txtConfirmarClave.Text)
            {
                Notificar("Contraseña Invalida", "Las contaseñas no coinciden\n(debe ser mayor a 8 caracteres)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!condicionesEmail(txtEMail.Text))
            {
                Notificar("Email Invalido", "El Email ingresado es invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private Boolean condicionesEmail(String email)
        {
            String condiciones;
            condiciones = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, condiciones))
            {
                if (Regex.Replace(email, condiciones, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }

        private void tlUsuarioDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
