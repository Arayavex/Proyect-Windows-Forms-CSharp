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
    public partial class CuentaMensajero : Form
    {
        public CuentaMensajero()
        {
            InitializeComponent();
            DataSet Ordenes = Comm.GetOrdenesCompletadas(Comm.userid);
            DGVMensajero.DataSource = Ordenes.Tables[0];
            DGVMensajero.Refresh();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            DashboardMensajero Dash = new DashboardMensajero();
            Dash.Show();
            Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            DataSet Ordenes = Comm.GetOrdenesCompletadas(Comm.userid);
            DGVMensajero.DataSource = Ordenes.Tables[0];
            DGVMensajero.Refresh();
        }
    }
}
