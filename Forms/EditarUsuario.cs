using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP3.Forms
{
    public partial class EditarUsuario : Form
    {
        private RedSocial rs;
        private Usuario usuario;
        private Home frm;
        private Admin frm1;
        private Login log;
        


        public EditarUsuario(RedSocial rs1, Admin frm1, Usuario user)
        {
            this.frm1 = frm1;
            this.rs = rs1;
            this.usuario = user;
            InitializeComponent();
            button1.Visible = true;
            nombre.Text = usuario.nombre;
            apellido.Text = usuario.apellido;
            mail.Text = usuario.email;
            dni.Text = usuario.dni.ToString();
        }
        public EditarUsuario(RedSocial rs1,Home frm1, Usuario user, Login log)
        {
            this.frm = frm1;
            this.rs = rs1;
            this.usuario = user;
            this.log = log;
            InitializeComponent();
            button1.Visible = false;
            nombre.Text = rs.usuarioActual.nombre;
            apellido.Text = rs.usuarioActual.apellido;
            mail.Text = rs.usuarioActual.email;
            dni.Text = rs.usuarioActual.dni.ToString();
        }

        // BUTTON 1 - GUARDAR MODIFICACIONES
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            Usuario editedUsuario = rs.searchUser(usuario.id);
            editedUsuario.nombre = nombre.Text;
            editedUsuario.apellido = apellido.Text;
            editedUsuario.email = mail.Text;
            editedUsuario.dni = Convert.ToInt32(dni.Text);
            if (rs.modificaUsuario(editedUsuario))
            {
                MessageBox.Show("Usuario Modificado con éxito");
                if (!rs.usuarioActual.isAdm)
                {
                    frm.labelNombreUsuario.Text = "Bienvenido " + rs.usuarioActual.nombre + " " + rs.usuarioActual.apellido;
                    frm.Enabled = true;
                    this.Close();
                }
                else
                {
                    frm1.Enabled = true;
                    frm1.refreshUsuariosEF();
                    this.Close();
                }
            }            


        }
        // BUTTON 2 - CANCELAR Y SALIR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!rs.usuarioActual.isAdm)
            {
                frm.Enabled = true;
                this.Close();
            }
            else
            {
                frm1.Enabled = true;
                this.Close();
            }

        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            rs.eliminarUsuario(usuario);
            if (!rs.usuarioActual.isAdm)
            {
                rs.cerrarSesion(frm, log);
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario fue eliminado");
                frm1.listaUsuarios.Rows.Clear();
                frm1.refreshUsuariosEF();
                frm1.Enabled = true;
                this.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario editedUsuario = rs.searchUser(usuario.id);
            if (rs.bloqUser(editedUsuario.id, false))
            {
                MessageBox.Show("El usuario fue desbloqueado");
                frm1.Enabled = true;
                this.Close();
            }
        }
    }
}
