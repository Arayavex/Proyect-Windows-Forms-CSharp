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
    public partial class PedirCantidad : Form
    {
        public int ReturnCantidad { get; set; }
        public float ReturnPrecio { get; set; }
        public float ReturnPrecioFinal { get; set; }
        public String ReturnDescripcion { get; set; }

        int IdProducto = 0;
        
        public PedirCantidad(int Id_Producto, Bitmap img)
        {
            InitializeComponent();
            IdProducto = Id_Producto;
            picboxPro.Image = img;
            cmbxCantidad.Text = "1";
            this.ReturnPrecio = 0;
            this.ReturnPrecioFinal = 0;
            this.ReturnDescripcion = "";
            cargaDatos();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cargaDatos()
        {
            // int cantidad = Comm.GetCantidadProducto(IdProducto);
            // MessageBox.Show(cantidad +"");
            SqlDataReader dr = Comm.GetDataProductosById(IdProducto);
            while (dr.Read())
            {
                long len = dr.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                picboxPro.BackgroundImageLayout = ImageLayout.Stretch;
                picboxPro.BorderStyle = BorderStyle.FixedSingle;
                MemoryStream ms = new MemoryStream(array);
                Bitmap bitmap = new Bitmap(ms);
                picboxPro.BackgroundImage = bitmap;

                lblDescripcion.Text = dr["DESCRP"].ToString() + " " + dr["MARCA"].ToString();
                this.ReturnDescripcion = lblDescripcion.Text;
                int cantidad = (int)dr["CANTIDAD"];
                this.ReturnPrecio = (float)Convert.ToDouble(dr["PRECIO"] );


                //Llena el combobox  
                if (cantidad > 10)
                {
                    cantidad = 10;
                }
                for (int i = 1; i <= cantidad; i++)
                {
                    cmbxCantidad.Items.Add(i);
                }
                break;
            }
            dr.Close();



        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.ReturnCantidad = Convert.ToInt32(cmbxCantidad.Text);
            this.ReturnPrecioFinal = this.ReturnCantidad * this.ReturnPrecio;
        }


    }
}
