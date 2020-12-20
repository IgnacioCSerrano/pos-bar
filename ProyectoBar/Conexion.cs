using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ProyectoBar
{
    public class Conexion
    {

        private MySqlConnection conexion1;
        private MySqlConnection conexion2;
        private MySqlCommand comando;
        private MySqlDataReader resultado;
        private MySqlBackup msb;

        public Conexion()
        {
            this.conexion1 = new MySqlConnection();
            this.conexion2 = new MySqlConnection();

            this.conexion1.ConnectionString =
                "server=freedb.tech;" +
                "database=freedbtech_antonio2020;" +
                "uid=freedbtech_javier2020;" +
                "pwd=javier2020;";
            //+ "old guids=true";
            this.conexion2.ConnectionString =
                "server=freedb.tech;" +
                "database=freedbtech_CopiaSeguridad;" +
                "uid=freedbtech_Dam2020;" +
                "pwd=Pili_2020;";
            //+ "old guids=true";

            try
            {
                this.conexion1.Open();
                this.conexion2.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void CerrarConexion()
        {
            this.conexion1.Close();
            this.conexion2.Close();
        }

        internal void GetProductos(List<Producto> productos)
        {
            productos.Clear();
            try
            {
                string cadenaSQL = "SELECT * FROM producto;";
                this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                this.resultado = this.comando.ExecuteReader();
                while (this.resultado.Read())
                {
                    Producto producto = new Producto();

                    producto.Id = (int)this.resultado["id_producto"];
                    producto.Nombre = (string)this.resultado["nombre"];
                    producto.IdProveedor = (int)this.resultado["id_proveedor"];
                    producto.Precio = (float)this.resultado["precio"];
                    producto.Stock = (int)this.resultado["stock_actual"];
                    producto.StockMinimo = (int)this.resultado["stock_minimo"];
                    producto.Imagen = (byte[])this.resultado["imagenes"];

                    productos.Add(producto);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex) // excepción salta si se cierra formulario principal mientras formulario secundario (gestión) sigue abierto (evento FormClosed)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                this.resultado.Close();
            }
        }

        internal void GetProveedores(List<Proveedor> proveedores)
        {
            proveedores.Clear();
            try
            {
                string cadenaSQL = "SELECT * FROM proveedor;";
                this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                this.resultado = this.comando.ExecuteReader();
                while (this.resultado.Read())
                {
                    Proveedor proveedor = new Proveedor();

                    proveedor.Id = (int)this.resultado[0];
                    proveedor.Nombre = (string)this.resultado[1];
                    proveedor.Apellidos = (string)this.resultado[2];
                    proveedor.Mail = (string)this.resultado[3];

                    proveedores.Add(proveedor);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.resultado.Close();
            }
        }

        internal int ActualizarAlmacen(List<Producto> cesta)
        {
            int codigo = 0;
            try
            {
                foreach (Producto p in cesta)
                {
                    string cadenaSQL = "UPDATE producto SET stock_actual = stock_actual - 1 WHERE id_producto = ?id;";
                    this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                    this.comando.Parameters.Add("?id", MySqlDbType.Int32).Value = p.Id;
                    codigo = this.comando.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return codigo;
        }

        internal int GenerarFactura(List<Producto> cesta, int id_camarero)
        {
            int codigo = 0;
            try
            {
                foreach (Producto p in cesta)
                {
                    string cadenaSQL = "INSERT INTO facturacionBar VALUES (?fecha, ?id, ?nombre, ?precio, ?id_camarero);";
                    this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                    this.comando.Parameters.Add("?fecha", MySqlDbType.DateTime).Value = DateTime.Now;
                    this.comando.Parameters.Add("?id", MySqlDbType.VarChar).Value = p.Id;
                    this.comando.Parameters.Add("?nombre", MySqlDbType.VarChar).Value = p.Nombre;
                    this.comando.Parameters.Add("?precio", MySqlDbType.Double).Value = Math.Round(p.Precio, 2);
                    this.comando.Parameters.Add("?id_camarero", MySqlDbType.VarChar).Value = id_camarero;
                    codigo = this.comando.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return codigo;
        }

        internal Camarero GetCamarero(string dni)
        {
            try
            {
                string cadenaSQL = "SELECT * FROM camarero WHERE dni = ?dni;";
                this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                this.comando.Parameters.Add("?dni", MySqlDbType.VarChar).Value = dni;
                this.resultado = this.comando.ExecuteReader();
                if (this.resultado.Read())
                {
                    Camarero camarero = new Camarero();
                    camarero.Id = (int)this.resultado[0];
                    camarero.Nombre = (string)this.resultado[1];
                    camarero.Mail = (string)this.resultado[2];
                    camarero.Dni = (string)this.resultado[3];
                    return camarero;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.resultado.Close();
            }
            return null;
        }

        internal void GetProductosRepo(List<Producto> productosRepo)
        {
            productosRepo.Clear();
            try
            {
                string cadenaSQL = "SELECT * FROM producto WHERE stock_actual <= stock_minimo;";
                this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                this.resultado = this.comando.ExecuteReader();
                while (this.resultado.Read())
                {
                    Producto producto = new Producto();

                    producto.Id = (int)this.resultado["id_producto"];
                    producto.Nombre = (string)this.resultado["nombre"];
                    producto.IdProveedor = (int)this.resultado["id_proveedor"];
                    producto.Precio = (float)this.resultado["precio"];
                    producto.Stock = (int)this.resultado["stock_actual"];
                    producto.StockMinimo = (int)this.resultado["stock_minimo"];
                    producto.Imagen = (byte[])this.resultado["imagenes"];

                    productosRepo.Add(producto);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.resultado.Close();
            }
        }

        internal void GetCamareros(List<Camarero> camareros)
        {
            camareros.Clear();
            try
            {
                string cadenaSQL = "SELECT * FROM camarero ORDER BY id_camarero;";
                this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                this.resultado = this.comando.ExecuteReader();
                while (this.resultado.Read())
                {
                    Camarero camarero = new Camarero();
                    camarero.Id = (int)this.resultado[0];
                    camarero.Nombre = (string)this.resultado[1];
                    camarero.Mail = (string)this.resultado[2];
                    camarero.Dni = (string)this.resultado[3];
                    camareros.Add(camarero);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.resultado.Close();
            }
        }

        internal void GetFacturacionCamarero(List<Facturacion> facturacion, Camarero c)
        {
            try
            {
                string cadenaSQL = "SELECT * FROM facturacionBar WHERE DATE(`fecha`) = CURDATE() AND idCamarero = ?id;";
                this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                this.comando.Parameters.Add("?id", MySqlDbType.VarChar).Value = c.Id;
                this.resultado = this.comando.ExecuteReader();
                while (this.resultado.Read())
                {
                    Facturacion linea = new Facturacion();
                    linea.Fecha = (DateTime)this.resultado[0];
                    linea.Id = (string)this.resultado[1];
                    linea.Nombre = (string)this.resultado[2];
                    linea.Precio = (double)this.resultado[3];
                    linea.IdCamarero = (string)this.resultado[4];
                    facturacion.Add(linea);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.resultado.Close();
            }
        }

        internal int ActualizarProducto(string[] campos)
        {
            int codigo = 0;
            try
            {
                string cadenaSQL = "UPDATE producto SET stock_actual = stock_actual + ?stock WHERE id_producto = ?id;";
                this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                this.comando.Parameters.Add("?stock", MySqlDbType.Int32).Value = campos[2];
                this.comando.Parameters.Add("?id", MySqlDbType.Int32).Value = campos[0];
                codigo = this.comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return codigo;
        }

        internal int UpdateProducto(Producto p)
        {
            int codigo = 0;
            try
            {
                string cadenaSQL = "UPDATE producto SET " +
                    "nombre = ?nombre," +
                    "id_proveedor = ?idProv," +
                    "precio = ?precio," +
                    "stock_actual = ?stock," +
                    "stock_minimo = ?stockMin," +
                    "imagenes = ?img " +
                    "WHERE id_producto = ?id;";
                this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                this.comando.Parameters.Add("?nombre", MySqlDbType.VarChar).Value = p.Nombre;
                this.comando.Parameters.Add("?idProv", MySqlDbType.Int32).Value = p.IdProveedor;
                this.comando.Parameters.Add("?precio", MySqlDbType.Float).Value = Math.Round(p.Precio, 2);
                this.comando.Parameters.Add("?stock", MySqlDbType.Int32).Value = p.Stock;
                this.comando.Parameters.Add("?stockMin", MySqlDbType.Int32).Value = p.StockMinimo;
                this.comando.Parameters.Add("?img", MySqlDbType.Blob).Value = p.Imagen;
                this.comando.Parameters.Add("?id", MySqlDbType.Int32).Value = p.Id;
                codigo = this.comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return codigo;
        }

        internal int InsertProducto(Producto p, bool isMainConnection)
        {
            int codigo = 0;
            try
            {
                string cadenaSQL = "INSERT INTO producto VALUES (?id, ?nombre, ?idProv, ?precio, ?stock, ?stockMin, ?img);";
                this.comando = new MySqlCommand(cadenaSQL, (isMainConnection ? this.conexion1 : this.conexion2));
                this.comando.Parameters.Add("?id", MySqlDbType.Int32).Value = p.Id;
                this.comando.Parameters.Add("?nombre", MySqlDbType.VarChar).Value = p.Nombre;
                this.comando.Parameters.Add("?idProv", MySqlDbType.Int32).Value = p.IdProveedor;
                this.comando.Parameters.Add("?precio", MySqlDbType.Float).Value = Math.Round(p.Precio, 2);
                this.comando.Parameters.Add("?stock", MySqlDbType.Int32).Value = p.Stock;
                this.comando.Parameters.Add("?stockMin", MySqlDbType.Int32).Value = p.StockMinimo;
                this.comando.Parameters.Add("?img", MySqlDbType.Blob).Value = p.Imagen;
                codigo = this.comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.ToString());
            }
            return codigo;
        }

        internal int UpdateCamarero(Camarero c)
        {
            int codigo = 0;
            try
            {
                string cadenaSQL = "UPDATE camarero SET " +
                    "nombre = ?nombre," +
                    "mailcamarero = ?mail," +
                    "dni = ?dni " +
                    "WHERE id_camarero = ?id;";
                this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                this.comando.Parameters.Add("?nombre", MySqlDbType.VarChar).Value = c.Nombre;
                this.comando.Parameters.Add("?mail", MySqlDbType.VarChar).Value = c.Mail;
                this.comando.Parameters.Add("?dni", MySqlDbType.VarChar).Value = c.Dni;
                this.comando.Parameters.Add("?id", MySqlDbType.Int32).Value = c.Id;
                codigo = this.comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return codigo;
        }

        internal int InsertCamarero(Camarero c)
        {
            int codigo = 0;
            try
            {
                string cadenaSQL = "INSERT INTO camarero VALUES (?id, ?nombre, ?mail, ?dni);";
                this.comando = new MySqlCommand(cadenaSQL, this.conexion1);
                this.comando.Parameters.Add("?id", MySqlDbType.Int32).Value = c.Id;
                this.comando.Parameters.Add("?nombre", MySqlDbType.VarChar).Value = c.Nombre;
                this.comando.Parameters.Add("?mail", MySqlDbType.VarChar).Value = c.Mail;
                this.comando.Parameters.Add("?dni", MySqlDbType.VarChar).Value = c.Dni;
                codigo = this.comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return codigo;
        }

        internal void ExportarSQL()
        {
            this.comando = new MySqlCommand();
            this.comando.Connection = this.conexion1;
            this.msb = new MySqlBackup(this.comando);
            this.msb.ExportToFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\backup.sql");
        }

        internal void ImportarSQL()
        {
            this.comando = new MySqlCommand();
            this.comando.Connection = this.conexion2;
            this.msb = new MySqlBackup(this.comando);
            try
            {
                this.msb.ImportFromFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\backup.sql");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error de conexión con la Base de Datos:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}