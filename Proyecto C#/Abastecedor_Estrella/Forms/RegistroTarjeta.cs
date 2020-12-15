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
    public partial class RegistroTarjeta : Form
    {
        private int IDTarjeta = -1;
        public RegistroTarjeta()
        {
            InitializeComponent();
        }
        
        public RegistroTarjeta(int Tarjeta)
        {
            InitializeComponent();
            IDTarjeta = Tarjeta;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            DateTime Vencimiento = DateTime.Parse("01/" + TxtFecExp.Text);
            int CodTarjeta = int.Parse(TxtCodigo.Text);
            if (IDTarjeta == -1)
            {
                IDTarjeta = Comm.RegistrarTarjeta(TxtTarjeta.Text, Vencimiento, CodTarjeta, TxtProveedor.Text);
                Comm.AsignarTarjeta(Comm.userid, IDTarjeta);
            }
            else
            {
                Comm.ActualizarTarjeta(IDTarjeta, TxtTarjeta.Text, Vencimiento, CodTarjeta, TxtProveedor.Text);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
