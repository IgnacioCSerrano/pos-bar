using IronBarCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBar
{
    public partial class Form2 : Form
    {
        FormTPV mainForm;
        List<Producto> productos;
        List<Camarero> camareros = new List<Camarero>();
        List<Facturacion> facturacion = new List<Facturacion>();

        /*
           Crear cuenta hosting gratuita:   https://go.runhosting.com/  
           Añadir subdominio:               Hosting Tools -> Domain Manager
           Crear cuenta FTP:                Hosting Tools -> FTP Manager
           Ver archivos subidos:            Hosting Tools -> File Manager

           Inicio sesión (Client ID 3647206):   https://cp1.runhosting.com/login/
        */

        private string baseUri = "ftp://nachodam.atwebpages.com/";
        private string username = "3647206_Nacho";
        private string password = "PAPIpapito123";

        public Form2(FormTPV mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.productos = mainForm.Productos;
            pbImg.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            mainForm.Conexion.GetCamareros(camareros);
            CargarComboBoxCamareros();
            CargarComboBoxProductos();
            CargarComboBoxFicheros();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mainForm.CargarContenidoTPV();
        }

        private void CargarComboBoxProductos()
        {
            cbProductos.Items.Clear();
            foreach (Producto p in productos)
            {
                cbProductos.Items.Add(p.Nombre);
            }
        }

        private void CargarComboBoxCamareros()
        {
            cbCamareros.Items.Clear();
            foreach (Camarero c in camareros)
            {
                cbCamareros.Items.Add(c.Id);
            }
        }

        private void CargarComboBoxFicheros()
        {
            cbFiles.Items.Clear();
            List<string> files = GetListFiles();
            files.RemoveRange(0, 2); // removes "." and ".." (first and second items)
            foreach (string file in files)
            {
                cbFiles.Items.Add(file);
            }
        }

        private bool IsEmptyField(GroupBox gb)
        {
            foreach (Control ctrl in gb.Controls)
            {
                if (ctrl is TextBox && ctrl.Text == "")
                {
                    return true;
                }
            }
            return false;
        }

        private void ResetFormProd()
        {
            foreach (Control ctrl in gbFormProd.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Clear();
                }
            }
            pbImg.Image = null;
            cbProductos.SelectedIndex = -1;
            btnUpdateProd.Enabled = false;
            btnAddProd.Enabled = true;
            tbIdProd.Enabled = true;
            tbIdProd.Focus();
        }

        private Bitmap GetResizedBitmap(Image img)
        {
            Bitmap pic = null;
            if (img.Height / img.Width > 0)
            {
                pic = new Bitmap(img, ((pbImg.Height - 10) * img.Width / img.Height), pbImg.Height - 10);
            }
            else
            {
                pic = new Bitmap(img, pbImg.Width - 10, ((pbImg.Width - 10) * img.Height / img.Width));
            }
            return pic;
        }

        private void cbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                Producto producto = mainForm.Productos.Find(p => p.Nombre == cbProductos.Text);
                tbIdProd.Text = producto.Id.ToString();
                tbNombreProd.Text = producto.Nombre;
                tbIdProv.Text = producto.IdProveedor.ToString();
                tbPrecio.Text = producto.Precio.ToString();
                tbStock.Text = producto.Stock.ToString();
                tbStockMin.Text = producto.StockMinimo.ToString();
                pbImg.Image = GetResizedBitmap(Image.FromStream(new MemoryStream(producto.Imagen)));

                btnUpdateProd.Enabled = true;
                tbIdProd.Enabled = false;
                btnAddProd.Enabled = false;
            }
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            if (imageIn == null)
            {
                return null;
            }
            var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private void pbImg_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Seleccione una imagen para el producto";
                openFile.Filter = "Image Files (*.jpg,*.jpeg,*.png)|*.jpg;*.jpeg;*.png|All Files (*.*)|*.*";
                openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    pbImg.Image = GetResizedBitmap(Image.FromFile(openFile.FileName));
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Fichero seleccionado no tiene formato de de imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetFormProd_Click(object sender, EventArgs e)
        {
            ResetFormProd();
        }

        private Producto GetFormProd()
        {
            Producto p = new Producto();
            p.Id = Convert.ToInt32(tbIdProd.Text);
            p.Nombre = tbNombreProd.Text;
            p.IdProveedor = Convert.ToInt32(tbIdProv.Text);
            p.Precio = Convert.ToSingle(tbPrecio.Text);
            p.Stock = Convert.ToInt32(tbStock.Text);
            p.StockMinimo = Convert.ToInt32(tbStockMin.Text);
            p.Imagen = ImageToByteArray(pbImg.Image);
            return p;
        }

        private void btnUpdateProd_Click(object sender, EventArgs e)
        {
            if (cbProductos.Text == "")
            {
                MessageBox.Show("Seleccione un producto de la lista.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (IsEmptyField(gbFormProd))
            {
                MessageBox.Show("Rellene todos los campos del formulario.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Producto p = GetFormProd();
                    if (mainForm.Conexion.UpdateProducto(p) == 1)
                    {
                        MessageBox.Show("Producto actualizado correctamente.", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainForm.Conexion.GetProductos(productos);
                        CargarComboBoxProductos();
                        ResetFormProd();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Formato de datos incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            if (IsEmptyField(gbFormProd))
            {
                MessageBox.Show("Rellene todos los campos del formulario.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (pbImg.Image == null)
            {
                MessageBox.Show("Seleccione una imagen desde su dispositivo local haciendo doble clic en el cuadrado de imagen.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Producto p = GetFormProd();
                    if (mainForm.Conexion.InsertProducto(p, true) == 1)
                    {
                        MessageBox.Show("Producto creado correctamente.", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mainForm.Conexion.GetProductos(productos);
                        CargarComboBoxProductos();
                        ResetFormProd();
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Formato de datos incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGenComision_Click(object sender, EventArgs e)
        {
            if (cbCamareros.Text != "")
            {
                Camarero camarero = camareros.Find(c => c.Id == Convert.ToInt32(cbCamareros.Text));
                facturacion.Clear();
                mainForm.Conexion.GetFacturacionCamarero(facturacion, camarero);
                mainForm.ImprimirInforme(facturacion, camarero);
                ResetFormCam();
                MessageBox.Show("Operación finalizada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un camarero de la lista", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ResetFormCam()
        {
            foreach (Control ctrl in gbFormCam.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Clear();
                }
            }
            cbCamareros.SelectedIndex = -1;
            btnUpdateCam.Enabled = false;
            btnGenComision.Enabled = false;
            btnAddCam.Enabled = true;
            tbIdCam.Enabled = true;
            tbIdCam.Focus();
        }

        private void cbCamareros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                Camarero camarero = camareros.Find(c => c.Id == Convert.ToInt32(cbCamareros.Text));
                tbIdCam.Text = camarero.Id.ToString();
                tbNombreCam.Text = camarero.Nombre;
                tbMail.Text = camarero.Mail;
                tbDni.Text = camarero.Dni;

                tbIdCam.Enabled = false;
                btnAddCam.Enabled = false;
                btnUpdateCam.Enabled = true;
                btnGenComision.Enabled = true;
            }
        }

        private void btnResetFormCam_Click(object sender, EventArgs e)
        {
            ResetFormCam();
        }

        private Camarero GetFormCam()
        {
            Camarero c = new Camarero();
            c.Id = Convert.ToInt32(tbIdCam.Text);
            c.Nombre = tbNombreCam.Text;
            c.Mail = tbMail.Text;
            c.Dni = tbDni.Text;
            return c;
        }

        private void btnUpdateCam_Click(object sender, EventArgs e)
        {
            if (cbCamareros.Text == "")
            {
                MessageBox.Show("Seleccione un camarero de la lista.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (IsEmptyField(gbFormCam))
            {
                MessageBox.Show("Rellene todos los campos del formulario.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Camarero c = GetFormCam();
                if (mainForm.Conexion.UpdateCamarero(c) == 1)
                {
                    MessageBox.Show("Camarero actualizado correctamente.", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm.Conexion.GetCamareros(camareros);
                    CargarComboBoxCamareros();
                    ResetFormCam();
                }
            }
        }

        private void btnAddCam_Click(object sender, EventArgs e)
        {
            if (IsEmptyField(gbFormCam))
            {
                MessageBox.Show("Rellene todos los campos del formulario.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Camarero c = GetFormCam();
                if (mainForm.Conexion.InsertCamarero(c) == 1)
                {
                    MessageBox.Show("Camarero creado correctamente.", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mainForm.Conexion.GetCamareros(camareros);
                    CargarComboBoxCamareros();
                    ResetFormCam();
                }
            }
        }

        private void btnCargarPedido_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Seleccione el fichero de datos";
            openFile.Filter = "Data Files (*.txt,*.sql,*.csv)|*.sql;*.txt;*.csv|All files (*.*)|*.*";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFile.FileName;
                StreamReader sr = new StreamReader(fileName);
                while (sr.Peek() != -1)
                {
                    string linea = sr.ReadLine();
                    string[] campos = linea.Split(',');
                    if (mainForm.Conexion.ActualizarProducto(campos) == 1)
                    {
                        MessageBox.Show("Almacén actualizado con éxito.", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnCamQR_Click(object sender, EventArgs e)
        {
            foreach (Camarero c in camareros)
            {
                BarcodeWriter.CreateBarcode(c.Dni, BarcodeWriterEncoding.QRCode).SaveAsPng(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/barcodes/camareros/" + c.Mail + " .png");
            }
            MessageBox.Show("Operación finalizada.", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            mainForm.Conexion.ExportarSQL();
            mainForm.Conexion.ImportarSQL();
            MessageBox.Show("Operación finalizada.", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string Serializar()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Seleccione un fichero para volcar datos";
            openFile.Filter = "Data Files (*.bin,*.dat,*.obj)|*.bin;*.dat;*.obj|All Files (*.*)|*.*";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFile.FileName, FileMode.Create);
                //FileStream fs = new FileStream(@"C:\datos.dat", FileMode.Create); // fichero datos.dat tiene que existir
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, productos);
                fs.Close();
                return openFile.FileName;
            }
            return "";
        }

        private List<Producto> Deserializar(string archivo)
        {
            FileStream fs = new FileStream(archivo, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<Producto> list = bf.Deserialize(fs) as List<Producto>;
            fs.Close();
            return list;
        }

        private void VolcarProductoBD(string file)
        {
            foreach (Producto p in Deserializar(file))
            //foreach (Producto p in Deserializar(@"C:\datos.dat"))
            {
                mainForm.Conexion.InsertProducto(p, false);
            }
        }

        private void btnImportProd_Click(object sender, EventArgs e)
        {
            string file = Serializar();
            if (file != "")
            {
                VolcarProductoBD(file);
                MessageBox.Show("Operación finalizada.", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUploadFTP_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Seleccione el fichero que desea subir";
            //openFile.Filter = "Data Files (*.bin,*.dat,*.obj)|*.bin;*.dat;*.obj|All Files (*.*)|*.*";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string documento = openFile.FileName;

                //Objeto necesario para conectar con el servidor

                //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(baseUri + documento.Substring(documento.LastIndexOf("\\") + 1));

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(baseUri + openFile.SafeFileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                //Credenciales para conectar con el servidor: user y password
                request.Credentials = new NetworkCredential(username, password);
                         
                //Información del fichero
                FileInfo fileInf = new FileInfo(documento);
                //Tipo de dato de la transferencia
                request.UseBinary = true;
                //Notificación del tamaño del fichero al servidor
                request.ContentLength = fileInf.Length;
                //Tamaño de bloques de memoria almacenados en buffer (establecemos 2kB pero podría ser cualquier otro valor)
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;
                //Apertura de Stream (System.IO.FileStream) para leer el fichero a subir.
                FileStream fs = fileInf.OpenRead();
                try
                {
                    //Objeto Stream para escribir los bloques en el servidor
                    Stream strm = request.GetRequestStream();
                    //Establecimiento de número de bloques de buffer de memoria
                    contentLen = fs.Read(buff, 0, buffLength);
                    //Mientras no llegues al final de los bloques
                    while (contentLen != 0)
                    {
                        // Escritura de contenido del fichero del buffer hacia Stream de servidor.
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                    }
                    strm.Close();
                    fs.Close();
                    CargarComboBoxFicheros();
                    MessageBox.Show("Operación finalizada.", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al subir fichero");
                }
            }
        }

        private List<string> GetListFiles()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(baseUri);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            request.Credentials = new NetworkCredential(username, password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string names = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private void btnDownloadFTP_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            openFolder.Description = "Seleccione la carpeta de destino";
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(baseUri + cbFiles.Text);
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.Credentials = new NetworkCredential(username, password);

                    Stream reader = request.GetResponse().GetResponseStream();
                    //FileStream fileStream = new FileStream(Environment.CurrentDirectory + "/" + cbFiles.Text, FileMode.Create);
                    FileStream fileStream = new FileStream(openFolder.SelectedPath + "/" + cbFiles.Text, FileMode.Create);

                    // We download data from the file in the form of chunks using byte array, reading the data of memory blocks of 2048 bytes (could be 1024, 4096 or any other numeric portion) into the buffer on each loop iteration.
                    byte[] buffer = new byte[2048];

                    //int bytesRead;
                    //do
                    //{
                    //    bytesRead = reader.Read(buffer, 0, buffer.Length);
                    //    fileStream.Write(buffer, 0, bytesRead);
                    //}
                    //while (bytesRead != 0);

                    int bytesRead = reader.Read(buffer, 0, buffer.Length);
                    while (bytesRead != 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                        bytesRead = reader.Read(buffer, 0, buffer.Length);
                    }

                    fileStream.Close();
                    MessageBox.Show("Operación finalizada.", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cbFiles.Text = "";
                }
            }
        }

    }
}
