using System;

namespace SM.BusinessObjects.Stuff.Interfaces
{
	public interface IStuff
	{
		DateTime DateAdded { get; set; }

		string Description { get; set; }

		int Id { get; set; }

		string ImageUrl { get; set; }

		string Name { get; set; }

		IPerson Owner { get; set; }
	}
}