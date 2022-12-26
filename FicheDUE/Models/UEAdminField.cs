namespace FicheDUE.Models
{
	public class UEAdminField
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(AdminField))]
		public int AdminFieldId { get; set; }

		[NotMapped]
		public AdminField? AdminField { get; set; }
	}
	
}
