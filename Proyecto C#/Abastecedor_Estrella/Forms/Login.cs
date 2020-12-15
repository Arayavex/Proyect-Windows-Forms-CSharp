using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abastecedor_Estrella
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            Form Formulario;

            if (Comm.claveValida(txtUsuario.Text, txtpass.Text))

            {
                if (Comm.EsCliente(txtUsuario.Text))
                {
                    Comm.userid = Convert.ToInt32(txtUsuario.Text);
                    Formulario = new Dashboard_cliente();
                }
                else if (txtUsuario.Text == "123" && txtpass.Text == "patito2")
                 {
                     Comm.userid = Convert.ToInt32(txtUsuario.Text);
                     Formulario = new Dash_Admin();
                 }
                  else
                    {
                    Comm.userid = Convert.ToInt32(txtUsuario.Text);
                    Formulario = new DashboardMensajero();
                    }
                   
             Formulario.Show();
             this.Close();
            }
            else
                MessageBox.Show("Usuario o clave incorrecto");
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Form Formulario = new Registro();
            Formulario.Show();
            Close();
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnIngresar.PerformClick();
            }
        }
    }
}
