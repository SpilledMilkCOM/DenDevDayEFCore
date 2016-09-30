using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SM.DataModels.Stuff.Entities
{
	[Table("Statuses")]
	public class Status
	{
		[Key]
		[Required]
		public int Id { get; set; }

		public DateTime? DateApproved { get; set; }

		public DateTime? DateCheckedIn { get; set; }

		public DateTime? DateCheckedOut { get; set; }

		public DateTime? DateRequested { get; set; }

		//[Required]
		public Person Requestor { get; set; }

		//[Required]
		public Stuff Stuff { get; set; }
	}
}