using System;
using System.ComponentModel.DataAnnotations;			// For [Key]
using System.ComponentModel.DataAnnotations.Schema;		// For [Table]

namespace SM.DataModels.Stuff.Entities
{
	[Table("People")]
	public class Person
	{
		[Key]
		[Column("PersonId")]
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