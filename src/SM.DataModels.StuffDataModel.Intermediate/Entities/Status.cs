using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SM.DataModels.StuffDataModel.Entities
{
	[Table("Statuses")]                             // DBA's like pluralized tables.
	public class Status
	{
		[Key]
		[Required]
		[Column("StatusesId")]
		public int Id { get; set; }

		[Column(TypeName = "datetime")]             // DBA's compained about using "datetime2" as default.
		public DateTime? DateApproved { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? DateCheckedIn { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? DateCheckedOut { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? DateRequested { get; set; }

		[Required]
		public Person Requestor { get; set; }

		[Required]
		public Stuff Stuff { get; set; }
	}
}