namespace FicheDUE.Models
{
	public class AdminField
	{
		[Key]
		public int Id { get; set; }
		public string Departement { get; set; } = string.Empty;
		public string Orientation { get; set; } = string.Empty;
		public string Cycle { get; set; } = string.Empty;
		public string BlocEtude { get; set; } = string.Empty;
		public string Situation { get; set; } = string.Empty;
		public string UEPrequises { get; set; } = string.Empty;
		public string UECorequises { get; set; } = string.Empty;

		[ForeignKey(nameof(LangueEnseignement))]
		public int LangueEnseignementId { get; set; }
		[NotMapped]
		public Langue? LangueEnseignement { get; set; }

		[ForeignKey(nameof(LangueEvaluation))]
		public int LangueEvaluationId { get; set; }
		[NotMapped]
		public Langue? LangueEvaluation { get; set; }

		[ForeignKey(nameof(Responsable))]
		public int RepsonableId { get; set; }
		[NotMapped]
		public Enseignant? Responsable { get; set; }
	}
}
