using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abastecedor_Estrella
{
    public partial class Pedir : Form
    {
        private PictureBox pic = new PictureBox();
        private Label price;
        private Label description;
        private BindingList<Producto> carrito = new BindingList<Producto>();
        
        
        public Pedir()
        {
            InitializeComponent();
            DGVCarrito.DataSource = carrito;
            DataGridViewImageColumn ImgCol = new DataGridViewImageColumn();
            ImgCol.Image = Properties.Resources.ElimItem;
            ImgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            DGVCarrito.Columns.Add(ImgCol);
            DGVCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVCarrito.AutoResizeColumns();
            DGVCarrito.DefaultCellStyle.SelectionBackColor = DGVCarrito.DefaultCellStyle.BackColor;
            DGVCarrito.DefaultCellStyle.SelectionForeColor = DGVCarrito.DefaultCellStyle.ForeColor;
            DGVCarrito.Visible = false;
            precioFinal();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Formulario1 = new Dashboard_cliente();
            Formulario1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ObtDatos("4");
            //AbrirFromHijo(new Productos());
        }
       /* private void AbrirFromHijo(object formHija)
        {
            if (this.Panelprincipal.Controls.Count > 0)
                this.Panelprincipal.Controls.RemoveAt(0);
            Form fh = formHija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Panelprincipal.Controls.Add(fh);
            fh.Show();

        }*/

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form Formulario1 = new Dashboard_cliente();
            Formulario1.Show();
        }

        private void ObtDatos(String pTip)
        {
            flowLayoutPanel1.Controls.Clear();
            SqlConnection Conn = Comm.RetornaAcceso();
            Conn.Open();
            SqlCommand Query = new SqlCommand("SELECT PRODUCTOIMAGEN, DESCRP, MARCA, PRECIO, ID_PRODUCTO FROM PRODUCTO WHERE ID_TIPO_TIPOPRODUCTO=@Tip and cantidad > 0");
            Query.Parameters.AddWithValue("Tip", pTip);
            Query.Connection = Conn;
            SqlDataReader dr;
            dr = Query.ExecuteReader();
            while (dr.Read())
            {
                long len = dr.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                pic = new PictureBox();
                pic.Width = 150;
                pic.Height = 150;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Tag = dr["ID_PRODUCTO"].ToString();

                price = new Label();
                price.Text = dr["Precio"].ToString();
                price.Width = 50;
                price.BackColor = Color.FromArgb(242, 148, 131);
                price.TextAlign = ContentAlignment.MiddleCenter;
                //price.Dock = DockStyle.Bottom;

                description = new Label();
                description.Text = dr["DESCRP"].ToString() + " " + dr["MARCA"].ToString();
                description.BackColor = Color.FromArgb(46, 134, 222);
                description.TextAlign = ContentAlignment.MiddleCenter;
                description.Dock = DockStyle.Bottom;

                MemoryStream ms = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(ms);
                pic.BackgroundImage = bitmap;

                pic.Controls.Add(description);
                pic.Controls.Add(price);
                flowLayoutPanel1.Controls.Add(pic);
                pic.Cursor = Cursors.Hand;

                pic.Click += new EventHandler(OnClick);
            }
            dr.Close();
            Conn.Close();
        }

        private void OnClick(object sender, EventArgs e)
        {
            String tag = ((PictureBox)sender).Tag.ToString();
            Bitmap img = (Bitmap)((PictureBox)sender).Image;
            //MessageBox.Show(tag);
            PedirCantidad frm = new PedirCantidad(Convert.ToInt32(tag), img);
            var result = frm.ShowDialog();
            if(result == DialogResult.OK)
            {
                //se obtienen valores de retorno
                //MessageBox.Show(frm.ReturnCantidad + " " + frm.ReturnPrecio + " " + frm.ReturnPrecioFinal + " " + frm.ReturnDescripcion);
                bool Existe = false;
                for(int i = 0; i < carrito.Count; i++)
                {
                    if(int.Parse(tag) == carrito[i].idProducto)
                    {
                        Existe = true;
                        if ((carrito[i].cantidad + frm.ReturnCantidad) > Comm.GetInventarioProducto(carrito[i].idProducto))
                            MessageBox.Show("El pedido supera las existencias actuales del producto");
                        else
                        {
                            carrito[i].cantidad += frm.ReturnCantidad;
                            carrito[i].precio = frm.ReturnPrecio * carrito[i].cantidad;
                        }
                    }
                }
                if(!Existe)
                    carrito.Add(new Producto(Convert.ToInt32(tag), frm.ReturnCantidad, frm.ReturnDescripcion, frm.ReturnPrecioFinal));
                DGVCarrito.Visible = true;
                DGVCarrito.Refresh();
                DGVCarrito.AutoResizeColumns();
                //new Producto(Convert.ToInt32(tag), frm.ReturnCantidad, frm.ReturnDescripcion, frm.ReturnPrecioFinal);
            }
            precioFinal();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ObtDatos("3");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ObtDatos("1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ObtDatos("2");
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            Pagar FrmPago = new Pagar(carrito);
            DialogResult Resultado = FrmPago.ShowDialog();
            if(Resultado == DialogResult.OK)
            {
                carrito.Clear();
                DGVCarrito.Refresh();
                MessageBox.Show("Compra exitosa!");
            }
        }

        private void DGVCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                carrito.RemoveAt(e.RowIndex);
                if (carrito.Count > 0)
                    DGVCarrito.Refresh();
                else
                    DGVCarrito.Visible = false;
            }
            precioFinal();
        }

        public void precioFinal()
        {
            double total = 0;
            for (var i = 0; i < carrito.Count; i++)
            {
                total = total + carrito[i].precio;
            }
            txtPrecioFinal.Text = "Total: " + total.ToString();
        }


    }
}
