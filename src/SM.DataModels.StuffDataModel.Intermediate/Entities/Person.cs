using System;
using System.ComponentModel.DataAnnotations;			// For [Key]
using System.ComponentModel.DataAnnotations.Schema;		// For [Table]

namespace SM.DataModels.StuffDataModel.Entities.Intermediate
{
	[Table("People")]
	public class Person
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[Required, MaxLength(64)]
		public string FirstName { get; set; }

		[Required, MaxLength(64)]
		public string LastName { get; set; }

		[Required, MaxLength(128)]
		public string Email { get; set; }

		[Required]
		public DateTime DateJoined { get; set; }
	}
}