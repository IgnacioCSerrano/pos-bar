namespace ProyectoBar
{
    internal class Proveedor
    {
        private int id;
        private string nombre;
        private string apellidos;
        private string mail;

        public Proveedor()
        {
            this.id = 0;
            this.nombre = "";
            this.apellidos = "";
            this.mail = "";
        }

        public Proveedor(int id, string nombre, string apellidos, string mail)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.mail = mail;
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

        public string Apellidos
        {
            get
            {
                return apellidos;
            }

            set
            {
                apellidos = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
            }
        }
    }
}