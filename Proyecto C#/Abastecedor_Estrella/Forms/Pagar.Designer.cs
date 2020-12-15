namespace Abastecedor_Estrella
{
    partial class Pagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pagar));
            this.ImgTarjeta = new System.Windows.Forms.PictureBox();
            this.ImgCash = new System.Windows.Forms.PictureBox();
            this.RdbPagoTarjeta = new System.Windows.Forms.RadioButton();
            this.RdbPagoCash = new System.Windows.Forms.RadioButton();
            this.GrpMetodos = new System.Windows.Forms.GroupBox();
            this.BtnAgregaTarjeta = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnPagar = new System.Windows.Forms.Button();
            this.TabTiposPago = new System.Windows.Forms.TabControl();
            this.TabTarjeta = new System.Windows.Forms.TabPage();
            this.LblMarca = new System.Windows.Forms.Label();
            this.LblFecVencimiento = new System.Windows.Forms.Label();
            this.LblNumTarjeta = new System.Windows.Forms.Label();
            this.TabCash = new System.Windows.Forms.TabPage();
            this.LblCash = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImgTarjeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCash)).BeginInit();
            this.GrpMetodos.SuspendLayout();
            this.TabTiposPago.SuspendLayout();
            this.TabTarjeta.SuspendLayout();
            this.TabCash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgTarjeta
            // 
            this.ImgTarjeta.Image = ((System.Drawing.Image)(resources.GetObject("ImgTarjeta.Image")));
            this.ImgTarjeta.Location = new System.Drawing.Point(37, 40);
            this.ImgTarjeta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImgTarjeta.Name = "ImgTarjeta";
            this.ImgTarjeta.Size = new System.Drawing.Size(140, 98);
            this.ImgTarjeta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgTarjeta.TabIndex = 0;
            this.ImgTarjeta.TabStop = false;
            this.ImgTarjeta.Click += new System.EventHandler(this.ImgTarjeta_Click);
            // 
            // ImgCash
            // 
            this.ImgCash.Image = ((System.Drawing.Image)(resources.GetObject("ImgCash.Image")));
            this.ImgCash.Location = new System.Drawing.Point(301, 21);
            this.ImgCash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImgCash.Name = "ImgCash";
            this.ImgCash.Size = new System.Drawing.Size(163, 134);
            this.ImgCash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgCash.TabIndex = 1;
            this.ImgCash.TabStop = false;
            this.ImgCash.Click += new System.EventHandler(this.ImgCash_Click);
            // 
            // RdbPagoTarjeta
            // 
            this.RdbPagoTarjeta.AutoSize = true;
            this.RdbPagoTarjeta.Location = new System.Drawing.Point(11, 86);
            this.RdbPagoTarjeta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RdbPagoTarjeta.Name = "RdbPagoTarjeta";
            this.RdbPagoTarjeta.Size = new System.Drawing.Size(17, 16);
            this.RdbPagoTarjeta.TabIndex = 2;
            this.RdbPagoTarjeta.TabStop = true;
            this.RdbPagoTarjeta.UseVisualStyleBackColor = true;
            // 
            // RdbPagoCash
            // 
            this.RdbPagoCash.AutoSize = true;
            this.RdbPagoCash.Location = new System.Drawing.Point(276, 86);
            this.RdbPagoCash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RdbPagoCash.Name = "RdbPagoCash";
            this.RdbPagoCash.Size = new System.Drawing.Size(17, 16);
            this.RdbPagoCash.TabIndex = 3;
            this.RdbPagoCash.TabStop = true;
            this.RdbPagoCash.UseVisualStyleBackColor = true;
            this.RdbPagoCash.CheckedChanged += new System.EventHandler(this.RdbPagoCash_CheckedChanged);
            // 
            // GrpMetodos
            // 
            this.GrpMetodos.Controls.Add(this.BtnAgregaTarjeta);
            this.GrpMetodos.Controls.Add(this.ImgTarjeta);
            this.GrpMetodos.Controls.Add(this.RdbPagoCash);
            this.GrpMetodos.Controls.Add(this.ImgCash);
            this.GrpMetodos.Controls.Add(this.RdbPagoTarjeta);
            this.GrpMetodos.Location = new System.Drawing.Point(17, 37);
            this.GrpMetodos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GrpMetodos.Name = "GrpMetodos";
            this.GrpMetodos.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GrpMetodos.Size = new System.Drawing.Size(509, 217);
            this.GrpMetodos.TabIndex = 4;
            this.GrpMetodos.TabStop = false;
            // 
            // BtnAgregaTarjeta
            // 
            this.BtnAgregaTarjeta.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAgregaTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAgregaTarjeta.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregaTarjeta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnAgregaTarjeta.Location = new System.Drawing.Point(41, 166);
            this.BtnAgregaTarjeta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnAgregaTarjeta.Name = "BtnAgregaTarjeta";
            this.BtnAgregaTarjeta.Size = new System.Drawing.Size(100, 41);
            this.BtnAgregaTarjeta.TabIndex = 4;
            this.BtnAgregaTarjeta.Text = "Agregar";
            this.BtnAgregaTarjeta.UseVisualStyleBackColor = false;
            this.BtnAgregaTarjeta.Click += new System.EventHandler(this.BtnAgregaTarjeta_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCancelar.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnCancelar.Location = new System.Drawing.Point(293, 535);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(106, 45);
            this.BtnCancelar.TabIndex = 6;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnPagar
            // 
            this.BtnPagar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPagar.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPagar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnPagar.Location = new System.Drawing.Point(165, 535);
            this.BtnPagar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnPagar.Name = "BtnPagar";
            this.BtnPagar.Size = new System.Drawing.Size(100, 45);
            this.BtnPagar.TabIndex = 7;
            this.BtnPagar.Text = "Pagar";
            this.BtnPagar.UseVisualStyleBackColor = false;
            this.BtnPagar.Click += new System.EventHandler(this.BtnPagar_Click);
            // 
            // TabTiposPago
            // 
            this.TabTiposPago.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabTiposPago.Controls.Add(this.TabTarjeta);
            this.TabTiposPago.Controls.Add(this.TabCash);
            this.TabTiposPago.Location = new System.Drawing.Point(13, 264);
            this.TabTiposPago.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabTiposPago.Name = "TabTiposPago";
            this.TabTiposPago.SelectedIndex = 0;
            this.TabTiposPago.Size = new System.Drawing.Size(513, 204);
            this.TabTiposPago.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabTiposPago.TabIndex = 0;
            // 
            // TabTarjeta
            // 
            this.TabTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(218)))), ((int)(((byte)(168)))));
            this.TabTarjeta.Controls.Add(this.LblMarca);
            this.TabTarjeta.Controls.Add(this.LblFecVencimiento);
            this.TabTarjeta.Controls.Add(this.LblNumTarjeta);
            this.TabTarjeta.Location = new System.Drawing.Point(4, 38);
            this.TabTarjeta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabTarjeta.Name = "TabTarjeta";
            this.TabTarjeta.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabTarjeta.Size = new System.Drawing.Size(505, 162);
            this.TabTarjeta.TabIndex = 0;
            // 
            // LblMarca
            // 
            this.LblMarca.AutoSize = true;
            this.LblMarca.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblMarca.Location = new System.Drawing.Point(9, 77);
            this.LblMarca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblMarca.Name = "LblMarca";
            this.LblMarca.Size = new System.Drawing.Size(75, 26);
            this.LblMarca.TabIndex = 3;
            this.LblMarca.Text = "Marca:";
            // 
            // LblFecVencimiento
            // 
            this.LblFecVencimiento.AutoSize = true;
            this.LblFecVencimiento.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFecVencimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblFecVencimiento.Location = new System.Drawing.Point(9, 122);
            this.LblFecVencimiento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblFecVencimiento.Name = "LblFecVencimiento";
            this.LblFecVencimiento.Size = new System.Drawing.Size(71, 26);
            this.LblFecVencimiento.TabIndex = 2;
            this.LblFecVencimiento.Text = "Fecha:";
            // 
            // LblNumTarjeta
            // 
            this.LblNumTarjeta.AutoSize = true;
            this.LblNumTarjeta.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblNumTarjeta.Location = new System.Drawing.Point(9, 29);
            this.LblNumTarjeta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNumTarjeta.Name = "LblNumTarjeta";
            this.LblNumTarjeta.Size = new System.Drawing.Size(92, 26);
            this.LblNumTarjeta.TabIndex = 1;
            this.LblNumTarjeta.Text = "Numero:";
            // 
            // TabCash
            // 
            this.TabCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(218)))), ((int)(((byte)(168)))));
            this.TabCash.Controls.Add(this.LblCash);
            this.TabCash.Location = new System.Drawing.Point(4, 38);
            this.TabCash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabCash.Name = "TabCash";
            this.TabCash.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabCash.Size = new System.Drawing.Size(505, 162);
            this.TabCash.TabIndex = 1;
            // 
            // LblCash
            // 
            this.LblCash.AutoSize = true;
            this.LblCash.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCash.Location = new System.Drawing.Point(142, 62);
            this.LblCash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCash.Name = "LblCash";
            this.LblCash.Size = new System.Drawing.Size(253, 40);
            this.LblCash.TabIndex = 0;
            this.LblCash.Text = "Pago en Efectivo";
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold);
            this.LblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblTotal.Location = new System.Drawing.Point(12, 473);
            this.LblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(141, 26);
            this.LblTotal.TabIndex = 8;
            this.LblTotal.Text = "Total a Pagar:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 511);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Pantalla Pago";
            // 
            // Pagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(218)))), ((int)(((byte)(168)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(551, 603);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.TabTiposPago);
            this.Controls.Add(this.BtnPagar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.GrpMetodos);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Pagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagar";
            ((System.ComponentModel.ISupportInitialize)(this.ImgTarjeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCash)).EndInit();
            this.GrpMetodos.ResumeLayout(false);
            this.GrpMetodos.PerformLayout();
            this.TabTiposPago.ResumeLayout(false);
            this.TabTarjeta.ResumeLayout(false);
            this.TabTarjeta.PerformLayout();
            this.TabCash.ResumeLayout(false);
            this.TabCash.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImgTarjeta;
        private System.Windows.Forms.PictureBox ImgCash;
        private System.Windows.Forms.RadioButton RdbPagoTarjeta;
        private System.Windows.Forms.RadioButton RdbPagoCash;
        private System.Windows.Forms.GroupBox GrpMetodos;
        private System.Windows.Forms.Button BtnAgregaTarjeta;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnPagar;
        private System.Windows.Forms.TabControl TabTiposPago;
        private System.Windows.Forms.TabPage TabTarjeta;
        private System.Windows.Forms.Label LblMarca;
        private System.Windows.Forms.Label LblFecVencimiento;
        private System.Windows.Forms.Label LblNumTarjeta;
        private System.Windows.Forms.TabPage TabCash;
        private System.Windows.Forms.Label LblCash;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}