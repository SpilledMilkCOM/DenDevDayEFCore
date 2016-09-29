using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SM.DataModels.Stuff.Entities
{
	[Table("Statuses")]
	public class Status
	{
		[Key]
		[Column("StatusId")]        // DBA will freak out because it should be "StatusesId" or possibly "statuses_id"
		[Required]
		public int Id { get; set; }

		public DateTime? DateApproved { get; set; }

		public DateTime? DateCheckedIn { get; set; }

		public DateTime? DateCheckedOut { get; set; }

		public DateTime? DateRequested { get; set; }

		public Person Requestor { get; set; }

		public Stuff Stuff { get; set; }
	}
}