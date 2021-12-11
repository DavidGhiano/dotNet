namespace Modelo
{
    public class Lugar
    {
        private int idLugar;
        private string nombre;

		public static int contadorLugares = 0;

		static Lugar()
		{
			contadorLugares = 1;
		}

		public Lugar()
		{
			this.IdLugar = 0;
			this.Nombre = "";
			contadorLugares++;
		}

		public Lugar(int idLugar, string nombre)
		{
			this.IdLugar = idLugar;
			this.Nombre = nombre;
			contadorLugares++;
		}

		public int IdLugar { get => idLugar; set => idLugar = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
