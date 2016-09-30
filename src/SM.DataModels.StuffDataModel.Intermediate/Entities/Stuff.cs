using System;
using System.ComponentModel.DataAnnotations;            // For [Key]
using System.ComponentModel.DataAnnotations.Schema;     // For [Table], [Column]

namespace SM.DataModels.StuffDataModel.Entities.Intermediate
{
	/// <summary>
	/// A basic entity to keep track of stuff.
	/// </summary>
	public class Stuff
	{
		[Key]
		[Required]
		[Column("StuffId")]
		public int Id { get; set; }

		[Required]
		public Person Owner { get; set; }

		[Required]
		[Column(TypeName = "varchar(64)")]          // DBA's compained about using "nvarchar" as default.
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "varchar(64)")]
		public string Description { get; set; }

		[Required]
		[Column(TypeName = "varchar(256)")]
		public string ImageUrl { get; set; }

		[Required]
		public DateTime DateAdded { get; set; }
	}
}