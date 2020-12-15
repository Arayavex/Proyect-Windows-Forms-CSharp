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
    public partial class Ordenes : Form
    {
        private int OrdenActual;
        public Ordenes()
        {
            InitializeComponent();
            TabOrden.ItemSize = new Size(0, 1);
            DataSet Ordenes = Comm.GetDatosOrdenes();
            DataGridViewImageColumn ImgCol = new DataGridViewImageColumn();
            ImgCol.Image = Properties.Resources.Check;
            ImgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DGVOrdenes.DataSource = Ordenes.Tables[0];
            DGVOrdenes.Columns.Add(ImgCol);
            DGVOrdenes.Columns[5].Visible = false;
            DGVOrdenes.Columns[6].Visible = false;
            DGVOrdenes.Refresh();
            OrdenActual = Comm.GetOrdenMensajero(Comm.userid);
            if (OrdenActual != -1)
            {
                DataSet Envio = Comm.GetInfoEnvio(OrdenActual);
                String EstadoActual = Envio.Tables[0].Rows[0]["Estado_Envio"].ToString();
                if (EstadoActual == enumEstadoEnvio.Preparando.ToString())
                    PrbEnvio.Value = 1;
                else if (EstadoActual == enumEstadoEnvio.Retirando.ToString())
                    PrbEnvio.Value = 2;
                else
                    PrbEnvio.Value = 3;
                TabOrden.SelectedIndex = 1;
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Form Dash = new DashboardMensajero();
            Dash.Show();
            Close();
        }

        private void DGVOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                TabOrden.SelectedIndex = 1;
                OrdenActual = int.Parse(DGVOrdenes.Rows[e.RowIndex].Cells[6].Value.ToString());
                int IDCliente = int.Parse(DGVOrdenes.Rows[e.RowIndex].Cells[7].Value.ToString());
                Comm.RegistrarEnvio(OrdenActual, Comm.userid, IDCliente);
                Comm.ActualizarEstadoOrden(OrdenActual, enumEstadoOrden.Procesada);
                PrbEnvio.Value = 1;
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            DataSet Ordenes = Comm.GetDatosOrdenes();
            DGVOrdenes.DataSource = Ordenes.Tables[0];
            DGVOrdenes.Refresh();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            switch(PrbEnvio.Value)
            {
                case 1: Comm.ActualizarEstadoEnvio(OrdenActual, enumEstadoEnvio.Retirando);
                    PrbEnvio.Value++;
                    break;
                case 2: Comm.ActualizarEstadoEnvio(OrdenActual, enumEstadoEnvio.Camino);
                    PrbEnvio.Value++;
                    break;
                case 3: Comm.ActualizarEstadoEnvio(OrdenActual, enumEstadoEnvio.Entregado);
                    Comm.ActualizarEstadoOrden(OrdenActual, enumEstadoOrden.Completa);
                    PrbEnvio.Value++;
                    MessageBox.Show("Orden Completada Exitosamente!");
                    TabOrden.SelectedIndex = 0;
                    BtnActualizar.PerformClick();
                    break;
            }
        }
    }
}
