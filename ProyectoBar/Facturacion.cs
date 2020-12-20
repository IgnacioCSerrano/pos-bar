using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBar
{
    public class Facturacion
    {
        private DateTime fecha;
        private string id;
        private string nombre;
        private double precio;
        private string id_camarero;

        public Facturacion()
        {
            this.fecha = DateTime.Now;
            this.id = "";
            this.nombre = "";
            this.precio = 0;
            this.id_camarero = "";
        }

        public Facturacion(DateTime fecha, string id, string nombre, double precio, string id_camarero)
        {
            this.fecha = fecha;
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.id_camarero = id_camarero;
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string Id
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

        public double Precio
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

        public string IdCamarero
        {
            get
            {
                return id_camarero;
            }

            set
            {
                id_camarero = value;
            }
        }
    }
}
