using System;

namespace ProyectoBar
{
    [Serializable]
    internal class Producto
    {
        private int id;
        private string nombre;
        private int idProveedor;
        private float precio;
        private int stock;
        private int stockMinimo;
        private byte[] imagen;

        public Producto()
        {
            this.id = 0;
            this.nombre = "";
            this.idProveedor = 0;
            this.precio = 0;
            this.stock = 0;
            this.stockMinimo = 0;
            this.imagen = null;
        }

        public Producto(int id, string nombre, int idProveedor, float precio, int stock, int stockMinimo, byte[] imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.idProveedor = idProveedor;
            this.precio = precio;
            this.stock = stock;
            this.stockMinimo = stockMinimo;
            this.imagen = imagen;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int IdProveedor
        {
            get
            {
                return idProveedor;
            }

            set
            {
                idProveedor = value;
            }
        }

        public float Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        public int Stock
        {
            get
            {
                return stock;
            }

            set
            {
                stock = value;
            }
        }

        public int StockMinimo
        {
            get
            {
                return stockMinimo;
            }

            set
            {
                stockMinimo = value;
            }
        }

        public byte[] Imagen
        {
            get
            {
                return imagen;
            }

            set
            {
                imagen = value;
            }
        }
    }
}