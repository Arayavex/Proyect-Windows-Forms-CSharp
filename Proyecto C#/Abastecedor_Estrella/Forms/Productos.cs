using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abastecedor_Estrella
{
    public partial class Form_Productos : Form
    {
        public Form_Productos()
        {
            InitializeComponent();
            label1.Text = Comm.GetNombre(Comm.userid);
            DataSet ds = new DataSet();
            ds = Comm.GetDataProductos();
            dataGv2.DataSource = ds.Tables[0];
            txtID.Text = dataGv2.Rows[0].Cells[0].Value.ToString();
            txtCantidad.Text = dataGv2.Rows[0].Cells[1].Value.ToString();
            txtPre.Text = dataGv2.Rows[0].Cells[2].Value.ToString();
            txtMarca.Text = dataGv2.Rows[0].Cells[3].Value.ToString();
            txtDesc.Text = dataGv2.Rows[0].Cells[4].Value.ToString();
            txtTipo.Text = dataGv2.Rows[0].Cells[5].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGv2.Rows[0].Cells[6].Value‌​);
            picboxPro.Image = Image.FromStream(ms);
        }

        private void dataGv2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtID.Text = dataGv2.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCantidad.Text = dataGv2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPre.Text = dataGv2.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtMarca.Text = dataGv2.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDesc.Text = dataGv2.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtTipo.Text = dataGv2.Rows[e.RowIndex].Cells[5].Value.ToString();
                MemoryStream msi = new MemoryStream((byte[])dataGv2.Rows[e.RowIndex].Cells[6].Value‌​);
                picboxPro.Image = Image.FromStream(msi);
            }
            catch
            { 

            }
           
        }

        private void ClearData()
        {
            txtID.Text = "";
            txtCantidad.Text = "";
            txtDesc.Text = "";
            txtMarca.Text = "";
            txtTipo.Text = "";
            txtPre.Text = "";
            txtRuta.Text = "";

        }

        private void btnIngreProd_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Comm.IngresoProducto(txtID.Text, txtCantidad.Text, txtPre.Text, txtMarca.Text, txtDesc.Text, txtTipo.Text, txtRuta.Text));
            DataSet ds = new DataSet();
            ds = Comm.GetDataProductos();
            dataGv2.DataSource = ds.Tables[0];
            ClearData();
        }

        private void btnActualiza_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Comm.ModificarProducto(txtID.Text, txtCantidad.Text, txtPre.Text, txtMarca.Text, txtDesc.Text, txtTipo.Text));
            DataSet ds = new DataSet();
            ds = Comm.GetDataProductos();
            dataGv2.DataSource = ds.Tables[0];
            ClearData();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario1 = new Dash_Admin();
            Formulario1.Show();
        }

        private void txtRuta_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = @"C:";
            open.Filter = "All Images Files (*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif)|*.png;*.jpeg;*.gif;*.jpg;*.bmp;*.tiff;*.tif" +
            "|PNG Portable Network Graphics (*.png)|*.png" +
            "|JPEG File Interchange Format (*.jpg *.jpeg *jfif)|*.jpg;*.jpeg;*.jfif" +
            "|BMP Windows Bitmap (*.bmp)|*.bmp" +
            "|TIF Tagged Imaged File Format (*.tif *.tiff)|*.tif;*.tiff" +
            "|GIF Graphics Interchange Format (*.gif)|*.gif";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = open.FileName;
                picboxPro.Image = Image.FromFile(txtRuta.Text);
            }
        }
    }
}
