namespace Abastecedor_Estrella
{
    partial class Ordenes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGVOrdenes = new System.Windows.Forms.DataGridView();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnVolver = new System.Windows.Forms.Button();
            this.TabOrden = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnSiguiente = new System.Windows.Forms.Button();
            this.PrbEnvio = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOrdenes)).BeginInit();
            this.TabOrden.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVOrdenes
            // 
            this.DGVOrdenes.AllowUserToAddRows = false;
            this.DGVOrdenes.AllowUserToDeleteRows = false;
            this.DGVOrdenes.AllowUserToResizeColumns = false;
            this.DGVOrdenes.AllowUserToResizeRows = false;
            this.DGVOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVOrdenes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGVOrdenes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVOrdenes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVOrdenes.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVOrdenes.Location = new System.Drawing.Point(15, 8);
            this.DGVOrdenes.Margin = new System.Windows.Forms.Padding(4);
            this.DGVOrdenes.MultiSelect = false;
            this.DGVOrdenes.Name = "DGVOrdenes";
            this.DGVOrdenes.RowHeadersVisible = false;
            this.DGVOrdenes.RowHeadersWidth = 51;
            this.DGVOrdenes.Size = new System.Drawing.Size(1309, 453);
            this.DGVOrdenes.TabIndex = 0;
            this.DGVOrdenes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVOrdenes_CellContentClick);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnActualizar.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Location = new System.Drawing.Point(20, 595);
            this.BtnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(130, 45);
            this.BtnActualizar.TabIndex = 1;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnVolver
            // 
            this.BtnVolver.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnVolver.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVolver.Location = new System.Drawing.Point(1226, 596);
            this.BtnVolver.Margin = new System.Windows.Forms.Padding(4);
            this.BtnVolver.Name = "BtnVolver";
            this.BtnVolver.Size = new System.Drawing.Size(130, 44);
            this.BtnVolver.TabIndex = 2;
            this.BtnVolver.Text = "Volver";
            this.BtnVolver.UseVisualStyleBackColor = false;
            this.BtnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
            // 
            // TabOrden
            // 
            this.TabOrden.Controls.Add(this.tabPage1);
            this.TabOrden.Controls.Add(this.tabPage2);
            this.TabOrden.ItemSize = new System.Drawing.Size(96, 21);
            this.TabOrden.Location = new System.Drawing.Point(16, 75);
            this.TabOrden.Margin = new System.Windows.Forms.Padding(4);
            this.TabOrden.Name = "TabOrden";
            this.TabOrden.SelectedIndex = 0;
            this.TabOrden.Size = new System.Drawing.Size(1340, 498);
            this.TabOrden.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabOrden.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DGVOrdenes);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1332, 469);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnSiguiente);
            this.tabPage2.Controls.Add(this.PrbEnvio);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1332, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnSiguiente
            // 
            this.BtnSiguiente.Location = new System.Drawing.Point(605, 180);
            this.BtnSiguiente.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSiguiente.Name = "BtnSiguiente";
            this.BtnSiguiente.Size = new System.Drawing.Size(153, 28);
            this.BtnSiguiente.TabIndex = 2;
            this.BtnSiguiente.Text = "Retirar Orden";
            this.BtnSiguiente.UseVisualStyleBackColor = true;
            this.BtnSiguiente.Click += new System.EventHandler(this.BtnSiguiente_Click);
            // 
            // PrbEnvio
            // 
            this.PrbEnvio.Location = new System.Drawing.Point(37, 41);
            this.PrbEnvio.Margin = new System.Windows.Forms.Padding(4);
            this.PrbEnvio.Maximum = 4;
            this.PrbEnvio.Name = "PrbEnvio";
            this.PrbEnvio.Size = new System.Drawing.Size(1284, 28);
            this.PrbEnvio.Step = 1;
            this.PrbEnvio.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PrbEnvio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Desktop;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(487, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dashboard de Ordenes";
            // 
            // Ordenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1377, 653);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TabOrden);
            this.Controls.Add(this.BtnVolver);
            this.Controls.Add(this.BtnActualizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ordenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envio";
            ((System.ComponentModel.ISupportInitialize)(this.DGVOrdenes)).EndInit();
            this.TabOrden.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVOrdenes;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnVolver;
        private System.Windows.Forms.TabControl TabOrden;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtnSiguiente;
        private System.Windows.Forms.ProgressBar PrbEnvio;
        private System.Windows.Forms.Label label1;
    }
}