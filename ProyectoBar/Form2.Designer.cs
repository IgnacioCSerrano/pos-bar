namespace ProyectoBar
{
    partial class Form2
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
            this.cbCamareros = new System.Windows.Forms.ComboBox();
            this.btnGenComision = new System.Windows.Forms.Button();
            this.btnCargarPedido = new System.Windows.Forms.Button();
            this.cbProductos = new System.Windows.Forms.ComboBox();
            this.tbIdProd = new System.Windows.Forms.TextBox();
            this.tbNombreProd = new System.Windows.Forms.TextBox();
            this.tbIdProv = new System.Windows.Forms.TextBox();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.tbStock = new System.Windows.Forms.TextBox();
            this.tbStockMin = new System.Windows.Forms.TextBox();
            this.pbImg = new System.Windows.Forms.PictureBox();
            this.labIdProd = new System.Windows.Forms.Label();
            this.labNombreProd = new System.Windows.Forms.Label();
            this.labIdProv = new System.Windows.Forms.Label();
            this.labPrecio = new System.Windows.Forms.Label();
            this.labStock = new System.Windows.Forms.Label();
            this.labStockMin = new System.Windows.Forms.Label();
            this.labImg = new System.Windows.Forms.Label();
            this.gbFormProd = new System.Windows.Forms.GroupBox();
            this.btnUpdateProd = new System.Windows.Forms.Button();
            this.btnAddProd = new System.Windows.Forms.Button();
            this.btnResetFormProd = new System.Windows.Forms.Button();
            this.btnUpdateCam = new System.Windows.Forms.Button();
            this.gbFormCam = new System.Windows.Forms.GroupBox();
            this.tbIdCam = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.tbNombreCam = new System.Windows.Forms.TextBox();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.labDNI = new System.Windows.Forms.Label();
            this.labNombreCam = new System.Windows.Forms.Label();
            this.labMail = new System.Windows.Forms.Label();
            this.labIdCam = new System.Windows.Forms.Label();
            this.btnAddCam = new System.Windows.Forms.Button();
            this.btnResetFormCam = new System.Windows.Forms.Button();
            this.btnCamQR = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageProd = new System.Windows.Forms.TabPage();
            this.tabPageCliente = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbFiles = new System.Windows.Forms.ComboBox();
            this.btnDownloadFTP = new System.Windows.Forms.Button();
            this.btnUploadFTP = new System.Windows.Forms.Button();
            this.btnImportProd = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
            this.gbFormProd.SuspendLayout();
            this.gbFormCam.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageProd.SuspendLayout();
            this.tabPageCliente.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCamareros
            // 
            this.cbCamareros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCamareros.FormattingEnabled = true;
            this.cbCamareros.Location = new System.Drawing.Point(19, 31);
            this.cbCamareros.Name = "cbCamareros";
            this.cbCamareros.Size = new System.Drawing.Size(100, 21);
            this.cbCamareros.TabIndex = 10;
            this.cbCamareros.SelectedIndexChanged += new System.EventHandler(this.cbCamareros_SelectedIndexChanged);
            // 
            // btnGenComision
            // 
            this.btnGenComision.Enabled = false;
            this.btnGenComision.Location = new System.Drawing.Point(253, 30);
            this.btnGenComision.Name = "btnGenComision";
            this.btnGenComision.Size = new System.Drawing.Size(147, 23);
            this.btnGenComision.TabIndex = 12;
            this.btnGenComision.Text = "Generar Informe Comisión";
            this.btnGenComision.UseVisualStyleBackColor = true;
            this.btnGenComision.Click += new System.EventHandler(this.btnGenComision_Click);
            // 
            // btnCargarPedido
            // 
            this.btnCargarPedido.Location = new System.Drawing.Point(453, 213);
            this.btnCargarPedido.Name = "btnCargarPedido";
            this.btnCargarPedido.Size = new System.Drawing.Size(90, 35);
            this.btnCargarPedido.TabIndex = 19;
            this.btnCargarPedido.Text = "Cargar Fichero Pedido";
            this.btnCargarPedido.UseVisualStyleBackColor = true;
            this.btnCargarPedido.Click += new System.EventHandler(this.btnCargarPedido_Click);
            // 
            // cbProductos
            // 
            this.cbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductos.FormattingEnabled = true;
            this.cbProductos.Location = new System.Drawing.Point(19, 31);
            this.cbProductos.Name = "cbProductos";
            this.cbProductos.Size = new System.Drawing.Size(150, 21);
            this.cbProductos.Sorted = true;
            this.cbProductos.TabIndex = 0;
            this.cbProductos.SelectedIndexChanged += new System.EventHandler(this.cbProductos_SelectedIndexChanged);
            // 
            // tbIdProd
            // 
            this.tbIdProd.Location = new System.Drawing.Point(6, 29);
            this.tbIdProd.Name = "tbIdProd";
            this.tbIdProd.Size = new System.Drawing.Size(120, 20);
            this.tbIdProd.TabIndex = 2;
            // 
            // tbNombreProd
            // 
            this.tbNombreProd.Location = new System.Drawing.Point(145, 29);
            this.tbNombreProd.Name = "tbNombreProd";
            this.tbNombreProd.Size = new System.Drawing.Size(120, 20);
            this.tbNombreProd.TabIndex = 3;
            // 
            // tbIdProv
            // 
            this.tbIdProv.Location = new System.Drawing.Point(283, 29);
            this.tbIdProv.Name = "tbIdProv";
            this.tbIdProv.Size = new System.Drawing.Size(120, 20);
            this.tbIdProv.TabIndex = 4;
            // 
            // tbPrecio
            // 
            this.tbPrecio.Location = new System.Drawing.Point(145, 78);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(120, 20);
            this.tbPrecio.TabIndex = 6;
            // 
            // tbStock
            // 
            this.tbStock.Location = new System.Drawing.Point(6, 78);
            this.tbStock.Name = "tbStock";
            this.tbStock.Size = new System.Drawing.Size(120, 20);
            this.tbStock.TabIndex = 5;
            // 
            // tbStockMin
            // 
            this.tbStockMin.Location = new System.Drawing.Point(283, 78);
            this.tbStockMin.Name = "tbStockMin";
            this.tbStockMin.Size = new System.Drawing.Size(120, 20);
            this.tbStockMin.TabIndex = 7;
            // 
            // pbImg
            // 
            this.pbImg.BackColor = System.Drawing.Color.White;
            this.pbImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImg.Location = new System.Drawing.Point(435, 29);
            this.pbImg.Margin = new System.Windows.Forms.Padding(0);
            this.pbImg.Name = "pbImg";
            this.pbImg.Padding = new System.Windows.Forms.Padding(20);
            this.pbImg.Size = new System.Drawing.Size(69, 69);
            this.pbImg.TabIndex = 13;
            this.pbImg.TabStop = false;
            this.pbImg.DoubleClick += new System.EventHandler(this.pbImg_DoubleClick);
            // 
            // labIdProd
            // 
            this.labIdProd.AutoSize = true;
            this.labIdProd.Location = new System.Drawing.Point(3, 13);
            this.labIdProd.Name = "labIdProd";
            this.labIdProd.Size = new System.Drawing.Size(18, 13);
            this.labIdProd.TabIndex = 14;
            this.labIdProd.Text = "ID";
            // 
            // labNombreProd
            // 
            this.labNombreProd.AutoSize = true;
            this.labNombreProd.Location = new System.Drawing.Point(142, 13);
            this.labNombreProd.Name = "labNombreProd";
            this.labNombreProd.Size = new System.Drawing.Size(44, 13);
            this.labNombreProd.TabIndex = 15;
            this.labNombreProd.Text = "Nombre";
            // 
            // labIdProv
            // 
            this.labIdProv.AutoSize = true;
            this.labIdProv.Location = new System.Drawing.Point(280, 13);
            this.labIdProv.Name = "labIdProv";
            this.labIdProv.Size = new System.Drawing.Size(70, 13);
            this.labIdProv.TabIndex = 16;
            this.labIdProv.Text = "ID Proveedor";
            // 
            // labPrecio
            // 
            this.labPrecio.AutoSize = true;
            this.labPrecio.Location = new System.Drawing.Point(142, 62);
            this.labPrecio.Name = "labPrecio";
            this.labPrecio.Size = new System.Drawing.Size(52, 13);
            this.labPrecio.TabIndex = 17;
            this.labPrecio.Text = "Precio (€)";
            // 
            // labStock
            // 
            this.labStock.AutoSize = true;
            this.labStock.Location = new System.Drawing.Point(3, 62);
            this.labStock.Name = "labStock";
            this.labStock.Size = new System.Drawing.Size(35, 13);
            this.labStock.TabIndex = 18;
            this.labStock.Text = "Stock";
            // 
            // labStockMin
            // 
            this.labStockMin.AutoSize = true;
            this.labStockMin.Location = new System.Drawing.Point(280, 62);
            this.labStockMin.Name = "labStockMin";
            this.labStockMin.Size = new System.Drawing.Size(73, 13);
            this.labStockMin.TabIndex = 19;
            this.labStockMin.Text = "Stock Mínimo";
            // 
            // labImg
            // 
            this.labImg.AutoSize = true;
            this.labImg.Location = new System.Drawing.Point(432, 13);
            this.labImg.Name = "labImg";
            this.labImg.Size = new System.Drawing.Size(42, 13);
            this.labImg.TabIndex = 20;
            this.labImg.Text = "Imagen";
            // 
            // gbFormProd
            // 
            this.gbFormProd.Controls.Add(this.tbIdProd);
            this.gbFormProd.Controls.Add(this.tbNombreProd);
            this.gbFormProd.Controls.Add(this.labStockMin);
            this.gbFormProd.Controls.Add(this.tbIdProv);
            this.gbFormProd.Controls.Add(this.labStock);
            this.gbFormProd.Controls.Add(this.tbPrecio);
            this.gbFormProd.Controls.Add(this.labPrecio);
            this.gbFormProd.Controls.Add(this.labImg);
            this.gbFormProd.Controls.Add(this.tbStock);
            this.gbFormProd.Controls.Add(this.pbImg);
            this.gbFormProd.Controls.Add(this.labIdProv);
            this.gbFormProd.Controls.Add(this.tbStockMin);
            this.gbFormProd.Controls.Add(this.labNombreProd);
            this.gbFormProd.Controls.Add(this.labIdProd);
            this.gbFormProd.Location = new System.Drawing.Point(19, 59);
            this.gbFormProd.Name = "gbFormProd";
            this.gbFormProd.Size = new System.Drawing.Size(509, 114);
            this.gbFormProd.TabIndex = 21;
            this.gbFormProd.TabStop = false;
            // 
            // btnUpdateProd
            // 
            this.btnUpdateProd.Enabled = false;
            this.btnUpdateProd.Location = new System.Drawing.Point(175, 29);
            this.btnUpdateProd.Name = "btnUpdateProd";
            this.btnUpdateProd.Size = new System.Drawing.Size(109, 23);
            this.btnUpdateProd.TabIndex = 1;
            this.btnUpdateProd.Text = "Actualizar Producto";
            this.btnUpdateProd.UseVisualStyleBackColor = true;
            this.btnUpdateProd.Click += new System.EventHandler(this.btnUpdateProd_Click);
            // 
            // btnAddProd
            // 
            this.btnAddProd.Location = new System.Drawing.Point(19, 177);
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(120, 23);
            this.btnAddProd.TabIndex = 8;
            this.btnAddProd.Text = "Añadir Producto";
            this.btnAddProd.UseVisualStyleBackColor = true;
            this.btnAddProd.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // btnResetFormProd
            // 
            this.btnResetFormProd.Location = new System.Drawing.Point(467, 29);
            this.btnResetFormProd.Name = "btnResetFormProd";
            this.btnResetFormProd.Size = new System.Drawing.Size(61, 23);
            this.btnResetFormProd.TabIndex = 9;
            this.btnResetFormProd.Text = "Reset";
            this.btnResetFormProd.UseVisualStyleBackColor = true;
            this.btnResetFormProd.Click += new System.EventHandler(this.btnResetFormProd_Click);
            // 
            // btnUpdateCam
            // 
            this.btnUpdateCam.Enabled = false;
            this.btnUpdateCam.Location = new System.Drawing.Point(125, 30);
            this.btnUpdateCam.Name = "btnUpdateCam";
            this.btnUpdateCam.Size = new System.Drawing.Size(120, 23);
            this.btnUpdateCam.TabIndex = 11;
            this.btnUpdateCam.Text = "Actualizar Camarero";
            this.btnUpdateCam.UseVisualStyleBackColor = true;
            this.btnUpdateCam.Click += new System.EventHandler(this.btnUpdateCam_Click);
            // 
            // gbFormCam
            // 
            this.gbFormCam.Controls.Add(this.tbIdCam);
            this.gbFormCam.Controls.Add(this.tbMail);
            this.gbFormCam.Controls.Add(this.tbNombreCam);
            this.gbFormCam.Controls.Add(this.tbDni);
            this.gbFormCam.Controls.Add(this.labDNI);
            this.gbFormCam.Controls.Add(this.labNombreCam);
            this.gbFormCam.Controls.Add(this.labMail);
            this.gbFormCam.Controls.Add(this.labIdCam);
            this.gbFormCam.Location = new System.Drawing.Point(19, 59);
            this.gbFormCam.Name = "gbFormCam";
            this.gbFormCam.Size = new System.Drawing.Size(509, 64);
            this.gbFormCam.TabIndex = 22;
            this.gbFormCam.TabStop = false;
            // 
            // tbIdCam
            // 
            this.tbIdCam.Location = new System.Drawing.Point(6, 29);
            this.tbIdCam.Name = "tbIdCam";
            this.tbIdCam.Size = new System.Drawing.Size(120, 20);
            this.tbIdCam.TabIndex = 13;
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(258, 29);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(120, 20);
            this.tbMail.TabIndex = 15;
            // 
            // tbNombreCam
            // 
            this.tbNombreCam.Location = new System.Drawing.Point(132, 29);
            this.tbNombreCam.Name = "tbNombreCam";
            this.tbNombreCam.Size = new System.Drawing.Size(120, 20);
            this.tbNombreCam.TabIndex = 14;
            // 
            // tbDni
            // 
            this.tbDni.Location = new System.Drawing.Point(384, 29);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(120, 20);
            this.tbDni.TabIndex = 16;
            // 
            // labDNI
            // 
            this.labDNI.AutoSize = true;
            this.labDNI.Location = new System.Drawing.Point(381, 13);
            this.labDNI.Name = "labDNI";
            this.labDNI.Size = new System.Drawing.Size(26, 13);
            this.labDNI.TabIndex = 17;
            this.labDNI.Text = "DNI";
            // 
            // labNombreCam
            // 
            this.labNombreCam.AutoSize = true;
            this.labNombreCam.Location = new System.Drawing.Point(129, 13);
            this.labNombreCam.Name = "labNombreCam";
            this.labNombreCam.Size = new System.Drawing.Size(44, 13);
            this.labNombreCam.TabIndex = 16;
            this.labNombreCam.Text = "Nombre";
            // 
            // labMail
            // 
            this.labMail.AutoSize = true;
            this.labMail.Location = new System.Drawing.Point(255, 13);
            this.labMail.Name = "labMail";
            this.labMail.Size = new System.Drawing.Size(32, 13);
            this.labMail.TabIndex = 15;
            this.labMail.Text = "Email";
            // 
            // labIdCam
            // 
            this.labIdCam.AutoSize = true;
            this.labIdCam.Location = new System.Drawing.Point(3, 13);
            this.labIdCam.Name = "labIdCam";
            this.labIdCam.Size = new System.Drawing.Size(18, 13);
            this.labIdCam.TabIndex = 14;
            this.labIdCam.Text = "ID";
            // 
            // btnAddCam
            // 
            this.btnAddCam.Location = new System.Drawing.Point(19, 129);
            this.btnAddCam.Name = "btnAddCam";
            this.btnAddCam.Size = new System.Drawing.Size(120, 23);
            this.btnAddCam.TabIndex = 17;
            this.btnAddCam.Text = "Añadir Camarero";
            this.btnAddCam.UseVisualStyleBackColor = true;
            this.btnAddCam.Click += new System.EventHandler(this.btnAddCam_Click);
            // 
            // btnResetFormCam
            // 
            this.btnResetFormCam.Location = new System.Drawing.Point(467, 29);
            this.btnResetFormCam.Name = "btnResetFormCam";
            this.btnResetFormCam.Size = new System.Drawing.Size(61, 23);
            this.btnResetFormCam.TabIndex = 18;
            this.btnResetFormCam.Text = "Reset";
            this.btnResetFormCam.UseVisualStyleBackColor = true;
            this.btnResetFormCam.Click += new System.EventHandler(this.btnResetFormCam_Click);
            // 
            // btnCamQR
            // 
            this.btnCamQR.Location = new System.Drawing.Point(453, 213);
            this.btnCamQR.Name = "btnCamQR";
            this.btnCamQR.Size = new System.Drawing.Size(90, 35);
            this.btnCamQR.TabIndex = 23;
            this.btnCamQR.Text = "Generar QR Camareros";
            this.btnCamQR.UseVisualStyleBackColor = true;
            this.btnCamQR.Click += new System.EventHandler(this.btnCamQR_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageProd);
            this.tabControl.Controls.Add(this.tabPageCliente);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(13, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(557, 280);
            this.tabControl.TabIndex = 24;
            // 
            // tabPageProd
            // 
            this.tabPageProd.Controls.Add(this.gbFormProd);
            this.tabPageProd.Controls.Add(this.btnCargarPedido);
            this.tabPageProd.Controls.Add(this.cbProductos);
            this.tabPageProd.Controls.Add(this.btnUpdateProd);
            this.tabPageProd.Controls.Add(this.btnAddProd);
            this.tabPageProd.Controls.Add(this.btnResetFormProd);
            this.tabPageProd.Location = new System.Drawing.Point(4, 22);
            this.tabPageProd.Name = "tabPageProd";
            this.tabPageProd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProd.Size = new System.Drawing.Size(549, 254);
            this.tabPageProd.TabIndex = 0;
            this.tabPageProd.Text = "Producto";
            this.tabPageProd.UseVisualStyleBackColor = true;
            // 
            // tabPageCliente
            // 
            this.tabPageCliente.Controls.Add(this.btnCamQR);
            this.tabPageCliente.Controls.Add(this.cbCamareros);
            this.tabPageCliente.Controls.Add(this.btnResetFormCam);
            this.tabPageCliente.Controls.Add(this.btnGenComision);
            this.tabPageCliente.Controls.Add(this.btnAddCam);
            this.tabPageCliente.Controls.Add(this.btnUpdateCam);
            this.tabPageCliente.Controls.Add(this.gbFormCam);
            this.tabPageCliente.Location = new System.Drawing.Point(4, 22);
            this.tabPageCliente.Name = "tabPageCliente";
            this.tabPageCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCliente.Size = new System.Drawing.Size(549, 254);
            this.tabPageCliente.TabIndex = 1;
            this.tabPageCliente.Text = "Camarero";
            this.tabPageCliente.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbFiles);
            this.tabPage1.Controls.Add(this.btnDownloadFTP);
            this.tabPage1.Controls.Add(this.btnUploadFTP);
            this.tabPage1.Controls.Add(this.btnImportProd);
            this.tabPage1.Controls.Add(this.btnBackup);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(549, 254);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Backup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbFiles
            // 
            this.cbFiles.FormattingEnabled = true;
            this.cbFiles.Location = new System.Drawing.Point(6, 102);
            this.cbFiles.Name = "cbFiles";
            this.cbFiles.Size = new System.Drawing.Size(150, 21);
            this.cbFiles.TabIndex = 4;
            // 
            // btnDownloadFTP
            // 
            this.btnDownloadFTP.Location = new System.Drawing.Point(162, 101);
            this.btnDownloadFTP.Name = "btnDownloadFTP";
            this.btnDownloadFTP.Size = new System.Drawing.Size(129, 23);
            this.btnDownloadFTP.TabIndex = 3;
            this.btnDownloadFTP.Text = "Descargar Archivo FTP";
            this.btnDownloadFTP.UseVisualStyleBackColor = true;
            this.btnDownloadFTP.Click += new System.EventHandler(this.btnDownloadFTP_Click);
            // 
            // btnUploadFTP
            // 
            this.btnUploadFTP.Location = new System.Drawing.Point(6, 67);
            this.btnUploadFTP.Name = "btnUploadFTP";
            this.btnUploadFTP.Size = new System.Drawing.Size(106, 23);
            this.btnUploadFTP.TabIndex = 2;
            this.btnUploadFTP.Text = "Subir Archivo FTP";
            this.btnUploadFTP.UseVisualStyleBackColor = true;
            this.btnUploadFTP.Click += new System.EventHandler(this.btnUploadFTP_Click);
            // 
            // btnImportProd
            // 
            this.btnImportProd.Location = new System.Drawing.Point(434, 6);
            this.btnImportProd.Name = "btnImportProd";
            this.btnImportProd.Size = new System.Drawing.Size(109, 34);
            this.btnImportProd.TabIndex = 1;
            this.btnImportProd.Text = "Importar productos desde archivo";
            this.btnImportProd.UseVisualStyleBackColor = true;
            this.btnImportProd.Click += new System.EventHandler(this.btnImportProd_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(6, 6);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(106, 34);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "Copia Seguridad Base Datos";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 307);
            this.Controls.Add(this.tabControl);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana de gestión";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
            this.gbFormProd.ResumeLayout(false);
            this.gbFormProd.PerformLayout();
            this.gbFormCam.ResumeLayout(false);
            this.gbFormCam.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageProd.ResumeLayout(false);
            this.tabPageCliente.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCamareros;
        private System.Windows.Forms.Button btnGenComision;
        private System.Windows.Forms.Button btnCargarPedido;
        private System.Windows.Forms.ComboBox cbProductos;
        private System.Windows.Forms.TextBox tbIdProd;
        private System.Windows.Forms.TextBox tbNombreProd;
        private System.Windows.Forms.TextBox tbIdProv;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.TextBox tbStock;
        private System.Windows.Forms.TextBox tbStockMin;
        private System.Windows.Forms.PictureBox pbImg;
        private System.Windows.Forms.Label labIdProd;
        private System.Windows.Forms.Label labNombreProd;
        private System.Windows.Forms.Label labIdProv;
        private System.Windows.Forms.Label labPrecio;
        private System.Windows.Forms.Label labStock;
        private System.Windows.Forms.Label labStockMin;
        private System.Windows.Forms.Label labImg;
        private System.Windows.Forms.GroupBox gbFormProd;
        private System.Windows.Forms.Button btnUpdateProd;
        private System.Windows.Forms.Button btnAddProd;
        private System.Windows.Forms.Button btnResetFormProd;
        private System.Windows.Forms.Button btnUpdateCam;
        private System.Windows.Forms.GroupBox gbFormCam;
        private System.Windows.Forms.TextBox tbIdCam;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.TextBox tbNombreCam;
        private System.Windows.Forms.TextBox tbDni;
        private System.Windows.Forms.Label labDNI;
        private System.Windows.Forms.Label labNombreCam;
        private System.Windows.Forms.Label labMail;
        private System.Windows.Forms.Label labIdCam;
        private System.Windows.Forms.Button btnAddCam;
        private System.Windows.Forms.Button btnResetFormCam;
        private System.Windows.Forms.Button btnCamQR;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageProd;
        private System.Windows.Forms.TabPage tabPageCliente;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnImportProd;
        private System.Windows.Forms.Button btnUploadFTP;
        private System.Windows.Forms.Button btnDownloadFTP;
        private System.Windows.Forms.ComboBox cbFiles;
    }
}