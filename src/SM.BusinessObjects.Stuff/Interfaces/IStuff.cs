using System;

namespace SM.BusinessObjects.Stuff.Interfaces
{
	public interface IStuff
	{
		int Id { get; set; }
		Person Owner { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		string ImageUrl { get; set; }
		DateTime DateAdded { get; set; }
	}
}