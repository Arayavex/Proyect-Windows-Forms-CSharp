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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            DataSet Paises = Comm.GetDataPais();
            CboPais.DataSource = Paises.Tables[0];
            CboPais.ValueMember = "ID_Pais";
            CboPais.DisplayMember = "Descripcion_Pais";
            PnlTarjeta.Visible = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Login();
            Formulario1.Show();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int IDPersona = int.Parse(TxtID.Text);
            Comm.RegistrarPersona(IDPersona, TxtNombre.Text, TxtPApellido.Text, TxtSApellido.Text, TxtTelefono.Text, TxtContrasena.Text);
            if(chkMensajero.Checked)
            {
                Comm.RegistrarMensajero(IDPersona);
                Comm.userid = (IDPersona);
                DashboardMensajero Mensajero = new DashboardMensajero();
                Mensajero.Show();
            }
            else
            {
                int IDTarjeta;
                int Edad = int.Parse(TxtEdad.Text);
                int CodDistrito = int.Parse(CboDistrito.SelectedValue.ToString());
                int CodDireccion = Comm.RegistrarDireccion(TxtLinea1.Text, TxtLinea2.Text, CodDistrito);
                if (ChkTarjeta.Checked)
                {
                    DateTime Vencimiento = DateTime.Parse("01/" + TxtFecExp.Text);
                    int CodTarjeta = int.Parse(TxtCodigo.Text);
                    IDTarjeta = Comm.RegistrarTarjeta(TxtTarjeta.Text, Vencimiento, CodTarjeta, TxtProveedor.Text);
                }
                else
                {
                    IDTarjeta = -1;
                }
                Comm.RegistrarCliente(IDPersona, TxtCorreo.Text, Edad, IDTarjeta, CodDireccion);
                Comm.userid = (IDPersona);
                Dashboard_cliente Cliente = new Dashboard_cliente();
                Cliente.Show();
            }
            this.Close();
        }

        private void chkMensajero_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMensajero.Checked)
            {
                PnlCliente.Visible = false;
                PnlTarjeta.Visible = false;
                ChkTarjeta.Visible = false;
            }
            else
            {
                PnlCliente.Visible = true;
                ChkTarjeta.Visible = true;
                PnlTarjeta.Visible = ChkTarjeta.Checked;
            }
        }

        private void ChkTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            PnlTarjeta.Visible = ChkTarjeta.Checked;
        }

        private void CboPais_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataSet Provincias = Comm.GetDataGeografia(123, Convert.ToInt32(CboPais.SelectedValue.ToString()));
            CboProvincia.DataSource = Provincias.Tables[0];
            CboProvincia.DisplayMember = "Descripcion_Geografica";
            CboProvincia.ValueMember = "ID_Geografia";
        }

        private void CboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboProvincia.Items.Count != 0)
            {
                int IDProvincia = int.Parse(CboProvincia.SelectedValue.ToString());
                DataSet Cantones = Comm.GetGeografiasHijas(124, IDProvincia);
                CboCanton.DataSource = Cantones.Tables[0];
                CboCanton.ValueMember = "ID_Geografia";
                CboCanton.DisplayMember = "Descripcion_Geografica";
            }
        }

        private void CboCanton_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboCanton.Items.Count != 0)
            {
                int IDCanton = int.Parse(CboCanton.SelectedValue.ToString());
                DataSet Distritos = Comm.GetGeografiasHijas(125, IDCanton);
                CboDistrito.DataSource = Distritos.Tables[0];
                CboDistrito.ValueMember = "ID_Geografia";
                CboDistrito.DisplayMember = "Descripcion_Geografica";
            }
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}
