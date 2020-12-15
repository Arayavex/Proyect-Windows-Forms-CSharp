namespace Abastecedor_Estrella
{
    partial class Form_Productos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Productos));
            this.dataGv2 = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtPre = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.btnActualiza = new System.Windows.Forms.Button();
            this.btnIngreProd = new System.Windows.Forms.Button();
            this.lbID = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btnSalida = new System.Windows.Forms.Button();
            this.lblRuta = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.picboxPro = new System.Windows.Forms.PictureBox();
            this.lblBien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPro)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGv2
            // 
            this.dataGv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGv2.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.dataGv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGv2.Location = new System.Drawing.Point(24, 271);
            this.dataGv2.Name = "dataGv2";
            this.dataGv2.RowHeadersWidth = 51;
            this.dataGv2.Size = new System.Drawing.Size(761, 233);
            this.dataGv2.TabIndex = 1;
            this.dataGv2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGv2_RowHeaderMouseClick);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(143, 123);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(116, 27);
            this.txtID.TabIndex = 4;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(143, 159);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(116, 27);
            this.txtDesc.TabIndex = 5;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(401, 117);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(116, 27);
            this.txtCantidad.TabIndex = 6;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(401, 155);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(116, 27);
            this.txtMarca.TabIndex = 7;
            // 
            // txtPre
            // 
            this.txtPre.Location = new System.Drawing.Point(143, 194);
            this.txtPre.Name = "txtPre";
            this.txtPre.Size = new System.Drawing.Size(116, 27);
            this.txtPre.TabIndex = 8;
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(401, 194);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(116, 27);
            this.txtTipo.TabIndex = 9;
            // 
            // btnActualiza
            // 
            this.btnActualiza.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualiza.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualiza.Location = new System.Drawing.Point(543, 182);
            this.btnActualiza.Name = "btnActualiza";
            this.btnActualiza.Size = new System.Drawing.Size(103, 35);
            this.btnActualiza.TabIndex = 10;
            this.btnActualiza.Text = "Actualizar";
            this.btnActualiza.UseVisualStyleBackColor = true;
            this.btnActualiza.Click += new System.EventHandler(this.btnActualiza_Click);
            // 
            // btnIngreProd
            // 
            this.btnIngreProd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngreProd.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngreProd.Location = new System.Drawing.Point(543, 118);
            this.btnIngreProd.Name = "btnIngreProd";
            this.btnIngreProd.Size = new System.Drawing.Size(103, 35);
            this.btnIngreProd.TabIndex = 11;
            this.btnIngreProd.Text = "Ingresar";
            this.btnIngreProd.UseVisualStyleBackColor = true;
            this.btnIngreProd.Click += new System.EventHandler(this.btnIngreProd_Click);
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(106, 123);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(30, 20);
            this.lbID.TabIndex = 13;
            this.lbID.Text = "ID:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Cambria", 10F);
            this.lblDescripcion.Location = new System.Drawing.Point(37, 162);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(99, 20);
            this.lblDescripcion.TabIndex = 14;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Cambria", 10F);
            this.lblPrecio.Location = new System.Drawing.Point(76, 197);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(60, 20);
            this.lblPrecio.TabIndex = 15;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Cambria", 10F);
            this.lblCantidad.Location = new System.Drawing.Point(312, 125);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(77, 20);
            this.lblCantidad.TabIndex = 16;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Cambria", 10F);
            this.lblMarca.Location = new System.Drawing.Point(331, 162);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(58, 20);
            this.lblMarca.TabIndex = 17;
            this.lblMarca.Text = "Marca:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Cambria", 10F);
            this.lblTipo.Location = new System.Drawing.Point(272, 197);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(117, 20);
            this.lblTipo.TabIndex = 18;
            this.lblTipo.Text = "Tipo Producto:";
            // 
            // btnSalida
            // 
            this.btnSalida.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalida.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalida.Location = new System.Drawing.Point(892, 493);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(87, 27);
            this.btnSalida.TabIndex = 19;
            this.btnSalida.Text = "Salir";
            this.btnSalida.UseVisualStyleBackColor = true;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Font = new System.Drawing.Font("Cambria", 10F);
            this.lblRuta.Location = new System.Drawing.Point(12, 235);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(124, 20);
            this.lblRuta.TabIndex = 21;
            this.lblRuta.Text = "Ruta de imagen:";
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(143, 232);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(503, 27);
            this.txtRuta.TabIndex = 22;
            this.txtRuta.Click += new System.EventHandler(this.txtRuta_Click);
            // 
            // picboxPro
            // 
            this.picboxPro.Location = new System.Drawing.Point(678, 24);
            this.picboxPro.Name = "picboxPro";
            this.picboxPro.Size = new System.Drawing.Size(301, 231);
            this.picboxPro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxPro.TabIndex = 23;
            this.picboxPro.TabStop = false;
            // 
            // lblBien
            // 
            this.lblBien.AutoSize = true;
            this.lblBien.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBien.Location = new System.Drawing.Point(317, 9);
            this.lblBien.Name = "lblBien";
            this.lblBien.Size = new System.Drawing.Size(178, 43);
            this.lblBien.TabIndex = 24;
            this.lblBien.Text = "Bienvenido/a";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(486, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 43);
            this.label1.TabIndex = 25;
            this.label1.Text = "USER";
            // 
            // Form_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(215)))), ((int)(((byte)(160)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(999, 532);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBien);
            this.Controls.Add(this.picboxPro);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.lblRuta);
            this.Controls.Add(this.btnSalida);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.btnIngreProd);
            this.Controls.Add(this.btnActualiza);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.txtPre);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.dataGv2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Productos";
            this.Text = "Products";
            ((System.ComponentModel.ISupportInitialize)(this.dataGv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGv2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtPre;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Button btnActualiza;
        private System.Windows.Forms.Button btnIngreProd;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.PictureBox picboxPro;
        private System.Windows.Forms.Label lblBien;
        private System.Windows.Forms.Label label1;
    }
}