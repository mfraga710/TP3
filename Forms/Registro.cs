using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP3
{
    public partial class Registro : Form
    {
        private RedSocial rs;
        private Login frm;

        public Registro(RedSocial rs1,Login formLogin)
        {
            this.rs = rs1;
            frm = formLogin;
            InitializeComponent();            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frm.Enabled = true;
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            int dni1 = Convert.ToInt32(textBoxDni.Text);
            if (textBoxPassword.Text.Equals(textBoxRepPassword.Text))
            {
                rs.registrarUsuario(textBoxNombre.Text, textBoxApellido.Text, textBoxMail.Text, dni1, textBoxPassword.Text,checkBox1.Checked);
                MessageBox.Show("Su usuario ha sido creado correctamente. Ya puede iniciar sesion.");
                frm.Enabled = true;
                this.Close();                
            }
            else
            {
                labelErrores.Show();
                labelErrores.Text = "La contraseña no coincide, intentelo de nuevo";
            }
        }
    }
}
