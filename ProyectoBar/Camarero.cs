namespace ProyectoBar
{
    public class Camarero
    {
        private int id;
        private string nombre;
        private string mail;
        private string dni;

        public Camarero()
        {
            this.id = 0;
            this.nombre = "";
            this.mail = "";
            this.dni = "";
        }

        public Camarero(int id, string nombre, string mail, string dni)
        {
            this.id = id;
            this.nombre = nombre;
            this.mail = mail;
            this.dni = dni;
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

        public string Dni
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }
    }
}