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
    public partial class Dashboard_cliente : Form
    {
        public Dashboard_cliente()
        {
            InitializeComponent();
            lblBienvenido.Text = "¡Hola " + Comm.GetNombre(Comm.userid) + "!";
            
        }

        private void btn_pedir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Formulario1 = new Pedir();
            Formulario1.Show();
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            Form Consulta = new ConsultarOrden();
            Consulta.Show();
            Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Formulario1 = new Login();
            Formulario1.Show();
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
            Form Cuenta = new CuentaCliente();
            Cuenta.Show();
            Close();
        }
    }
}
