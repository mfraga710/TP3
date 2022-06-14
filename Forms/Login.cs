using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3
{
    public partial class Login : Form
    {
        private RedSocial rs;
        int intentosFallidos = 3;

        public Login(RedSocial rs1)
        {
            this.rs = rs1;
            
            InitializeComponent();
        }

        public Login(Login formLogin)
        {
            //this.rs = rs1;
            InitializeComponent();
        }


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            if (rs.iniciarSesion(textBoxUsuario.Text, textBoxPassword.Text))
            {
                if (rs.usuarioActual.isAdm)
                {
                    this.Hide();
                    Forms.Admin Admin = new Forms.Admin(rs, this);
                    Admin.Show();
                }
                else
                {
                    this.Hide();
                    Forms.Home home = new Forms.Home(rs, this);
                    home.Show();
                }
                ;
            }
            else
            {
                foreach (Usuario user in rs.usuarios)
                {
                    if (user.email == textBoxUsuario.Text)
                    {
                        if (user.bloqueado == false)
                        {
                            user.intentosFallidos++;
                            intentosFallidos--;
                            label7.Show();
                            label7.Text = "Inicio de sesión Fallido, quedan " + intentosFallidos + " intentos";
                            if (intentosFallidos == 0)
                            {
                                user.bloqueado = true;
                            }
                        }
                        else
                        {
                            label7.Show();
                            label7.Text = "Su usuario ha sido bloqueado por idiota";                            
                        }
                    }
                }
            }
            textBoxUsuario.Clear();
            textBoxPassword.Clear();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Registro reg = new Registro(rs, this);
            this.Enabled = false;
            reg.Show();
        }
    }
}
