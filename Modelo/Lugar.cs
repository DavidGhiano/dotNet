namespace Modelo
{
    public class Lugar
    {
        protected int idLugar;
        protected string nombre;
		protected bool habilitado;

		public static int contadorLugares = 0;

		static Lugar()
		{
			contadorLugares = 1;
		}

		public Lugar()
		{
			this.IdLugar = 0;
			this.Nombre = "";
			this.Habilitado = true;
			contadorLugares++;
		}

		public Lugar(int idLugar, string nombre, bool habilitado)
		{
			this.IdLugar = idLugar;
			this.Nombre = nombre;
			this.habilitado = habilitado;
			contadorLugares++;
		}

		public int IdLugar { get => idLugar; set => idLugar = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Habilitado { get => habilitado; set => habilitado = value; }
    }
}
