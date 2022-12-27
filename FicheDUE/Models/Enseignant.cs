namespace FicheDUE.Models
{
	public class Enseignant
	{
		public int Id { get; set; }
		public string Nom { get; set; } = string.Empty;
		public string Prenoms { get; set; } = string.Empty;

		public Enseignant(int id, string nom, string prenoms)
		{
			Id = id;
			Nom = nom;
			Prenoms = prenoms;
		}
	}
}
