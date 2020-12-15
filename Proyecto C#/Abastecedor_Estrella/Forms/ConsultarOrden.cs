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
    public partial class ConsultarOrden : Form
    {
        public ConsultarOrden()
        {
            InitializeComponent();
            DataSet Ordenes = Comm.GetInfoOrdenesCliente(Comm.userid);
            DGVOrdenes.DataSource = Ordenes.Tables[0];
            DGVOrdenes.Refresh();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            DataSet Ordenes = Comm.GetInfoOrdenesCliente(Comm.userid);
            DGVOrdenes.DataSource = Ordenes.Tables[0];
            DGVOrdenes.Refresh();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Dashboard_cliente Dash = new Dashboard_cliente();
            Dash.Show();
            Close();
        }
    }
}
