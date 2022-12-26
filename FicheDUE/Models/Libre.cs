namespace FicheDUE.Models
{
	public class Libre
	{
		public int Id { get; set; }

		public string Valeur { get; set; } = string.Empty;

		public string Type { get; set; } = string.Empty;

		[ForeignKey(nameof(Cours))]
		public int CoursId { get; set; }

		[NotMapped]
		public Cours? Cours { get; set; }
	}
}
