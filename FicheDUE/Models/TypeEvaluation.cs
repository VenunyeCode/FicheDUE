namespace FicheDUE.Models
{
	public class TypeEvaluation
	{
		[Key]
		public int Id { get; set; }
		public string Session { get; set; } = string.Empty;
		public DateTime Date { get; set; }
		public float Pourcentage { get; set; }
		public float NotFinale { get; set; }
		[ForeignKey(nameof(Cours))]
		public int CoursId { get; set; }
		[NotMapped]
		public Cours? Cours { get; set; }
		[ForeignKey(nameof(ModeEvaluation))]
		public int ModeEvaluationId { get; set; }
		[NotMapped]
		public ModeEvaluation? ModeEvaluation { get; set; }
	}
}
