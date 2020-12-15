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
    public partial class Dash_Admin : Form
    {
        public Dash_Admin()
        {
            InitializeComponent();
        }


        private void btnPais_Click(object sender, EventArgs e)
        {
            Form Formulario = new Forms_Paises();
            Formulario.Show();
            Close();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            Form Formulario = new Form_Productos();
            Formulario.Show();
            Close();
        }

        private void lblout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Login();
            Formulario1.Show();

        }

        private void picanimated_Click(object sender, EventArgs e)
        {

        }
    }
}
