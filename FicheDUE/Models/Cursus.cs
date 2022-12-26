namespace FicheDUE.Models
{
	public class Cursus
	{
		[Key]
		public int Id { get; set; }
		public string Implantation { get; set; } = string.Empty;
		public string Libelle { get; set; } = string.Empty;
		public string TelSecretariat { get; set; } = string.Empty;
	}
}
