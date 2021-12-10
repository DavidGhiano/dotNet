namespace Modelo
{
    public class Lugar
    {
        private int idLugar;
        private string nombre;

		public Lugar()
		{
			this.IdLugar = 0;
			this.Nombre = "";
		}

		public Lugar(int idLugar, string nombre)
		{
			this.IdLugar = idLugar;
			this.Nombre = nombre;
		}

		public int IdLugar { get => idLugar; set => idLugar = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
