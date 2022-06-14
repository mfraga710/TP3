using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP3.Forms
{
    public partial class MostrarUsuario : Form
    {
        private RedSocial rs;
        private Home frm;
        public MostrarUsuario(RedSocial rs1, Home frm1, Usuario u)
        {
            this.frm = frm1;
            this.rs = rs1;
            InitializeComponent();
            rs.mostrarDatos(u);
            labelNombre.Text = u.nombre;
            labelApellido.Text = u.apellido;
            labelMail.Text = u.email;
            labelDNI.Text = u.dni.ToString();
        }
        // BUTTON 2 - CIERRA FORMULARIO
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            frm.Enabled = true;
            this.Close();
        }
    }
}
