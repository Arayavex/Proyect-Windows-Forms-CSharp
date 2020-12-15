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
    public partial class CuentaCliente : Form
    {
        bool Modificando;
        int IDTarjeta;
        public CuentaCliente()
        {
            Modificando = false;
            InitializeComponent();
            CargaTarjeta();
            VisibilizarControles(false);
            CargarDatosCliente();
            BtnCancelar.Visible = false;
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Dashboard_cliente Dash = new Dashboard_cliente();
            Dash.Show();
            Close();
        }

        private void BtnTarjeta_Click(object sender, EventArgs e)
        {
            Form Tarjeta = (IDTarjeta != -1) ?  new RegistroTarjeta(IDTarjeta) : new RegistroTarjeta();
            Tarjeta.ShowDialog();
            if (Tarjeta.DialogResult == DialogResult.OK)
                CargaTarjeta();
        }

        private void BtnModifica_Click(object sender, EventArgs e)
        {
            if(!Modificando)
            {
                LblTelefono.Text = "Telefono: ";
                LblCorreo.Text = "Correo: ";
                LblEdad.Text = "Edad: ";
                LblPais.Text = "País: ";
                LblProvincia.Text = "Provincia: ";
                LblCanton.Text = "Canton: ";
                LblDistrito.Text = "Distrito: ";
                VisibilizarControles(true);
                DataSet Paises = Comm.GetDataPais();
                CboPais.DataSource = Paises.Tables[0];
                CboPais.ValueMember = "ID_Pais";
                CboPais.DisplayMember = "Descripcion_Pais";
                BtnModifica.Text = "Confirmar";
                Modificando = true;
                BtnCancelar.Visible = true;
            }
            else
            {
                VisibilizarControles(false);
                int Edad = int.Parse(TxtEdad.Text);
                int Distrito = int.Parse(CboDistrito.SelectedValue.ToString());
                Comm.ActualizaCliente(Comm.userid, TxtCorreo.Text, TxtTelefono.Text, Edad, Distrito);
                CargarDatosCliente();
                BtnModifica.Text = "Modificar";
                Modificando = false;
                BtnCancelar.Visible = false;
            }
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

        private void VisibilizarControles(bool Visible)
        {
            TxtCorreo.Visible = Visible;
            TxtTelefono.Visible = Visible;
            TxtEdad.Visible = Visible;
            CboPais.Visible = Visible;
            CboProvincia.Visible = Visible;
            CboCanton.Visible = Visible;
            CboDistrito.Visible = Visible;
        }

        private void CargarDatosCliente()
        {
            DataSet DatosCliente = Comm.GetInfoCliente(Comm.userid);
            DataRow FilaCliente = DatosCliente.Tables[0].Rows[0];
            LblNombre.Text = "Nombre: " + FilaCliente["Nombre"].ToString();
            LblNombre.Text += " " + FilaCliente["Primer_Apellido"].ToString();
            LblNombre.Text += " " + FilaCliente["Segundo_Apellido"].ToString();
            LblID.Text = "ID: " + Comm.userid;
            LblCorreo.Text = "Correo: " + FilaCliente["Correo"].ToString();
            LblTelefono.Text = "Telefono: " + FilaCliente["Telefono"].ToString();
            LblEdad.Text = "Edad: " + FilaCliente["Edad"].ToString();
            LblPais.Text = "País: " + FilaCliente["Descripcion_Pais"].ToString();
            LblProvincia.Text = "Provincia: " + FilaCliente["Provincia"].ToString();
            LblCanton.Text = "Canton: " + FilaCliente["Canton"].ToString();
            LblDistrito.Text = "Distrito: " + FilaCliente["Distrito"].ToString();
            TxtCorreo.Text = FilaCliente["Correo"].ToString();
            TxtTelefono.Text = FilaCliente["Telefono"].ToString();
            TxtEdad.Text = FilaCliente["Edad"].ToString();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            VisibilizarControles(false);
            CargarDatosCliente();
            BtnModifica.Text = "Modificar";
            Modificando = false;
            BtnCancelar.Visible = false;
        }

        private void CargaTarjeta()
        {
            IDTarjeta = Comm.GetIDMetodoPago(Comm.userid);
            if (IDTarjeta != -1)
            {
                DataSet InfoTarjeta = Comm.GetInfoTarjeta(IDTarjeta);
                String NumTarjeta = InfoTarjeta.Tables[0].Rows[0]["Numero_Tarjeta"].ToString();
                LblNumTarjeta.Text = "**** **** **** " + NumTarjeta.Substring(NumTarjeta.Length - 4);
                String StrVencimiento = InfoTarjeta.Tables[0].Rows[0]["Fecha_Vencimiento"].ToString();
                DateTime FecVencimiento = DateTime.Parse(StrVencimiento);
                LblFecVencimiento.Text = FecVencimiento.ToString("MM/yy");
                LblMarca.Text = InfoTarjeta.Tables[0].Rows[0]["Proveedor"].ToString();
                PnlMetodoPago.Visible = true;
            }
            else
                PnlMetodoPago.Visible = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Dashboard_cliente Dash = new Dashboard_cliente();
            Dash.Show();
            Close();
        }
    }
}
