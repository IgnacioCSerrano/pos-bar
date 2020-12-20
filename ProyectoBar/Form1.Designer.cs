namespace ProyectoBar
{
    partial class FormTPV
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flpProducto = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.labN = new System.Windows.Forms.Label();
            this.labP = new System.Windows.Forms.Label();
            this.labS = new System.Windows.Forms.Label();
            this.labNombre = new System.Windows.Forms.Label();
            this.labPrecio = new System.Windows.Forms.Label();
            this.labStock = new System.Windows.Forms.Label();
            this.dgvCesta = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labTotal = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.panelTPV = new System.Windows.Forms.Panel();
            this.btnGestion = new System.Windows.Forms.Button();
            this.dgvHidden = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labCamarero = new System.Windows.Forms.Label();
            this.labC = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labClock = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCesta)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.panelTPV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHidden)).BeginInit();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpProducto
            // 
            this.flpProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flpProducto.AutoSize = true;
            this.flpProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpProducto.Location = new System.Drawing.Point(270, 3);
            this.flpProducto.Name = "flpProducto";
            this.flpProducto.Size = new System.Drawing.Size(0, 193);
            this.flpProducto.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(735, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // labN
            // 
            this.labN.AutoSize = true;
            this.labN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labN.Location = new System.Drawing.Point(598, 26);
            this.labN.Name = "labN";
            this.labN.Size = new System.Drawing.Size(54, 13);
            this.labN.TabIndex = 2;
            this.labN.Text = "Nombre:";
            // 
            // labP
            // 
            this.labP.AutoSize = true;
            this.labP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labP.Location = new System.Drawing.Point(598, 66);
            this.labP.Name = "labP";
            this.labP.Size = new System.Drawing.Size(47, 13);
            this.labP.TabIndex = 3;
            this.labP.Text = "Precio:";
            // 
            // labS
            // 
            this.labS.AutoSize = true;
            this.labS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labS.Location = new System.Drawing.Point(598, 106);
            this.labS.Name = "labS";
            this.labS.Size = new System.Drawing.Size(44, 13);
            this.labS.TabIndex = 4;
            this.labS.Text = "Stock:";
            // 
            // labNombre
            // 
            this.labNombre.AutoSize = true;
            this.labNombre.Location = new System.Drawing.Point(658, 26);
            this.labNombre.Name = "labNombre";
            this.labNombre.Size = new System.Drawing.Size(86, 13);
            this.labNombre.TabIndex = 5;
            this.labNombre.Text = "PLACEHOLDER";
            // 
            // labPrecio
            // 
            this.labPrecio.AutoSize = true;
            this.labPrecio.Location = new System.Drawing.Point(658, 66);
            this.labPrecio.Name = "labPrecio";
            this.labPrecio.Size = new System.Drawing.Size(86, 13);
            this.labPrecio.TabIndex = 6;
            this.labPrecio.Text = "PLACEHOLDER";
            // 
            // labStock
            // 
            this.labStock.AutoSize = true;
            this.labStock.Location = new System.Drawing.Point(658, 106);
            this.labStock.Name = "labStock";
            this.labStock.Size = new System.Drawing.Size(86, 13);
            this.labStock.TabIndex = 7;
            this.labStock.Text = "PLACEHOLDER";
            // 
            // dgvCesta
            // 
            this.dgvCesta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCesta.Location = new System.Drawing.Point(3, 221);
            this.dgvCesta.Name = "dgvCesta";
            this.dgvCesta.Size = new System.Drawing.Size(540, 133);
            this.dgvCesta.TabIndex = 8;
            this.dgvCesta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFactura_CellDoubleClick);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.flpProducto, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(540, 199);
            this.tableLayoutPanel.TabIndex = 9;
            // 
            // labTotal
            // 
            this.labTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTotal.Location = new System.Drawing.Point(548, 323);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(248, 31);
            this.labTotal.TabIndex = 10;
            this.labTotal.Text = "0,00 €";
            this.labTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(720, 179);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 23);
            this.btnFacturar.TabIndex = 11;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // panelTPV
            // 
            this.panelTPV.Controls.Add(this.btnGestion);
            this.panelTPV.Controls.Add(this.tableLayoutPanel);
            this.panelTPV.Controls.Add(this.labTotal);
            this.panelTPV.Controls.Add(this.btnFacturar);
            this.panelTPV.Controls.Add(this.dgvCesta);
            this.panelTPV.Controls.Add(this.labN);
            this.panelTPV.Controls.Add(this.labP);
            this.panelTPV.Controls.Add(this.labS);
            this.panelTPV.Controls.Add(this.labStock);
            this.panelTPV.Controls.Add(this.labNombre);
            this.panelTPV.Controls.Add(this.labPrecio);
            this.panelTPV.Controls.Add(this.dgvHidden);
            this.panelTPV.Enabled = false;
            this.panelTPV.Location = new System.Drawing.Point(12, 47);
            this.panelTPV.Name = "panelTPV";
            this.panelTPV.Size = new System.Drawing.Size(798, 357);
            this.panelTPV.TabIndex = 12;
            // 
            // btnGestion
            // 
            this.btnGestion.Location = new System.Drawing.Point(720, 221);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(75, 23);
            this.btnGestion.TabIndex = 13;
            this.btnGestion.Text = "Gestión";
            this.btnGestion.UseVisualStyleBackColor = true;
            this.btnGestion.Visible = false;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // dgvHidden
            // 
            this.dgvHidden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHidden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHidden.Location = new System.Drawing.Point(3, 286);
            this.dgvHidden.Name = "dgvHidden";
            this.dgvHidden.Size = new System.Drawing.Size(540, 10);
            this.dgvHidden.TabIndex = 12;
            this.dgvHidden.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "DNI";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(41, 6);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(150, 20);
            this.tbDNI.TabIndex = 14;
            this.tbDNI.UseSystemPasswordChar = true;
            this.tbDNI.TextChanged += new System.EventHandler(this.tbDNI_TextChanged);
            this.tbDNI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDNI_KeyDown);
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.tbDNI);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Location = new System.Drawing.Point(12, 9);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(210, 32);
            this.panelLogin.TabIndex = 16;
            // 
            // labCamarero
            // 
            this.labCamarero.AutoSize = true;
            this.labCamarero.Location = new System.Drawing.Point(317, 17);
            this.labCamarero.Name = "labCamarero";
            this.labCamarero.Size = new System.Drawing.Size(86, 13);
            this.labCamarero.TabIndex = 12;
            this.labCamarero.Text = "PLACEHOLDER";
            // 
            // labC
            // 
            this.labC.AutoSize = true;
            this.labC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labC.Location = new System.Drawing.Point(247, 17);
            this.labC.Name = "labC";
            this.labC.Size = new System.Drawing.Size(64, 13);
            this.labC.TabIndex = 15;
            this.labC.Text = "Camarero:";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(633, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(96, 23);
            this.btnLogout.TabIndex = 17;
            this.btnLogout.Text = "Cerrar sesión";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Visible = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labClock
            // 
            this.labClock.AutoSize = true;
            this.labClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labClock.Location = new System.Drawing.Point(523, 11);
            this.labClock.Name = "labClock";
            this.labClock.Size = new System.Drawing.Size(104, 25);
            this.labClock.TabIndex = 18;
            this.labClock.Text = "00:00:00";
            // 
            // FormTPV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 416);
            this.ControlBox = false;
            this.Controls.Add(this.labClock);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.labCamarero);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.labC);
            this.Controls.Add(this.panelTPV);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormTPV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TPV Bar";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCesta)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panelTPV.ResumeLayout(false);
            this.panelTPV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHidden)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpProducto;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label labN;
        private System.Windows.Forms.Label labP;
        private System.Windows.Forms.Label labS;
        private System.Windows.Forms.Label labNombre;
        private System.Windows.Forms.Label labPrecio;
        private System.Windows.Forms.Label labStock;
        private System.Windows.Forms.DataGridView dgvCesta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labTotal;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Panel panelTPV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label labCamarero;
        private System.Windows.Forms.Label labC;
        private System.Windows.Forms.DataGridView dgvHidden;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labClock;
        private System.Windows.Forms.Button btnGestion;
    }
}

