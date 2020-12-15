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
    public partial class Pagar : Form
    {
        BindingList<Producto> Carrito;
        double TotalOrden;
        private int MetodoPago;
        public Pagar(BindingList<Producto> Compras)
        {
            InitializeComponent();
            TabTiposPago.ItemSize = new Size(0, 1);
            Carrito = Compras;
            TotalOrden = 0;
            foreach (Producto p in Compras)
            {
                TotalOrden += p.precio;
            }
            LblTotal.Text = "Precio a Total: " + TotalOrden;
            CargaTarjeta();
        }

        private void RdbPagoCash_CheckedChanged(object sender, EventArgs e)
        {
            TabTiposPago.SelectedIndex = (RdbPagoCash.Checked) ? 1 : 0;
        }

        private void ImgTarjeta_Click(object sender, EventArgs e)
        {
            RdbPagoTarjeta.Checked = true;
        }

        private void ImgCash_Click(object sender, EventArgs e)
        {
            RdbPagoCash.Checked = true;
        }

        private void BtnAgregaTarjeta_Click(object sender, EventArgs e)
        {
            Form Registro = new RegistroTarjeta();
            Registro.ShowDialog();
            if (Registro.DialogResult == DialogResult.OK)
                CargaTarjeta();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            enumTipoPago MetodoPago = (RdbPagoCash.Checked) ? enumTipoPago.Efectivo : enumTipoPago.Tarjeta;
            int IDOrden = Comm.RegistrarOrden(MetodoPago, TotalOrden);
            foreach(Producto p in Carrito)
            {
                Comm.RegistrarDetalleOrden(IDOrden, p.idProducto, p.cantidad, p.precio);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void CargaTarjeta()
        {
            MetodoPago = Comm.GetIDMetodoPago(Comm.userid);
            if (MetodoPago == -1)
            {
                BtnAgregaTarjeta.Visible = true;
                TabTiposPago.SelectedIndex = 1;
                RdbPagoTarjeta.Enabled = false;
                ImgTarjeta.Enabled = false;
                RdbPagoCash.Checked = true;
            }
            else
            {
                TabTiposPago.SelectedIndex = 0;
                BtnAgregaTarjeta.Visible = false;
                RdbPagoTarjeta.Checked = true;
                RdbPagoTarjeta.Enabled = true;
                ImgTarjeta.Enabled = true;
                DataSet InfoTarjeta = Comm.GetInfoTarjeta(MetodoPago);
                String NumTarjeta = InfoTarjeta.Tables[0].Rows[0]["Numero_Tarjeta"].ToString();
                LblNumTarjeta.Text = "**** **** **** " + NumTarjeta.Substring(NumTarjeta.Length - 4);
                String StrVencimiento = InfoTarjeta.Tables[0].Rows[0]["Fecha_Vencimiento"].ToString();
                DateTime FecVencimiento = DateTime.Parse(StrVencimiento);
                LblFecVencimiento.Text = FecVencimiento.ToString("MM/yy");
                LblMarca.Text = InfoTarjeta.Tables[0].Rows[0]["Proveedor"].ToString();
            }
        }
    }
}
