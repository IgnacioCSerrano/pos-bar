using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBar
{
    public partial class FormTPV : Form
    {
        Conexion conexion;
        List<Producto> productos = new List<Producto>();
        List<Proveedor> proveedores = new List<Proveedor>();
        List<Producto> cesta = new List<Producto>();
        List<Facturacion> facturacion = new List<Facturacion>();
        Camarero camarero = null;
        float total = 0;
        DateTime ahora;

        string user_email = "icuevass01@educarex.es";
        string user_password = ""; // PROPORCIONAR CONTRASEÑA

        public Conexion Conexion
        {
            get
            {
                return conexion;
            }
        }

        internal List<Producto> Productos
        {
            get
            {
                return productos;
            }
        }

        public FormTPV()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexion = new Conexion();
            Conexion.GetProveedores(proveedores);
            //CargarContenidoTPV();
            ClearLabels();
            labCamarero.Text = "";
            tbDNI.Select();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Conexion.CerrarConexion();
            this.Close();
        }

        private void LimpiarCesta()
        {
            dgvCesta.DataSource = null;
            total = 0;
            labTotal.Text = string.Format("{0:0.00} €", total);
            cesta.Clear();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LimpiarCesta();
            btnGestion.Visible = false;
            panelTPV.Enabled = false;
            btnLogout.Visible = false;
            panelLogin.Visible = true;
            labCamarero.Text = "";
            tbDNI.Focus();
        }

        private void ClearLabels()
        {
            labNombre.Text = "";
            labPrecio.Text = "";
            labStock.Text = "";
        }

        public void CargarContenidoTPV()
        {
            flpProducto.Controls.Clear();
            Conexion.GetProductos(Productos);
            for (int i = 0; i < Productos.Count; i++)
            {
                Button btn = new Button();
                btn.Name = Productos[i].Nombre;
                btn.Tag = i;
                btn.Width = 60;
                btn.Height = 60;
                btn.BackColor = Color.White;
                if (Productos[i].Imagen != null)
                {
                    MemoryStream ms = new MemoryStream(Productos[i].Imagen);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms); // Image es una referencia ambigüa entre System.Drawing.Image e iTextSharp.text.Image
                    Bitmap pic = null;
                    if (img.Height / img.Width > 0)
                    {
                        pic = new Bitmap(img, btn.Height * img.Width / img.Height, btn.Height);
                    }
                    else
                    {
                        pic = new Bitmap(img, btn.Width, btn.Width * img.Height / img.Width);
                    }
                    //btn.BackgroundImage = pic;
                    //btn.BackgroundImageLayout = ImageLayout.Center;
                    btn.Image = pic;
                }
                else
                {
                    btn.Text = Productos[i].Nombre;
                }
                btn.Click += Btn_Click;
                btn.MouseHover += Btn_MouseHover;
                btn.MouseLeave += Btn_MouseLeave;
                flpProducto.Controls.Add(btn);
            }
        }

        private void Login()
        {
            if (tbDNI.Text == "")
            {
                //MessageBox.Show("Rellene el campo de DNI.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDNI.Focus();
            }
            else
            {
                camarero = Conexion.GetCamarero(tbDNI.Text);
                if (camarero != null)
                {
                    CargarContenidoTPV();
                    panelTPV.Enabled = true;
                    btnLogout.Visible = true;
                    panelLogin.Visible = false;
                    labCamarero.Text = camarero.Nombre.ToUpper();
                    if (camarero.Nombre.ToUpper() == "ADMIN")
                    {
                        btnGestion.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("DNI incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbDNI.Focus();
                }
                tbDNI.Clear();
            }
        }

        private void tbDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        //private void tbDNI_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = true; // impide pulsar cualquier tecla sobre Text Box
        //}

        private async void tbDNI_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int startLength = tb.Text.Length;
            
            await Task.Delay(300);
            
            /*
                After the 300 miliseconds delay, we have called the event as many times as characters have been
                typed, but in this point we only want to check login once, with the full Text Box text, 
                least we get flooded with prompt error messages for incorrect (incomplete) values. 
                Thanks to this condition we only call Login method once, for the last character typed and none 
                of the prior ones.
            */ 
            if (startLength == tb.Text.Length)
            {
                Login();
            }
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            ClearLabels();
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            Producto producto= Productos[(int)btn.Tag];

            labNombre.Text = producto.Nombre;
            labPrecio.Text = string.Format("{0:0.00} €", producto.Precio);
            labStock.Text = string.Format("{0} unidades", producto.Stock);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            Producto producto = Productos[(int)btn.Tag];
            if (producto.Stock > 0)
            {
                producto.Stock--;              
                total += producto.Precio;
                labTotal.Text = string.Format("{0:0.00} €", total);

                cesta.Add(producto);
                dgvCesta.DataSource = null;
                dgvCesta.DataSource = cesta.Select(p => new { p.Id, p.Nombre, p.Precio }).ToList();
            }
            else
            {
                MessageBox.Show("No hay stock suficiente", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvFactura_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCesta.RowCount > 0)
            {
                int posicion = dgvCesta.CurrentRow.Index;
                Producto producto = cesta[posicion];
                DialogResult resultado = MessageBox.Show("¿Desea eliminar producto " + producto.Nombre + "?", "TPV", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    bool encontrado = false;
                    int i = 0;
                    while (!encontrado && i < Productos.Count)
                    {
                        if (Productos[i].Id == producto.Id)
                        {
                            Productos[i].Stock++;
                            total -= producto.Precio;
                            labTotal.Text = string.Format("{0:0.00} €", total);

                            cesta.RemoveAt(posicion);
                            dgvCesta.DataSource = null;
                            dgvCesta.DataSource = cesta.Select(p => new { p.Id, p.Nombre, p.Precio }).ToList();

                            encontrado = true;
                        }
                        i++;
                    }
                }
            }
        }

        private PdfPTable CrearTabla(DataGridView dgv)
        {
            PdfPTable pdfTable = new PdfPTable(dgv.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                    catch { }
                }
            }
            return pdfTable;
        }
        
        private void ImprimirTicket()
        {
            PdfPTable pdfTable = CrearTabla(dgvCesta);
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\tickets\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
            string filePath = folderPath + "ticket" + fecha + ".pdf";
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);

                Paragraph t = new Paragraph(string.Format("Total: {0:0.00} €", total));
                t.SetAlignment("Right");
                pdfDoc.Add(t);

                pdfDoc.Close();
                stream.Close();
            }
        }

        private void EnviarEmail(Email email)
        {
            MailMessage msg = new MailMessage();
            try
            {
                msg.From = new MailAddress(email.Sender);
                msg.To.Add(email.Receiver);
                msg.Subject = email.Subject;
                msg.Body = email.Body;

                if (email.Attachment != null)
                {
                    Attachment attachment = new Attachment(email.Attachment);
                    msg.Attachments.Add(attachment);
                }

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = true;
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential(email.Sender, user_password);
                client.Timeout = 20000;

                client.Send(msg);
                
                //MessageBox.Show("Correo enviado con éxito", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //MessageBox.Show("No se ha podido enviar el correo al destinatario por el siguiente motivo:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                msg.Dispose();
            }
        }

        private void ImprimirAvisoStock(Proveedor proveedor)
        {
            PdfPTable pdfTable = CrearTabla(dgvHidden);
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/reposiciones/";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
            string filePath = folderPath + "reposicion" + fecha + ".pdf";
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
            Email email = new Email(
                user_email,
                proveedor.Mail,
                "Aviso Reposición Producto",
                string.Format("A la atención del Sr. {0} {1}:\n\nComo proveedor de nuestro establecimiento, le envío este correo para solicitarle la reposición, con la mayor brevedad posible, de los productos recogidos en la lista adjunta.\n\nAtentamente:\n\nLa Dirección", proveedor.Nombre, proveedor.Apellidos),
                filePath
            );
            EnviarEmail(email);
        }

        private void ComprobarStock()
        {         
            List<Producto> productosRepo = new List<Producto>();

            Conexion.GetProductosRepo(productosRepo);

            if (productosRepo.Count != 0)
            {
                foreach (Proveedor proveedor in proveedores)
                {
                    var lista = productosRepo
                        .Where(p => p.IdProveedor == proveedor.Id)
                        .Select(p => new { p.Id, p.Nombre, p.Stock })
                        .ToList();
                    if (lista.Count != 0)
                    {
                        dgvHidden.DataSource = null;
                        dgvHidden.DataSource = lista;
                        ImprimirAvisoStock(proveedor);
                    }
                }

                //dgvHidden.DataSource = null;
                //dgvHidden.DataSource = productosRepo.Select(p => new { p.Id, p.Nombre, p.Stock }).ToList();
                //ImprimirAvisoStock();
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (total == 0)
            {
                MessageBox.Show("No ha seleccionado ningún producto", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int codigoCompra = Conexion.ActualizarAlmacen(cesta);
                int codigoFactura = Conexion.GenerarFactura(cesta, camarero.Id);

                if (codigoCompra == 1 && codigoFactura == 1)
                {
                    ComprobarStock();

                    ImprimirTicket();
                    CargarContenidoTPV();

                    MessageBox.Show("Compra procesada con éxito.", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCesta();
                }
                else
                {
                    MessageBox.Show("Error al procesar la compra. Inténtelo de nuevo", "TPV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private double GetTotalFacturacion(List<Facturacion> facturacion)
        {
            double total = 0;
            foreach (Facturacion factura in facturacion)
            {
                total += factura.Precio;
            }
            return total;
        }

        public void ImprimirInforme(List<Facturacion> facturacion, Camarero c) // Clases Facturacion y Camarero tienen que ser public para poder invocar ImprimirInforme desde Form2
        {
            dgvHidden.DataSource = null;
            dgvHidden.DataSource = facturacion;
            PdfPTable pdfTable = CrearTabla(dgvHidden);
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\informes\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
            string filePath = folderPath + c.Dni + "_" + fecha + ".pdf";
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);

                Paragraph t = new Paragraph(string.Format("Comisión (20%): {0:0.00} €", GetTotalFacturacion(facturacion) * 0.2));
                t.SetAlignment("Right");
                pdfDoc.Add(t);

                pdfDoc.Close();
                stream.Close();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ahora = DateTime.Now;
            labClock.Text = ahora.ToString("HH:mm:ss");
            if (ahora.Hour == 0 && ahora.Minute == 0 && ahora.Second == 0)
            {
                facturacion.Clear();
                Conexion.GetFacturacionCamarero(facturacion, camarero);
                ImprimirInforme(facturacion, camarero);
            }
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            Form form = new Form2(this);
            form.Show(this);
        }

    }
}
