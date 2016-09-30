using System;
using System.ComponentModel.DataAnnotations;			// For [Key]
using System.ComponentModel.DataAnnotations.Schema;		// For [Table], [Column]

namespace SM.DataModels.StuffDataModel.Entities.Intermediate
{
	[Table("People")]                              // DBA's like pluralized tables.
	public class Person
	{
		[Key]
		[Required]
		[Column("PeopleId")]						// DBA's like it this way.
		public int Id { get; set; }

		[Required]
		[Column(TypeName = "varchar(64)")]			// DBA's compained about using "nvarchar" as default.
		public string FirstName { get; set; }

		[Required]
		[Column(TypeName = "varchar(64)")]
		public string LastName { get; set; }

		[Required]
		[Column(TypeName = "varchar(128)")]
		public string Email { get; set; }

		[Required]
		[Column(TypeName = "datetime")]				// DBA's compained about using "datetime2" as default.
		public DateTime DateJoined { get; set; }
	}
}