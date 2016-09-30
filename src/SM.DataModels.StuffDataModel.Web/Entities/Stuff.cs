using System;
using System.ComponentModel.DataAnnotations;            // For [Key]
using System.ComponentModel.DataAnnotations.Schema;     // For [Table], [Column]

namespace SM.DataModels.StuffDataModel.Entities
{
	/// <summary>
	/// A basic entity to keep track of stuff.
	/// </summary>
	public class Stuff
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[Required]
		public Person Owner { get; set; }

		[Required, MaxLength(64)]
		public string Name { get; set; }

		[Required, MaxLength(64)]
		public string Description { get; set; }

		[Required, MaxLength(256)]
		public string ImageUrl { get; set; }

		[Required]
		public DateTime DateAdded { get; set; }
	}
}