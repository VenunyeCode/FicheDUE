namespace FicheDUE.Models
{
	public class ModeEvaluation
	{
		[Key]
		public int Id { get; set; }
		public string Type { get; set; } = string.Empty;
	}
}
