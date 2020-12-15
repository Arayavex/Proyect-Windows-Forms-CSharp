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
    public partial class DashboardMensajero : Form
    {
        public DashboardMensajero()
        {
            InitializeComponent();
            LblUsuario.Text = "¡Hola " + Comm.GetNombre(Comm.userid) + "!";
        }

        private void btn_Envio_Click(object sender, EventArgs e)
        {
            Form FrmEnvio = new Ordenes();
            FrmEnvio.Show();
            Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form Formulario1 = new Login();
            Formulario1.Show();
            this.Close();
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
            Form Cuenta = new CuentaMensajero();
            Cuenta.Show();
            this.Close();
        }
    }
}
