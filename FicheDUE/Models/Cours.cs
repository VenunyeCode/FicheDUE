namespace FicheDUE.Models
{
	public class Cours
	{
		[Key]
		public int Id { get; set; }
		public string Libelle { get; set; } = string.Empty;
		public string Contenu { get; set; } = string.Empty;
		public string Methode { get; set; } = string.Empty;
		public bool IsOnline { get; set; }

		[ForeignKey(nameof(Titulaire))]
		public int TitulaireId { get; set; }
		[NotMapped]
		public Enseignant? Titulaire { get; set; }

		[ForeignKey(nameof(UE))]
		public int UEId { get; set; }

		[NotMapped]
		public UE? UE { get; set; }
	}
}
