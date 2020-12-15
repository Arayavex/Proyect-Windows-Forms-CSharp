using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abastecedor_Estrella
{
    public partial class Form_Geografia : Form
    {
       int ID_Pais = 0;
        public Form_Geografia(int IDPais)
        {
            ID_Pais = (IDPais);
            InitializeComponent();
            cargaComboGeografia();
            DataSet ds = new DataSet();
            ds = Comm.GetDataGeografia(Convert.ToInt32(cbx_TipoGeografia.SelectedValue?.ToString()), IDPais);
            dataGv1.DataSource = ds.Tables[0];
            try
            {
                txtGeo.Text = dataGv1.Rows[0].Cells[0].Value?.ToString();
                txtNombre.Text = dataGv1.Rows[0].Cells[1].Value?.ToString();
            }
            catch
            {
                MessageBox.Show("No hay datos disponibles para este pais actualmente.");
            }

        }



        public void cargaComboGeografia()
        {
            cbx_TipoGeografia.ValueMember = "ID_Tipo_Geografia_PK";
            cbx_TipoGeografia.DisplayMember = "Descripcion";
            cbx_TipoGeografia.DataSource = Comm.cargaComboGeografia();

        }

        private void ClearData()
        {
            txtGeo.Text = "";
            txtNombre.Text = "";
        }


        private void cbxTipGeograf_Ind_Chang(object sender, EventArgs e)
        {
            //MessageBox.Show(cbx_TipoGeografia.SelectedValue.ToString());
            DataSet ds = new DataSet();
            ds = Comm.GetDataGeografia(Convert.ToInt32(cbx_TipoGeografia.SelectedValue.ToString()), (ID_Pais));
            dataGv1.DataSource = ds.Tables[0];

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Formulario;
            Formulario = new Forms_Paises();
            Formulario.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int nully = Convert.ToInt32(cmbPertenece.SelectedValue?.ToString());
         
            MessageBox.Show(txtGeo.Text + " " + txtNombre.Text + " " + nully + " " + cbx_TipoGeografia.SelectedValue?.ToString() + " " + ID_Pais);
            MessageBox.Show(Comm.IngresoGeografia(txtGeo.Text, txtNombre.Text, nully, cbx_TipoGeografia.SelectedValue?.ToString(), Convert.ToString(ID_Pais)));
            DataSet ds = new DataSet();
            ds = Comm.GetDataGeografia(Convert.ToInt32(cbx_TipoGeografia.SelectedValue?.ToString()), ID_Pais);
            dataGv1.DataSource = ds.Tables[0];
            ClearData();
        }

     

        private void dataGv1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtGeo.Text = dataGv1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dataGv1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbPertenece.ValueMember = "id_geografia";
            cmbPertenece.DisplayMember = "descripcion_geografica";
            try
            {
                cmbPertenece.DataSource = Comm.cargaComboPerteneceGeografia(Convert.ToInt32(dataGv1.Rows[e.RowIndex].Cells[3].Value) - 1, Convert.ToInt32(ID_Pais));
            }
            catch
            {
                
            }
            cmbPertenece.SelectedItem = dataGv1.Rows[e.RowIndex].Cells[2].Value;
           // cmbPertenece.SelectedItem = cmbPertenece.FindStringExact(dataGv1.Rows[e.RowIndex].Cells[2].Value.ToString());
            //cmbPertenece.SelectedItem = cmbPertenece.Items.IndexOf(dataGv1.Rows[e.RowIndex].Cells[2].Value);

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            String nully = dataGv1.Rows[0].Cells[2].Value.ToString();
            if (nully == null)
            {
                nully = null;
            }
            MessageBox.Show(txtGeo.Text + " " + txtNombre.Text + " " + nully + " " + dataGv1.Rows[0].Cells[3].Value.ToString() + " " + ID_Pais);
            MessageBox.Show(Comm.ActualizaGeografia(txtGeo.Text, txtNombre.Text, nully, dataGv1.Rows[0].Cells[3].Value.ToString(), Convert.ToString(ID_Pais)));
            DataSet ds = new DataSet();
            ds = Comm.GetDataGeografia(Convert.ToInt32(dataGv1.Rows[0].Cells[3].Value.ToString()), (ID_Pais));
            dataGv1.DataSource = ds.Tables[0];
            ClearData();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Comm.EliminarGeografia(txtGeo.Text));
            DataSet ds = new DataSet();
            ds = Comm.GetDataGeografia(Convert.ToInt32(dataGv1.Rows[0].Cells[3].Value.ToString()), (ID_Pais));
            dataGv1.DataSource = ds.Tables[0];
            ClearData();
        }
    }
}
