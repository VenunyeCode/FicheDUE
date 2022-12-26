namespace FicheDUE.Models
{
	public class UE
	{
		[Key]
		public string CodeUE { get; set; } = string.Empty;
		public string NomUE { get; set; } = string.Empty;

		[NotMapped]
		public List<Cours> Cours { get; set; } = new();

		public float NoteUE { get; set; }
	}
}
